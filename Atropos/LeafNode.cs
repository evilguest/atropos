using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Atropos
{
    internal struct LeafNode<T> : IListNodeImpl<LeafNode<T>, T>
    {
        private Bunch<T> data;
        private int _count;
        private Span<T> AsSpan => MemoryMarshal.CreateSpan(ref data._data0, _count);
        internal void Fill(T value, int count)
        {
            Debug.Assert(count <= 16);
            _count = count;
            MemoryMarshal.CreateSpan(ref data._data0, count).Fill(value);

        }
        public LeafNode(T value, int count) : this() => Fill(value, count);

        public T this[int index]
        {
            get => data[index];
            set => data[index] = value;
        }

        public bool IsFull => _count == 16;

        public int Count => _count;

        public bool IsHalfEmpty => _count <= 8;

        private static IListNode<T> _empty = new Box<LeafNode<T>, T>().Freeze();
        public static IListNode<T> Empty => _empty;

        public (Box<LeafNode<T>, T>, Box<LeafNode<T>, T>) Split()
        {
            Debug.Assert(IsFull);

            var left = new Box<LeafNode<T>, T>();
            left.Node._count = 8;
            AsSpan.Slice(0, 8).CopyTo(left.Node.AsSpan);

            var right = new Box<LeafNode<T>, T>();
            right.Node._count = 8;
            AsSpan.Slice(8, 8).CopyTo(right.Node.AsSpan);
            return (left, right);
        }
        
        public Box<BranchNode<LeafNode<T>, T>,T> SplitNGrow()
        {
            var r = new Box<BranchNode<LeafNode<T>, T>, T>();
            r.Node.InitChildren(Split());
            return r;
        }
            

        public Box<LeafNode<T>, T> InsertDataAt(Box<LeafNode<T>, T> self, int index, T value)
        {
            if (self.Frozen)
            {
                var r = new Box<LeafNode<T>, T>();
                r.Node._count = Count + 1;
                var t = r.Node.AsSpan;
                AsSpan.Slice(0, index).CopyTo(t);
                t[index] = value;
                AsSpan.Slice(index).CopyTo(t.Slice(index + 1));
                return r;
            }
            else
            {
                var count = self.Count;
                self.Node._count++;

                self.Node.AsSpan.Slice(index, count - index).CopyTo(self.Node.AsSpan.Slice(index + 1));
                self.Node[index] = value;
                return self;
            }
        }

        public Box<LeafNode<T>, T> RemoveAt(Box<LeafNode<T>, T> self, int index)
        {
            var r = self;
            if (self.Frozen)
            {
                r = new Box<LeafNode<T>, T>();
                r.Node = self.Node;
            }
            r.Node.AsSpan.Slice(index + 1).CopyTo(r.Node.AsSpan.Slice(index));
            r.Node._count--;
            return r;
        }

        public Box<LeafNode<T>, T> InsertAt(Box<LeafNode<T>, T> self, int index, T value)
        {
            Debug.Assert(!self.IsFull);
            if(self.Frozen)
            {
                var r = new Box<LeafNode<T>, T>();
                r.Node._count = self.Count + 1;
                self.Node.AsSpan.Slice(0, index).CopyTo(r.Node.AsSpan);
                r.Node[index] = value;
                self.Node.AsSpan.Slice(index).CopyTo(r.Node.AsSpan.Slice(index + 1));
                return r;
            }
            else
            {
                var count = self.Count;
                self.Node._count++;
                self.Node.AsSpan.Slice(index, count-index).CopyTo(self.Node.AsSpan.Slice(index + 1));
                self.Node[index] = value;
                return self;
            }
        }

        public Box<LeafNode<T>, T> ReplaceAt(Box<LeafNode<T>, T> self, int index, T value)
        {
            if (self.Frozen)
            {
                var r = new Box<LeafNode<T>, T>();
                r.Node._count = self.Count;
                self.Node.AsSpan.CopyTo(r.Node.AsSpan);
                r.Node[index] = value;
                return r;
            }
            else
            {
                self.Node[index] = value;
                return self;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_count < 0x1)
                yield break;
            yield return data._data0;
            if (_count < 0x2)
                yield break;
            yield return data._data1;
            if (_count < 0x3)
                yield break;
            yield return data._data2;
            if (_count < 0x4)
                yield break;
            yield return data._data3;
            if (_count < 0x5)
                yield break;
            yield return data._data4;
            if (_count < 0x6)
                yield break;
            yield return data._data5;
            if (_count < 0x7)
                yield break;
            yield return data._data6;
            if (_count < 0x8)
                yield break;
            yield return data._data7;
            if (_count < 0x9)
                yield break;
            yield return data._data8;
            if (_count < 0xA)
                yield break;
            yield return data._data9;
            if (_count < 0xB)
                yield break;
            yield return data._dataA;
            if (_count < 0xC)
                yield break;
            yield return data._dataB;
            if (_count < 0xD)
                yield break;
            yield return data._dataC;
            if (_count < 0xE)
                yield break;
            yield return data._dataD;
            if (_count < 0xF)
                yield break;
            yield return data._dataE;
            if (_count < 0x10)
                yield break;
            yield return data._dataF;

        }

        public void Freeze() {}

        public Box<LeafNode<T>, T> Merge(Box<LeafNode<T>, T> left, Box<LeafNode<T>, T> right)
        {
            Debug.Assert(left.Count + right.Count <= 16);

            var ret = left;
            if (left.Frozen)
            {
                ret = new Box<LeafNode<T>, T>();
                ret.Node = left.Node;
            }
            var count = left.Count;
            ret.Node._count += right.Count;
            right.Node.AsSpan.CopyTo(ret.Node.AsSpan.Slice(count));
            return ret;
        }

        public IListNode<T> MergeNCut(Box<LeafNode<T>, T> self) => self;


        public (Box<LeafNode<T>, T>, Box<LeafNode<T>, T>) Balance(Box<LeafNode<T>, T> left, Box<LeafNode<T>, T> right)
        {
            var (oldLeftCount, oldRightcount) = (left.Count, right.Count);


            var leftCount = (oldLeftCount + oldRightcount) / 2;
            var rightCount = oldLeftCount + oldRightcount - leftCount;

            var (newLeft, newRight) = (left, right);

            if (left.Frozen)
            {
                newLeft = new Box<LeafNode<T>, T>();
                newLeft.Node._count = left.Count;
                var s = left.Node.AsSpan;

                if (left.Count >= leftCount)
                    s = s.Slice(0, leftCount);
                s.CopyTo(newLeft.Node.AsSpan);
            } 
            if (right.Frozen)
            {
                newRight = new Box<LeafNode<T>, T>();
                newRight.Node._count = right.Count;
            }

            // ok, now it is time to balance stuff
            if (oldLeftCount > leftCount) // moving from left to right:
            {
                // first move the right tail
                right.Node._count = rightCount;
                right.Node.AsSpan.Slice(0, oldRightcount).CopyTo(newRight.Node.AsSpan.Slice(oldLeftCount - leftCount));
                // now move the left tail to the right head
                left.Node.AsSpan.Slice(leftCount).CopyTo(newRight.Node.AsSpan);
                newLeft.Node._count = leftCount;
            }
            else // moving from right to left:
            {
                // first move the right head to left tail
                newLeft.Node._count = leftCount;
                right.Node.AsSpan.Slice(0, leftCount - oldLeftCount).CopyTo(newLeft.Node.AsSpan.Slice(oldLeftCount));
                // now move right tail leftwards
                right.Node.AsSpan.Slice(leftCount - oldLeftCount).CopyTo(newRight.Node.AsSpan);
                newRight.Node._count = rightCount;
            }
            Debug.Assert(newLeft.Count + newRight.Count == oldLeftCount + oldRightcount);
            return (newLeft, newRight);
        }
    }
}