using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Atropos.Benchmarks
{
    public abstract class PreInitedBase<E, I, A, C, T, R> : BenchmarkBase<I, A, C, T, R>
        where A : I
        where C : I
        where T : I
    {
        private Converter<int, E> _initConverter;
        private readonly Converter<IEnumerable<E>, A> _constructorA;
        private readonly Converter<IEnumerable<E>, C> _constructorC;
        private readonly Converter<IEnumerable<E>, T> _constructorT;

        protected PreInitedBase(Converter<int, E> initConverter,
            Converter<IEnumerable<E>, A> constructorA,
            Converter<IEnumerable<E>, C> constructorC,
            Converter<IEnumerable<E>, T> constructorT)
        {
            _initConverter = initConverter ?? throw new ArgumentNullException(nameof(initConverter));
            _constructorA = constructorA ?? throw new ArgumentNullException(nameof(constructorA));
            _constructorC = constructorC ?? throw new ArgumentNullException(nameof(constructorC));
            _constructorT = constructorT ?? throw new ArgumentNullException(nameof(constructorT));
        }

        [GlobalSetup]
        public virtual void Initialize()
        {
            var r = from i in Enumerable.Range(0, Size) select _initConverter(i);

            _A = _constructorA(r);
            _C = _constructorC(r);
            _T = _constructorT(r);
        }
    }
}