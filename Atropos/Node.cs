using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;

namespace Atropos
{
    interface INode<out T>
    {
//        T[] Data { get; }
//        INode<T>[] Children { get; }
        int SubtreeCount { get; }
        T Get(int index);
        bool IsFull { get; }
        bool IsEmpty { get; }
        INode<T> RemoveAt(int index);
        INode<T>[] Split();
        bool IsLeaf { get; }
    }
    internal abstract class NodeBase<T>
    {
        public abstract INode<T> ReplaceDataAt(int index, T value);
    }
    internal static class Node
    {

        //internal static (INode<T>, INode<T>) Split<T>(this INode<T> node)
        //{
        //    if (node is LeafNode<T> leafNode)
        //        return leafNode.Split();
        //    if (node is InternalNode<T> internalNode)
        //        return internalNode.Split();
        //    throw new InvalidOperationException("Unknown node type");
        //}
        internal static LeafNode<B> InsertDataAt<B, T>(this LeafNode<T> node, int index, B value)
        {
            //ok, we're to insert the data. The way we implement the method, we always have some spare space
            B[] data = new B[node.SubtreeCount + 1];
            Array.Copy(node.Data, 0, data, 0, index);
            data[index] = value;
            Array.Copy(node.Data, index, data, index + 1, node.Data.Length - index);
            return new LeafNode<B>(data);
        }


        internal static INode<T> InsertDataAt<T>(this INode<T> node, int index, T value)
        {
            // we need to figure out if this node is a leaf or not
            if (node is LeafNode<T> leaf)
            {
                return leaf.InsertDataAt(index, value);
            }
            else if (node is InternalNode<T> internalNode)
            {
                return internalNode.InsertDataAt(index, value);
            }
            throw new InvalidOperationException("Unknown node type");
        }

        internal static INode<B> InsertDataAt<B, T>(this INode<T> node, int index, B value)
           where T : class, B
        {
            // we need to figure out if this node is a leaf or not
            if (node is LeafNode<T> leaf)
            {
                return leaf.InsertDataAt(index, value);
            }
            else if (node is InternalNode<T> internalNode)
            {
                int c;
                // find child
                (c, index) = internalNode.FindChildIndex(index);
                var child = internalNode.GetChild(c);

                // and ensure it has enough room to insert:
                if (child.IsFull)
                {
                    if (child is LeafNode<T> leafNode)
                    {
                        var (child1, child2) = leafNode.SplitAndInsert(index, value);
                        return internalNode.ReplaceChildAt(c, child1, child2);
                    }
                    else if (child is InternalNode<T> internalNodeChild)
                    {
                        var (child1, child2) = internalNodeChild.SplitAndInsert(index, value);
                        return internalNode.ReplaceChildAt(c, child1, child2);
                    }
                }
                else
                {
                    var newNode = child.InsertDataAt(index, value);
                    return internalNode.ReplaceChildAt(c, newNode);
                }
            }
            throw new InvalidOperationException("Unknown node type");
        }


        internal static (INode<B> left, INode<B> right) SplitAndInsert<B, T>(this InternalNode<T> node, int index, B value)
            where T: class, B
        {
            INode<B>[] lr;
            lr = node.Split();
            return (index <= lr[0].SubtreeCount)
                ? (lr[0].InsertDataAt(index, value), lr[1])
                : (lr[0], lr[1].InsertDataAt(index - lr[0].SubtreeCount, value));
        }
        internal static (LeafNode<B> left, LeafNode<B> right) SplitAndInsert<B, T>(this LeafNode<T> leaf, int index, B value)
            where T : B
        {
            var halfPage = (ImmutableList<B>.pageSize / 2);
            B[] dataL, dataR;
            if (index <= halfPage)
            {
                dataL = new B[halfPage + 1];
                Array.Copy(leaf.Data, 0, dataL, 0, index);
                dataL[index] = value;
                Array.Copy(leaf.Data, index, dataL, index + 1, halfPage - index);
                dataR = new B[halfPage];
                Array.Copy(leaf.Data, halfPage, dataR, 0, halfPage);
            }
            else
            {
                index -= halfPage;
                dataL = new B[halfPage];
                Array.Copy(leaf.Data, 0, dataL, 0, halfPage);
                dataR = new B[halfPage + 1];
                Array.Copy(leaf.Data, halfPage, dataR, 0, index);
                dataR[index] = value;
                Array.Copy(leaf.Data, halfPage + index, dataR, index + 1, halfPage - index);
            }
            return (new LeafNode<B>(dataL), new LeafNode<B>(dataR));
        }

        internal static InternalNode<B> ReplaceChildAt<B, T>(this InternalNode<T> node, int index, INode<B> child)
        {
            var children = new INode<B>[node.Children.Length];
            node.Children.CopyTo(children, 0);
            children[index] = child; // we're almost ready...

            return new InternalNode<B>(children);
        }

        internal static InternalNode<B> ReplaceChildAt<B, T>(this InternalNode<T> node, int index, INode<B> child1, INode<B> child2)
        {
            var children = new INode<B>[node.Children.Length + 1];
            Array.Copy(node.Children, 0, children, 0, index);
            children[index] = child1;
            children[index + 1] = child2;
            Array.Copy(node.Children, index + 1, children, index + 2, node.Children.Length - index - 1);
            return new InternalNode<B>(children);
        }

        //internal static INode<T> ReplaceDataAt<T>(this INode<T> node, int index, T value)
        //    where T: struct
        //{
        //    if (node.IsLeaf)
        //        return new LeafNode<T>((LeafNode<T>)node, index, value);
        //    else
        //        return new InternalNode<T>((InternalNode<T>)node, index, value)
        //}
        internal static INode<B> ReplaceDataAt<B, T>(this INode<T> node, int index, B value)
            where T : class, B
        {
            if(node is LeafNode<T> leafNode)
            {
                return LeafNode<B>.CreateFrom(leafNode, index, value); 
            }
            else if (node is InternalNode<T> internalNode)
            {
                int c;
                (c, index) = internalNode.FindChildIndex(index);
                var child = internalNode.GetChild(c);
                return internalNode.ReplaceChildAt(c, child.ReplaceDataAt(index, value));
            }
            throw new InvalidOperationException("Unknown node type");
        }
        internal static INode<T> ReplaceDataAt<T>(this INode<T> node, int index, T value)
        {
            return ((NodeBase<T>)node).ReplaceDataAt(index, value);
        }
        internal static INode<T> AddData<T>(this INode<T> node, T value)
        {
            return node.InsertDataAt(node.SubtreeCount, value);
        }
        internal static INode<B> AddData<B, T>(this INode<T> node, B value)
            where T : class, B => node.InsertDataAt(node.SubtreeCount, value);

        //internal static InternalNode<B> AddChild<T, B>(this InternalNode<T> node, INode<B> child)
        //{
        //    var children = new INode<B>[node.Children.Length + 1];
        //    node.Children.CopyTo(children, 0);
        //    children[node.Children.Length] = child;
        //    return new InternalNode<B>(children);
        //}

        internal static INode<T> Fill<T>(T value, int count)
        {
            if (count <= ImmutableList<T>.pageSize)
            {
                var data = new T[count];
                Array.Fill(data, value);
                return new LeafNode<T>(data);
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
                var children = new INode<T>[pageCount];
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
                return new InternalNode<T>(children);
            }

        }

/*        internal static LeafNode<B> Merge<T, B>(this LeafNode<T> node1, LeafNode<B> node2)
            where T : B
        {
            var data = new B[node1.SubtreeCount + node2.SubtreeCount];
            node1.Data.CopyTo(data, 0);
            node2.Data.CopyTo(data, node1.SubtreeCount);
            return new LeafNode<B>(data);
        }
        internal static LeafNode<B> Merge<T, B>(this LeafNode<B> node1, LeafNode<T> node2)
            where T: B
        {
            var data = new B[node1.SubtreeCount + node2.SubtreeCount];
            node1.Data.CopyTo(data, 0);
            node2.Data.CopyTo(data, node1.SubtreeCount);
            return new LeafNode<B>(data);
        }*/

        internal static INode<T> Merge<T> (this INode<T> node, INode<T> other)
        {
            if (node is LeafNode<T> leafNode && other is LeafNode<T> leafOther)
                return leafNode.Merge(leafOther);
            if (node is InternalNode<T> internalNode && other is InternalNode<T> internalOther)
                return internalNode.Merge(internalOther);

            throw new InvalidOperationException("Unknown node type");
        }

        public static (T[] left, T[] right) BalanceWith<T>(this T[] left, T[] right)
        {
            var leftCount = (left.Length + right.Length) / 2;
            var rightCount = (left.Length + right.Length) - leftCount;
            var newLeft = new T[leftCount];
            var newRight = new T[rightCount];
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

        public static (INode<T>, INode<T>) BalanceWith<T>(this INode<T> node, INode<T> other)
        {
            if (node is LeafNode<T> leafNode && other is LeafNode<T> leafOther)
                return leafNode.BalanceWith(leafOther);
            if (node is InternalNode<T> internalNode && other is InternalNode<T> internalOther)
                return internalNode.BalanceWith(internalOther);
            throw new InvalidOperationException("Unknown node type");
        }

    }

}