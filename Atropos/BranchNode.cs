using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace Atropos
{
    internal struct BranchNode<N, T>: IListNodeImpl<BranchNode<N, T>, T>
        where N: struct, IListNodeImpl<N, T>
    {
        private Bunch<int> _indices;
        private Bunch<Box<N, T>> _children;
        private int _childrenCount;
        public void Freeze()
        {
            foreach(var child in Children)
                child.Freeze();
        }

        public T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                Debug.Assert(index >= 0 && index < Count);
                var (t, i) = FindChildS(index);
                return t.Node[i];
            }
        }

        public bool IsFull => _childrenCount == 16;
        public bool IsHalfEmpty => _childrenCount <= 8;

        public int Count => _childrenCount > 0 ? _indices[_childrenCount - 1] : 0;

        internal Span<Box<N, T>> Children => MemoryMarshal.CreateSpan(ref _children._data0, _childrenCount);
        internal Span<int> Indices => MemoryMarshal.CreateSpan(ref _indices._data0, _childrenCount);
        internal ReadOnlySpan<Vector256<int>> VectorIndices => MemoryMarshal.Cast<int, Vector256<int>>(MemoryMarshal.CreateReadOnlySpan(ref _indices._data0, 16));



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public (Box<N, T> child, int index) FindChildV(int index)
        {
            (Box<N, T>, int) Return(ref BranchNode<N, T> self, int childNo) 
                => (self.Children[childNo], index - (childNo > 0 ? self.Indices[childNo - 1] : 0));


            var c = Vector256.Create(index);
            var a = 0;
            foreach (var m in VectorIndices)
            {
                var t = Avx2.CompareGreaterThan(m, c);
                var o = Avx2.MoveMask(t.AsSingle()) | 0xFFFFFF00;
                var p = BitOperations.TrailingZeroCount((uint)o); // our mask is 8-bit wide;
                var child = a + p;
                if (child >= _childrenCount)
                    return Return(ref this, _childrenCount - 1);
                if (p < 8)
                {
                    return Return(ref this, child);
                }
                a += 8;
            }
            return Return(ref this, _childrenCount - 1);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public (Box<N, T> child, int index) FindChildS(int index)
        {
            var c = Indices;
            for (var i = 0; i < c.Length; i++)
                if (Indices[i] > index)
                    return (Children[i], i > 0 ? index - Indices[i - 1] : index);
            return (Children[_childrenCount - 1], index - Indices[_childrenCount - 2]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public (Box<N, T> child, int index) FindChild(int index)
        =>
            index < _indices._data7 || _childrenCount < 9
                ? index < _indices._data3 || _childrenCount < 5
                    ? index < _indices._data1 || _childrenCount < 3
                        ? index < _indices._data0
                            ? (_children._data0, index)
                            : (_children._data1, index - _indices._data0)
                        : index < _indices._data2 || _childrenCount < 4
                            ? (_children._data2, index - _indices._data1)
                            : (_children._data3, index - _indices._data2)
                    : index < _indices._data5 || _childrenCount < 7
                        ? index < _indices._data4 || _childrenCount < 6
                            ? (_children._data4, index - _indices._data3)
                            : (_children._data5, index - _indices._data4)
                        : index < _indices._data6 || _childrenCount < 8
                            ? (_children._data6, index - _indices._data5)
                            : (_children._data7, index - _indices._data6)
                : index < _indices._dataB || _childrenCount < 13
                    ? index < _indices._data9 || _childrenCount < 11
                        ? index < _indices._data8 || _childrenCount < 10
                            ? (_children._data8, index - _indices._data7)
                            : (_children._data9, index - _indices._data8)
                        : index < _indices._dataA || _childrenCount < 12
                            ? (_children._dataA, index - _indices._data9)
                            : (_children._dataB, index - _indices._dataA)
                    : index < _indices._dataD || _childrenCount < 15
                        ? index < _indices._dataC || _childrenCount < 14
                            ? (_children._dataC, index - _indices._dataB)
                            : (_children._dataD, index - _indices._dataC)
                        : index < _indices._dataE || _childrenCount < 16
                            ? (_children._dataE, index - _indices._dataD)
                            : (_children._dataF, index - _indices._dataE);

        internal void InitChildren((Box<N, T> left, Box<N, T> right) children)
        {
            _childrenCount = 2;

            _children = default;
            _children._data0 = children.left;
            _children._data1 = children.right;

            _indices = default;
            _indices._data0 = children.left.Count;
            _indices._data1 = children.left.Count + children.right.Count;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private (int child, int index) FindChildIndex(int index)
        {
            return index < _indices._data7 || _childrenCount < 9
                ? index < _indices._data3 || _childrenCount < 5
                    ? index < _indices._data1 || _childrenCount < 3
                        ? index < _indices._data0 
                            ? (0x0, index) 
                            : (0x1, index - _indices._data0)
                        : index < _indices._data2 || _childrenCount < 4
                            ? (0x2, index - _indices._data1)
                            : (0x3, index - _indices._data2)
                    : index < _indices._data5 || _childrenCount < 7
                        ? index < _indices._data4 || _childrenCount < 6
                            ? (0x4, index - _indices._data3)
                            : (0x5, index - _indices._data4)
                        : index < _indices._data6 || _childrenCount < 8
                            ? (0x6, index - _indices._data5)
                            : (0x7, index - _indices._data6)
                : index < _indices._dataB || _childrenCount < 13
                    ? index < _indices._data9 || _childrenCount < 11
                        ? index < _indices._data8 || _childrenCount < 10
                            ? (0x8, index - _indices._data7)
                            : (0x9, index - _indices._data8)
                        : index < _indices._dataA || _childrenCount < 12
                            ? (0xA, index - _indices._data9)
                            : (0xB, index - _indices._dataA)
                    : index < _indices._dataD || _childrenCount < 15
                        ? index < _indices._dataC || _childrenCount < 14
                            ? (0xC, index - _indices._dataB)
                            : (0xD, index - _indices._dataC)
                        : index < _indices._dataE || _childrenCount < 16
                            ? (0xE, index - _indices._dataD)
                            : (0xF, index - _indices._dataE);
        }



        public Box<BranchNode<N, T>, T> InsertAt(Box<BranchNode<N, T>, T> self, int index, T value)
        {
            int c;
            // find child
            (c, index) = self.Node.FindChildIndex(index);
            var child = self.Node.Children[c];

            // and ensure it has enough room to insert:
            if (child.Node.IsFull)
            {
                var (child1, child2) = child.Node.Split();
                if (index <= child1.Count)
                    child1 = child1.Node.InsertAt(child1, index, value);
                else
                    child2 = child2.Node.InsertAt(child2, index - child1.Count, value);

                return self.Node.ReplaceChildAt(self, c, child1, child2);
            }
            else
                return self.Node.ReplaceChildAt(self, c, child.Node.InsertAt(child, index, value));
        }


        internal Box<BranchNode<N, T>, T> ReplaceChildAt(Box<BranchNode<N, T>, T> self, int childIndex, Box<N, T> child)
        {
            var r = self;

            if(self.Frozen)
            {
                r = new Box<BranchNode<N, T>, T>();
                r.Node = self.Node;
            } 

            r.Node.Children[childIndex] = child;
            r.Node.InitChildIndicesStartingFrom(childIndex);
            return r;
        }


        internal Box<BranchNode<N, T>, T> ReplaceChildAt(Box<BranchNode<N, T>, T> self, int childIndex, Box<N, T> child1, Box<N, T> child2)
        {
            var result = self;
            var oldChildrenCount = self.Node._childrenCount;
            if (self.Frozen)
            {
                result = new Box<BranchNode<N, T>, T>();
                result.Node._childrenCount = self.Node._childrenCount + 1;
                self.Node.Children.Slice(0, childIndex).CopyTo(result.Node.Children);
                self.Node.Indices.Slice(0, childIndex).CopyTo(result.Node.Indices);
            }
            else
                self.Node._childrenCount++;

            self.Node.Children.Slice(childIndex + 1, oldChildrenCount - childIndex - 1).CopyTo(result.Node.Children.Slice(childIndex + 2));
            result.Node.Children[childIndex] = child1;
            result.Node.Children[childIndex + 1] = child2;
            result.Node.InitChildIndicesStartingFrom(childIndex);
            return result;
        }

        public Box<BranchNode<N, T>, T> ReplaceChildrenAt(Box<BranchNode<N, T>, T> self, int childIndex, Box<N, T> newChild)
        {
            var result = self;
            if (self.Frozen)
            {
                result = new Box<BranchNode<N, T>, T>();
                result.Node._childrenCount = self.Node._childrenCount;
                self.Node.Children.Slice(0, childIndex).CopyTo(result.Node.Children);
                self.Node.Indices.Slice(0, childIndex).CopyTo(result.Node.Indices);
            }
            result.Node.Children[childIndex] = newChild;

            self.Node.Children.Slice(childIndex + 2).CopyTo(result.Node.Children.Slice(childIndex + 1));
            result.Node._childrenCount--;
            result.Node.InitChildIndicesStartingFrom(childIndex);
            return result;
        }

        internal Box<BranchNode<N, T>, T> ReplaceChildrenAt(Box<BranchNode<N, T>, T> self, int childIndex, (Box<N, T> left, Box<N, T> right) children)
        {
            var result = self;
            if (self.Frozen)
            {
                result = new Box<BranchNode<N, T>, T>();
                result.Node = self.Node;
            }
            result.Node.Children[childIndex] = children.left;
            result.Node.Children[childIndex + 1] = children.right;
            result.Node.InitChildIndicesStartingFrom(childIndex);
            return result;

        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void InitChildIndicesStartingFrom(int start)
        {
            var s = start == 0 ? 0 : Indices[start - 1];
            int i = start;
            while (i < Indices.Length && i < Children.Length)
            {
                Indices[i] = s += Children[i].Count;
                i++;
            }
            while (i < 16)
            {
                _indices[i] = 0;
                i++;
            }
        }

        public Box<BranchNode<N, T>, T> RemoveAt(Box<BranchNode<N, T>, T> self, int index)
        {
            var (childNo, childIndex) = self.Node.FindChildIndex(index);

            Debug.Assert(childNo >= 0);
            Debug.Assert(childNo < self.Node._childrenCount);

            var child = self.Node.Children[childNo];

            child = child.Node.RemoveAt(child, childIndex);

            if (!child.IsHalfEmpty)
                return ReplaceChildAt(self, childNo, child);
            else
            {
                if (childNo > 0) // check the left sibling
                {
                    var leftSibling = self.Node.Children[childNo - 1];
                    if (leftSibling.IsHalfEmpty) 
                        return ReplaceChildrenAt(self, childNo - 1, leftSibling.Node.Merge(leftSibling, child));
                    else
                        return ReplaceChildrenAt(self, childNo - 1, leftSibling.Node.Balance(leftSibling, child));
                }
                else // check the right sibling
                {
                    var rightSibling = self.Node.Children[1];
                    if (rightSibling.IsHalfEmpty) 
                        return ReplaceChildrenAt(self, 0, child.Node.Merge(child, rightSibling));
                    else 
                        return ReplaceChildrenAt(self, 0, child.Node.Balance(child, rightSibling));
                }
            }
        }

        public Box<BranchNode<N, T>, T> ReplaceAt(Box<BranchNode<N, T>, T> self, int index, T value)
        {
            int c;
            // find child
            (c, index) = self.Node.FindChildIndex(index);
            var child = self.Node.Children[c];
            child = child.Node.ReplaceAt(child, index, value);
            return ReplaceChildAt(self, c, child);
        }

        public Box<BranchNode<BranchNode<N, T>, T>, T> SplitNGrow()
        {
            var r = new Box<BranchNode<BranchNode<N, T>, T>, T>();
            r.Node.InitChildren(Split());
            return r;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_childrenCount < 0x1)
                yield break;
            foreach(var gc in _children._data0) yield return gc;
            if (_childrenCount < 0x2)
                yield break;
            foreach(var gc in _children._data1) yield return gc;
            if (_childrenCount < 0x3)
                yield break;
            foreach(var gc in _children._data2) yield return gc;
            if (_childrenCount < 0x4)
                yield break;
            foreach(var gc in _children._data3) yield return gc;
            if (_childrenCount < 0x5)
                yield break;
            foreach(var gc in _children._data4) yield return gc;
            if (_childrenCount < 0x6)
                yield break;
            foreach(var gc in _children._data5) yield return gc;
            if (_childrenCount < 0x7)
                yield break;
            foreach(var gc in _children._data6) yield return gc;
            if (_childrenCount < 0x8)
                yield break;
            foreach(var gc in _children._data7) yield return gc;
            if (_childrenCount < 0x9)
                yield break;
            foreach(var gc in _children._data8) yield return gc;
            if (_childrenCount < 0xA)
                yield break;
            foreach(var gc in _children._data9) yield return gc;
            if (_childrenCount < 0xB)
                yield break;
            foreach(var gc in _children._dataA) yield return gc;
            if (_childrenCount < 0xC)
                yield break;
            foreach(var gc in _children._dataB) yield return gc;
            if (_childrenCount < 0xD)
                yield break;
            foreach(var gc in _children._dataC) yield return gc;
            if (_childrenCount < 0xE)
                yield break;
            foreach(var gc in _children._dataD) yield return gc;
            if (_childrenCount < 0xF)
                yield break;
            foreach(var gc in _children._dataE) yield return gc;
            if (_childrenCount < 0x10)
                yield break;
            foreach(var gc in _children._dataF) yield return gc;
        }


        public (Box<BranchNode<N, T>, T>, Box<BranchNode<N, T>, T>) Split()
        {
            Debug.Assert(IsFull);

            var left = new Box<BranchNode<N, T>, T>();
            left.Node._childrenCount = 8;

            Children.Slice(0, 8).CopyTo(left.Node.Children);
            Indices.Slice(0, 8).CopyTo(left.Node.Indices);

            var right = new Box<BranchNode<N, T>, T>();
            right.Node._childrenCount = 8;
            Children.Slice(8).CopyTo(right.Node.Children);
            var si = Indices.Slice(8);
            for (var i = 0; i < right.Node.Indices.Length && i < si.Length; i++)
                right.Node.Indices[i] = si[i] - left.Count;
            return (left, right);
        }

        public Box<BranchNode<N, T>, T> Merge(Box<BranchNode<N, T>, T> left, Box<BranchNode<N, T>, T> right)
        {
            var ret = left;
            if (left.Frozen)
            {
                ret = new Box<BranchNode<N, T>, T>();
                ret.Node = left.Node;
            }
            var count = left.Node._childrenCount;
            ret.Node._childrenCount += right.Node._childrenCount;
            right.Node.Children.CopyTo(ret.Node.Children.Slice(count));
            ret.Node.InitChildIndicesStartingFrom(count);
            return ret;
        }

        public IListNode<T> MergeNCut(Box<BranchNode<N, T>, T> self)
        {
            if (self.Node._childrenCount == 1)
                return self.Node.Children[0];
            else return self;
        }

        public (Box<BranchNode<N, T>, T>, Box<BranchNode<N, T>, T>) Balance(Box<BranchNode<N, T>, T> left, Box<BranchNode<N, T>, T> right)
        {
            var (oldLeftCount, oldRightCount) = (left.Node._childrenCount, right.Node._childrenCount);


            var leftCount = (oldLeftCount + oldRightCount) / 2;
            var rightCount = oldLeftCount + oldRightCount - leftCount;

            var (newLeft, newRight) = (left, right);

            if (left.Frozen)
            {
                newLeft = new Box<BranchNode<N, T>, T>();
                newLeft.Node._childrenCount = left.Node._childrenCount;
                var c = left.Node.Children.Slice(0, leftCount < oldLeftCount ? leftCount : oldLeftCount);
                var i = left.Node.Indices.Slice(0, leftCount < oldLeftCount ? leftCount : oldLeftCount);

                c.CopyTo(newLeft.Node.Children);
                i.CopyTo(newLeft.Node.Indices);
            }
            if (right.Frozen)
            {
                newRight = new Box<BranchNode<N, T>, T>();
                newRight.Node._childrenCount = right.Node._childrenCount;
            }

            // ok, now it is time to balance stuff
            if (oldLeftCount > leftCount) // moving from left to right:
            {
                // first move the right tail
                right.Node._childrenCount = rightCount;
                right.Node.Children.Slice(0, oldRightCount).CopyTo(newRight.Node.Children.Slice(oldLeftCount - leftCount));
                // now move the left tail to the right head
                left.Node.Children.Slice(leftCount).CopyTo(newRight.Node.Children);
                newLeft.Node._childrenCount = leftCount;
                newRight.Node.InitChildIndicesStartingFrom(0);
                newLeft.Node.InitChildIndicesStartingFrom(leftCount);
            }
            else // moving from right to left:
            {
                // first move the right head to left tail
                newLeft.Node._childrenCount = leftCount;
                right.Node.Children.Slice(0, leftCount - oldLeftCount).CopyTo(newLeft.Node.Children.Slice(oldLeftCount));
                newLeft.Node.InitChildIndicesStartingFrom(oldLeftCount);
                // now move right tail leftwards
                right.Node.Children.Slice(leftCount - oldLeftCount).CopyTo(newRight.Node.Children);
                newRight.Node._childrenCount = rightCount;
                newRight.Node.InitChildIndicesStartingFrom(0);
            }
            Debug.Assert(newLeft.Node._childrenCount + newRight.Node._childrenCount == oldLeftCount + oldRightCount);
            return (newLeft, newRight);
        }
    }
}