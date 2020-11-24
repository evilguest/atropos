using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;

using SImmutableList = System.Collections.Immutable.ImmutableList;
using SImmutableListInt = System.Collections.Immutable.ImmutableList<int>;

namespace Atropos.Benchmarks.List
{
    [InProcess]
    //[RPlotExporter]
    [MemoryDiagnoser]
    public abstract class ImmutableListBenchmarkBase
    {
        public static IEnumerable<int> Sizes()
        {
            foreach (var i in Enumerable.Range(1, 16))
            {
                var p = (1 << i);
                yield return p - p / (2 * i);
                yield return p;
                if (i > 2)
                    yield return p + p / (2 * i);
            }
        }
        protected ImmutableList<int> _Alist;
        protected SImmutableListInt _Clist;
        protected TunnelVisionLabs.Collections.Trees.Immutable.ImmutableTreeList<int> _Tlist;
        //private List<int> _Llist;
        [GlobalSetup]
        public virtual void Initialize()
        {
            var r = Enumerable.Range(0, Size);
            _Alist = ImmutableList<int>.Empty.AddRange(r);
            _Clist = SImmutableList.CreateRange(r);
            _Tlist = TunnelVisionLabs.Collections.Trees.Immutable.ImmutableTreeList.CreateRange(r);
            //_Llist = new List<int>(Enumerable.Repeat(42, Size));
        }
        [ParamsSource(nameof(Sizes))]
        public int Size { get; set; } = 1;
        [Params(1000)]
        public int Repetitions { get; set; } = 10;


    }
}
