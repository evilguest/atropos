![Build Status](https://github.com/evilguest/atropos/workflows/.NET%20Core/badge.svg?branch=main) 
# atropos
The immutable (persistent) data structures for .Net.
See the [Documentation](./Atropos/Documentation/Atropos.md) for more detail
## Project overview
Atropos is an attempt to improve over the default implementation of the immutable collections offered by System.Collections.Immutable.
The following collections are provided:
1. ImmutableList&lt;T&gt; - the immutable list of T elements intended to support fast operations for accessing and modifying the element by index. I.e. this[int] and Set(int, T) are supposed 
to be executed within O(Log(Count)) with sufficiently large logaritm base. Insertions/Removals and list splits/merges are supposed to also work with O(Log(Count)) asymptotics.
*Note*: immutable arrays that have this[index] done with O(1) time perform much worse at modifications. Therefore the choice is made in favor of the B+ -tree implementation.
2. ImmutableDictionary<K, T> - the immutable dictionary. Optimized for acessing and modifying the values by key. 
3. ImmutableDeque<T> - the immutable 2-linked list. Optimized for fast O(1) insertion/update of the list, and bidirectional traversing. Presumably, based on http://www.math.tau.ac.il/~haimk/adv-ds-2000/jacm-final.pdf

## Authors
1. Anton Zlygostev a.zlygostev@g.nsu.ru - ImmutableList&lt;T&gt; and ImmutableDeque.
2. Dmitry Seleznev <d.seleznev6@g.nsu.ru> - ImmutableDictionary<K, T> and ImmutableDeque.

## Calendar plan

| # | Phase | ETA (DMY) | Status |
| - | ----- | ---------:|:---:|
| 1 | Initial implementation (basic functions) | 20.11.2020 | Done |
| 2 | Unit test coverage | 27.11.2020 | [![Coverage Status](https://coveralls.io/repos/github/evilguest/atropos/badge.svg?branch=main)](https://coveralls.io/github/evilguest/atropos?branch=main)|
| 3 | Extended functions (Merge, Split, mass-initialization, etc) | 4.12.2020 | |
| 4 | Benchmarks | 11.12.2020 | |
| 5 | Performance optimizations | 25.12.2020 | |

## Benchmarks
### ImmutableList
### Index (this[i] operation)
This is the most common operation for the lists. There were two performance goals for this[i] operation within the Atropos project immutable list class:
1. Provide O(log(Count)) asymptotic, so it is not too bad for the reasonable list sizes 
2. Make sure it is no (consistently) worse than the default implementation of [System.Collections.Immutable.ImmutableList](https://docs.microsoft.com/dotnet/api/system.collections.immutable.immutablelist-1?view=net-5.0)
See also the [Use B+-trees instead of AVL trees for Immutable Collections](https://github.com/dotnet/runtime/issues/14477) proposal for the dotnet / runtime project.
Some existing work by TunnelVisionLabs published at https://github.com/tunnelvisionlabs/dotnet-trees/ is based on the very same idea, with a bit different implementation detail:
- they use polymorphic Index and Leaf nodes in the B+ tree, which slows down the tree traversal due to the virtual calls
- they use the node size = 8, which yields ~4 branch factor for the newly-initialized lists, serving a poor improvement over the factor 2 of AVL trees in the Microsoft implementation.
- they rely on the Array.BinarySearch when looking for the child node during the tree traversal, which is far from optimal for finging the upper bound with the array lengths employed.
The results of running the benchmarks for the this[i] operation over the ImmutableList&lt;int&gt; are provided on the chart below. The Y axis is the single request time in nanoseconds; X axis is the collection size (with log2 scale).
Each test iteration involves 1000 requests at different indices to avoid measuring "lucky" points (AVL trees do store data at various levels, so traversal might take from 1 to log2(N) parent->child retrievals).
Note that each measure consists of this[i], integer addition, and increment - to make sure neither compiler no JIT does eliminate the access to the list element. 
Anyway, the benchmark provides good enough insight on the comparative performance of the implementations for the various collection sizes.
![Index](./Atropos.Benchmarks/Atropos.Benchmarks.List.Index.png)
Note how Official implementation does feature a gradual degradation somewhere between 256 and 1024 - most likely attributed to the cache effects.
Also note the stair-like behavior of the Atropos and TunnelVision implementation, reflecting their branch factors. 