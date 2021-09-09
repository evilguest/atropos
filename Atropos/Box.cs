using System;
using System.Collections.Generic;

namespace Atropos
{
    internal class Box<N, T>: IListNode<T>
        where N: struct, IListNodeImpl<N, T>
    {
        public Box() { }

        public N Node;
        private bool _frozen;

        public bool IsFull => Node.IsFull;

        public int Count => Node.Count;

        public bool Frozen => _frozen;

        public bool IsHalfEmpty => Node.IsHalfEmpty;

        public T this[int index] => Node[index];

        public IListNode<T> Add(T value) => Node.InsertAt(this, Count, value);

        public IListNode<T> RemoveAt(int index) => Node.MergeNCut(Node.RemoveAt(this, index));

        public IListNode<T> InsertAt(int index, T value) => Node.InsertAt(this, index, value);

        public IListNode<T> ReplaceAt(int index, T value) => Node.ReplaceAt(this, index, value);

        public IListNode<T> SplitNGrow() => Node.SplitNGrow();

        public IListNode<T> Freeze()
        {
            if(!_frozen)
            {
                Node.Freeze();
                _frozen = true;
            }
            return this;
        }

        public IEnumerator<T> GetEnumerator() => Node.GetEnumerator();

        public int IndexOf(T item, int index, int count, IEqualityComparer<T> equalityComparer)
        {
            if (index < 0 || index + count > Count)
                throw new IndexOutOfRangeException();
            equalityComparer ??= EqualityComparer<T>.Default;
            for (var i = index; i < index + count; i++)
                if (equalityComparer.Equals(this[i], item))
                    return i;
            return -1;
        }
        public int LastIndexOf(T item, int index, int count, IEqualityComparer<T> equalityComparer)
        {
            if (index >= Count || index - count + 1 < 0)
                throw new IndexOutOfRangeException();
            equalityComparer ??= EqualityComparer<T>.Default;
            for (var i = index; i >= index - count + 1; i--)
                if (equalityComparer.Equals(this[i], item))
                    return i;
            return -1;
        }
    }
}