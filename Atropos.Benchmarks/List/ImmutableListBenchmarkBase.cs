using BenchmarkDotNet.Attributes;
using System.Linq;

using SImmutableList = System.Collections.Immutable.ImmutableList;
using SImmutableListInt = System.Collections.Immutable.ImmutableList<int>;

namespace Atropos.Benchmarks.List
{
    //[InProcess]
    //[RPlotExporter]
    [MemoryDiagnoser]
    public abstract class ImmutableListBenchmarkBase
    {
        protected ImmutableList<int> _Alist;
        protected SImmutableListInt _Clist;
        //private List<int> _Llist;
        [GlobalSetup]
        public virtual void Initialize()
        {
            _Alist = ImmutableList<int>.Empty.AddRange(Enumerable.Range(0, Size));
            _Clist = SImmutableList.CreateRange(Enumerable.Range(0, Size));
            //_Llist = new List<int>(Enumerable.Repeat(42, Size));
        }
        [Params(
            //1 << 0, 
            //1 << 1, 
            1 << 4, 
            //1 << 8, 
            //1 << 12, 
            //1 << 14, 
            //1 << 16, 
            1 << 18
            //1 << 20,
            )]
        public int Size { get; set; } = 1;


    }
}
