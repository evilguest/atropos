using System;

namespace Atropos
{
    internal class LeafNode<T> : NodeBase<T>, INode<T>
    {
        public T[] Data { get; }


        public int SubtreeCount => Data.Length;

        internal LeafNode(T[] data)
            => Data = data;

        internal LeafNode()
            => Data = Array.Empty<T>();

        
        internal LeafNode(T data) : this(new T[] { data }) { }


        public T Get(int index) => Data[index];

        public bool IsFull => SubtreeCount == ImmutableList<T>.pageSize;

        public bool IsEmpty => SubtreeCount <= ImmutableList<T>.pageSize / 2;

        public bool IsLeaf => true;
        public LeafNode<T> Merge(LeafNode<T> other)
        {
            var data = new T[SubtreeCount + other.SubtreeCount];
            Data.CopyTo(data, 0);
            other.Data.CopyTo(data, SubtreeCount);
            return new LeafNode<T>(data);
        }
        private LeafNode<T> Split(int start, int count)
        {
            var data = new T[count];
            Array.Copy(Data, start, data, 0, count);
            return new LeafNode<T>(data);
        }
        private LeafNode<T> Split(int start)
            => Split(start, Data.Length - start);

        public INode<T>[] Split()
        {
            int len = Data.Length / 2;
            return new[] { Split(0, len), Split(len) };
        }
        public INode<T> RemoveAt(int index)
        {
            var data = new T[SubtreeCount - 1];
            Array.Copy(Data, 0, data, 0, index);
            Array.Copy(Data, index + 1, data, index, SubtreeCount - index - 1);
            return new LeafNode<T>(data);
        }
        public override INode<T> ReplaceDataAt(int index, T value) 
            => new LeafNode<T>(Data, index, value);

        public (INode<T>, INode<T>) BalanceWith(LeafNode<T> other)
        {
            var (l, r) = Data.BalanceWith(other.Data);
            return (new LeafNode<T>(l), new LeafNode<T>(r));
        }
        public LeafNode(T[] data, int index, T value)
        {
            Data = new T[data.Length];
            data.CopyTo(Data, 0);
            Data[index] = value;
        }
        public static LeafNode<T> CreateFrom<D>(LeafNode<D> other, int index, T value)
            where D: class, T
        {
            return new LeafNode<T>(other.Data, index, value);
        }
        public LeafNode(LeafNode<T> other, int index, T value) : this(other.Data, index, value) { }
    }

}