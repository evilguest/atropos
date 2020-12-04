using BenchmarkDotNet.Attributes;
using System.Collections.Immutable;

namespace Atropos.Benchmarks.List
{
    public class AddInt : PreInitedBaseIntCollection
    {
        [Benchmark]
        public override IImmutableList<int> Atropos() => _A.Add(42);

        [Benchmark]
        public override IImmutableList<int> Official() => _C.Add(42);

        [Benchmark]
        public override IImmutableList<int> Tunnel() => _T.Add(42);
    }
}
