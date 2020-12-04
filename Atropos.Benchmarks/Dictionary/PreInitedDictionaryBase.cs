using System;
using System.Collections.Generic;
using System.Linq;

using BenchmarkDotNet.Attributes;

using TunnelVisionLabs.Collections.Trees.Immutable;

namespace Atropos.Benchmarks.Dictionary
{
    public abstract class PreInitedDictionaryBase<TKey, TValue, R>: DictionaryBase<TKey, TValue, R>
        where TKey:IComparable<TKey>
    {
        private readonly Converter<int, TKey> _keyConverter;
        private readonly Converter<int, TValue> _valueConverter;

        public PreInitedDictionaryBase(Converter<int, TKey> keyConverter, Converter<int, TValue> valueConverter)
        {
            _keyConverter = keyConverter ?? throw new ArgumentNullException(nameof(keyConverter));
            _valueConverter = valueConverter ?? throw new ArgumentNullException(nameof(valueConverter));
        }
        [GlobalSetup]
        public void Initialize()
        {
            var pairs = from i in Enumerable.Range(0, Size) select KeyValuePair.Create(_keyConverter(i), _valueConverter(i));
            _A = new ImmutableDictionary<TKey, TValue>().AddRange(pairs);
            _C = System.Collections.Immutable.ImmutableDictionary.CreateRange(pairs);
            _T = ImmutableTreeDictionary.CreateRange(pairs);
        }
    }

    public abstract class PreInitedDictionaryBaseIntString<R> : PreInitedDictionaryBase<int, string, R>
    {
        public PreInitedDictionaryBaseIntString() : base(i => i, i => i.ToString()) { }

        [Params(1000)]
        public int Repetitions { get; set; } = 10;
    }

}
