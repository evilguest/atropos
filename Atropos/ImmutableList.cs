using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;

namespace Atropos
{
    /// <summary>
    /// Helper class with the extension methods for the <see cref="ImmutableList{T}"/> class.
    /// </summary>
    public static class ImmutableList
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImmutableList{T}"/> class
        /// </summary>
        /// <typeparam name="T">Immutable list element type, inferred automatically from the <paramref name="item"/>parameter</typeparam>
        /// <param name="item">value of the element(s) to repeat <paramref name="count"/> times</param>
        /// <param name="count">The number of times to repeat the provided <paramref name="item"/></param>
        /// <returns>A new immutable list that contains <paramref name="count"/> instances of <paramref name="item"/></returns>
        public static ImmutableList<T> Init<T>(T item, int count = 1)
            => new ImmutableList<T>(item, count);


        /// <summary>
        /// Makes a copy of the list, and adds the specified object to the end of the copied list.
        /// </summary>
        /// <typeparam name="T">Element type of the original list</typeparam>
        /// <typeparam name="B">Added item type</typeparam>
        /// <param name="list">Original immutable list</param>
        /// <param name="value">The object to add to the list</param>
        /// <returns>A new list with the object added</returns>
        public static ImmutableList<B> Add<T, B>(this ImmutableList<T> list, B value)
            where T : class, B
        {
            var root = (INode<B>)list._root;
            var levels = list._levels;

            // ImmutableList<B> result = new ImmutableList<B>();
            var (page, add) = root.AddData(levels, value);
            if (add)
            {
                root = new Node<B>(root, page);
                levels++;
            }
            else
                root = page;
            return new ImmutableList<B>(root, levels);
        }
        /// <summary>
        /// Makes a copy of the list, and adds the specified object to the end of the copied list.
        /// </summary>
        /// <typeparam name="T">Element type of the original list</typeparam>
        /// <param name="list">Original immutable list</param>
        /// <param name="value">The object to add to the list</param>
        /// <returns>A new list with the object added</returns>
        public static ImmutableList<T> Add<T>(this ImmutableList<T> list, T value)
            where T : struct
        {
            var root = list._root;
            var levels = list._levels;

            // ImmutableList<B> result = new ImmutableList<B>();
            var (page, add) = root.AddData(levels, value);
            if (add)
            {
                root = new Node<T>(root, page);
                levels++;
            }
            else
                root = page;
            return new ImmutableList<T>(root, levels);
        }

        /// <summary>
        /// Adds a range of items to the immutable list
        /// </summary>
        /// <typeparam name="T">Element type of the original list</typeparam>
        /// <typeparam name="B">Added item type</typeparam>
        /// <param name="list">Original immutable list</param>
        /// <param name="items">The list of items to add</param>
        /// <returns>A new immutable list equal to the original list with the <paramref name="items"/> added at the end.</returns>
        public static ImmutableList<B> AddRange<T, B>(this ImmutableList<T> list, IEnumerable<B> items)
            where T : class, B
        {
            var root = (INode<B>)list._root;
            var levels = list._levels;
            foreach (var item in items)
            {
                var (page, add) = root.AddData(levels, item);
                if (add)
                {
                    root = new Node<B>(root, page);
                    levels++;
                }
                else
                    root = page;
            }
            return new ImmutableList<B>(root, levels);
        }

        /// <summary>
        /// Adds a range of items to the immutable list
        /// </summary>
        /// <typeparam name="T">Element type of the original list</typeparam>
        /// <param name="list">Original immutable list</param>
        /// <param name="items">The list of items to add</param>
        /// <returns>A new immutable list equal to the original list with the <paramref name="items"/> added at the end.</returns>
        public static ImmutableList<T> AddRange<T>(this ImmutableList<T> list, IEnumerable<T> values)
            where T : struct
        {
            var root = list._root;
            var levels = list._levels;
            foreach (var value in values)
            {
                var (page, add) = root.AddData(levels, value);
                if (add)
                {
                    root = new Node<T>(root, page);
                    levels++;
                }
                else
                    root = page;
            }
            return new ImmutableList<T>(root, levels);
        }
        /// <summary>
        /// Inserts the specified element at the specified index in the immutable list.
        /// </summary>
        /// <typeparam name="T">Element type of the original list</typeparam>
        /// <typeparam name="B">Added item type</typeparam>
        /// <param name="list">Original immutable list</param>
        /// <param name="index">The zero-based index at which to insert the value.</param>
        /// <param name="element">The object to insert.</param>
        /// <returns>A new immutable list that includes the specified element.</returns>
        public static ImmutableList<B> Insert<T, B>(this ImmutableList<T> list, int index, B element)
            where T : B
            => throw new NotImplementedException();

        /// <summary>
        /// Inserts the specified elements at the specified index in the immutable list.
        /// </summary>
        /// <typeparam name="T">Element type of the original list</typeparam>
        /// <typeparam name="B">Added item type</typeparam>
        /// <param name="list">Original immutable list</param>
        /// <param name="index">The zero-based index at which the new elements should be inserted.</param>
        /// <param name="items">The elements to insert.</param>
        /// <returns>A new immutable list that includes the specified elements.</returns>
        public static ImmutableList<B> InsertRange<T, B>(this ImmutableList<T> list, int index, IEnumerable<B> items)
            where T : B
            => throw new NotImplementedException();

        /// <summary>
        ///  Returns a new list with the first matching element in the list replaced with 
        ///  the specified element.
        /// </summary>
        /// <typeparam name="T">Element type of the original list</typeparam>
        /// <typeparam name="B">Added item type</typeparam>
        /// <param name="list">Original immutable list</param>
        /// <param name="oldValue">The element to be replaced.</param>
        /// <param name="newValue">The element to replace the first occurrence of oldValue with</param>
        /// <returns>A new list that contains newValue, even if oldvalue is the same as newValue.</returns>
        public static ImmutableList<B> Replace<T, B>(ImmutableList<T> list, T oldValue, B newValue)
            where T : B
            => list.SetItem(list.IndexOf(oldValue, 0, list.Count), newValue);
        /// <summary>
        /// Replaces an element in the list at a given position with the specified element.
        /// </summary>
        /// <typeparam name="T">Element type of the original list</typeparam>
        /// <typeparam name="B">The type of the replacement value</typeparam>
        /// <param name="list">Original immutable list</param>
        /// <param name="index">The position in the list of the element to replace.</param>
        /// <param name="value">The element to replace the old element with.</param>
        /// <returns>A new list that contains the new element, even if the element at the specified
        /// location is the same as the new element.</returns>
        public static ImmutableList<B> SetItem<T, B>(this ImmutableList<T> list, int index, B value)
            where T : B
            => throw new NotImplementedException();

    }

    /// <summary>
    /// Immutable list
    /// </summary>
    /// <typeparam name="T">Type of the list elements</typeparam>
    public class ImmutableList<T> : IReadOnlyList<T>, IReadOnlyCollection<T>
    {
        /// <summary>
        /// Returns an empty <see cref="ImmutableList{T}"/>
        /// </summary>
        public static ImmutableList<T> Empty { get; } = new ImmutableList<T>();
        /// <summary>
        /// Clears the list
        /// </summary>
        /// <returns>A new immutable list of the same type as this, but with no elements</returns>
        public ImmutableList<T> Clear() => Empty;


        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first 
        /// occurrence within the range of elements in the list
        /// that starts at the specified index and contains the specified number of elements.
        /// </summary>
        /// <param name="item">Object to find</param>
        /// <param name="index">Zero-based start index</param>
        /// <param name="count">The length of the search range</param>
        /// <returns>The zero-based index of the first occurrence of item within the range of elements
        /// in the <see cref="ImmutableList{T}"/> that starts at <paramref name="index"/> and contains <paramref name="count"/> number 
        /// of elements if found; otherwise -1.</returns>
        public int IndexOf(T item, int index, int count) =>
            throw new NotImplementedException();

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the last occurrence within 
        /// the range of elements in the <see cref="ImmutableList{T}"/>
        /// that contains the specified number of elements and ends at the specified index.
        /// </summary>
        /// <param name="item">The object to locate in the list. The value can be null for reference types.</param>
        /// <param name="index">The zero-based starting index of the search. 0 (zero) is valid in an empty list.</param>
        /// <param name="count"> The number of elements in the section to search.</param>
        /// <returns>The zero-based index of the last occurrence of item within the range of elements
        /// in the <see cref="ImmutableList{T}"/> that starts at <paramref name="index"/> and contains <paramref name="count"/> number 
        /// of elements if found; otherwise -1.</returns>
        public int LastIndexOf(T item, int index, int count)
            => throw new NotImplementedException();

        /// <summary>
        /// Removes the first occurrence of a specified object from this immutable list.
        /// </summary>
        /// <param name="value">The object to remove from the list.</param>
        /// <returns>A new immutable list with the specified object removed</returns>
        public ImmutableList<T> Remove(T value)
            => throw new NotImplementedException();

        /// <summary>
        /// Removes all the elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="match">The delegate that defines the conditions of the elements to remove.</param>
        /// <returns>A new immutable list with the elements removed.</returns>
        public ImmutableList<T> RemoveAll(Predicate<T> match)
            => throw new NotImplementedException();

        /// <summary>
        /// Removes the element at the specified index of the immutable list.
        /// </summary>
        /// <param name="index">The index of the element to remove.</param>
        /// <returns>A new immutable list with the element removed.</returns>
        public static ImmutableList<T> RemoveAt(int index)
            => throw new NotImplementedException();
        /// <summary>
        /// Removes the specified objects from the list.
        /// </summary>
        /// <param name="items">The objects to remove from the list.</param>
        /// <returns> A new immutable list with the specified objects removed, if items matched objects in the list.</returns>
        public static ImmutableList<T> RemoveRange(IEnumerable<T> items)
            => throw new NotImplementedException();

        /// <summary>
        /// Removes a range of elements from the <see cref="ImmutableList{T}"/>
        /// </summary>
        /// <param name="index">The zero-based starting index of the range of elements to remove.</param>
        /// <param name="count">The number of elements to remove.</param>
        /// <returns>A new immutable list with the elements removed.</returns>
        public static ImmutableList<T> RemoveRange(int index, int count)
            => throw new NotImplementedException();

        /// <summary>
        /// Returns an element from the list. Asympthotic is O(log(<see cref="ImmutableList{T}.Count"/>)).
        /// </summary>
        /// <param name="index">The zero-based index of the element to return</param>
        /// <returns>The value at the requested <paramref name="index"/></returns>
        /// <exception cref="IndexOutOfRangeException">Thrown when requested index is below zero or aboove <see cref="ImmutableList{T}.Count"/>-1</exception>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _root.SubtreeCount)
                    throw new IndexOutOfRangeException();
                var n = _root;
                for (int l = _levels; l > 0; l--)
                    n = n.Children[(index >> (l * logBrf + logPageSize)) & maskBrf];
                return n.Data[index & maskPageSize];
            }
        }
        internal int _levels;

        /// <summary>
        /// Returns count of the elements in the <see cref="ImmutableList{T}"/>
        /// </summary>
        public int Count => _root.SubtreeCount;

        /// <summary>
        /// Returns the list enumerator
        /// </summary>
        /// <returns>The list enumerator</returns>
        public IEnumerator<T> GetEnumerator()
            => GetEnumerator(-1);
        public IEnumerator<T> GetEnumerator(int index)
        {
            return new ImmutableListEnumerator<T>(this, index);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        internal INode<T> _root;
        
        /// <summary>
        /// Constructs a list from the value
        /// </summary>
        /// <param name="value">The value of the list element</param>
        /// <param name="count">The count of elements to create</param>
        public ImmutableList(T value, int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), "Count must be above zero");
            if (count == 0)
            {
                _root = new Node<T>();
                return;
            }

            // figure out the levels count
            for (var cnt = count >> logPageSize; cnt > 0; cnt >>= logBrf)
                _levels++;

            (_root, _levels) = Node.Fill(value, count);
            
            //_root = new Node<T>(value);
        }
        /// <summary>
        /// Creates a new empty immutable list
        /// </summary>
        public ImmutableList() => _root = new Node<T>();
        internal ImmutableList(INode<T> root, int levels) 
            => (_root, _levels) = (root, levels);

        internal const int logBrf = 3;
        internal const int Brf = 1 << logBrf;
        internal const int maskBrf = Brf - 1;

        internal const int logPageSize = 4;
        internal const int pageSize = 1 << logPageSize;
        internal const int maskPageSize = pageSize - 1;
    }

    internal struct ImmutableListEnumerator<T> : IEnumerator<T>
    {
        private ImmutableList<T> _list;
        private INode<T> _leaf;
        private int _index;

        public ImmutableListEnumerator(ImmutableList<T> list, int index)
        {
            _list = list;
            _leaf = index >= 0 ? FindLeaf(_list, index) : null;
            _index = index;
        }

        public T Current => _leaf.Data[_index & ImmutableList<T>.maskPageSize];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            var index = _index + 1;
            if (index >= _list.Count)
                return false;
            if ((index & ImmutableList<T>.maskBrf) == 0) 
                _leaf = FindLeaf(_list, index); // wrap to the next leaf
            _index = index;
            return true;
        }

        private static INode<T> FindLeaf(ImmutableList<T> list, int index)
        {
            var node = list._root;
            for (var level = list._levels; level > 0; level--)
                node = node.Children[(index >> (ImmutableList<T>.logPageSize + (level - 1) * ImmutableList<T>.logBrf)) & ImmutableList<T>.maskBrf];
            return node; 
        }
        public void Reset()
        {
            _index = -1;
        }
    }

    internal static class Node
    {
        internal static Node<B> ReplaceChildAt<B, T>(this INode<T> node, int index, INode<B> newNode)
            where T : B
        {
            var children = new INode<B>[node.Children.Length];
            node.Children.CopyTo(children, 0);
            children[index] = newNode;
            return new Node<B>(children, node.SubtreeCount);
        }
        internal static Node<B> ReplaceDataAt<B, T>(this INode<T> node, int index, B value)
            where T : B
        {
            B[] data = new B[node.Data.Length];
            node.Data.CopyTo(data, 0);
            data[index] = value;
            return new Node<B>(data, node.SubtreeCount);
        }
        private static Node<B> AddData<B, T>(this INode<T> node, B value)
            where T : B
        {
            B[] data = new B[node.Data.Length + 1];
            node.Data.CopyTo(data, 0);
            data[node.Data.Length] = value;
            return new Node<B>(data, node.SubtreeCount + 1);
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

        internal static (INode<T> node, int _levels) Fill<T>(T value, int count)
        {
            if (count <= ImmutableList<T>.pageSize)
            {
                var data = new T[count];
                Array.Fill(data, value);
                return (new Node<T>(data, count), 0);
            }
            else
            {
                var levels = 0;
                for (var cnt = count >> ImmutableList<T>.logPageSize; cnt > 0; cnt >>= ImmutableList<T>.logBrf)
                    levels++;
                
                var blockSize = 1 << ((levels-1)*ImmutableList<T>.logBrf + ImmutableList<T>.logPageSize);
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
    }
    interface INode<out T>
    {
        T[] Data { get; }
        INode<T>[] Children { get; }
        int SubtreeCount { get; }
    }
    internal class Node<T> : INode<T>
    {
        public T[] Data { get; }

        public INode<T>[] Children { get; }

        public int SubtreeCount { get; }

        internal Node()
        {
            Children = null;
            Data = null;
            SubtreeCount = 0;
        }
        internal Node(T[] data, int subtreeCount) 
            => (Data, SubtreeCount) = (data, subtreeCount);
        internal Node(INode<T>[] children, int subtreeCount) 
            => (Children, SubtreeCount) = (children, subtreeCount);
        
        internal Node(T data)
        {
            SubtreeCount = 1;
            Data = new T[1];
            Data[0] = data;
        }
        internal Node(INode<T> child)
        {
            SubtreeCount = child.SubtreeCount;
            Children = new Node<T>[1];
            Children[0] = child;
        }
        internal Node(INode<T> child1, INode<T> child2)
        {
            SubtreeCount = child1.SubtreeCount + child2.SubtreeCount;
            Children = new Node<T>[2];
            Children[0] = child1;
            Children[1] = child2;
        }

    }
    /*
    internal unsafe class Leaf<T>
    {
        private static readonly int Size = 256 / (typeof(T).IsByRef ? sizeof(IntPtr) : Marshal.SizeOf<T>());
        private int _count;
        private Block256 data;

    }
    [StructLayout(LayoutKind.Explicit)]
    internal unsafe struct Block256
    {
        [FieldOffset(0)]
        private fixed int data[8];
        [FieldOffset(0)]
        private Vector256<int> vdata;
    }*/
}
