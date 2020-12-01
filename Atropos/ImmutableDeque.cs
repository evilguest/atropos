using System;
using System.Collections.Generic;
using System.Text;

namespace Atropos
{
    /// <summary>
    /// Represents an immutable Deque - i.e. the two-ended queue that supports push/pop operations from both ends with an amortized cost ot O(1) per operation.
    /// </summary>
    /// <typeparam name="T">The type of the Deque elements</typeparam>
    public interface IImmutableDeque<T>
    {
        /// <summary>
        /// Peeks the leftmost element in the deque
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the deque is empty</exception>
        T Left { get; }
        /// <summary>
        /// Peeks the rightmost element in the deque
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the deque is empty</exception>
        T Right { get; }

        /// <summary>
        /// Enqueues the specified element to the left of the deque
        /// </summary>
        /// <param name="value">The value to enqueue</param>
        /// <returns>A new <see cref="IImmutableDeque{T}"/> that contains the same elements as this deque, plus the <paramref name="value"/> pushed from the left</returns>
        IImmutableDeque<T> EnqueueLeft(T value);
        /// <summary>
        /// Enqueues the specified element to the right of the deque
        /// </summary>
        /// <param name="value">The value to enqueue</param>
        /// <returns>A new <see cref="IImmutableDeque{T}"/> that contains the same elements as this deque, plus the <paramref name="value"/> pushed from the right</returns>
        IImmutableDeque<T> EnqueueRight(T value);
        /// <summary>
        /// Removes one element from deque's left
        /// </summary>
        /// <returns>A new <see cref="IImmutableDeque{T}"/> that contains all the elements of this deque, except for the leftmost one</returns>
        /// <exception cref="InvalidOperationException">Thrown when the deque is empty</exception>
        IImmutableDeque<T> DequeueLeft();
        /// <summary>
        /// Removes one element from deque's right
        /// </summary>
        /// <returns>A new <see cref="IImmutableDeque{T}"/> that contains all the elements of this deque, except for the rightmost one</returns>
        /// <exception cref="InvalidOperationException">Thrown when the deque is empty</exception>
        IImmutableDeque<T> DequeueRight();
        //IImmutableDeque<T> Concat(IImmutableDeque<T> right); 
        /// <summary>
        /// Verifies if the deque is empty
        /// </summary>
        bool IsEmpty { get; }
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
        /// Peeks the leftmost element of the deque
        /// </summary>
        public T Left => _left.Left;
        /// <summary>
        /// Peeks the rightmost element of the deque
        /// </summary>
        public T Right => _right.Right;
    }
}
