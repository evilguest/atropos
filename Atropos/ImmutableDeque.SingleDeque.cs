namespace Atropos
{

    public sealed partial class ImmutableDeque<T>
    {
        private sealed class SingleDeque : IImmutableDeque<T>
        {
            public SingleDeque(T t) 
                => item = t;
            private readonly T item;
            public bool IsEmpty => false;
            public IImmutableDeque<T> EnqueueLeft(T value) 
                => new ImmutableDeque<T>(new One(value), ImmutableDeque<Dequelette>.Empty, new One(item));
            public IImmutableDeque<T> EnqueueRight(T value) 
                => new ImmutableDeque<T>(new One(item), ImmutableDeque<Dequelette>.Empty, new One(value));
            public IImmutableDeque<T> DequeueLeft() => Empty;
            public IImmutableDeque<T> DequeueRight() => Empty;
            public T Left => item;
            public T Right => item;
        }
    }
}
