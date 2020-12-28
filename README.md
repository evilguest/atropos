![Build Status](https://github.com/evilguest/atropos/workflows/.NET%20Core/badge.svg?branch=main) 
# atropos
The immutable (persistent) data structures for .Net.
See the [Documentation](./Atropos/Documentation/Atropos.md) for more detail
## Project overview
> _Atropos (/ˈætrəpɒs/; Ancient Greek: Ἄτροπος "without turn"), in Greek mythology, was one of the three [Moirai] (https://en.wikipedia.org/wiki/Moirai), goddesses of fate and destiny.
>
> Atropos was the oldest of the Three Fates, and was known as "the Inflexible One. It was Atropos who ended the life of mortals by cutting their threads. She worked along with her two sisters, Clotho, who spun the thread, and Lachesis, who measured the length.
 
Atropos Projectis an attempt to improve over the default implementation of the persistent (immutable) collections offered by System.Collections.Immutable.
The following collections are provided:
1. ImmutableList&lt;T&gt; - the immutable list of T elements intended to support fast operations for accessing and modifying the element by index. I.e. this[int] and Set(int, T) are supposed 
to be executed within O(Log(Count)) with sufficiently large logaritm base. Insertions/Removals and list splits/merges are supposed to also work with O(Log(Count)) asymptotics.
*Note*: immutable arrays that have this[index] done with O(1) time perform much worse at modifications. Therefore the choice is made in favor of the B+ -tree implementation.
2. ImmutableDictionary<K, T> - the immutable dictionary. Optimized for acessing and modifying the values by key. 
3. ImmutableDeque<T> - the immutable 2-linked list. Optimized for fast O(1) insertion/update of the list, and bidirectional traversing. Based on the finger trees, inspired by the works of Eric Lippert.

## Authors
1. Anton Zlygostev a.zlygostev@g.nsu.ru - ImmutableList&lt;T&gt; and ImmutableDeque.
2. Dmitry Seleznev <d.seleznev6@g.nsu.ru> - ImmutableDictionary<K, T>

## Calendar plan

| # | Phase | ETA (DMY) | Status |
| - | ----- | ---------:|:---:|
| 1 | Initial implementation (basic functions) | 20.11.2020 | Done |
| 2 | Unit test coverage | 27.11.2020 | [![Coverage Status](https://coveralls.io/repos/github/evilguest/atropos/badge.svg?branch=main)](https://coveralls.io/github/evilguest/atropos?branch=main)|
| 3 | Extended functions (Merge, Split, mass-initialization, etc) | 4.12.2020 | Done |
| 4 | [Benchmarks](./Atropos.Benchmarks) | 11.12.2020 | Done |
| 5 | Performance optimizations | 25.12.2020 | Partially done |
