using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;

namespace Atropos.Benchmarks.List
{
    //[EtwProfiler]
    public class Index: ImmutableListBenchmarkBase
    {
        [Benchmark]
        public int Atropos()
        {
            var s = 0;
            for(int i=0; i<Repetitions;i++)
                unchecked { s += _Alist[i % Size]; }
            return s;
        }

        [Benchmark(Baseline = true)]
        public int Official()
        {
            var s = 0;
            for (int i = 0; i < Repetitions; i++)
                unchecked { s += _Clist[i % Size]; }
            return s;
        }

        [Benchmark]
        public int Tunnel()
        {
            var s = 0;
            for(int i=0; i<Repetitions;i++)
                unchecked { s += _Tlist[i % Size]; }
            return s;
        }

        /*        [Benchmark()]
                public void Mutable()
                    => _Llist.Add(50);
                [IterationSetup]
                public void InitializeMutable()
                {
                    _Llist = new List<int>(Enumerable.Repeat(42, Size));
                }*/
    }
}
