using BenchmarkDotNet.Attributes;
using System.Collections.Immutable;

namespace Atropos.Benchmarks.List
{
    public class Add: ImmutableListBenchmarkBase
    {
        [Benchmark]
        public IImmutableList<int> Atropos()
            => _Alist.Add(50);

        [Benchmark(Baseline = true)]
        public IImmutableList<int> Official()
            => _Clist.Add(50);

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
