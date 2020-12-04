using BenchmarkDotNet.Attributes;
using System.Collections.Immutable;

namespace Atropos.Benchmarks.Deque
{
    public class DequeueInt: PreInitedDequeBase<int, IImmutableQueue<int>>
    {
        public DequeueInt() : base(i => i) { }
        [Benchmark]
        public override IImmutableQueue<int> Atropos() => _A.Dequeue();
        [Benchmark(Baseline =true)]
        public override IImmutableQueue<int> Official() => _C.Dequeue();
        [Benchmark]
        public override IImmutableQueue<int> Tunnel() => _T.Dequeue();

    }
}
