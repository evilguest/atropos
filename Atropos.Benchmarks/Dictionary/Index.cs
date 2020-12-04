using BenchmarkDotNet.Attributes;
namespace Atropos.Benchmarks.Dictionary
{
    public class IndexIntString : PreInitedDictionaryBaseIntString<int>
    {
        [Benchmark]
        public override int Atropos()
        {
            var s = 0;
            for (int i = 0; i < Repetitions; i++)
                unchecked { s += _A[i % Size].Length; }
            return s;
        }

        [Benchmark]
        public override int Official()
        {
            var s = 0;
            for (int i = 0; i < Repetitions; i++)
                unchecked { s += _C[i % Size].Length; }
            return s;
        }

        [Benchmark]
        public override int Tunnel()
        {
            var s = 0;
            for (int i = 0; i < Repetitions; i++)
                unchecked { s += _T[i % Size].Length; }
            return s;
        }
    }
}
