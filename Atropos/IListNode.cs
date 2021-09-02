using System.Collections.Generic;

namespace Atropos
{
    internal interface IListNodeBase<T>
    {
        public T this[int index] { get; }
        IEnumerator<T> GetEnumerator();
        public bool IsFull { get; }
        public bool IsHalfEmpty { get; }
        public int Count { get; }
    }
    internal interface IListNode<T>: IListNodeBase<T>
    {
        IListNode<T> Add(T value);
        IListNode<T> RemoveAt(int index);
        IListNode<T> InsertAt(int index, T value);
        IListNode<T> ReplaceAt(int index, T value);


        public IListNode<T> SplitNGrow();
        public int IndexOf(T item, int index, int count, IEqualityComparer<T> equalityComparer);
        public int LastIndexOf(T item, int index, int count, IEqualityComparer<T> equalityComparer);

        IListNode<T> Freeze();
        bool Frozen { get; }
    }

    internal interface IListNodeImpl<N, T>: IListNodeBase<T>
        where N: struct, IListNodeImpl<N, T>
    {
        Box<N, T> RemoveAt(Box<N, T> self, int index);
        Box<N, T> InsertAt(Box<N, T> self, int index, T value);
        Box<N, T> ReplaceAt(Box<N, T> self, int index, T value);

        Box<BranchNode<N, T>, T> SplitNGrow();
        IListNode<T> MergeNCut(Box<N, T> self);
        (Box<N, T>, Box<N, T>) Split();
        Box<N, T> Merge(Box<N, T> left, Box<N, T> right);
        (Box<N, T>, Box<N, T>) Balance(Box<N, T> left, Box<N, T> right);
        void Freeze();

    }
}