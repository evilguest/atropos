using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Atropos
{
    /// <summary>
    /// Helper class for the <see cref="ImmutableDeque{T}"/>
    /// </summary>
    public static class ImmutableDeque
    {
        /// <summary>
        /// Initializes a new immutable deque to the list of items passed
        /// </summary>
        /// <typeparam name="T">Type of the deque element</typeparam>
        /// <param name="items">The collection to use for initialization</param>
        /// <returns>If the passed argument is <see cref="IImmutableDeque{T}"/> then returns it without change.
        /// Otherwise a new <see cref="ImmutableDeque{T}"/>  created from the items passed in the <paramref name="items"/> argument.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="items"/> is null</exception>
        public static IImmutableDeque<T> CreateRange<T>(IEnumerable<T> items)
        {
            if (items is null)
                throw new ArgumentNullException(nameof(items));

            if (items is IImmutableDeque<T> deque) return deque;

            var d = ImmutableDeque<T>.Empty;
            foreach (var item in items)
                d = d.EnqueueRight(item);
            return d;
        }
        /// <summary>
        /// Adds a range of item to the right of this queue
        /// </summary>
        /// <typeparam name="T">Type of the deque element</typeparam>
        /// <param name="deque">The deque</param>
        /// <param name="items">The list of items to enqueue on the right</param>
        /// <returns>If the <paramref name="items"/> collection is empty, then the original <paramref name="deque"/> is returned.
        /// If the <paramref name="items"/> is another <see cref="IImmutableDeque{T}"/>, then the <see cref="IImmutableDeque{T}.Concat(IImmutableDeque{T})"/> method is used.
        /// Otherwise, <paramref name="items"/> are fed one by one into the <see cref="IImmutableDeque{T}.EnqueueRight(T)"/> method.
        /// </returns>
        public static IImmutableDeque<T> AddRange<T>(this IImmutableDeque<T> deque, IEnumerable<T> items)
        {
            //if (items is IImmutableDeque<T> otherDeque)
            //    return deque.Concat(otherDeque);
            //else
            //{
            foreach (var item in items)
                deque = deque.EnqueueRight(item);
            return deque;
            //}
        }
    }

    /// <summary>
    /// An efficient implementation of the <see cref="IImmutableDeque{T}"/> based on the Eric Lippert's deque, which is based on the Hughes lists.
    /// See also https://docs.microsoft.com/en-us/archive/blogs/ericlippert/immutability-in-c-part-eleven-a-working-double-ended-queue
    /// </summary>
    /// <typeparam name="T">The type of deque elements</typeparam>
    public sealed partial class ImmutableDeque<T> : IImmutableDeque<T>
    {

        private static readonly IImmutableDeque<T> empty = new EmptyDeque();
        /// <summary>
        /// An empty deque of <typeparamref name="T"/>
        /// </summary>
        public static IImmutableDeque<T> Empty => empty;

        private ImmutableDeque(Dequelette left, IImmutableDeque<Dequelette> middle, Dequelette right) 
            => (_left, _middle, _right) = (left, middle, right);

        private readonly Dequelette _left;
        private readonly IImmutableDeque<Dequelette> _middle;
        private readonly Dequelette _right;

        #region IEnumerable<T>
        /// <summary>
        /// Traverses this deque from left to right
        /// </summary>
        /// <returns>The enumerator that traverses this deque from left to right</returns>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _left)
                yield return item;

            foreach (var dequelette in _middle)
                foreach (var item in dequelette)
                    yield return item;

            foreach (var item in _right)
                yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion

        #region IImmutableQueue<T>
        /// <summary>
        /// Implements <see cref="IImmutableQueue{T}.IsEmpty"/>. Always false for this class - we have a separate internal class for an empty deque.
        /// </summary>
        public bool IsEmpty => false;

        /// <summary>
        /// Implements the <see cref="IImmutableQueue{T}.Dequeue()"/>, synonym for <see cref="IImmutableDeque{T}.DequeueLeft()"/>
        /// </summary>
        /// <returns>A new <see cref="ImmutableDeque{T}"/> with the leftmost element removed.</returns>
        public IImmutableQueue<T> Dequeue() => DequeueLeft();

        /// <summary>
        /// Implements the <see cref="ImmutableQueue{T}.Enqueue(T)"/>, synonym for <see cref="IImmutableDeque{T}.EnqueueRight(T)"/>
        /// </summary>
        /// <param name="value">The value to enqueue</param>
        /// <returns>A new <see cref="ImmutableQueue{T}"/> that contains the same elements as this queue plus the <paramref name="value"/> as the rightmost element</returns>
        public IImmutableQueue<T> Enqueue(T value) => EnqueueRight(value);

        /// <summary>
        /// Peeks the element on the left of the queue without removing it
        /// </summary>
        /// <returns></returns>
        public T Peek() => Left;

        IImmutableQueue<T> IImmutableQueue<T>.Clear() => Empty;
        #endregion

        #region IImmutableDeque<T>
        /// <summary>
        /// Enqueues the specified element to the left of the deque
        /// </summary>
        /// <param name="value">The value to enqueue</param>
        /// <returns>A new <see cref="ImmutableDeque{T}"/> that contains the same elements as this deque, plus the <paramref name="value"/> pushed from the left</returns>
        /// <remarks>
        /// The cost of this operation varies depending on the deque size; but the amortized cost is O(1).
        /// </remarks>
        public IImmutableDeque<T> EnqueueLeft(T value)
            => _left.Full
                ? new ImmutableDeque<T>(
                    new Two(value, _left.Left),
                    _middle.EnqueueLeft(_left.DequeueLeft()),
                    _right)
                : new ImmutableDeque<T>(_left.EnqueueLeft(value), _middle, _right);
        /// <summary>
        /// Enqueues the specified element to the right of the deque
        /// </summary>
        /// <param name="value">The value to enqueue</param>
        /// <returns>A new <see cref="ImmutableDeque{T}"/> that contains the same elements as this deque, plus the <paramref name="value"/> pushed from the right</returns>
        /// <remarks>
        /// The cost of this operation varies depending on the deque size; but the amortized cost is O(1).
        /// </remarks>
        public IImmutableDeque<T> EnqueueRight(T value)
            => _right.Full
                ? new ImmutableDeque<T>(
                    _left,
                    _middle.EnqueueRight(_right.DequeueRight()),
                    new Two(_right.Right, value))
                : new ImmutableDeque<T>(_left, _middle, _right.EnqueueRight(value));

        /// <summary>
        /// Removes one element from deque's left
        /// </summary>
        /// <returns>A new <see cref="IImmutableDeque{T}"/> that contains all the elements of this deque, except for the leftmost one</returns>
        /// <remarks>
        /// The cost of this operation varies depending on the deque size; but the amortized cost is O(1).
        /// </remarks>
        public IImmutableDeque<T> DequeueLeft()
        {
            if (_left.Size > 1)
                return new ImmutableDeque<T>(_left.DequeueLeft(), _middle, _right);
            if (!_middle.IsEmpty)
                return new ImmutableDeque<T>(_middle.Left, _middle.DequeueLeft(), _right);
            if (_right.Size > 1)
                return new ImmutableDeque<T>(new One(_right.Left), _middle, _right.DequeueLeft());
            return new SingleDeque(_right.Left);
        }
        /// <summary>
        /// Removes one element from deque's right
        /// </summary>
        /// <returns>A new <see cref="IImmutableDeque{T}"/> that contains all the elements of this deque, except for the rightmost one</returns>
        /// <remarks>
        /// The cost of this operation varies depending on the deque size; but the amortized cost is O(1).
        /// </remarks>
        public IImmutableDeque<T> DequeueRight()
        {
            if (_right.Size > 1)
                return new ImmutableDeque<T>(_left, _middle, _right.DequeueRight());
            if (!_middle.IsEmpty)
                return new ImmutableDeque<T>(_left, _middle.DequeueRight(), _middle.Right);
            if (_left.Size > 1)
                return new ImmutableDeque<T>(_left.DequeueRight(), _middle, new One(_left.Right));
            return new SingleDeque(_left.Right);
        }


        /// <summary>
        /// Concatenates the specified deque to the right of this one.
        /// </summary>
        /// <param name="other">The other deque</param>
        /// <returns></returns>
        public IImmutableDeque<T> Concat(IImmutableDeque<T> other)
        {
            if (other.IsEmpty)
                return this;
            if (other is SingleDeque single)
                return EnqueueRight(single.item);
            // ok, now we're having at least two items in the other deque, and at least two items in our own deque.
            // we need to concatenate this._middle, this._right, other._left, and other._middle.
            // essentially, everything depends on (this._right.Size + other._left.Size) % 3
            if (other is ImmutableDeque<T> deque)
            {
                return new ImmutableDeque<T>(_left, 
                    _middle.EnqueueRight(_right).EnqueueRight(deque._left).Concat(deque._middle), 
                    deque._right);

            }
            // fallback: rare case where we've faced a foreign deque
            return this.AddRange(other);
        }

        /// <summary>
        /// Returns a new queue with all the elements removed.
        /// </summary>
        /// <returns>An empty immutable queue.</returns>
        public IImmutableDeque<T> Clear() => Empty;


        /// <summary>
        /// Peeks the leftmost element of the deque
        /// </summary>
        public T Left => _left.Left;
        /// <summary>
        /// Peeks the rightmost element of the deque
        /// </summary>
        public T Right => _right.Right;
        #endregion
    }
}
