using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
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
    public class ImmutableDictionary<TKey, TValue> : IImmutableDictionary<TKey, TValue>
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
        /// Sets the specified key and value to the dictionary, possibly overwriting an existing value for the given key.
        /// </summary>
        /// <param name="key">The key of the entry to add.</param>
        /// <param name="value">The value of the entry to add.</param>
        /// <returns>The new dictionary containing the additional key-value pair.</returns>
        /// <remarks>
        /// If the given key-value pair are already in the dictionary, the existing instance is returned.
        /// If the key already exists but with a different value, a new instance with the overwritten value will be returned.
        /// </remarks>
        public ImmutableDictionary<TKey, TValue> SetItem(TKey key, TValue value)
        {
            var result = this;
            if (result.ContainsKey(key))
            {
                result = result.Remove(key);
            }

            return result.Add(key, value);
        }

        /// <summary>
        /// Applies a given set of key=value pairs to an immutable dictionary, replacing any conflicting keys in the resulting dictionary.
        /// </summary>
        /// <param name="items">The key=value pairs to set on the dictionary.  Any keys that conflict with existing keys will overwrite the previous values.</param>
        /// <returns>An immutable dictionary.</returns>
        public ImmutableDictionary<TKey, TValue> SetItems (IEnumerable<KeyValuePair<TKey, TValue>> items)
        {
            var result = this;
            return items.Aggregate(result, (current, kv) => current.SetItem(kv.Key, kv.Value));
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
        /// Removes the specified keys from the dictionary with their associated values.
        /// </summary>
        /// <param name="keys">The keys to remove.</param>
        /// <returns>A new dictionary with those keys removed; or this instance if those keys are not in the dictionary.</returns>
        public ImmutableDictionary<TKey, TValue> RemoveRange (IEnumerable<TKey> keys)
        {
            var result = this;
            return keys.Aggregate(result, (current, key) => current.Remove(key));
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

        /// <summary>
        /// Searches the dictionary for a given key and returns the equal key it finds, if any.
        /// </summary>
        /// <param name="equalKey">The key to search for.</param>
        /// <param name="actualKey">The key from the dictionary that the search found, or <paramref name="equalKey"/> if the search yielded no match.</param>
        /// <returns>A value indicating whether the search was successful.</returns>
        /// <remarks>
        /// This can be useful when you want to reuse a previously stored reference instead of
        /// a newly constructed one (so that more sharing of references can occur) or to look up
        /// the canonical value, or a value that has more complete data than the value you currently have,
        /// although their comparer functions indicate they are equal.
        /// </remarks>
        [Pure]
        public bool TryGetKey(TKey equalKey, out TKey actualKey)
        {
            var node = _rootNode?.FindNode(new ComparableKeyValuePair(equalKey, default(TValue)));
            if (node == null)
            {
                actualKey = equalKey;
                return false;
            }

            actualKey = node.Value.Key;
            return true;
        }

        [Pure]
        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        #region IImmutableDictionary<TKey, TValue> implementation

        IImmutableDictionary<TKey, TValue> IImmutableDictionary<TKey, TValue>.Add(TKey key, TValue value)
            => Add(key, value);

        IImmutableDictionary<TKey, TValue> IImmutableDictionary<TKey, TValue>.AddRange(IEnumerable<KeyValuePair<TKey, TValue>> pairs)
            => AddRange(pairs);

        IImmutableDictionary<TKey, TValue> IImmutableDictionary<TKey, TValue>.SetItem(TKey key, TValue value)
            => SetItem(key, value);

        IImmutableDictionary<TKey, TValue> IImmutableDictionary<TKey, TValue>.SetItems(IEnumerable<KeyValuePair<TKey, TValue>> items)
            => SetItems(items);

        IImmutableDictionary<TKey, TValue> IImmutableDictionary<TKey, TValue>.Clear()
            => Clear();

        IImmutableDictionary<TKey, TValue> IImmutableDictionary<TKey, TValue>.Remove(TKey key)
            => Remove(key);

        IImmutableDictionary<TKey, TValue> IImmutableDictionary<TKey, TValue>.RemoveRange(IEnumerable<TKey> keys)
            => RemoveRange(keys);

        bool IImmutableDictionary<TKey, TValue>.TryGetKey(TKey equalKey, out TKey actualKey)
            => TryGetKey(equalKey, out actualKey);

        #endregion

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