using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Atropos.Benchmarks.List
{
    class Insert: ImmutableListBenchmarkBase
    {
        [Benchmark]
        public IImmutableList<int> Atropos()
            => _Alist.Insert(Size/2, 42);

        [Benchmark(Baseline = true)]
        public IImmutableList<int> Official()
            => _Clist.Insert(Size / 2, 42);


    }
}
