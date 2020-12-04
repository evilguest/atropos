using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace Atropos.Benchmarks
{
    [InProcess]
    [MemoryDiagnoser]
    public abstract class BenchmarkBase<I, A, C, T, R>
        where A: I
        where C: I
        where T: I
    {
        protected abstract IEnumerable<int> GetSizes();
        public IEnumerable<int> Sizes()
            => GetSizes();
        
        protected A _A;
        protected T _T;
        protected C _C;
       
        [ParamsSource(nameof(Sizes))]
        public int Size { get; set; } = 1;
        public abstract R Atropos();

        public abstract R Official();

        public abstract R Tunnel();
    }
}
