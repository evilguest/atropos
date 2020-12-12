using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Atropos
{

    public sealed partial class ImmutableDeque<T>
    {
        private sealed class EmptyDeque : IImmutableDeque<T>
        {
            private static readonly Exception _ioe = new InvalidOperationException("This deque is empty");
            public bool IsEmpty => true;
            public IImmutableQueue<T> Enqueue(T value) => new SingleDeque(value);
            public IImmutableDeque<T> EnqueueLeft(T value) => new SingleDeque(value);
            public IImmutableDeque<T> EnqueueRight(T value) => new SingleDeque(value);
            public IImmutableDeque<T> DequeueLeft() => throw _ioe;
            public IImmutableDeque<T> DequeueRight() => throw _ioe;
            public IImmutableQueue<T> Dequeue() => throw _ioe;

            public IEnumerator<T> GetEnumerator() 
                => Enumerable.Empty<T>().GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator()
                => GetEnumerator();
            public IImmutableDeque<T> Concat(IImmutableDeque<T> right)
                => right;
            public IImmutableDeque<T> Clear() => this;
            IImmutableQueue<T> IImmutableQueue<T>.Clear() => this;
            public T Peek() => throw _ioe;

            public T PeekLeft()
            {
                throw _ioe;
            }

            public T PeekRight()
            {
                throw _ioe;
            }
        }
    }
}
