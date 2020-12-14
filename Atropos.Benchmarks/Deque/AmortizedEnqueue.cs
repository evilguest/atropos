using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TunnelVisionLabs.Collections.Trees.Immutable;

namespace Atropos.Benchmarks.Deque
{
    public class AmortizedEnqueueInt : DequeBase<int, IImmutableQueue<int>>
    {
        [Benchmark]
        public override IImmutableQueue<int> Atropos()
        {
            return ImmutableDeque.CreateRange(Enumerable.Range(0, Size));
        }

        [Benchmark]
        public override IImmutableQueue<int> Official()
        {
            return ImmutableQueue.CreateRange(Enumerable.Range(0, Size));
        }

        [Benchmark]
        public override IImmutableQueue<int> Tunnel()
        {
            return ImmutableTreeQueue.CreateRange(Enumerable.Range(0, Size));
        }

        protected override IEnumerable<int> GetSizes() => DequeBase<int, int>.DequeSizes();
    }
}
