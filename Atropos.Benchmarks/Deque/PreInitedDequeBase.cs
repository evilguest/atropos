using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using TunnelVisionLabs.Collections.Trees.Immutable;

namespace Atropos.Benchmarks.Deque
{
    public abstract class PreInitedDequeBase<T, R>: PreInitedBase<T, IImmutableQueue<T>, IImmutableDeque<T>, ImmutableQueue<T>, ImmutableTreeQueue<T>, R>
    {
        protected PreInitedDequeBase(Converter<int, T> initConverter)
            : base(initConverter,
                 ImmutableDeque.CreateRange,
                 ImmutableQueue.CreateRange,
                 ImmutableTreeQueue.CreateRange)
        { }
        protected override IEnumerable<int> GetSizes() => DequeBase<T, R>.DequeSizes();
    }
}
