using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TunnelVisionLabs.Collections.Trees.Immutable;

namespace Atropos.Benchmarks.List
{
    public abstract class PreInitedListBase<T, R>: PreInitedBase<T, IImmutableList<T>, ImmutableList<T>, System.Collections.Immutable.ImmutableList<T>, ImmutableTreeList<T>, R>
    {
        protected PreInitedListBase(Converter<int, T> initConverter)
            : base(initConverter,
                 ImmutableList.CreateRange,
                 System.Collections.Immutable.ImmutableList.CreateRange,
                 ImmutableTreeList.CreateRange)
        { }
        protected override IEnumerable<int> GetSizes() => ListBase<T, R>.ListSizes();
    }
}
