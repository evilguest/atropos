using System;
using System.Collections;
using System.Collections.Generic;

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
        public static IImmutableDeque<T> InitRange<T>(IEnumerable<T> items)
        {
            if (items is null)
                throw new ArgumentNullException(nameof(items));

            if (items is IImmutableDeque<T> deque) return deque;

            var d = ImmutableDeque<T>.Empty;
            foreach (var item in items)
                d = d.EnqueueRight(item);
            return d;
        }
    }

    /// <summary>
    /// An efficient implementation of the <see cref="IImmutableDeque{T}"/> based on the Eric Lippert's deque, which is based on the Hughes lists.
    /// See also https://docs.microsoft.com/en-us/archive/blogs/ericlippert/immutability-in-c-part-eleven-a-working-double-ended-queue
    /// </summary>
    /// <typeparam name="T">The type of deque elements</typeparam>
    public sealed partial class ImmutableDeque<T> : IImmutableDeque<T>, IEnumerable<T>
    {

        private static readonly IImmutableDeque<T> empty = new EmptyDeque();
        /// <summary>
        /// An empty deque of <typeparamref name="T"/>
        /// </summary>
        public static IImmutableDeque<T> Empty => empty;

        /// <summary>
        /// Implements <see cref="IImmutableDeque{T}.IsEmpty"/>. Always false for this class - we have a separate internal class for an empty deque.
        /// </summary>
        public bool IsEmpty => false;

        private ImmutableDeque(Dequelette left, IImmutableDeque<Dequelette> middle, Dequelette right) 
            => (_left, _middle, _right) = (left, middle, right);

        private readonly Dequelette _left;
        private readonly IImmutableDeque<Dequelette> _middle;
        private readonly Dequelette _right;

        /// <summary>
        /// Enqueues the specified element to the left of the deque
        /// </summary>
        /// <param name="value">The value to enqueue</param>
        /// <returns>A new <see cref="ImmutableDeque{T}"/> that contains the same elements as this deque, plus the <paramref name="value"/> pushed from the left</returns>
        /// <remarks>
        /// The cost of this operation varies depending on the deque size; but the amortized cost is O(1).
        /// </remarks>
        public IImmutableDeque<T> EnqueueLeft(T value)
            => !_left.Full
                ? new ImmutableDeque<T>(_left.EnqueueLeft(value), _middle, _right)
                : new ImmutableDeque<T>(
                    new Two(value, _left.Left),
                    _middle.EnqueueLeft(_left.DequeueLeft()),
                    _right);
        /// <summary>
        /// Enqueues the specified element to the right of the deque
        /// </summary>
        /// <param name="value">The value to enqueue</param>
        /// <returns>A new <see cref="ImmutableDeque{T}"/> that contains the same elements as this deque, plus the <paramref name="value"/> pushed from the right</returns>
        /// <remarks>
        /// The cost of this operation varies depending on the deque size; but the amortized cost is O(1).
        /// </remarks>
        public IImmutableDeque<T> EnqueueRight(T value)
            => !_right.Full
                ? new ImmutableDeque<T>(_left, _middle, _right.EnqueueRight(value))
                : new ImmutableDeque<T>(
                    _left,
                    _middle.EnqueueRight(_right.DequeueRight()),
                    new Two(_right.Right, value));

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
                return (_right.Size, deque._left.Size) switch
                {
                    (1, 2) => new ImmutableDeque<T>(_left, _middle.EnqueueRight(deque._left.EnqueueLeft(_right.Right)).Concat(deque._middle), deque._right),
                    (1, 3) => null,
                    (1, 4) => null,
                    (2, 1) => new ImmutableDeque<T>(_left, _middle.EnqueueRight(_right.EnqueueRight(deque._left.Left)).Concat(deque._middle), deque._right),
                    (2, 2) => null,
                    (2, 4) => new ImmutableDeque<T>(_left, _middle.EnqueueRight(_right.EnqueueRight(deque._left.Left)).EnqueueRight(deque._left.DequeueLeft()).Concat(deque._middle), deque._right),
                    (3, 1) => null,
                    (3, 2) => null,
                    (3, 3) => new ImmutableDeque<T>(_left, _middle.EnqueueRight(_right).EnqueueRight(deque._left).Concat(deque._middle), deque._right),
                    (3, 4) => null,
                    (4, 1) => null,
                    (4, 2) => new ImmutableDeque<T>(_left, _middle.EnqueueRight(_right.DequeueRight()).EnqueueRight(deque._left.EnqueueLeft(_right.Right)).Concat(deque._middle), deque._right),
                    (4, 3) => null,
                    (4, 4) => null,
                    _ => null
                };
            }
            return null;
            /*            var left = _left;
            var middle = _middle;
            var right = _right;

            if (right.Full)
            {
                middle = middle.EnqueueRight(right.DequeueRight());
                right = new One(right.Right);
            }
            // ok, now right contains one, two, or three items;
            if (right.Size == 3)
            {
                middle = middle.EnqueueRight(right);
            }*/

        }

        /// <summary>
        /// Peeks the leftmost element of the deque
        /// </summary>
        public T Left => _left.Left;
        /// <summary>
        /// Peeks the rightmost element of the deque
        /// </summary>
        public T Right => _right.Right;
    }
}
