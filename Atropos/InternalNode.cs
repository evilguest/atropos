using System;
using System.Runtime.InteropServices;

namespace Atropos
{
    //internal interface INodeManager<T>
    //{
    //    T Merge(T left, T right);
    //    (T, T) Balance(T left, T right);
    //}

    internal class InternalNode<T> : NodeBase<T>, INode<T>
    {
        internal int[] _childrenLastIndices;
        public int SubtreeCount => _childrenLastIndices[_childrenLastIndices.Length - 1] + 1;
        public (int child, int index) FindChildIndex(int index)
        {
            // TODO: compare with the SIMD implementation
            int child = Array.BinarySearch(_childrenLastIndices, index);
            if (child < 0)
                child = ~child;
            if (child > 0)
                index -= (_childrenLastIndices[child - 1] + 1);
            return (child, index);
        }
        private static readonly int BranchFactor = 64 / Marshal.SizeOf<IntPtr>();

        internal INode<T>[] Children { get; }

        public bool IsFull => Children.Length == BranchFactor;
        public bool IsEmpty => Children.Length <= BranchFactor / 2;

        public bool IsLeaf => false;

        private InternalNode<T> Split(int start, int count)
        {
            var children = new INode<T>[count];
            Array.Copy(Children, start, children, 0, count);
            if (start == 0)
            {
                var indices = new int[count];
                Array.Copy(_childrenLastIndices, start, indices, 0, count);
                return new InternalNode<T>(children, indices);
            }
            else // indices have to be regenerated
                return new InternalNode<T>(children); 
        }
        private InternalNode<T> Split(int start)
            => Split(start, Children.Length - start);

        public INode<T>[] Split()
        {
            int len = Children.Length / 2;
            return new[] { Split(0, len), Split(len) };
        }

        public T Get(int index)
        {
            INode<T> node = this;
            int child;
            while (node is InternalNode<T> internalNode)
            {
                (child, index) = internalNode.FindChildIndex(index);
                node = internalNode.GetChild(child);
            }

            return node.Get(index); // this is a leaf node
        }
        public INode<T> GetChild(int child) => Children[child];
        private static int[] GetChildIndices(INode<T>[] children)
        {
            var result = new int[children.Length];
            var s = 0;
            for (int i = 0; i < children.Length; i++)
            {
                s += children[i].SubtreeCount;
                result[i] = s - 1;
            }
            return result;
        }

        public override INode<T> ReplaceDataAt(int index, T value)
        {
            int c;
            (c, index) = FindChildIndex(index);
            return ReplaceChildAt(c, Children[c].ReplaceDataAt(index, value));
        }

        internal InternalNode<T> ReplaceChildAt(int index, INode<T> child)
        {
            var children = new INode<T>[Children.Length];
            Children.CopyTo(children, 0);
            children[index] = child; // we're almost ready...

            return new InternalNode<T>(children);
        }
        internal InternalNode<T> ReplaceChildrenAt(int index, INode<T> newNode)
        {
            var children = new INode<T>[Children.Length - 1];
            Array.Copy(Children, 0, children, 0, index);
            children[index] = newNode;
            Array.Copy(Children, index + 2, children, index + 1, Children.Length - index - 2);
            return new InternalNode<T>(children);
        }

        public INode<T> RemoveAt(int index)
        {
            int c;
            (c, index) = FindChildIndex(index);

            var child = Children[c];

            child = child.RemoveAt(index);
            if (!child.IsEmpty)
                return ReplaceChildAt(c, child);
            else
            {
                InternalNode<T> ret;
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

        internal (INode<T>, INode<T>) BalanceWith(InternalNode<T> other)
        {
            var (l, r) = Children.BalanceWith(other.Children);
            return (new InternalNode<T>(l), new InternalNode<T>(r));

        }

        public InternalNode(INode<T>[] children, int[] childrenLastIndices)
                => (Children, _childrenLastIndices) = (children, childrenLastIndices);
        public InternalNode(INode<T>[] children) : this(children, GetChildIndices(children)) { }

        internal InternalNode<T> Merge(InternalNode<T> other)
        {
            var children = new INode<T>[Children.Length + other.Children.Length];
            Children.CopyTo(children, 0);
            other.Children.CopyTo(children, Children.Length);
            return new InternalNode<T>(children);
        }

        internal InternalNode<T> ReplaceChildrenAt(int index, INode<T> newNode1, INode<T> newNode2)
        {
            var children = new INode<T>[Children.Length];
            Children.CopyTo(children, 0);
            children[index] = newNode1;
            children[index + 1] = newNode2;
            return new InternalNode<T>(children);
        }

        internal INode<T> InsertDataAt(int index, T value)
        {
            int c;
            // find child
            (c, index) = FindChildIndex(index);
            if (c == Children.Length)
            {
                c--;
                index = Children[c].SubtreeCount;
            }

            var child = Children[c];

            // and ensure it has enough room to insert:
            if (child.IsFull)
            {
                if (child is LeafNode<T> leafNode)
                {
                    var (child1, child2) = leafNode.SplitAndInsert(index, value);
                    return this.ReplaceChildAt(c, child1, child2);
                }
                else if (child is InternalNode<T> internalNode)
                {
                    var (child1, child2) = internalNode.SplitAndInsert(index, value);
                    return this.ReplaceChildAt(c, child1, child2);
                }
                throw new InvalidOperationException("Unknown node type");
            }
            else
            {
                child = child.InsertDataAt(index, value);
                return this.ReplaceChildAt(c, child);
            }

        }
        internal (INode<T> left, INode<T> right) SplitAndInsert(int index, T value)
        {
            var lr = Split();
            return (index <= lr[0].SubtreeCount)
                ? (lr[0].InsertDataAt(index, value), lr[1])
                : (lr[0], lr[1].InsertDataAt(index - lr[0].SubtreeCount, value));

        }


    }

}