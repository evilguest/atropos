using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Atropos
{

    public sealed partial class ImmutableDeque<T>
    {
        private sealed class SingleDeque : IImmutableDeque<T>
        {
            public readonly T item;
            public SingleDeque(T t) 
                => item = t;

            #region IEnumerable<T>
            public IEnumerator<T> GetEnumerator()
            {
                yield return item;
            }

            IEnumerator IEnumerable.GetEnumerator()
                => GetEnumerator();
            #endregion

            #region IImmutableQueue<T>
            public IImmutableQueue<T> Enqueue(T value)
                => EnqueueRight(value);
            public IImmutableQueue<T> Dequeue() => Empty;
            IImmutableQueue<T> IImmutableQueue<T>.Clear() => Empty;
            public T Peek() => PeekLeft();
            #endregion
            #region IImmutableDeque<T>
            public bool IsEmpty => false;
            public IImmutableDeque<T> EnqueueLeft(T value) 
                => new ImmutableDeque<T>(new One(value), ImmutableDeque<Dequelette>.Empty, new One(item));
            public IImmutableDeque<T> EnqueueRight(T value) 
                => new ImmutableDeque<T>(new One(item), ImmutableDeque<Dequelette>.Empty, new One(value));
            public IImmutableDeque<T> DequeueLeft() => Empty;
            public IImmutableDeque<T> DequeueRight() => Empty;


            public IImmutableDeque<T> Concat(IImmutableDeque<T> right) => right.EnqueueLeft(item);

            public IImmutableDeque<T> Clear() => Empty;

            public T PeekLeft()
            {
                return item;
            }

            public T PeekRight()
            {
                return item;
            }
            #endregion
        }
    }
}
