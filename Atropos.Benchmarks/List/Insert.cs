using BenchmarkDotNet.Attributes;
using System.Collections.Immutable;

namespace Atropos.Benchmarks.List
{
    class InsertInt : PreInitedBaseIntCollection
    {
        [Benchmark]
        public override IImmutableList<int> Atropos() => _A.Insert(Size / 2, 42);
        [Benchmark]
        public override IImmutableList<int> Official() => _C.Insert(Size / 2, 42);
        [Benchmark]
        public override IImmutableList<int> Tunnel() => _C.Insert(Size / 2, 42);
    }
}
