using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TunnelVisionLabs.Collections.Trees.Immutable;

namespace Atropos.Benchmarks.Deque
{
    public abstract class DequeBase<T, R> : BenchmarkBase<IImmutableQueue<T>, ImmutableDeque<T>, ImmutableQueue<T>, ImmutableTreeQueue<T>, R>
    {
        public static IEnumerable<int> DequeSizes() => Enumerable.Range(1, 32);
    }
}
