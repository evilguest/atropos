using System.Collections.Immutable;

namespace Atropos.Benchmarks.List
{
    public abstract class PreInitedBaseInt<R>: PreInitedListBase<int, R>
    {
        public PreInitedBaseInt() : base(i => i) { }
    }

    public abstract class PreInitedBaseIntCollection : PreInitedBaseInt<IImmutableList<int>>
    { }
}
