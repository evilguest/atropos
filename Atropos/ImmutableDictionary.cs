using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace Atropos
{
    /// <summary>
    /// Provides the helper methods for the <see cref="ImmutableDictionary{TKey, TValue}"/>
    /// </summary>
    public static class ImmutableDictionary
    {
        /// <summary>
        /// Initializes the immutable dictionary based on the provided key-value pairs 
        /// </summary>
        /// <typeparam name="TKey">The dictionary key type</typeparam>
        /// <typeparam name="TValue">The dictionary value type</typeparam>
        /// <param name="keyValuePairs">The pairs to use for the immutable dictionary</param>
        /// <returns>A new immutable dictionary containing the provided <paramref name="keyValuePairs"/></returns>
        public static ImmutableDictionary<TKey, TValue> Init<TKey, TValue>(IEnumerable<(TKey, TValue)> keyValuePairs)
            => throw new NotImplementedException();
    }
    /// <summary>
    /// Represents an immutable dictionary
    /// </summary>
    /// <typeparam name="TKey">Type of the key</typeparam>
    /// <typeparam name="TValue">Type of the value</typeparam>
    public class ImmutableDictionary<TKey, TValue>: IReadOnlyDictionary<TKey, TValue>
    {
        /// <summary>
        /// Returns the value by the given key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException">Thrown when the given key is not present in the dictionary</exception>
        public TValue this[TKey key] => throw new NotImplementedException();

        /// <summary>
        /// Returns an enumeration of all the keys in this dictionary
        /// </summary>
        public IEnumerable<TKey> Keys => throw new NotImplementedException();

        //public IEnumerable<TValue> Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public IEnumerable<TValue> Values => throw new NotImplementedException();

        public ImmutableDictionary<TKey, TValue> Add(TKey key, TValue value)
        {
            throw new NotImplementedException();
        }

        public ImmutableDictionary<TKey, TValue> AddRange(IEnumerable<KeyValuePair<TKey, TValue>> pairs)
        {
            throw new NotImplementedException();
        }

        public ImmutableDictionary<TKey, TValue> Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> pair)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public ImmutableDictionary<TKey, TValue> Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public ImmutableDictionary<TKey, TValue> RemoveRange(IEnumerable<TKey> keys)
        {
            throw new NotImplementedException();
        }

        public ImmutableDictionary<TKey, TValue> SetItem(TKey key, TValue value)
        {
            throw new NotImplementedException();
        }

        public ImmutableDictionary<TKey, TValue> SetItems(IEnumerable<KeyValuePair<TKey, TValue>> items)
        {
            throw new NotImplementedException();
        }

        public bool TryGetKey(TKey equalKey, out TKey actualKey)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
