using System.Collections.Generic;
using System.Collections.Immutable;
using BenchmarkDotNet.Attributes;

namespace Atropos.Benchmarks.Dictionary
{
    public class AddRangeIntString : PreInitedDictionaryBaseIntString<IImmutableDictionary<int, string>>
    {
        private readonly KeyValuePair<int, string>[] _range =
        {
            new KeyValuePair<int, string>(123451, "123451"),
            new KeyValuePair<int, string>(123452, "123452"),
            new KeyValuePair<int, string>(123453, "123453"),
            new KeyValuePair<int, string>(123454, "123454"),
            new KeyValuePair<int, string>(123455, "123455"),
            new KeyValuePair<int, string>(123456, "123456"),
            new KeyValuePair<int, string>(123457, "123457"),
            new KeyValuePair<int, string>(123458, "123458"),
            new KeyValuePair<int, string>(123459, "123459"),
            new KeyValuePair<int, string>(1234510, "1234510"),
            new KeyValuePair<int, string>(1234511, "1234511"),
            new KeyValuePair<int, string>(1234512, "1234512"),
            new KeyValuePair<int, string>(1234513, "1234513"),
            new KeyValuePair<int, string>(1234514, "1234514"),
            new KeyValuePair<int, string>(1234515, "1234515")
        };

        [Benchmark]
        public override IImmutableDictionary<int, string> Atropos() => _A.AddRange(_range);

        [Benchmark]
        public override IImmutableDictionary<int, string> Official() => _C.AddRange(_range);

        [Benchmark]
        public override IImmutableDictionary<int, string> Tunnel() => _T.AddRange(_range);
    }
}
