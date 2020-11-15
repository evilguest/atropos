using BenchmarkDotNet.Attributes;

namespace Atropos.Benchmarks.List
{
    public class Index: ImmutableListBenchmarkBase
    {
        [Benchmark]
        public int Atropos()
            => _Alist[Size / 2];

        [Benchmark(Baseline = true)]
        public int Official()
            => _Clist[Size / 2];

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
