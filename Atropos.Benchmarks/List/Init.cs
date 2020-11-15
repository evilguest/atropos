using BenchmarkDotNet.Attributes;
using System;

namespace Atropos.Benchmarks.List
{
    /* 
     * Commented out as Unfair benchmark.
     * 
    public class Init:ImmutableListBenchmarkBase
    {
        private int[] feed;
        public override void Initialize()
        {
            //base.Initialize(); we don't need to initialize this one
            feed = new int[Size];
            Array.Fill(feed, 42);
        }
        [Benchmark]
        public ImmutableList<int> Atropos()
            => ImmutableList.Init(42, Size);

        [Benchmark(Baseline = true)]
        public System.Collections.Immutable.IImmutableList<int> Official()
            => System.Collections.Immutable.ImmutableList.Create(feed);


    }
    */
}
