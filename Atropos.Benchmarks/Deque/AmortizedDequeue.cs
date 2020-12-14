using BenchmarkDotNet.Attributes;
using System.Collections.Immutable;

namespace Atropos.Benchmarks.Deque
{
    public class AmortizedDequeueInt : PreInitedDequeBase<int, IImmutableQueue<int>>
    {
        public AmortizedDequeueInt() : base(i => i) { }

        [Benchmark]
        public override IImmutableQueue<int> Atropos()
        {
            IImmutableQueue<int> a = _A;
            while (!a.IsEmpty)
                a = a.Dequeue();
            return a;
        }

        [Benchmark]
        public override IImmutableQueue<int> Official()
        {
            IImmutableQueue<int> c = _C;
            while (!c.IsEmpty)
                c = c.Dequeue();
            return c;
        }

        [Benchmark]
        public override IImmutableQueue<int> Tunnel()
        {
            IImmutableQueue<int> t = _T;
            while (!t.IsEmpty)
                t = t.Dequeue();
            return t;
        }
    }
}
