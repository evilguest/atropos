using System.Collections;
using System.Collections.Generic;

namespace Atropos
{

    public sealed partial class ImmutableDeque<T>
    {
        private sealed class SingleDeque : IImmutableDeque<T>
        {
            public SingleDeque(T t) 
                => item = t;
            public readonly T item;
            public bool IsEmpty => false;
            public IImmutableDeque<T> EnqueueLeft(T value) 
                => new ImmutableDeque<T>(new One(value), ImmutableDeque<Dequelette>.Empty, new One(item));
            public IImmutableDeque<T> EnqueueRight(T value) 
                => new ImmutableDeque<T>(new One(item), ImmutableDeque<Dequelette>.Empty, new One(value));
            public IImmutableDeque<T> DequeueLeft() => Empty;
            public IImmutableDeque<T> DequeueRight() => Empty;

            public IEnumerator<T> GetEnumerator()
            {
                yield return item;
            }

            IEnumerator IEnumerable.GetEnumerator()
                => GetEnumerator();

            public IImmutableDeque<T> Concat(IImmutableDeque<T> right) => right.EnqueueLeft(item);

            public T Left => item;
            public T Right => item;
        }
    }
}
