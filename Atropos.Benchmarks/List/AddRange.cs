using BenchmarkDotNet.Attributes;
using System.Collections.Immutable;

namespace Atropos.Benchmarks.List
{
    public class AddRange: ImmutableListBenchmarkBase
    {
        private int[] _range = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, };
        [Benchmark]
        public IImmutableList<int> Atropos()
            => _Alist.AddRange(_range);

        [Benchmark(Baseline = true)]
        public IImmutableList<int> Official()
            => _Clist.AddRange(_range);

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
