using BenchmarkDotNet.Attributes;

namespace Atropos.Benchmarks.Dictionary
{
    public class TryGetValueIntString : PreInitedDictionaryBaseIntString<bool>
    {
        [Benchmark]
        public override bool Atropos() => _A.TryGetValue(12345, out _);

        [Benchmark]
        public override bool Official() => _C.TryGetValue(12345, out _);

        [Benchmark]
        public override bool Tunnel() => _T.TryGetValue(12345, out _);
    }
}
