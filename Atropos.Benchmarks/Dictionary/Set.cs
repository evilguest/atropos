using System.Collections.Immutable;

using BenchmarkDotNet.Attributes;

namespace Atropos.Benchmarks.Dictionary
{
    public class SetIntString : PreInitedDictionaryBaseIntString<IImmutableDictionary<int, string>>
    {
        [Benchmark]
        public override IImmutableDictionary<int, string> Atropos()
        {
            var a = _A;
            for(var i = 0; i<Repetitions;i++)
                a = a.SetItem(i, (i+1).ToString());
            return a;
        }


        [Benchmark]
        public override IImmutableDictionary<int, string> Official()
        {
            var c = _C;
            for (var i = 0; i < Repetitions; i++)
                c = c.SetItem(i, (i + 1).ToString());
            return c;
        }

        [Benchmark]
        public override IImmutableDictionary<int, string> Tunnel()
        {
            var t = _T;
            for (var i = 0; i < Repetitions; i++)
                t = t.SetItem(i, (i + 1).ToString());
            return t;
        }
    }
}
