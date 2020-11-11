# atropos
The immutable (persistent) data structures for .Net.
See the [Documentation](./Atropos/Atropos.md) for more detail
## Project overview
Atropos is an attempt to improve over the default implementation of the immutable collections offered by System.Collections.Immutable.
The following collections are provided:
1. ImmutableList<T> - the immutable list of T elements intended to support fast operations for accessing and modifying the element by index. I.e. this[int] and Set(int, T) are supposed 
to be executed within O(Log(Count)) with sufficiently large logaritm base. Insertions/Removals and list splits/merges are supposed to also work with O(Log(Count)) asymptotics.
*Note*: immutable arrays that have this[index] done with O(1) time perform much worse at modifications. Therefore the choice is made in favor of the B+ -tree implementation.
2. ImmutableDictionary<K, T> - the immutable dictionary. Optimized for acessing and modifying the values by key. 
3. ImmutableDoubleList<T> - the immutable 2-linked list. Optimized for fast O(1) insertion/update of the list, and bidirectional traversing.

## Authors
1. Anton Zlygostev a.zlygostev@g.nsu.ru - ImmutableList<T> and ImmutableDictionary<K, T>.
2. Dmitry Seleznev <d.seleznev6@g.nsu.ru> - ImmutableDoubleList<T>

## Calendar plan

| # | Phase | ETA (DMY) |
| - | ----- | --- :|
| 1 | Initial implementation (basic functions) | 20.11.2020 |
| 2 | Unit test coverage | 27.11.2020
| 3 | Extended functions (Merge, Split, mass-initialization, etc) | 4.12.2020 |
| 4 | Benchmarks | 11.12.2020 |
| 5 | Performance optimizations | 25.12.2020 |