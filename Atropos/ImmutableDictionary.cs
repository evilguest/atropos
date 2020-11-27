﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Atropos
{
    /// <summary>
    /// Represents an immutable key-value dictionary.
    /// </summary>
    /// <typeparam name="TKey">Type of the key.</typeparam>
    /// <typeparam name="TValue">Type of the value.</typeparam>
    public class ImmutableDictionary<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>
        where TKey : IComparable<TKey>
    {
        private readonly TreeNode<ComparableKeyValuePair> _rootNode;

        /// <summary>
        /// Constructs an immutable dictionary.
        /// </summary>
        public ImmutableDictionary()
        {
        }

        private ImmutableDictionary(TreeNode<ComparableKeyValuePair> rootNode, int count)
        {
            _rootNode = rootNode;
            Count = count;
        }

        /// <summary>
        /// Returns the value by the given key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Thrown when the given key is null.</exception>
        /// <exception cref="KeyNotFoundException">Thrown when the given key is not present in the dictionary.</exception>
        public TValue this[TKey key]
        {
            [Pure]
            get
            {
                if (key == null)
                {
                    throw new ArgumentNullException(nameof(key));
                }

                if (!TryGetValue(key, out var value))
                {
                    throw new KeyNotFoundException(key.ToString());
                }

                return value;
            }
        }

        /// <summary>
        /// Returns an enumeration of all the keys in this dictionary.
        /// </summary>
        public IEnumerable<TKey> Keys
        {
            [Pure]
            get
            {
                if (_rootNode == null)
                {
                    return new TKey[0];
                }

                return _rootNode.Select(pair => pair.Key);
            }
        }

        /// <summary>
        /// Returns count of the elements in the <see cref="ImmutableDictionary{TKey, TValue}"/>
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Returns an enumeration of all the values in this dictionary.
        /// </summary>
        public IEnumerable<TValue> Values
        {
            [Pure]
            get
            {
                if (_rootNode == null)
                {
                    return new TValue[0];
                }

                return _rootNode.Select(pair => pair.Value);
            }
        }

        /// <summary>
        /// Adds an element with the specified key and value to the immutable dictionary.
        /// </summary>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="value">The value of the element to add. The value can be null for reference types.</param>
        /// <returns>A new immutable dictionary that contains the additional key/value pair.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given key is null</exception>
        [Pure]
        public ImmutableDictionary<TKey, TValue> Add([NotNull] TKey key, TValue value)
        {
            var pair = new ComparableKeyValuePair(key, value);
            var nodeWithRemovedOldValue = _rootNode?.Remove(pair, out _);
            if (nodeWithRemovedOldValue == null)
            {
                return new ImmutableDictionary<TKey, TValue>(
                    new TreeNode<ComparableKeyValuePair>(pair), 1);
            }

            return new ImmutableDictionary<TKey, TValue>(_rootNode.Insert(pair), Count + 1);
        }

        /// <summary>
        /// Adds the specified key/value pairs to the immutable dictionary.
        /// </summary>
        /// <param name="pairs">The key/value pairs to add.</param>
        /// <returns>A new immutable dictionary that contains the additional key/value pairs.</returns>
        public ImmutableDictionary<TKey, TValue> AddRange(IEnumerable<KeyValuePair<TKey, TValue>> pairs)
        {
            var result = this;
            return pairs.Aggregate(result, (current, kv) => current.Add(kv.Key, kv.Value));
        }

        /// <summary>
        /// Retrieves an empty immutable dictionary.
        /// </summary>
        /// <returns>An empty immutable dictionary.</returns>
        public ImmutableDictionary<TKey, TValue> Clear()
        {
            return this.Count == 0 ? this : new ImmutableDictionary<TKey, TValue>();
        }

        /// <summary>
        /// Determines whether this immutable dictionary contains the specified key/value pair.
        /// </summary>
        /// <param name="pair">TThe key/value pair to locate.</param>
        /// <returns><c>true</c> if the specified key/value pair is found in the dictionary; otherwise, <c>false</c>.</returns>
        public bool Contains(KeyValuePair<TKey, TValue> pair)
        {
            var node = _rootNode?.FindNode(new ComparableKeyValuePair(pair.Key, pair.Value));
            return node != null && node.Value.Value.Equals(pair.Value);
        }

        /// <summary>
        /// Determines whether the immutable dictionary contains an element with the specified key.
        /// </summary>
        /// <param name="key">The key to locate.</param>
        /// <returns>
        /// <c>true</c> if the immutable dictionary contains an element with the specified key; otherwise, <c>false</c>.
        /// </returns>
        [Pure]
        public bool ContainsKey([NotNull] TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            return _rootNode?.FindNode(new ComparableKeyValuePair(key, default(TValue))) != null;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the immutable dictionary.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the dictionary.
        /// </returns>
        [Pure]
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            if (_rootNode == null)
            {
                yield break;
            }

            foreach (var pair in _rootNode)
            {
                yield return new KeyValuePair<TKey, TValue>(pair.Key, pair.Value);
            }
        }

        /// <summary>
        /// Removes the specified key from the dictionary with its associated value.
        /// </summary>
        /// <param name="key">The key to remove.</param>
        /// <returns>A new dictionary with the matching entry removed; or this instance if the key is not in the dictionary.</returns>
        [Pure]
        public ImmutableDictionary<TKey, TValue> Remove([NotNull] TKey key)
        {
            if (_rootNode == null)
            {
                return this;
            }

            var pair = new ComparableKeyValuePair(key, default(TValue));
            var nodeWithoutKey = _rootNode.Remove(pair, out var success);
            if (!success)
            {
                return this;
            }

            return new ImmutableDictionary<TKey, TValue>(nodeWithoutKey, Count - 1);
        }

        /// <summary>
        /// Searches the dictionary for the value by the given key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>A value indicating whether the search was successful.</returns>
        [Pure]
        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default(TValue);
            var node = _rootNode?.FindNode(new ComparableKeyValuePair(key, default(TValue)));
            if (node == null)
            {
                return false;
            }

            value = node.Value.Value;
            return true;
        }

        [Pure]
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private struct ComparableKeyValuePair : IComparable<ComparableKeyValuePair>
        {
            public ComparableKeyValuePair([NotNull] TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }

            public TKey Key { get; }

            public TValue Value { get; }

            public int CompareTo(ComparableKeyValuePair other)
            {
                return Key.CompareTo(other.Key);
            }
        }
    }
}