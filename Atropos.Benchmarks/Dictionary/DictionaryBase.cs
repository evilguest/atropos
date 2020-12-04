using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TunnelVisionLabs.Collections.Trees.Immutable;

namespace Atropos.Benchmarks.Dictionary
{
    public abstract class DictionaryBase<TKey, TValue, R> 
        : BenchmarkBase<
            IImmutableDictionary<TKey, TValue>, 
            ImmutableDictionary<TKey, TValue>, 
            System.Collections.Immutable.ImmutableDictionary<TKey, TValue>, 
            ImmutableTreeDictionary<TKey, TValue>, R>
        where TKey: IComparable<TKey>
    {
        protected override IEnumerable<int> GetSizes()
            => DictionarySizes();
        public static IEnumerable<int> DictionarySizes()
        {
            foreach (var i in Enumerable.Range(1, 16))
            {
                var p = (1 << i);
                yield return p - p / (2 * i);
                if (i > 2)
                    yield return p + p / (2 * i);
            }
        }
    }
}
