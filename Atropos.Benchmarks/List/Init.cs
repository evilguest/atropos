using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TunnelVisionLabs.Collections.Trees.Immutable;

namespace Atropos.Benchmarks.List
{
    public class InitInt : ListBase<int, IImmutableList<int>>
    {
        private IEnumerable<int> Range => Enumerable.Range(0, Size);
        [Benchmark]
        public override IImmutableList<int> Atropos() => ImmutableList.CreateRange(Range);
        [Benchmark]
        public override IImmutableList<int> Official() => System.Collections.Immutable.ImmutableList.CreateRange(Range);
        [Benchmark]
        public override IImmutableList<int> Tunnel() => ImmutableTreeList.CreateRange(Range);
    }
}
