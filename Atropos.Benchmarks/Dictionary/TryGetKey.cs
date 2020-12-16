using BenchmarkDotNet.Attributes;

namespace Atropos.Benchmarks.Dictionary
{
    public class TryGetKeyIntString : PreInitedDictionaryBaseIntString<bool>
    {
        [Benchmark]
        public override bool Atropos() => _A.TryGetKey(123, out _);

        [Benchmark]
        public override bool Official() => _C.TryGetKey(123, out _);

        [Benchmark]
        public override bool Tunnel() => _T.TryGetKey(123, out _);
    }
}
