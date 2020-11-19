using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace Atropos
{

    internal class Node
    {
        internal int[] ChildrenIndices { get; }
        public Node(int[] childrenIndices) => ChildrenIndices = childrenIndices;

    }
    internal class Node<T>:Node
    {
        private static readonly int BranchFactor = 64 / Marshal.SizeOf<IntPtr>();
        internal int SubtreeCount => IsLeaf ? Data.Length : ChildrenIndices[Children.Length]; // takes the value from the stop-node
        internal bool IsFull => IsLeaf ? SubtreeCount == ImmutableList<T>.pageSize : Children.Length == BranchFactor;
        bool IsEmpty => IsLeaf ? SubtreeCount <= ImmutableList<T>.pageSize / 2 : Children.Length <= BranchFactor / 2;
        internal (Node<T>, Node<T>) Split() => IsLeaf ? SplitLeaf() : SplitBranch();

        bool IsLeaf => ChildrenIndices == null;
        Node<T>[] Children { get; } // works only for IsLeaf == false
        public T[] Data { get; }

        public T this[int index]
        {
            get
            {
                var node = this;
                while(!node.IsLeaf)
                {
                    int child;
                    (child, index) = FindChildIndexSIMD(node, index);
                    node = node.Children[child];
                }
                return node.Data[index];
            }
        }
        internal Node(T[] data) : base(null)
            => Data = data;

        internal Node((Node<T> left, Node<T> right) children): this(new[] { children.left, children.right }) { }


        internal Node() : this(Array.Empty<T>()) { }
        internal Node(T data) : this(new T[] { data }) { }

        internal Node<T> Merge(Node<T> other) => IsLeaf ? MergeLeaf(other) : MergeBranch(other);

        private Node<T> MergeLeaf(Node<T> other)
        {
            var data = new T[SubtreeCount + other.SubtreeCount];
            Data.CopyTo(data, 0);
            other.Data.CopyTo(data, SubtreeCount);
            return new Node<T>(data);
        }

        internal Node<T> MergeBranch(Node<T> other)
        {
            var children = new Node<T>[Children.Length + other.Children.Length];
            Children.CopyTo(children, 0);
            other.Children.CopyTo(children, Children.Length);
            return new Node<T>(children);
        }

        private Node<T> SplitLeaf(int start, int count)
        {
            var data = new T[count];
            Array.Copy(Data, start, data, 0, count);
            return new Node<T>(data);
        }

        private Node<T> SplitBranch(int start, int count)
        {
            var children = new Node<T>[count];
            Array.Copy(Children, start, children, 0, count);
            if (start == 0)
            {
                var indices = new int[BranchFactor+1];
                Array.Copy(ChildrenIndices, start, indices, 0, count);
                indices[count] = ChildrenIndices[count] + 1; // stop-node
                return new Node<T>(children, indices);
            }
            else // indices have to be regenerated
                return new Node<T>(children);
        }

        private Node<T> SplitBranch(int start)
            => SplitBranch(start, Children.Length - start);

        public (Node<T>,Node<T>) SplitBranch()
        {
            int len = Children.Length / 2;
            return (SplitBranch(0, len), SplitBranch(len));
        }

        public Node<T> GetChild(int child) => Children[child];


        public Node<T> RemoveAt(int index)
        {
            if (IsLeaf)
            {
                var data = new T[SubtreeCount - 1];
                Array.Copy(Data, 0, data, 0, index);
                Array.Copy(Data, index + 1, data, index, SubtreeCount - index - 1);
                return new Node<T>(data);

            }
            else
            {
                int c;
                (c, index) = FindChildIndex(index);

                var child = Children[c];

                child = child.RemoveAt(index);
                if (!child.IsEmpty)
                    return ReplaceChildAt(c, child);
                else
                {
                    Node<T> ret;
                    if (c > 0) // check the left sibling
                    {
                        var siblingLeft = Children[c - 1];
                        if (siblingLeft.IsEmpty) // merge
                            ret = ReplaceChildrenAt(c - 1, siblingLeft.Merge(child));
                        else
                        {
                            var (l, r) = siblingLeft.BalanceWith(child);
                            ret = ReplaceChildrenAt(c - 1, l, r);
                        }
                    }
                    else // check the right sibling
                    {
                        var siblingRight = Children[1];
                        if (siblingRight.IsEmpty) // merge siblings
                        {
                            ret = ReplaceChildrenAt(0, child.Merge(siblingRight));
                        }
                        else // let's balance
                        {
                            var (l, r) = child.BalanceWith(siblingRight);
                            ret = ReplaceChildrenAt(0, l, r);
                        }
                    }

                    if (ret.Children.Length == 1) // thin root 
                        return ret.Children[0]; // chopping down the tree
                    else
                        return ret;
                }
            }
        }

        private Node<T> SplitLeaf(int start)
            => SplitLeaf(start, Data.Length - start);

        public (Node<T>, Node<T>) SplitLeaf()
        {
            int len = Data.Length / 2;
            return (SplitLeaf(0, len), SplitLeaf(len));
        }
        public static (int child, int index) FindChildIndex(Node node, int index)
        {
            return FindChildIndexSIMD(node, index);
            // TODO: compare with the SIMD implementation
            int child = Array.BinarySearch(node.ChildrenIndices, index);
            if (child < 0)
                child = ~child;
            if (child > 0)
                index -= (node.ChildrenIndices[child - 1] + 1);
            return (child, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public (int, int) FindChildIndex(int index)
        {
            if (index == 0)
                return (0, index);

            if (index == SubtreeCount)
            {
                var child = Children.Length - 1;
                index -= (ChildrenIndices[child] + 1);
                return (child, index);
            }

            return FindChildIndexSIMD(this, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static (int child, int index) FindChildIndexSIMD(Node node, int index)
        {
            var indexVector = Vector256.Create(index);
            var children = MemoryMarshal.Cast<int, Vector256<int>>(node.ChildrenIndices.AsSpan());
            uint child = 8;
            for (int i = 0; i < children.Length && child == 8; i++)
            {
                var compare = ~unchecked((uint)Avx2.MoveMask(Avx2.CompareGreaterThan(indexVector, children[0]).AsByte()));
                child = Bmi1.TrailingZeroCount(compare) >> 2;
            }
            child -= 1;
            index -= node.ChildrenIndices[child] + 1;
            return ((int)child, index);
        }
       

        internal Node(Node<T>[] children, int[] childrenIndices) : base(childrenIndices)
            => Children = children;
        internal Node(Node<T>[] children) : this(children, GetChildIndices(children)) { }
        public Node(T[] data, int index, T value): base(null)
        {
            Data = new T[data.Length];
            data.CopyTo(Data, 0);
            Data[index] = value;
        }
        internal Node<T> InsertDataAt(int index, T value)
        {
            // we need to figure out if this node is a leaf or not
            if (IsLeaf)
            {
                T[] data = new T[SubtreeCount + 1];
                Array.Copy(Data, 0, data, 0, index);
                data[index] = value;
                Array.Copy(Data, index, data, index + 1, SubtreeCount - index);
                return new Node<T>(data);
            }
            else
            {
                int c;
                // find child
                (c, index) = FindChildIndex(index);
                if (c == Children.Length)
                {
                    throw new InvalidOperationException("fell of the cliff");
                    c--;
                    index = Children[c].SubtreeCount;
                }

                var child = Children[c];

                // and ensure it has enough room to insert:
                if (child.IsFull)
                {
                    var (child1, child2) = child.Split();
                    if (index <= child1.SubtreeCount)
                        child1 = child1.InsertDataAt(index, value);
                    else
                        child2 = child2.InsertDataAt(index - child1.SubtreeCount, value);

                    return ReplaceChildAt(c, child1, child2);
                }
                else
                    return ReplaceChildAt(c, child.InsertDataAt(index, value));
            }
        }

        private static int[] GetChildIndices(Node<T>[] children)
        {
            var result = new int[BranchFactor+1];
            var s = 0;
            for (int i = 0; i < children.Length; i++)
            {
                result[i] = s - 1;
                s += children[i].SubtreeCount;
            }
            result[children.Length] = s; // stop-node should have one more item so the search for the "last+1" index finds the last branch
            return result;
        }

        internal Node<T> ReplaceDataAt(int index, T value)
        {
            if (IsLeaf)
                return new Node<T>(Data, index, value);
            else
            {
                var (c, localIndex) = FindChildIndex(index);
                return ReplaceChildAt(c, Children[c].ReplaceDataAt(localIndex, value));
            }
        }

        internal Node<T> ReplaceChildAt(int index, Node<T> child)
        {
            var children = new Node<T>[Children.Length];
            Children.CopyTo(children, 0);
            children[index] = child; // we're almost ready...

            return new Node<T>(children);
        }

        public Node<T> ReplaceChildrenAt(int index, Node<T> newChild)
        {
            var children = new Node<T>[Children.Length - 1];
            Array.Copy(Children, 0, children, 0, index);
            children[index] = newChild;
            Array.Copy(Children, index + 2, children, index + 1, Children.Length - index - 2);
            return new Node<T>(children);
        }

        internal Node<T> ReplaceChildrenAt(int index, Node<T> newNode1, Node<T> newNode2)
        {
            var children = new Node<T>[Children.Length];
            Children.CopyTo(children, 0);
            children[index] = newNode1;
            children[index + 1] = newNode2;
            return new Node<T>(children);
        }

        internal Node<T> ReplaceChildAt(int childIndex, Node<T> child1, Node<T> child2)
        {
            var children = new Node<T>[Children.Length + 1];
            Array.Copy(Children, 0, children, 0, childIndex);
            children[childIndex] = child1;
            children[childIndex + 1] = child2;
            Array.Copy(Children, childIndex + 1, children, childIndex + 2, Children.Length - childIndex - 1);
            return new Node<T>(children);
        }
        internal Node<T> AddData(T value) => InsertDataAt(SubtreeCount, value);

        public static (U[] left, U[] right) Balance<U>(U[] left, U[] right)
        {
            var leftCount = (left.Length + right.Length) / 2;
            var rightCount = (left.Length + right.Length) - leftCount;
            var newLeft = new U[leftCount];
            var newRight = new U[rightCount];
            if (leftCount < left.Length)
            {
                Array.Copy(left, 0, newLeft, 0, leftCount);
                Array.Copy(left, leftCount, newRight, 0, left.Length - leftCount);
                right.CopyTo(newRight, left.Length - leftCount);
            }
            else
            {
                left.CopyTo(newLeft, 0);
                Array.Copy(right, 0, newLeft, left.Length, leftCount - left.Length);
                Array.Copy(right, leftCount - left.Length, newRight, 0, rightCount);
            }

            return (newLeft, newRight);
        }

        public (Node<T>, Node<T>) BalanceWith(Node<T> other)
        {
            if (IsLeaf)
            {
                var (l, r) = Balance(Data, other.Data);
                return (new Node<T>(l), new Node<T>(r));
            }
            else
            {
                var (l, r) = Balance(Children, other.Children);
                return (new Node<T>(l), new Node<T>(r));
            }
        }

        internal static Node<T> Fill(T value, int count)
        {
            if (count <= ImmutableList<T>.pageSize)
            {
                var data = new T[count];
                Array.Fill(data, value);
                return new Node<T>(data);
            }
            else
            {

                // the minimum number of the pages we would need is ceiling(count / pageSize).
                var pageCount = count >> ImmutableList<T>.logPageSize;
                var excess = count & ImmutableList<T>.maskPageSize;
                if (excess > 0)
                    pageCount++;

                // now we need to see whether we can fit this into the root:
                var blockSize = ImmutableList<T>.pageSize;
                var levels = 1;
                while (pageCount > ImmutableList<T>.Brf)
                {
                    excess = pageCount & ImmutableList<T>.maskBrf;
                    pageCount >>= ImmutableList<T>.logBrf;
                    if (excess > 0)
                        pageCount++;
                    blockSize <<= ImmutableList<T>.logBrf;
                    levels++;
                }
                var children = new Node<T>[pageCount];
                var pageSize = count / pageCount;
                var page = Fill(value, pageSize);
                var largePageCount = count % pageCount;
                var smallPageCount = pageCount - largePageCount;

                children.AsSpan(0, smallPageCount).Fill(page);
                if (largePageCount > 0)
                {
                    page = Fill(value, pageSize + 1);
                    children.AsSpan(smallPageCount).Fill(page);
                }
                return new Node<T>(children);
            }

        }



    }

}