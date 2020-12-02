using BenchmarkDotNet.Attributes;
using System.Collections.Immutable;

namespace Atropos.Benchmarks.List
{
    class Insert: ImmutableListBenchmarkBase
    {
        [Benchmark]
        public IImmutableList<int> Atropos()
        {
            var t = _Alist; 
            for (var i = 0; i < Repetitions; i++)
                t = _Alist.Insert(Size / 2, 42);
            return t;
        }

        [Benchmark(Baseline = true)]
        public IImmutableList<int> Official()
        {
            var t = _Clist;
            for (var i = 0; i < Repetitions; i++)
                t = _Clist.Insert(Size / 2, 42);
            return t;
        }


    }
}
