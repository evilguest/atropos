using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Atropos.Benchmarks.Deque
{
    public class AmortizedDequeueInt : PreInitedDequeBase<int, IImmutableQueue<int>>
    {
        public AmortizedDequeueInt() : base(i => i) { }

        public override IImmutableQueue<int> Atropos()
        {
            IImmutableQueue<int> a = _A;
            while (!a.IsEmpty)
                a = a.Dequeue();
            return a;
        }

        public override IImmutableQueue<int> Official()
        {
            IImmutableQueue<int> c = _C;
            while (!c.IsEmpty)
                c = c.Dequeue();
            return c;
        }

        public override IImmutableQueue<int> Tunnel()
        {
            IImmutableQueue<int> t = _T;
            while (!t.IsEmpty)
                t = t.Dequeue();
            return t;
        }
    }
}
