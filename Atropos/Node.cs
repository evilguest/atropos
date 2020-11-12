using System;
using System.Diagnostics;
using System.Linq;

namespace Atropos
{
    internal static class Node
    {
        internal static INode<B> InsertDataAt<B, T>(this INode<T> node, int index, B value)
        {
            //ok, we're to insert the data. The way we implement the method, we always have some spare space
            B[] data = new B[node.SubtreeCount + 1];
            Array.Copy(node.Data, 0, data, 0, index);
            data[index] = value;
            Array.Copy(node.Data, index, data, index + 1, node.Data.Length - index);
            return new Node<B>(data);
        }
        internal static INode<B> InsertDataAt<B, T>(this INode<T> node, int index, int level, B value)
            where T : B
        {
            if (level == 0)
            {
                return node.InsertDataAt(index, value);
            }
            else
            {   //locate a child to insert the data ...
                for (int s = 0, i = 0; i < node.Children.Length; s += node.Children[i].SubtreeCount, i++)
                    if (s + node.Children[i].SubtreeCount > index)
                    {
                        var child = node.Children[i];
                        index -= s; // index within the selected child
                        // and ensure it has enough room to insert:
                        if (child.IsFull(level - 1))
                        {
                            var (child1, child2) =
                                level == 1
                                ? child.SplitLeafAndInsert(index, value)
                                : child.SplitNodeAndInsert(index, level-1, value);
                            return node.ReplaceChildAt(i, child1, child2);
                        }
                        else
                        {
                            var newNode = child.InsertDataAt(index, level - 1, value);
                            return node.ReplaceChildAt(i, newNode);
                        }
                    }
                throw new InvalidOperationException("Failed to find index in the tree");
            }
        }

        internal static (INode<B> left, INode<B> right) SplitNodeAndInsert<B, T>(this INode<T> node, int index, int level, B value)
        {
            var halfPage = ImmutableList<B>.Brf / 2;
            var childrenL = new INode<B>[halfPage];
            Array.Copy(node.Children, 0, childrenL, 0, halfPage);
            var childrenR = new INode<B>[halfPage];
            Array.Copy(node.Children, halfPage, childrenR, 0, halfPage);

            INode<B> l = new Node<B>(childrenL);
            INode<B> r = new Node<B>(childrenR);

            if (index <= l.SubtreeCount)
                l = l.InsertDataAt(index, level, value);
            else
                r = r.InsertDataAt(index - l.SubtreeCount, level, value);

            return (l, r);
        }
        internal static (INode<B> left, INode<B> right) SplitLeafAndInsert<B, T>(this INode<T> leaf, int index, B value)
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
            return (new Node<B>(dataL), new Node<B>(dataR));
        }
        internal static Node<B> ReplaceChildAt<B, T>(this INode<T> node, int index, INode<B> newNode)
            where T : B
        {
            var children = new INode<B>[node.Children.Length];
            node.Children.CopyTo(children, 0);
            var sc = children[index].SubtreeCount;
            children[index] = newNode;
            return new Node<B>(children, node.SubtreeCount + newNode.SubtreeCount - sc);
        }
        internal static Node<B> ReplaceChildrenAt<B, T>(this INode<T> node, int index, INode<B> newNode1, INode<B> newNode2)
            where T : B
        {
            var children = new INode<B>[node.Children.Length];
            node.Children.CopyTo(children, 0);
            var sc = children[index].SubtreeCount + children[index + 1].SubtreeCount;
            children[index] = newNode1;
            children[index + 1] = newNode2;
            return new Node<B>(children, node.SubtreeCount + newNode1.SubtreeCount + newNode2.SubtreeCount - sc);
        }

        internal static Node<B> ReplaceChildrenAt<B, T>(this INode<T> node, int index, INode<B> newNode)
            where T : B
        {
            var children = new INode<B>[node.Children.Length - 1];
            var sc = node.Children[index].SubtreeCount + node.Children[index + 1].SubtreeCount;
            Array.Copy(node.Children, 0, children, 0, index);
            children[index] = newNode;
            Array.Copy(node.Children, index + 2, children, index + 1, node.Children.Length - index - 2);
            return new Node<B>(children, node.SubtreeCount + newNode.SubtreeCount - sc);
        }

        internal static Node<B> ReplaceChildAt<B, T>(this INode<T> node, int index, INode<B> child1, INode<B> child2)
        {
            var children = new INode<B>[node.Children.Length + 1];
            Array.Copy(node.Children, 0, children, 0, index);
            children[index] = child1;
            children[index + 1] = child2;
            Array.Copy(node.Children, index + 1, children, index + 2, node.Children.Length - index - 1);
            var sc = node.Children[index].SubtreeCount;
            return new Node<B>(children, node.SubtreeCount + child1.SubtreeCount + child2.SubtreeCount - sc);
        }

        internal static Node<B> ReplaceDataAt<B, T>(this INode<T> node, int index, int level, B value)
            where T : B
        {
            if (level == 0)
                return node.ReplaceDataAt(index, value);
            else
            {
                for (int s = 0, i = 0; i < node.Children.Length; s += node.Children[i].SubtreeCount, i++)
                    if (s + node.Children[i].SubtreeCount > index)
                    {
                        var newNode = node.Children[i].ReplaceDataAt(index - s, level - 1, value);
                        return node.ReplaceChildAt(i, newNode);
                    }
                throw new InvalidOperationException("Failed to find index in the tree");
            }
        }

        internal static Node<B> ReplaceDataAt<B, T>(this INode<T> node, int index, B value)
            where T : B
        {
            B[] data = new B[node.Data.Length];
            node.Data.CopyTo(data, 0);
            data[index] = value;
            return new Node<B>(data);
        }
        private static Node<B> AddData<B, T>(this INode<T> node, B value)
            where T : B
        {
            B[] data = new B[node.Data.Length + 1];
            node.Data.CopyTo(data, 0);
            data[node.Data.Length] = value;
            return new Node<B>(data);
        }
        internal static (Node<B>, bool add) AddData<B, T>(this INode<T> node, int level, B value)
            where T : B
        {
            if (level == 0)
            {
                var add = node.Data.Length == ImmutableList<B>.pageSize;
                return (add ? new Node<B>(value) : node.AddData(value), add);
            }
            else
            {
                var (newNode, add) = node.Children[node.Children.Length - 1].AddData(level - 1, value);
                if (!add) // the node fits into the existing one
                    return (node.ReplaceChildAt(node.Children.Length - 1, newNode), false);
                else
                {
                    add = node.Children.Length == ImmutableList<B>.Brf;
                    return (add ? new Node<B>(newNode) : node.AddChild(newNode), add);
                }
            }
        }
        internal static Node<B> AddChild<T, B>(this INode<T> node, INode<B> child)
        {
            var children = new INode<B>[node.Children.Length + 1];
            node.Children.CopyTo(children, 0);
            children[node.Children.Length] = child;
            return new Node<B>(children, node.SubtreeCount + child.SubtreeCount);
        }

        internal static (INode<T> node, int levels) Fill<T>(T value, int count)
        {
            if (count <= ImmutableList<T>.pageSize)
            {
                var data = new T[count];
                Array.Fill(data, value);
                return (new Node<T>(data), 0);
            }
            else
            {
                var levels = 0;
                for (var cnt = count >> ImmutableList<T>.logPageSize; cnt > 0; cnt >>= ImmutableList<T>.logBrf)
                    levels++;

                var blockSize = 1 << ((levels - 1) * ImmutableList<T>.logBrf + ImmutableList<T>.logPageSize);
                var blockCount = count >> ((levels - 1) * ImmutableList<T>.logBrf + ImmutableList<T>.logPageSize);
                var excess = count & (blockSize - 1);
                var children = new INode<T>[blockCount + (excess == 0 ? 0 : 1)];
                var fullChildren = children.AsSpan(0, blockCount);
                var (fullNode, _) = Fill(value, blockSize);

                fullChildren.Fill(fullNode);
                if (excess != 0)
                    (children[children.Length - 1], _) = Fill(value, excess);

                return (new Node<T>(children, count), levels);

            }

        }
        internal static bool IsFull<T>(this INode<T> node, int level) =>
            level == 0 ? node.Data.Length == ImmutableList<T>.pageSize : node.Children.Length == ImmutableList<T>.Brf;
        internal static bool IsEmpty<T>(this INode<T> node, int level) =>
            level == 0 ? node.Data.Length <= ImmutableList<T>.pageSize / 2 : node.Children.Length <= ImmutableList<T>.Brf / 2;

        internal static Node<T> Merge<T>(this INode<T> node1, INode<T> node2, int level)
        {
            if (level == 0) // merge leafs
            {
                var data = new T[node1.SubtreeCount + node2.SubtreeCount];
                node1.Data.CopyTo(data, 0);
                node2.Data.CopyTo(data, node1.SubtreeCount);
                return new Node<T>(data);
            }
            else // merge internal nodes
            {
                var children = new T[node1.Children.Length + node2.Children.Length];
                node1.Children.CopyTo(children, 0);
                node2.Children.CopyTo(children, node1.Children.Length);
                return new Node<T>(children);
            }
        }
        internal static (Node<T> node, int level) RemoveAt<T>(this INode<T> node, int index, int level)
        {
            if (level == 0) // leaf
            {
                var data = new T[node.SubtreeCount - 1];
                Array.Copy(node.Data, 0, data, 0, index);
                Array.Copy(node.Data, index + 1, data, index, node.SubtreeCount - index - 1);
                return (new Node<T>(data), level);
            }

            for (int s = 0, i = 0; i < node.Children.Length; s += node.Children[i].SubtreeCount, i++)
                if (s + node.Children[i].SubtreeCount > index)
                {
                    var child = node.Children[i];
                    index -= s; // index within the selected child
                                // and ensure it has enough data to remove:
                    int _;
                    if (level == 1 && (child.IsEmpty(0)))
                    {
                        (child, _) = child.RemoveAt(index, level - 1); 
                        if (i > 0) // check the left sibling
                        {
                            var siblingLeft = node.Children[i - 1];
                            if (!siblingLeft.IsEmpty(0)) // let's borrow the last item
                            {
                                var moved = siblingLeft.Data[siblingLeft.SubtreeCount - 1];
                                (siblingLeft, _) = siblingLeft.RemoveAt(siblingLeft.SubtreeCount - 1, 0);
                                child = child.InsertDataAt(0, moved);
                                return (node.ReplaceChildrenAt(i - 1, siblingLeft, child), level);
                            }
                            else // merge siblings
                            {
                                return (node.ReplaceChildrenAt(i - 1, siblingLeft.Merge(child, level - 1)), level);
                            }
                        }
                        else // check the right sibling
                        {
                            var siblingRight = node.Children[1];
                            if (!siblingRight.IsEmpty(0)) // let's borrow the first item
                            {
                                var moved = siblingRight.Data[0];
                                (siblingRight, _) = siblingRight.RemoveAt(0, 0);
                                child = child.AddData(moved);
                                return (node.ReplaceChildrenAt(0, child, siblingRight), level);
                            }
                            else // merge siblings
                            {
                                return (node.ReplaceChildrenAt(i, child.Merge(siblingRight, level - 1)), level);
                            }
                        }
                    }
                    else
                    {
                        var (c, _) = child.RemoveAt(index, level - 1);
                        return (node.ReplaceChildAt(i, c), level);
                    }
                }
            throw new InvalidOperationException("Failed to find index in the tree");
        }
    }

    internal struct Node<T> : INode<T>
    {
        public T[] Data { get; }

        public INode<T>[] Children { get; }

        public int SubtreeCount { get; }

        /*        internal Node()
                {
                    Children = null;
                    Data = null;
                    SubtreeCount = 0;
                }*/
        internal Node(T[] data)
            => (Data, SubtreeCount, Children) = (data, data.Length, null);
        internal Node(INode<T>[] children, int subtreeCount)
            => (Children, SubtreeCount, Data) = (children, subtreeCount, null);
        internal Node(INode<T>[] children) : this(children, children.Select(c => c.SubtreeCount).Sum()) { }

        internal Node(T data) : this(new T[] { data }) { }
        internal Node(INode<T> child) : this(new INode<T>[] { child }, child.SubtreeCount) { }
        internal Node(INode<T> child1, INode<T> child2) : this(new INode<T>[] { child1, child2 }, child1.SubtreeCount + child2.SubtreeCount) { }

        public T Get(int index, int level)
        {
            if (level == 0)
                return Data[index];
            else // find the child node holding the index
                for (int s = 0, i = 0; i < Children.Length; s += Children[i].SubtreeCount, i++)
                    if (s + Children[i].SubtreeCount > index)
                        return Children[i].Get(index - s, level - 1);
            throw new IndexOutOfRangeException();
        }



    }

}