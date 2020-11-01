using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

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
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Makes a copy of the list, and adds the specified object to the end of the copied
        ///     list.
        /// </summary>
        /// <typeparam name="T">Element type of the original list</typeparam>
        /// <typeparam name="B">Added item type</typeparam>
        /// <param name="list">Original immutable list</param>
        /// <param name="value">The object to add to the list</param>
        /// <returns>A new list with the object added</returns>
        public static ImmutableList<B> Add<T, B>(this ImmutableList<T> list, B value)
            where T : B
            => throw new NotImplementedException();
        /// <summary>
        /// Adds a range of items to the immutable list
        /// </summary>
        /// <typeparam name="T">Element type of the original list</typeparam>
        /// <typeparam name="B">Added item type</typeparam>
        /// <param name="list">Original immutable list</param>
        /// <param name="items">The list of items to add</param>
        /// <returns>A new immutable list equal to the original list with the <paramref name="items"/> added at the end.</returns>
        public static ImmutableList<B> AddRange<T, B>(this ImmutableList<T> list, IEnumerable<B> items)
            where T : B
            => throw new NotImplementedException();
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
        /// Clears the list
        /// </summary>
        /// <returns>A new immutable list of the same type as this, but with no elements</returns>
        public ImmutableList<T> Clear()
            => throw new NotImplementedException();


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
        /// <returns>A new immutable list with the elements removed./returns>
        public static ImmutableList<T> RemoveRange(int index, int count)
            => throw new NotImplementedException();

        /// <summary>
        /// Returns an element from the list. Asympthotic is O(log(<see cref="ImmutableList{T}.Count"/>)).
        /// </summary>
        /// <param name="index">The zero-based index of the element to return</param>
        /// <returns>The value at the requested <paramref name="index"/></returns>
        /// <exception cref="IndexOutOfRangeException">Thrown when requested index is below zero or aboove <see cref="ImmutableList{T}.Count"/>-1</exception>
        public T this[int index] => throw new NotImplementedException();

        /// <summary>
        /// Returns count of the elements in the <see cref="ImmutableList{T}"/>
        /// </summary>
        public int Count => throw new NotImplementedException();

        /// <summary>
        /// Returns the list enumerator
        /// </summary>
        /// <returns>The list enumerator</returns>
        public IEnumerator<T> GetEnumerator() => throw new NotImplementedException();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
