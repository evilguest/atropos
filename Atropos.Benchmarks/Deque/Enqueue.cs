using BenchmarkDotNet.Attributes;
using System.Collections.Immutable;

namespace Atropos.Benchmarks.Deque
{
    public class EnqueueInt: PreInitedDequeBase<int, IImmutableQueue<int>>
    {
        public EnqueueInt() : base(i => i) { }
        [Benchmark]
        public override IImmutableQueue<int> Atropos() => _A.Enqueue(42);
        [Benchmark]
        public override IImmutableQueue<int> Official() => _C.Enqueue(42);
        [Benchmark]
        public override IImmutableQueue<int> Tunnel() => _T.Enqueue(42);

    }
}
