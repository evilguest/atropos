using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TunnelVisionLabs.Collections.Trees.Immutable;

namespace Atropos.Benchmarks.List
{
    public abstract class ListBase<T, R> : BenchmarkBase<IImmutableList<T>, ImmutableList<T>, System.Collections.Immutable.ImmutableList<T>, ImmutableTreeList<T>, R>
    {
        protected override IEnumerable<int> GetSizes()
            => ListSizes();
        public static IEnumerable<int> ListSizes()
        {
            foreach (var i in Enumerable.Range(1, 1)) //16
            {
                var p = (1 << i);
                yield return p - p / (2 * i);
                if (i > 2)
                    yield return p + p / (2 * i);
            }
        }
    }
}
