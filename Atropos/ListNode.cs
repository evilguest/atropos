using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

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
        //internal int childIndexF;
        public static unsafe int Length => sizeof(Indexes)/sizeof(int);
    }
    [StructLayout(LayoutKind.Explicit)]
    internal unsafe struct ChildrenRef<T>
    {
        [FieldOffset(0)]
        public ListNode<T>[] Branches;
        [FieldOffset(0)]
        public T[][] Leaves;
    }

    internal class ListNode
    {
        internal Indexes _indexes;
        protected unsafe int GetChildIndex(int i)
        {
            fixed (int* children = &_indexes.childIndex0)
                return children[i];
        }
        //protected unsafe void SetChildIndex(int i, int index)
        //{
        //    fixed (int* children = &_indexes.childIndex0)
        //        children[i] = index;
        //}
        public bool Frozen { get; protected set; }

        //public Node(int[] childrenIndices) => ChildrenIndices = childrenIndices;

    }
    internal class ListNode<T> : ListNode, IReadOnlyList<T>
    {
        private const int PageSize = 16;
        private static readonly int BranchFactor = 128 / Marshal.SizeOf<IntPtr>();
        internal static readonly ListNode<T> Empty = new ListNode<T>(new T[0], 0);
        private int _count;
        private int _childrenCount;
       

        public ListNode<T> Freeze()
        {
            if (!Frozen)
            {
                for (var i=0; i<_childrenCount;i++)
                    Children[i].Freeze();
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
            for (var i = index; i >= index - count + 1; i--)
                if (equalityComparer.Equals(this[i], item))
                    return i;
            return -1;
        }

        public int Count => _count; 

        internal bool IsFull 
            => IsLeaf 
                ? _count == PageSize 
                : _childrenCount == BranchFactor;
        bool IsEmpty 
            => IsLeaf 
                ? _count < PageSize/2 
                : _childrenCount < BranchFactor / 2;
        internal (ListNode<T>, ListNode<T>) Split() => IsLeaf ? SplitLeaf() : SplitBranch();

        ListNode<T>[] Children { get; set; } // works only for IsLeaf == false
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
                    (node, index) = FindChild(node, index);
                return node.Data[index];
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public (int, int) FindChildIndex(int index)
             => FindChildIndex(this, index);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static (ListNode<T> child, int localIndex) FindChild(ListNode<T> node, int index) => 
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
        private static (int child, int index) FindChildIndex(ListNode<T> node, int index)
        {
            return index < node._indexes.childIndex7 || node._indexes.childIndex7 == 0
                ? index < node._indexes.childIndex3 || node._indexes.childIndex3 == 0
                    ? index < node._indexes.childIndex1 || node._indexes.childIndex1 == 0
                        ? index < node._indexes.childIndex0 ? (0, index) : (1, index - node._indexes.childIndex0)
                        : index < node._indexes.childIndex2 || node._indexes.childIndex2 == 0
                            ? (2, index - node._indexes.childIndex1)
                            : (3, index - node._indexes.childIndex2)
                    : index < node._indexes.childIndex5 || node._indexes.childIndex5 == 0
                        ? index < node._indexes.childIndex4 || node._indexes.childIndex4 == 0
                            ? (4, index - node._indexes.childIndex3)
                            : (5, index - node._indexes.childIndex4)
                        : index < node._indexes.childIndex6 || node._indexes.childIndex6 == 0
                            ? (6, index - node._indexes.childIndex5)
                            : (7, index - node._indexes.childIndex6)
                : index < node._indexes.childIndexB || node._indexes.childIndexB == 0
                    ? index < node._indexes.childIndex9 || node._indexes.childIndex9 == 0
                        ? index < node._indexes.childIndex8 || node._indexes.childIndex8 == 0
                            ? (8, index - node._indexes.childIndex7)
                            : (9, index - node._indexes.childIndex8)
                        : index < node._indexes.childIndexA || node._indexes.childIndexA == 0
                            ? (10, index - node._indexes.childIndex9)
                            : (11, index - node._indexes.childIndexA)
                    : index < node._indexes.childIndexD || node._indexes.childIndexD == 0
                        ? index < node._indexes.childIndexC || node._indexes.childIndexC == 0
                            ? (12, index - node._indexes.childIndexB)
                            : (13, index - node._indexes.childIndexC)
                        : index < node._indexes.childIndexE || node._indexes.childIndexE == 0
                            ? (14, index - node._indexes.childIndexD)
                            : (15, index - node._indexes.childIndexE);
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

        internal ListNode(T[] data, int count)
        { 
            Data = data;
            _count = count;
            Frozen = Data.Length == 0;
        }

        internal ListNode((ListNode<T> left, ListNode<T> right) children)
        {
            Children = new ListNode<T>[BranchFactor];
            _childrenCount = 2;
            Children[0] = children.left;
            Children[1] = children.right;
            InitChildIndicesStartingFrom(0);
        }


        //internal Node() : this(Array.Empty<T>()) { }
        //internal Node(T data) : this(new T[] { data }) { }

        internal ListNode<T> Merge(ListNode<T> other) => IsLeaf ? MergeLeaf(other) : MergeBranch(other);

        private ListNode<T> MergeLeaf(ListNode<T> other)
        {
            if (Frozen)
            {
                var data = new T[PageSize];
                Array.Copy(Data, data, Count);
                Array.Copy(other.Data, 0, data, Count, other.Count);
                return new ListNode<T>(data, Count+other.Count);
            }
            else
            {
                Array.Copy(other.Data, 0, Data, Count, other.Count);
                _count += other.Count;
                return this;
            }
        }

        internal ListNode<T> MergeBranch(ListNode<T> other)
        {
            if (Frozen)
            {
                var children = new ListNode<T>[BranchFactor];
                Array.Copy(Children, 0, children, 0, _childrenCount);
                Array.Copy(other.Children, 0, children, _childrenCount, other._childrenCount);
                return new ListNode<T>(children, _childrenCount + other._childrenCount);
            }
            else
            {
                var oldLength = _childrenCount - 1;
                Array.Copy(other.Children, 0, Children, _childrenCount, other._childrenCount);
                _childrenCount += other._childrenCount;
                InitChildIndicesStartingFrom(oldLength);
                return this;
            }
        }


        internal unsafe ListNode(ListNode<T> original, int start, int childrenCount)
        {
            Children = new ListNode<T>[BranchFactor];
            Array.Copy(original.Children, start, Children, 0, childrenCount);
            _childrenCount = childrenCount;
            if (start == 0)
            {
                fixed (int* source = &original._indexes.childIndex0)
                fixed (int* target = &_indexes.childIndex0)
                    Buffer.MemoryCopy(source, target, sizeof(Indexes), (childrenCount - 1) * sizeof(int));
                _count = GetChildIndex(_childrenCount - 2) + Children[_childrenCount - 1].Count;
            }
            else // indices have to be regenerated
                InitChildIndicesStartingFrom(0);
        }
        internal unsafe ListNode(ListNode<T> original, int start) 
            : this(original, start, original._childrenCount - start) { }

      
        public (ListNode<T> left, ListNode<T> right) SplitBranch()
        {
            int len = _childrenCount / 2;
            return (new ListNode<T>(this, 0, len), new ListNode<T>(this, len));
        }

        public ListNode<T> RemoveAt(int index)
        {
            Debug.Assert(index >= 0);
            Debug.Assert(index < Count);
            if (IsLeaf)
            {
                if (Frozen)
                {
                    var data = new T[PageSize];
                    Array.Copy(Data, 0, data, 0, index);
                    Array.Copy(Data, index + 1, data, index, Count - index - 1);
                    return new ListNode<T>(data, Count-1);
                }
                else
                {
                    Array.Copy(Data, index + 1, Data, index, Count - index - 1);
                    _count--;
                    return this;
                }
            }
            else
            {
                int c;
                (c, index) = FindChildIndex(index);

                Debug.Assert(c >= 0);
                Debug.Assert(c < _childrenCount);

                var child = Children[c];

                child = child.RemoveAt(index);
                if (!child.IsEmpty)
                    return ReplaceChildAt(c, child);
                else
                {
                    ListNode<T> ret;
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

                    if (ret._childrenCount == 1) // thin root 
                        return ret.Children[0]; // chopping down the tree
                    else
                        return ret;
                }
            }
        }

        private ListNode<T> SplitLeaf(int start, int count)
        {
            if (Frozen || start > 0)
            {
                var data = new T[PageSize];
                Array.Copy(Data, start, data, 0, count);

                return new ListNode<T>(data, count);
            }
            else
            {
                _count = count;
                return this;
            }
        }

        private ListNode<T> SplitLeaf(int start)
            => SplitLeaf(start, Count - start);

        public (ListNode<T>, ListNode<T>) SplitLeaf()
        {
            int len = Count / 2;
            var second = SplitLeaf(len);
            return (SplitLeaf(0, len), second);
        }


        internal ListNode(ListNode<T>[] children, int childrenCount)
        {
            Children = children;
            _childrenCount = childrenCount; 
            InitChildIndicesStartingFrom(0);
        }
        public ListNode(ListNode<T> otherLeaf, int index, T value)
        {
            Data = new T[PageSize];
            Array.Copy(otherLeaf.Data, 0, Data, 0, otherLeaf.Count);
            Data[index] = value;
            _count = otherLeaf.Count;
        }
        internal ListNode<T> InsertDataAt(int index, T value)
        {
            // we need to figure out if this node is a leaf or not
            if (IsLeaf)
            {
                if (Frozen)
                {
                    T[] data = new T[PageSize];
                    Array.Copy(Data, 0, data, 0, index);
                    data[index] = value;
                    Array.Copy(Data, index, data, index + 1, Count - index);
                    return new ListNode<T>(data, Count+1);
                }
                else
                {
                    Array.Copy(Data, index, Data, index + 1, Count - index);
                    Data[index] = value;
                    _count++;
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

        private unsafe void InitChildIndicesStartingFrom(int start)
        {
            var s = start == 0 ? 0 : GetChildIndex(start - 1);
            int i = start;
            fixed (int* indices = &_indexes.childIndex0)
            {
                while (i < _childrenCount - 1)
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

        internal ListNode<T> ReplaceDataAt(int index, T value)
        {
            if (IsLeaf)
            {
                //if (Frozen) // we don't have a code for the group SetItem operations. 
                return new ListNode<T>(this, index, value);
                //else
                //{
                //    Data[index] = value;
                //    return this;
                //}
            }
            else
            {
                var (c, localIndex) = FindChildIndex(index);
                return ReplaceChildAt(c, Children[c].ReplaceDataAt(localIndex, value));
            }
        }

        internal ListNode<T> ReplaceChildAt(int childIndex, ListNode<T> child)
        {
            if (child != Children[childIndex])
            {
                if (Frozen)
                {
                    var children = new ListNode<T>[BranchFactor];
                    Array.Copy(Children, 0, children, 0, _childrenCount);
                    children[childIndex] = child; // 
                    return new ListNode<T>(children, _childrenCount);
                }
                else
                    Children[childIndex] = child;
            }

            InitChildIndicesStartingFrom(childIndex);
            return this;
        }

        public ListNode<T> ReplaceChildrenAt(int childIndex, ListNode<T> newChild)
        {
            if (Frozen)
            {
                var children = new ListNode<T>[BranchFactor];
                Array.Copy(Children, 0, children, 0, childIndex);
                children[childIndex] = newChild;
                Array.Copy(Children, childIndex + 2, children, childIndex + 1, _childrenCount - childIndex - 2);
                return new ListNode<T>(children, _childrenCount - 1);
            }
            else
            {
                Children[childIndex] = newChild;
                Array.Copy(Children, childIndex + 2, Children, childIndex + 1, _childrenCount - childIndex - 2);
                _childrenCount--;
                InitChildIndicesStartingFrom(childIndex);
                return this;
            }
        }

        internal ListNode<T> ReplaceChildrenAt(int childIndex, ListNode<T> newNode1, ListNode<T> newNode2)
        {
            if (Frozen)
            {
                var children = new ListNode<T>[BranchFactor];
                Array.Copy(Children, 0, children, 0, _childrenCount);
                children[childIndex] = newNode1;
                children[childIndex + 1] = newNode2;
                return new ListNode<T>(children, _childrenCount);
            }
            else
            {
                Children[childIndex] = newNode1;
                Children[childIndex + 1] = newNode2;
                InitChildIndicesStartingFrom(childIndex);
                return this;
            }
        }

        internal ListNode<T> ReplaceChildAt(int childIndex, ListNode<T> child1, ListNode<T> child2)
        {
            if (Frozen)
            {
                var children = new ListNode<T>[BranchFactor];
                Array.Copy(Children, 0, children, 0, childIndex);
                children[childIndex] = child1;
                children[childIndex + 1] = child2;
                Array.Copy(Children, childIndex + 1, children, childIndex + 2, _childrenCount - childIndex - 1);
                return new ListNode<T>(children, _childrenCount+1);
            }
            else
            {
                Array.Copy(Children, childIndex + 1, Children, childIndex + 2, _childrenCount - childIndex - 1);
                Children[childIndex] = child1;
                Children[childIndex + 1] = child2;
                _childrenCount++;
                InitChildIndicesStartingFrom(childIndex);
                return this;
            }

        }
        internal ListNode<T> AddData(T value)
            => InsertDataAt(Count, value);
        

        private (ListNode<T>, ListNode<T>) BalanceLeaf(ListNode<T> other)
        {
            var originalCount = Count + other.Count;
            var leftLength = originalCount / 2;
            var rightLength = originalCount - leftLength;
            ListNode<T> left, right;
            if (Frozen)
            {
                var data = new T[PageSize];
                Array.Copy(Data, 0, data, 0, Count);
                if (leftLength > Count) // copy the head of other into data's tail
                    Array.Copy(other.Data, 0, data, Count, leftLength - Count);
                left = new ListNode<T>(data, leftLength);
            }
            else
            {
                if (leftLength > Count) // copy the head of other into data's tail
                    Array.Copy(other.Data, 0, Data, Count, leftLength - Count);
                _count = leftLength;
                left = this;
            }
            if(other.Frozen)
            {
                var data = new T[PageSize];
                if (rightLength > other.Count) // 11+4=>7+8; 
                {
                    Array.Copy(Data, leftLength, data, 0, rightLength - other.Count);
                    Array.Copy(other.Data, 0, data, rightLength - other.Count, other.Count);
                } 
                else
                    Array.Copy(other.Data, other.Count - rightLength, data, 0, rightLength);
                right = new ListNode<T>(data, rightLength);
            }
            else
            {
                if (rightLength > other.Count) // 11+4=>7+8; 
                {
                    Array.Copy(other.Data, 0, other.Data, rightLength - other.Count, other.Count);
                    Array.Copy(Data, leftLength, other.Data, 0, rightLength - other.Count);
                }
                else
                    Array.Copy(other.Data, other.Count - rightLength, other.Data, 0, rightLength);
                other._count = rightLength;
                right = other;
            }
            Debug.Assert(left.Count + right.Count == originalCount);
            return (left, right);
        }

        public (ListNode<T>, ListNode<T>) BalanceBranch(ListNode<T> other)
        {
            var totalChildren = _childrenCount + other._childrenCount;
            var totalCount = Count + other.Count;

            var leftLength = totalChildren / 2;
            var rightLength = totalChildren - leftLength;
            ListNode<T> left, right;
            if (Frozen)
            {
                var children = new ListNode<T>[BranchFactor];
                Array.Copy(Children, 0, children, 0, _childrenCount);
                if (leftLength > _childrenCount) // copy the head of other into data's tail
                    Array.Copy(other.Children, 0, children, _childrenCount, leftLength - _childrenCount);
                left = new ListNode<T>(children, leftLength);
            }
            else
            {
                var oldLength = _childrenCount;
                _childrenCount = leftLength;
                if (leftLength > oldLength) // copy the head of other into data's tail
                {
                    Array.Copy(other.Children, 0, Children, oldLength, leftLength - oldLength);
                    InitChildIndicesStartingFrom(oldLength - 1);
                }
                else
                    InitChildIndicesStartingFrom(leftLength - 1);
                left = this;
            }
            if (other.Frozen)
            {
                var children = new ListNode<T>[BranchFactor];
                if (rightLength > other._childrenCount) // 11+4=>7+8; 
                {
                    Array.Copy(Children, leftLength, children, 0, rightLength - other._childrenCount);
                    Array.Copy(other.Data, 0, children, rightLength - other._childrenCount, other._childrenCount);
                }
                else
                    Array.Copy(other.Children, other._childrenCount- rightLength, children, 0, rightLength);
                right = new ListNode<T>(children, rightLength);
            }
            else
            {
                if (rightLength > other._childrenCount) // 11+4=>7+8; 
                {
                    Array.Copy(other.Children, 0, other.Children, rightLength - other._childrenCount, other._childrenCount);
                    Array.Copy(Children, leftLength, other.Children, 0, rightLength - other._childrenCount);
                }
                else
                    Array.Copy(other.Children, other._childrenCount - rightLength, other.Children, 0, rightLength);
                other._childrenCount = rightLength;
                other.InitChildIndicesStartingFrom(0);
                right = other;
            }
            Debug.Assert(totalChildren == left._childrenCount + right._childrenCount);
            Debug.Assert(totalCount == left.Count + right.Count);
            return (left, right);
        }
        public (ListNode<T>, ListNode<T>) BalanceWith(ListNode<T> other) 
            => IsLeaf 
                ? BalanceLeaf(other) 
                : BalanceBranch(other);

        internal static ListNode<T> Fill(T value, int count)
        {
            if (count <= PageSize)
            {
                var data = new T[PageSize];
                Array.Fill(data, value);
                var n = new ListNode<T>(data, count);
                n.Freeze();
                return n;
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
                var children = new ListNode<T>[pageCount];
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
                var n = new ListNode<T>(children, pageCount);
                n.Freeze();
                return n;
            }
        }

        public IEnumerator<T> GetEnumerator() 
            => IsLeaf ? GetLeafEnumerator() : GetBranchEnumerator();
        private IEnumerator<T> GetLeafEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return Data[i];
        }
        private IEnumerator<T> GetBranchEnumerator()
        {
            for (var i=0; i< _childrenCount; i++)
                foreach (var item in Children[i])
                    yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}