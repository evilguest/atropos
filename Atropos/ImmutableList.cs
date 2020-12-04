using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
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
        /// Initializes a new <see cref="ImmutableList{T}"/> with the specified <paramref name="items"/>.
        /// </summary>
        /// <typeparam name="T">Type of the list items</typeparam>
        /// <param name="items">Collection of items to initialize</param>
        /// <returns>A new <see cref="ImmutableList{T}"/> that contais all the items from <paramref name="items"/> in the same order.</returns>
        public static ImmutableList<T> CreateRange<T>(IEnumerable<T> items) 
            => items is ImmutableList<T> list ? list : ImmutableList<T>.Empty.AddRange(items);

        /// <summary>
        /// Creates an <see cref="ImmutableList{T}"/> from <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">Type of the list items</typeparam>
        /// <param name="items">Collection of items to initialize</param>
        /// <returns>An <see cref="ImmutableList{T}"/> that contais all the elements of the input sequence.</returns>
        /// <remarks>Implementation is eager. Do not call on the infinite sequences.</remarks>
        public static ImmutableList<T> ToImmutableList<T>(this IEnumerable<T> items)
            => CreateRange(items);
            
        /// <summary>
        /// Makes a copy of the list, and adds the specified <paramref name="value"/> to the end of the copied list.
        /// </summary>
        /// <typeparam name="T">Type of the original list items</typeparam>
        /// <typeparam name="B">Type of the value to add</typeparam>
        /// <param name="list">Original list</param>
        /// <param name="value">The object to add to the list</param>
        /// <returns>A new list with the object added</returns>
        /// <remarks>Warning: the operation asymptotic is O(<paramref name="list"/>.Count), as we have to clone the list.
        /// Reusing the nodes of the original list is impossible due to the limitations of the C# type system: Node&lt;<typeparamref name="T"/>&gt; cannot be made covariant, and 
        /// storing INode&lt;<typeparamref name="T"/>&gt; would kill the performance due to the indirect call.</remarks>
        public static ImmutableList<B> Add<T, B>(this ImmutableList<T> list, B value)
            where T : class, B => CreateRange<B>(list) + value;
        /// <summary>
        /// Makes a copy of the list, and inserts the specified <paramref name="value"/> at the specified <paramref name="index"/>.
        /// </summary>
        /// <typeparam name="T">Type of the original list items</typeparam>
        /// <typeparam name="B">Type of the value to add</typeparam>
        /// <param name="list">Original list</param>
        /// <param name="index">Position of the insertion</param>
        /// <param name="value">The object to insert into the list</param>
        /// <returns>A new list with the object added</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown when <paramref name="index"/> is outside of the <paramref name="list"/> bounds.</exception>
        /// <remarks>Warning: the operation asymptotic is O(<paramref name="list"/>.Count), as we have to clone the list.
        /// Reusing the nodes of the original list is impossible due to the limitations of the C# type system: Node&lt;<typeparamref name="T"/>&gt; cannot be made covariant, and 
        /// storing INode&lt;<typeparamref name="T"/>&gt; would kill the performance due to the indirect call.</remarks>
        public static ImmutableList<B> Insert<T, B>(this ImmutableList<T> list, int index, B value)
            where T : class, B => CreateRange<B>(list) + (index, value);
        /// <returns>A new list that contains the new element</returns>

        /// <summary>
        /// Makes a copy of the list, and replaces an element in the list at a given position with the specified element.
        /// </summary>
        /// <typeparam name="T">Type of the original list items</typeparam>
        /// <typeparam name="B">Type of the new element</typeparam>
        /// <param name="list">Original list</param>
        /// <param name="index">The position in the list of the element to replace.</param>
        /// <param name="value">The element to replace the old element with.</param>
        /// <returns>A new list with the object added</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown when <paramref name="index"/> is outside of the <paramref name="list"/> bounds.</exception>
        /// <remarks>Warning: the operation asymptotic is O(<paramref name="list"/>.Count), as we have to clone the list.
        /// Reusing the nodes of the original list is impossible due to the limitations of the C# type system: Node&lt;<typeparamref name="T"/>&gt; cannot be made covariant, and 
        /// storing INode&lt;<typeparamref name="T"/>&gt; would kill the performance due to the indirect call.</remarks>
        public static ImmutableList<B> SetItem<T, B>(this ImmutableList<T> list, int index, B value)
            where T : class, B => CreateRange<B>(list).SetItem(index, value);
    }

    /// <summary>
    /// Immutable list
    /// </summary>
    /// <typeparam name="T">Type of the list elements</typeparam>
    public class ImmutableList<T> : IReadOnlyList<T>, IReadOnlyCollection<T>, IImmutableList<T>
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
        /// <param name="equalityComparer">The comparer to use for comparing items with <paramref name="item"/></param>
        /// <returns>The zero-based index of the first occurrence of item within the range of elements
        /// in the <see cref="ImmutableList{T}"/> that starts at <paramref name="index"/> and contains <paramref name="count"/> number 
        /// of elements if found; otherwise -1.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown when requested <paramref name="index"/> is below zero or (<paramref name="index"/>+<paramref name="count"/>) is above <see cref="ImmutableList{T}.Count"/>-1.</exception>
        public int IndexOf(T item, int index, int count, IEqualityComparer<T> equalityComparer = null) 
            => _root.IndexOf(item, index, count, equalityComparer);


        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first 
        /// occurrence within the range of elements in the list
        /// that starts at the specified index and contains the specified number of elements.
        /// </summary>
        /// <param name="item">Object to find</param>
        /// <param name="equalityComparer">The comparer to use for comparing items with <paramref name="item"/></param>
        /// <returns>The zero-based index of the first occurrence of item within the <see cref="ImmutableList{T}"/> if found; otherwise -1.</returns>
        public int IndexOf(T item, IEqualityComparer<T> equalityComparer = null)
            => IndexOf(item, 0, Count, equalityComparer);

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the last occurrence within 
        /// the range of elements in the <see cref="ImmutableList{T}"/>
        /// that contains the specified number of elements and ends at the specified index.
        /// </summary>
        /// <param name="item">The object to locate in the list. The value can be null for reference types.</param>
        /// <param name="index">The zero-based starting index of the search. 0 (zero) is valid in an empty list.</param>
        /// <param name="count"> The number of elements in the section to search.</param>
        /// <param name="equalityComparer">The equality comparer to use when searching for the <paramref name="item"/>.</param>
        /// <returns>The zero-based index of the last occurrence of item within the range of elements
        /// in the <see cref="ImmutableList{T}"/> that starts at <paramref name="index"/> and contains <paramref name="count"/> number 
        /// of elements if found; otherwise -1.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown when requested <paramref name="index"/> is below zero or (<paramref name="index"/>+<paramref name="count"/>) is above <see cref="ImmutableList{T}.Count"/>-1.</exception>
        public int LastIndexOf(T item, int index, int count, IEqualityComparer<T> equalityComparer = null)
            => _root.LastIndexOf(item, index, count, equalityComparer);

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the last occurrence within 
        /// the <see cref="ImmutableList{T}"/>.
        /// </summary>
        /// <param name="item">The object to locate in the list. The value can be null for reference types.</param>
        /// <param name="equalityComparer">The equality comparer to use when searching for the <paramref name="item"/>.</param>
        /// <returns>The zero-based index of the last occurrence of item within the <see cref="ImmutableList{T}"/> if found; otherwise -1.</returns>
        public int LastIndexOf(T item, IEqualityComparer<T> equalityComparer = null)
            => LastIndexOf(item, 0, Count, equalityComparer);

        /// <summary>
        /// Removes the first occurrence of a specified object from this immutable list.
        /// </summary>
        /// <param name="value">The object to remove from the list.</param>
        /// <param name="equalityComparer">Equality comparer to use when searching for <paramref name="value"/>.</param>
        /// <returns>A new immutable list with the specified object removed</returns>
        public ImmutableList<T> Remove(T value, IEqualityComparer<T> equalityComparer = null)
        {
            var index = IndexOf(value, 0, Count, equalityComparer);
            return index >= 0 ? RemoveAt(index) : this;
        }

        /// <summary>
        /// Removes all the elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="match">The delegate that defines the conditions of the elements to remove.</param>
        /// <returns>A new immutable list with the elements removed.</returns>
        public ImmutableList<T> RemoveAll(Predicate<T> match)
        {
            var i = 0;
            var root = _root;
            while (i < root.Count)
            {
                if (match(root[i]))
                    root = root.RemoveAt(i);
                else
                    i++;
            }
            return new ImmutableList<T>(root.Freeze());
        }

        /// <summary>
        /// Removes the element at the specified index of the immutable list.
        /// </summary>
        /// <param name="index">The index of the element to remove.</param>
        /// <returns>A new immutable list with the element removed.</returns>
        public ImmutableList<T> RemoveAt(int index) 
            => new ImmutableList<T>(_root.RemoveAt(index).Freeze());

        /// <summary>
        /// Returns a new list with the first matching element in the list replaced with the specified element.
        /// </summary>
        /// <param name="oldValue">The element to be replaced.</param>
        /// <param name="newValue">The element to replace the first occurrence of <paramref name="oldValue"/> with</param>
        /// <param name="equalityComparer"> The equality comparer to use for matching <paramref name="oldValue"/>.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><paramref name="oldValue"/> does not exist in the list.</exception>
        public ImmutableList<T> Replace(T oldValue, T newValue, IEqualityComparer<T> equalityComparer = null)
        {
            equalityComparer = equalityComparer ?? EqualityComparer<T>.Default;
            var index = IndexOf(oldValue, 0, Count, equalityComparer);
            if (index < 0)
                throw new ArgumentException("The original value not found", nameof(oldValue));

            return SetItem(index, newValue);
        }

        /// <summary>
        /// Inserts the specified value at the specified index
        /// </summary>
        /// <param name="index">Location of the element to insert</param>
        /// <param name="value">Value of the element to insert</param>
        /// <returns>a new <see cref="ImmutableList{T}"/> with the specified <paramref name="value"/> inserted at the specified <paramref name="index"/></returns>
        /// <exception cref="IndexOutOfRangeException">Thrown in case <paramref name="index"/> is outside of the list bounds.</exception> 
        public ImmutableList<T> Insert(int index, T value)
        {
            if (index < 0 || index > Count)
                throw new IndexOutOfRangeException($"Trying to get element #{index} out of {Count}");

            var root = _root;

            if (root.IsFull) // split the root
                root = new Node<T>(_root.Split());
            root = root.InsertDataAt(index, value);
            
            return new ImmutableList<T>(root.Freeze());
        }

        /// <summary>
        /// Inserts the specified elements at the specified index in the immutable list.
        /// </summary>
        /// <param name="index">The zero-based index at which the new elements should be inserted.</param>
        /// <param name="items">The elements to insert.</param>
        /// <returns>A new immutable list that includes the specified elements.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown when <paramref name="index"/>is out of list bounds.</exception>
        public ImmutableList<T> InsertRange(int index, IEnumerable<T> items)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();
            var root = _root;

            // if root is full then split
            foreach (var item in items)
            {
                if (root.IsFull) // split the root
                    root = new Node<T>(root.Split());
                root = root.InsertDataAt(index, item);
                index++;
            }
            return new ImmutableList<T>(root.Freeze());
        }

        /// <summary>
        /// Removes the specified objects from the list.
        /// </summary>
        /// <param name="items">The objects to remove from the list.</param>
        /// <param name="equalityComparer">The comparer to use when searchign for <paramref name="items"/>.</param>
        /// <returns> A new immutable list with the specified objects removed, if items matched objects in the list.</returns>
        public ImmutableList<T> RemoveRange(IEnumerable<T> items, IEqualityComparer<T> equalityComparer = null)
        {
            
            var root = _root;
            foreach (var item in items)
            {
                var i = root.IndexOf(item, 0, root.Count, equalityComparer);
                if (i>=0) root = root.RemoveAt(i);
            }
            return new ImmutableList<T>(root.Freeze());
        }

        /// <summary>
        /// Removes a range of elements from the <see cref="ImmutableList{T}"/>
        /// </summary>
        /// <param name="index">The zero-based starting index of the range of elements to remove.</param>
        /// <param name="count">The number of elements to remove.</param>
        /// <returns>A new immutable list with the elements removed.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown when the requested range crosses the list boundaries.</exception>
        public ImmutableList<T> RemoveRange(int index, int count)
        {
            if (index < 0 || index + count > Count)
                throw new IndexOutOfRangeException();
            var list = this;
            for (var i = 0; i < count; i++)
                list = list.RemoveAt(index);
            return list;
        }

        /// <summary>
        /// Returns an element from the list. Asympthotic is O(log(<see cref="ImmutableList{T}.Count"/>)).
        /// </summary>
        /// <param name="index">The zero-based index of the element to return</param>
        /// <returns>The value at the requested <paramref name="index"/></returns>
        /// <exception cref="IndexOutOfRangeException">Thrown when requested <paramref name="index"/>  is below zero or above <see cref="ImmutableList{T}.Count"/>-1.</exception>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _root.Count)
                    throw new IndexOutOfRangeException();
                return _root[index];
            }
        }

        /// <summary>
        /// Returns count of the elements in the <see cref="ImmutableList{T}"/>
        /// </summary>
        public int Count => _root.Count;

        /// <summary>
        /// Returns the list enumerator
        /// </summary>
        /// <returns>The list enumerator</returns>
        public IEnumerator<T> GetEnumerator()
            => _root.GetEnumerator();
        /*/// <summary>
        /// Returns the list enumerator that starts at the specific index
        /// </summary>
        /// <param name="index">Index where to start</param>
        /// <returns>A new enumerator that is positioned immediately before the element at <paramref name="index"/> position.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown if the index requested is outside of the list.</exception>
        public IEnumerator<T> GetEnumerator(int index)
        {
            return new ImmutableListEnumerator<T>(this, index);
        }*/

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        internal Node<T> _root;

        /// <summary>
        /// Constructs a list from the value
        /// </summary>
        /// <param name="value">The value of the list element</param>
        /// <param name="count">The count of elements to create</param>
        public ImmutableList(T value, int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), "Count must be above zero");
            _root = count == 0 
                ? new Node<T>() 
                : Node<T>.Fill(value, count).Freeze();
        }
        /// <summary>
        /// Creates a new empty immutable list
        /// </summary>
        public ImmutableList() => _root = Node<T>.Empty;
        internal ImmutableList(Node<T> root)
        {
            Debug.Assert(root.Frozen);
            _root = root;
        }

        //internal const int logBrf = 3;
        //internal const int Brf = 1 << logBrf;
        //internal const int maskBrf = Brf - 1;

        //internal const int logPageSize = 4;
        //internal const int pageSize = 1 << logPageSize;
        //internal const int maskPageSize = pageSize - 1;

        /// <summary>
        /// Makes a copy of the list, and adds the specified object to the end of the copied list.
        /// </summary>
        /// <param name="value">The object to add to the list</param>
        /// <returns>A new list with the object added</returns>
        public ImmutableList<T> Add(T value)
        {
            var root = (_root.IsFull
                    ? new Node<T>(_root.Split())
                    : _root)
                .AddData(value);
            root.Freeze();
            return new ImmutableList<T>(root);
        }

        /// <summary>
        /// Adds a range of items to the immutable list
        /// </summary>
        /// <param name="values">The list of items to add</param>
        /// <returns>A new immutable list equal to the original list with the <paramref name="values"/> added at the end.</returns>
        public ImmutableList<T> AddRange(IEnumerable<T> values)
        {
            var root = _root;
            foreach (var value in values)
            {
                if (root.IsFull)
                    root = new Node<T>(root.Split());
                root = root.AddData(value);
            }
            return new ImmutableList<T>(root.Freeze());
        }

        /// <summary>
        /// Replaces an element in the list at a given position with the specified element.
        /// </summary>
        /// <param name="index">The position in the list of the element to replace.</param>
        /// <param name="value">The element to replace the old element with.</param>
        /// <returns>A new list that contains the new element</returns>
        public ImmutableList<T> SetItem(int index, T value)
            => this[index].Equals(value) ? this : new ImmutableList<T>(_root.ReplaceDataAt(index, value).Freeze());

        #region Operators
        /// <summary>
        /// Inserion operator - inserts the specified value at the specified index.
        /// Convenient for the compound assignment operator:
        /// list = list.Insert(index, value) &lt;=&gt; list += (index, value)
        /// </summary>
        /// <param name="list">The immutable list</param>
        /// <param name="param">The pair of (index, value)</param>
        /// <returns>The new immutable list with the <paramref name="param"/>.value inserted at the <paramref name="param"/>.index.</returns>
        public static ImmutableList<T> operator +(ImmutableList<T> list, (int index, T value) param)
            => list.Insert(param.index, param.value);

        /// <summary>
        /// Addition operator - adds the specified value to the immutable list.
        /// Convenient in the compound assignment operator:
        /// list = list.Add(value) &lt;=&gt; list += value
        /// </summary>
        /// <param name="list">The immutable list</param>
        /// <param name="value">The value to add to the end of the list</param>
        /// <returns>The new immutable list with the <paramref name="value"/> inserted at the end.</returns>
        public static ImmutableList<T> operator +(ImmutableList<T> list, T value)
            => list.Add(value);
        /// <summary>
        /// Removal operator - removes the first occurence of the specified value from the list, using the default equality comparer.
        /// Convenient in the compound assignment operator:
        /// list = list.Remove(item, null) &lt;=&gt; list -= item;
        /// </summary>
        /// <param name="list">The immutable list</param>
        /// <param name="value">Value to remove from the list</param>
        /// <returns>A new list with the first occurence of <paramref name="value"/> removed.</returns>
        /// <remarks>Note that for ImmutableList&lt;<see cref="int"/>&gt; this operator overlaps with the <see cref="operator -(ImmutableList{T}, int)"/> and loses.
        /// To remove some value from an <see cref="ImmutableList{T}"/> where T is <see cref="int"/> use the <see cref="Remove"/> method explicitly.
        /// </remarks>
        public static ImmutableList<T> operator -(ImmutableList<T> list, T value)
            => list.Remove(value);

        /// <summary>
        /// Removal operator - removes the first occurence of the specified value from the list, using the specified equality comparer.
        /// Convenient in the compound assignment operator:
        /// list = list.Remove(item, comparer) &lt;=&gt; list -= (item, comparer);
        /// </summary>
        /// <param name="list">The immutable list</param>
        /// <param name="param">Item to remove from the list:
        /// - <paramref name="param"/>.value - the value to remove
        /// - <paramref name="param"/>.comparer - the comparer to use
        /// </param>
        /// <returns>A new list with the first occurence of <paramref name="param"/>. removed.</returns>
        public static ImmutableList<T> operator -(ImmutableList<T> list, (T value, IEqualityComparer<T> comparer) param)
            => list.Remove(param.value, param.comparer);

        /// <summary>
        /// Removal operator - removes item at the specified position. 
        /// Convenient in the compound assignment operator:
        /// list = list.RemoveAt(index) &lt;=&gt; list -= index;
        /// </summary>
        /// <param name="list">The immutable list</param>
        /// <param name="index">Index of an item to remove from the list</param>
        /// <remarks>Note that for ImmutableList&lt;<see cref="int"/>&gt; this operator overlaps with the <see cref="operator -(ImmutableList{T}, T)"/> and wins.
        /// To remove some value from an <see cref="ImmutableList{T}"/> where T is <see cref="int"/> use the <see cref="Remove"/> method explicitly.</remarks>
        /// <returns>A new <see cref="ImmutableList{T}"/> with the specified item removed.</returns>
        public static ImmutableList<T> operator -(ImmutableList<T> list, int index)
            => list.RemoveAt(index);
        /// <summary>
        /// Addition operator - adds the specified range of items to the immutable list.
        /// Convenient in the compound assignment operator:
        /// <code>list = list.AddRange(items) &lt;=&gt; list += items;</code>
        /// </summary>
        /// <param name="list">Immutable list</param>
        /// <param name="items">The items to add </param>
        /// <returns>A new <see cref="ImmutableList{T}"/> with the <paramref name="items"/> appended to the end of the <paramref name="list"/>.</returns>
        public static ImmutableList<T> operator +(ImmutableList<T> list, IEnumerable<T> items)
            => list.AddRange(items);
        /// <summary>
        /// Removal operator - removes the specified items from the immutable list, using the default equality comparer
        /// </summary>
        /// <param name="list">Immutable list</param>
        /// <param name="items">Items to remove</param>
        /// <returns>A new <see cref="ImmutableList{T}"/> with the specified items excluded.</returns>
        public static ImmutableList<T> operator -(ImmutableList<T> list, IEnumerable<T> items)
            => list.RemoveRange(items);

        /// <summary>
        /// Mutation operator - sets the item at the specified index to the specified value.
        /// Convenient in the compound assignment operator; especially when the <typeparamref name="T"/> is itself immutable.
        /// The following two code fragment
        /// <code>
        /// list = list.SetItem(index, list[index].Add(item));
        /// </code>
        /// is equivalent to 
        /// <code>
        /// list |= (index, list[index]+item);
        /// </code>
        /// </summary>
        /// <param name="list"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static ImmutableList<T> operator |(ImmutableList<T> list, (int index, T value) param) 
            => list.SetItem(param.index, param.value);
        #endregion

        #region IImmutableList<T> implementation
        IImmutableList<T> IImmutableList<T>.Add(T value)
            => Add(value);

        IImmutableList<T> IImmutableList<T>.AddRange(IEnumerable<T> items)
            => AddRange(items);

        IImmutableList<T> IImmutableList<T>.Clear()
            => Clear();

        int IImmutableList<T>.IndexOf(T item, int index, int count, IEqualityComparer<T> equalityComparer)
            => IndexOf(item, index, count, equalityComparer);

        IImmutableList<T> IImmutableList<T>.Insert(int index, T element)
            => Insert(index, element);

        IImmutableList<T> IImmutableList<T>.InsertRange(int index, IEnumerable<T> items)
            => InsertRange(index, items);

        int IImmutableList<T>.LastIndexOf(T item, int index, int count, IEqualityComparer<T> equalityComparer)
            => LastIndexOf(item, index, count, equalityComparer);

        IImmutableList<T> IImmutableList<T>.Remove(T value, IEqualityComparer<T> equalityComparer)
            => Remove(value, equalityComparer);

        IImmutableList<T> IImmutableList<T>.RemoveAll(Predicate<T> match)
            => RemoveAll(match);

        IImmutableList<T> IImmutableList<T>.RemoveAt(int index)
            => RemoveAt(index);

        IImmutableList<T> IImmutableList<T>.RemoveRange(IEnumerable<T> items, IEqualityComparer<T> equalityComparer)
            => RemoveRange(items, equalityComparer);

        IImmutableList<T> IImmutableList<T>.RemoveRange(int index, int count)
            => RemoveRange(index, count);

        IImmutableList<T> IImmutableList<T>.Replace(T oldValue, T newValue, IEqualityComparer<T> equalityComparer)
            => Replace(oldValue, newValue, equalityComparer);

        IImmutableList<T> IImmutableList<T>.SetItem(int index, T value)
            => SetItem(index, value);
        #endregion
    }

    //internal struct ImmutableListEnumerator<T> : IEnumerator<T>
    //{
    //    private readonly ImmutableList<T> _list;
    //    //private INode<T> _leaf;
    //    private int _index;

    //    public ImmutableListEnumerator(ImmutableList<T> list, int index)
    //    {
    //        _list = list;
    //        //_leaf = index >= 0 ? FindLeaf(_list, index) : null;
    //        _index = index;
    //    }

    //    public T Current => _list._root[_index]; //_leaf.Data[_index & ImmutableList<T>.maskPageSize];

    //    object IEnumerator.Current => Current;

    //    public void Dispose() { }

    //    public bool MoveNext()
    //    {
    //        var index = _index + 1;
    //        if (index >= _list.Count)
    //            return false;
    //        //if ((index & ImmutableList<T>.maskBrf) == 0) 
    //        //    _leaf = FindLeaf(_list, index); // wrap to the next leaf
    //        _index = index;
    //        return true;
    //    }

    //    //private static INode<T> FindLeaf(ImmutableList<T> list, int index)
    //    //{
    //    //    var node = list._root;
    //    //    for (var level = list._levels; level > 0; level--)
    //    //        node = node.Children[(index >> (ImmutableList<T>.logPageSize + (level - 1) * ImmutableList<T>.logBrf)) & ImmutableList<T>.maskBrf];
    //    //    return node; 
    //    //}
    //    public void Reset()
    //    {
    //        _index = -1;
    //    }
    //}

}
