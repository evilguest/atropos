using System;
using System.Collections.Generic;
using System.Text;

namespace Atropos
{
    /// <summary>
    /// Represents an immutable Deque - i.e. the two-ended queue that supports push/pop operations from both ends with an amortized cost ot O(1) per operation.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IImmutableDeque<T>
    {
        T PeekLeft();
        T PeekRight();
        IImmutableDeque<T> EnqueueLeft(T value);
        IImmutableDeque<T> EnqueueRight(T value);
        IImmutableDeque<T> DequeueLeft();
        IImmutableDeque<T> DequeueRight();
        //IImmutableDeque<T> Concat(IImmutableDeque<T> right); 
        bool IsEmpty { get; }
    }

    public sealed partial class ImmutableDeque<T> : IImmutableDeque<T>
    {

        private static readonly IImmutableDeque<T> empty = new EmptyDeque();
        public static IImmutableDeque<T> Empty => empty;

        public bool IsEmpty => false;

        private ImmutableDeque(Dequelette left, IImmutableDeque<Dequelette> middle, Dequelette right) 
            => (_left, _middle, _right) = (left, middle, right);

        private readonly Dequelette _left;
        private readonly IImmutableDeque<Dequelette> _middle;
        private readonly Dequelette _right;

        public IImmutableDeque<T> EnqueueLeft(T value)
            => !_left.Full
                ? new ImmutableDeque<T>(_left.EnqueueLeft(value), _middle, _right)
                : new ImmutableDeque<T>(
                    new Two(value, _left.PeekLeft()),
                    _middle.EnqueueLeft(_left.DequeueLeft()),
                    _right);
        public IImmutableDeque<T> EnqueueRight(T value)
            => !_right.Full
                ? new ImmutableDeque<T>(_left, _middle, _right.EnqueueRight(value))
                : new ImmutableDeque<T>(
                    _left,
                    _middle.EnqueueRight(_right.DequeueRight()),
                    new Two(_right.PeekRight(), value));
        
        public IImmutableDeque<T> DequeueLeft()
        {
            if (_left.Size > 1)
                return new ImmutableDeque<T>(_left.DequeueLeft(), _middle, _right);
            if (!_middle.IsEmpty)
                return new ImmutableDeque<T>(_middle.PeekLeft(), _middle.DequeueLeft(), _right);
            if (_right.Size > 1)
                return new ImmutableDeque<T>(new One(_right.PeekLeft()), _middle, _right.DequeueLeft());
            return new SingleDeque(_right.PeekLeft());
        }
        public IImmutableDeque<T> DequeueRight()
        {
            if (_right.Size > 1)
                return new ImmutableDeque<T>(_left, _middle, _right.DequeueRight());
            if (!_middle.IsEmpty)
                return new ImmutableDeque<T>(_left, _middle.DequeueRight(), _middle.PeekRight());
            if (_left.Size > 1)
                return new ImmutableDeque<T>(_left.DequeueRight(), _middle, new One(_left.PeekRight()));
            return new SingleDeque(_left.PeekRight());
        }
        public T PeekLeft() => _left.PeekLeft();
        public T PeekRight() => _right.PeekRight();
    }
}
