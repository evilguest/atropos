﻿using BenchmarkDotNet.Attributes;

namespace Atropos.Benchmarks.List
{
    public class IndexInt : PreInitedBaseInt<int>
    {
        [Benchmark]
        public override int Atropos()
        {
            var s = 0;
            for (int i = 0; i < Repetitions; i++)
                unchecked { s += _A[i % Size]; }
            return s;
        }

        [Benchmark]
        public override int Official()
        {
            var s = 0;
            for (int i = 0; i < Repetitions; i++)
                unchecked { s += _C[i % Size]; }
            return s;
        }

        [Benchmark]
        public override int Tunnel()
        {
            var s = 0;
            for(int i=0; i<Repetitions;i++)
                unchecked { s += _T[i % Size]; }
            return s;
        }

        [Params(1000)]
        public int Repetitions { get; set; } = 10;
    }
}
