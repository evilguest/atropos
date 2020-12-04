using BenchmarkDotNet.Attributes;
using System.Collections.Immutable;

namespace Atropos.Benchmarks.List
{
    public class AddRangeInt : PreInitedBaseIntCollection
    {
        private int[] _range = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, };

        [Benchmark]
        public override IImmutableList<int> Atropos() => _A.AddRange(_range);

        [Benchmark]
        public override IImmutableList<int> Official() => _C.AddRange(_range);

        [Benchmark]
        public override IImmutableList<int> Tunnel() => _T.AddRange(_range);
    }
}
