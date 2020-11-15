using BenchmarkDotNet.Attributes;
using System.Linq;

using SImmutableList = System.Collections.Immutable.ImmutableList;
using SImmutableListInt = System.Collections.Immutable.ImmutableList<int>;

namespace Atropos.Benchmarks.List
{
    [InProcess]
    [RPlotExporter]
    [MemoryDiagnoser]
    public abstract class ImmutableListBenchmarkBase
    {
        protected ImmutableList<int> _Alist;
        protected SImmutableListInt _Clist;
        //private List<int> _Llist;
        [GlobalSetup]
        public virtual void Initialize()
        {
            _Alist = ImmutableList.Init(42, Size);
            _Clist = SImmutableList.CreateRange(Enumerable.Repeat(42, Size));
            //_Llist = new List<int>(Enumerable.Repeat(42, Size));
        }
        [Params(1, 2, 16, 256, 2048, 16384, 65536, 2 << 18, 2 << 20)]
        public int Size { get; set; } = 1;


    }
}
