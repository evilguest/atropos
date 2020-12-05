using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace Atropos
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct Indexes
    {
        internal int childIndex0;
        internal int childIndex1;
        internal int childIndex2;
        internal int childIndex3;
        internal int childIndex4;
        internal int childIndex5;
        internal int childIndex6;
        internal int childIndex7;
        internal int childIndex8;
        internal int childIndex9;
        internal int childIndexA;
        internal int childIndexB;
        internal int childIndexC;
        internal int childIndexD;
        internal int childIndexE;
        internal int childIndexF;
        //internal int childIndexG;
        public static unsafe int Length => sizeof(Indexes)/sizeof(int);
    }
    [StructLayout(LayoutKind.Explicit)]
    internal unsafe struct NodeRef<T>
    {
        [FieldOffset(0)]
        public Node<T> Node;
        [FieldOffset(0)]
        public T[] Data;
    }

    internal class Node
    {
        //internal int[] ChildrenIndices { get; }
        internal Indexes _indexes;
        protected unsafe int GetChildIndex(int i)
        {
            fixed (int* children = &_indexes.childIndex0)
                return children[i];
        }
        protected unsafe void SetChildIndex(int i, int index)
        {
            fixed (int* children = &_indexes.childIndex0)
                children[i] = index;
        }
        public bool Frozen { get; protected set; }

        //public Node(int[] childrenIndices) => ChildrenIndices = childrenIndices;

    }
    internal class Node<T>:Node, IReadOnlyList<T>
    {
        private const int PageSize = 16;
        private static readonly int BranchFactor = 128 / Marshal.SizeOf<IntPtr>();
        internal static readonly Node<T> Empty = new Node<T>(new T[0]);
        private int _count;

        public Node<T> Freeze()
        {
            if (!Frozen)
            {
                if (!IsLeaf)
                    foreach (var child in Children)
                        child.Freeze();
                Frozen = true;
            }

            return this;
        }

        public int IndexOf(T item, int index, int count, IEqualityComparer<T> equalityComparer)
        {
            equalityComparer ??= EqualityComparer<T>.Default;
            if (index < 0 || index + count > Count)
                throw new IndexOutOfRangeException();
            for (var i = index; i < index + count; i++)
                if (equalityComparer.Equals(this[i], item))
                    return i;
            return -1;
        }
        public int LastIndexOf(T item, int index, int count, IEqualityComparer<T> equalityComparer)
        {
            equalityComparer ??= EqualityComparer<T>.Default;
            if (index >= Count || index - count + 1 < 0)
                throw new IndexOutOfRangeException();
            for (var i = index; i >= index - count; i--)
                if (equalityComparer.Equals(this[i], item))
                    return i;
            return -1;
        }

        public int Count => 
            IsLeaf 
                ? Data.Length 
                : _count; 
        internal bool IsFull 
            => IsLeaf 
                ? Data.Length == PageSize 
                : Children.Length == BranchFactor;
        bool IsEmpty 
            => IsLeaf 
                ? Data.Length <= PageSize/2 
                : Children.Length <= BranchFactor / 2;
        internal (Node<T>, Node<T>) Split() => IsLeaf ? SplitLeaf() : SplitBranch();

        Node<T>[] Children { get; set; } // works only for IsLeaf == false
        public T[] Data { get; set; }
        internal bool IsLeaf => Children == null;//ChildrenIndices == null;

        public T this[int index]
        {
            get
            {
                Debug.Assert(index >= 0);
                Debug.Assert(index < Count);
                var node = this;
                while(!node.IsLeaf)
                {
                    (node, index) = FindChild(node, index);
//                    node = node.Children[child];
                }
                return node.Data[index];
            }
        }


        //public static (int child, int index) FindChildIndex(Node node, int index)
        //{
        //    int child = Array.BinarySearch(node.ChildrenIndices, index);
        //    if (child < 0)
        //        child = ~child;
        //    if (child > 0)
        //        index -= (node.ChildrenIndices[child - 1] + 1);
        //    return (child, index);
        //}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public (int, int) FindChildIndex(int index)
             => FindChildIndex(this, index);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static (Node<T> child, int localIndex) FindChild(Node<T> node, int index) => 
            index < node._indexes.childIndex7 || node._indexes.childIndex7 == 0
                ? index < node._indexes.childIndex3 || node._indexes.childIndex3 == 0
                    ? index < node._indexes.childIndex1 || node._indexes.childIndex1 == 0
                        ? index < node._indexes.childIndex0
                            ? (node.Children[0], index)
                            : (node.Children[1], index - node._indexes.childIndex0)
                        : index < node._indexes.childIndex2 || node._indexes.childIndex2 == 0
                            ? (node.Children[2], index - node._indexes.childIndex1)
                            : (node.Children[3], index - node._indexes.childIndex2)
                    : index < node._indexes.childIndex5 || node._indexes.childIndex5 == 0
                        ? index < node._indexes.childIndex4 || node._indexes.childIndex4 == 0
                            ? (node.Children[4], index - node._indexes.childIndex3)
                            : (node.Children[5], index - node._indexes.childIndex4)
                        : index < node._indexes.childIndex6 || node._indexes.childIndex6 == 0
                            ? (node.Children[6], index - node._indexes.childIndex5)
                            : (node.Children[7], index - node._indexes.childIndex6)
                : index < node._indexes.childIndexB || node._indexes.childIndexB == 0
                    ? index < node._indexes.childIndex9 || node._indexes.childIndex9 == 0
                        ? index < node._indexes.childIndex8 || node._indexes.childIndex8 == 0
                            ? (node.Children[8], index - node._indexes.childIndex7)
                            : (node.Children[9], index - node._indexes.childIndex8)
                        : index < node._indexes.childIndexA || node._indexes.childIndexA == 0
                            ? (node.Children[10], index - node._indexes.childIndex9)
                            : (node.Children[11], index - node._indexes.childIndexA)
                    : index < node._indexes.childIndexD || node._indexes.childIndexD == 0
                        ? index < node._indexes.childIndexC || node._indexes.childIndexC == 0
                            ? (node.Children[12], index - node._indexes.childIndexB)
                            : (node.Children[13], index - node._indexes.childIndexC)
                        : index < node._indexes.childIndexE || node._indexes.childIndexE == 0
                            ? (node.Children[14], index - node._indexes.childIndexD)
                            : (node.Children[15], index - node._indexes.childIndexE);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static (int child, int index) FindChildIndex(Node<T> node, int index)
        {
            if (index < node._indexes.childIndex7 || node._indexes.childIndex7 == 0)
            {
                if (index < node._indexes.childIndex3 || node._indexes.childIndex3 == 0)
                {
                    if (index < node._indexes.childIndex1 || node._indexes.childIndex1 == 0)
                    { 
                        if(index < node._indexes.childIndex0 )
                            return (0, index);
                        else // >= child0
                            return (1, index - node._indexes.childIndex0);
                    }
                    else
                    {
                        if (index < node._indexes.childIndex2 || node._indexes.childIndex2 == 0)
                            return (2, index - node._indexes.childIndex1);
                        else // >= child2
                            return (3, index - node._indexes.childIndex2);
                    }
                }
                else // >= child3
                {
                    if (index < node._indexes.childIndex5 || node._indexes.childIndex5 == 0)
                    {
                        if (index < node._indexes.childIndex4 || node._indexes.childIndex4 == 0)
                            return (4, index - node._indexes.childIndex3);
                        else // > child5
                            return (5, index - node._indexes.childIndex4);
                    }
                    else // >= child5
                    {
                        if (index < node._indexes.childIndex6 || node._indexes.childIndex6 == 0)
                            return (6, index - node._indexes.childIndex5);
                        else // >= child6
                            return (7, index - node._indexes.childIndex6);
                    }
                }
            }
            else // >= child7
            {
                if (index < node._indexes.childIndexB || node._indexes.childIndexB == 0)
                {
                    if (index < node._indexes.childIndex9 || node._indexes.childIndex9 == 0)
                    {
                        if (index < node._indexes.childIndex8 || node._indexes.childIndex8 == 0)
                            return (8, index - node._indexes.childIndex7);
                        else // >= child8
                            return (9, index - node._indexes.childIndex8);
                    }
                    else // >= child9
                    {
                        if (index < node._indexes.childIndexA || node._indexes.childIndexA == 0)
                            return (10, index - node._indexes.childIndex9);
                        else // >= childA
                            return (11, index - node._indexes.childIndexA);
                    }
                }
                else // >= childB
                {
                    if (index < node._indexes.childIndexD || node._indexes.childIndexD == 0)
                    {
                        if (index < node._indexes.childIndexC || node._indexes.childIndexC == 0)
                            return (12, index - node._indexes.childIndexB);
                        else // >= childC
                            return (13, index - node._indexes.childIndexC);
                    }
                    else // > childD
                    {
                        if (index < node._indexes.childIndexE || node._indexes.childIndexE == 0)
                            return (14, index - node._indexes.childIndexD);
                        else // >= childE
                            return (15, index - node._indexes.childIndexE);
                    }
                }
            }
        }


        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //private static unsafe (int child, int index) FindChildIndex(Node<T> node, int index)
        //{
        //    var indexVector = Vector256.Create(index);
        //    fixed (int* childP = &node._indexes.childIndex0)
        //    {
        //        int child = 8;
        //        int i = 0;
        //        while (i < 16 && child == 8)
        //        {
        //            var compare = ~unchecked((uint)Avx2.MoveMask(Avx2.CompareGreaterThan(indexVector, *(Vector256<int>*)(childP + i)).AsByte()));
        //            child = unchecked((int)Bmi1.TrailingZeroCount(compare)) >> 2;
        //            i += 8;
        //        }
        //        child += i - 9;
        //        index -= node.GetChildIndex(child) + 1;
        //        return (child, index);
        //    }
        //}

        internal Node(T[] data)
        { 
            Data = data;
            Frozen = Data.Length == 0;
        }

        internal Node((Node<T> left, Node<T> right) children): this(new[] { children.left, children.right }) { }


        internal Node() : this(Array.Empty<T>()) { }
        internal Node(T data) : this(new T[] { data }) { }

        internal Node<T> Merge(Node<T> other) => IsLeaf ? MergeLeaf(other) : MergeBranch(other);

        private Node<T> MergeLeaf(Node<T> other)
        {
            var data = new T[Count + other.Count];
            Data.CopyTo(data, 0);
            other.Data.CopyTo(data, Count);
            if (Frozen)
                return new Node<T>(data);
            else
            {
                Data = data;
                return this;
            }
        }

        internal Node<T> MergeBranch(Node<T> other)
        {
            var children = new Node<T>[Children.Length + other.Children.Length];
            Children.CopyTo(children, 0);
            other.Children.CopyTo(children, Children.Length);
            if(Frozen)
                return new Node<T>(children);
            else
            {
                var oldLength = Children.Length-1;
                Children = children;
                InitChildIndices(oldLength);
                return this;
            }
        }


        internal unsafe Node(Node<T> original, int start, int count)
        {
            Children = new Node<T>[count];
            Array.Copy(original.Children, start, Children, 0, count);
            if (start == 0)
            {
                fixed (int* source = &original._indexes.childIndex0)
                fixed (int* target = &_indexes.childIndex0)
                    Buffer.MemoryCopy(source, target, sizeof(Indexes), (count - 1) * sizeof(int));
                _count = GetChildIndex(Children.Length - 2) + Children[Children.Length - 1].Count;
            }
            else // indices have to be regenerated
                InitChildIndices(0);
        }
        internal unsafe Node(Node<T> original, int start) 
            : this(original, start, original.Children.Length - start) { }

      
        public (Node<T>,Node<T>) SplitBranch()
        {
            int len = Children.Length / 2;
            return (new Node<T>(this, 0, len), new Node<T>(this, len));
        }

        public Node<T> RemoveAt(int index)
        {
            Debug.Assert(index >= 0);
            Debug.Assert(index < Count);
            if (IsLeaf)
            {
                var data = new T[Count - 1];
                Array.Copy(Data, 0, data, 0, index);
                Array.Copy(Data, index + 1, data, index, Count - index - 1);
                if (Frozen)
                    return new Node<T>(data);
                else
                {
                    Data = data;
                    return this;
                }

            }
            else
            {
                int c;
                (c, index) = FindChildIndex(index);

                Debug.Assert(c >= 0);
                Debug.Assert(c < Children.Length);

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

        private Node<T> SplitLeaf(int start, int count)
        {
            var data = new T[count];
            Array.Copy(Data, start, data, 0, count);
            return new Node<T>(data);
        }

        private Node<T> SplitLeaf(int start)
            => SplitLeaf(start, Data.Length - start);

        public (Node<T>, Node<T>) SplitLeaf()
        {
            int len = Data.Length / 2;
            var second = SplitLeaf(len);
            return (SplitLeaf(0, len), second);
        }


        internal Node(Node<T>[] children)
        {
            Children = children;
            InitChildIndices(0);
        }
        public Node(T[] data, int index, T value)
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
                T[] data = new T[Count + 1];
                Array.Copy(Data, 0, data, 0, index);
                data[index] = value;
                Array.Copy(Data, index, data, index + 1, Count - index);
                if (Frozen)
                    return new Node<T>(data);
                else
                {
                    Data = data;
                    return this;
                }
            }
            else
            {
                int c;
                // find child
                (c, index) = FindChildIndex(index);
                var child = Children[c];

                // and ensure it has enough room to insert:
                if (child.IsFull)
                {
                    var (child1, child2) = child.Split();
                    if (index <= child1.Count)
                        child1 = child1.InsertDataAt(index, value);
                    else
                        child2 = child2.InsertDataAt(index - child1.Count, value);

                    return ReplaceChildAt(c, child1, child2);
                }
                else
                    return ReplaceChildAt(c, child.InsertDataAt(index, value));
            }
        }

        private unsafe void InitChildIndices(int start)
        {
            var s = start == 0 ? 0 : GetChildIndex(start - 1);
            int i = start;
            fixed (int* indices = &_indexes.childIndex0)
            {
                while (i < Children.Length - 1)
                {
                    indices[i] = s += Children[i].Count;
                    i++;
                }
                _count = s + Children[i].Count;
                while (i < Indexes.Length)
                {
                    indices[i] = 0;
                    i++;
                }
            }
        }

        internal Node<T> ReplaceDataAt(int index, T value)
        {
            if (IsLeaf)
            {
                if (Frozen)
                    return new Node<T>(Data, index, value);
                else
                {
                    Data[index] = value;
                    return this;
                }
            }
            else
            {
                var (c, localIndex) = FindChildIndex(index);
                return ReplaceChildAt(c, Children[c].ReplaceDataAt(localIndex, value));
            }
        }

        internal Node<T> ReplaceChildAt(int index, Node<T> child)
        {
            if (child != Children[index])
            {
                if (Frozen)
                {
                    var children = new Node<T>[Children.Length];
                    Children.CopyTo(children, 0);
                    children[index] = child; // 
                    return new Node<T>(children);
                }
                else
                {
                    Children[index] = child;
                }
            }

            InitChildIndices(index);
            return this;
        }

        public Node<T> ReplaceChildrenAt(int index, Node<T> newChild)
        {
            var children = new Node<T>[Children.Length - 1];
            Array.Copy(Children, 0, children, 0, index);
            children[index] = newChild;
            Array.Copy(Children, index + 2, children, index + 1, Children.Length - index - 2);
            if (Frozen)
                return new Node<T>(children);
            else
            {
                Children = children;
                InitChildIndices(index);
                return this;
            }
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

            if (Frozen)
            {
                return new Node<T>(children);
            }
            else
            {
                Children = children;
                InitChildIndices(childIndex);
                return this;
            }

        }
        internal Node<T> AddData(T value)
            => InsertDataAt(Count, value);
        

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
            if (count <= PageSize)
            {
                var data = new T[count];
                Array.Fill(data, value);
                return new Node<T>(data);
            }
            else
            {

                // the minimum number of the pages we would need is ceiling(count / pageSize).
                var pageCount = count / PageSize;
                var excess = count % PageSize;
                if (excess > 0)
                    pageCount++;

                // now we need to see whether we can fit this into the root:
                var blockSize = BranchFactor;
                var levels = 1;
                while (pageCount > BranchFactor)
                {
                    excess = pageCount % BranchFactor;
                    pageCount /= BranchFactor;
                    if (excess > 0)
                        pageCount++;
                    blockSize *= BranchFactor;
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

        public IEnumerator<T> GetEnumerator() 
            => IsLeaf ? GetLeafEnumerator() : GetBranchEnumerator();
        private IEnumerator<T> GetLeafEnumerator()
            => ((IEnumerable<T>)Data).GetEnumerator();
        private IEnumerator<T> GetBranchEnumerator()
        {
            foreach (var child in Children)
                foreach (var item in child)
                    yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}