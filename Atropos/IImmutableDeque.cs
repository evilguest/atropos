using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Atropos
{
    /// <summary>
    /// Represents an immutable Deque - i.e. the two-ended queue that supports push/pop operations from both ends with an amortized cost ot O(1) per operation.
    /// </summary>
    /// <typeparam name="T">The type of the Deque elements</typeparam>
    public interface IImmutableDeque<T>: IImmutableQueue<T>
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
        /// Removes one element from deque's left.
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
        /// <summary>
        /// Concatenates two deques together.
        /// </summary>
        /// <param name="right">The deque to concatenate to the right</param>
        /// <returns></returns>
        IImmutableDeque<T> Concat(IImmutableDeque<T> right);
        /// <summary>
        /// Returns a new immutable deque with the same element type as this one, but empty
        /// </summary>
        /// <returns>A new immutable deque with the same element type as this one, but empty</returns>
        new IImmutableDeque<T> Clear();
    }
}
