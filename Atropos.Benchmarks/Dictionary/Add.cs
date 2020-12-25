using System.Collections.Immutable;
using BenchmarkDotNet.Attributes;

namespace Atropos.Benchmarks.Dictionary
{
    public class AddIntString : PreInitedDictionaryBaseIntString<IImmutableDictionary<int, string>>
    {
        [Benchmark]
        public override IImmutableDictionary<int, string> Atropos() => _A.Add(42, "42");

        [Benchmark]
        public override IImmutableDictionary<int, string> Official() => _C.Add(42, "42");

        [Benchmark]
        public override IImmutableDictionary<int, string> Tunnel() => _T.Add(42, "42");
    }
}
