# Benchmarks
The goal of the Atropos project is to provide a reasonable performance.
In order to verify that the implementation is not utterly bad, we're comparing Atropos with the reference sources, mostly with the 
default implementation provided by the [System.Collections.Immutable] (https://docs.microsoft.com/dotnet/api/system.collections.immutable) library.
Some existing work by TunnelVisionLabs published at https://github.com/tunnelvisionlabs/dotnet-trees/ is based on the very same idea.
## [ImmutableList](../Atropos/Documentation/ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')
The immutable list is partially inspired by the [Use B+-trees instead of AVL trees for Immutable Collections](https://github.com/dotnet/runtime/issues/14477) proposal for the dotnet/runtime project.
We use the B+ tree with index page size and data page size = 16. When using the sequential population, this leads to the branch factor of approximately 8, providing a good base for the 
logarithm in the operations complexity asymptotics. 
The benchmarks below were taken with the different list sizes - see the [List/ImmutableListBenchmarkBase.cs](./List/ImmutableListBenchmarkBase.cs).
In most cases we used 1000 repetitions per invocation (to avoid jitter and noise related to the single operation), so the Y axis displays the single-op execution time measured in nanoseconds. 
### Index ([this[i]](../Atropos/Documentation/ImmutableList-T--this-int-.md) operation)
This is the most common operation for the lists. 
The results of running the benchmarks for the this[i] operation over the ImmutableList&lt;int&gt; are provided on the chart below. The Y axis is the single request time in nanoseconds; X axis is the collection size (with log2 scale).
Each test iteration involves 1000 requests at different indices to avoid measuring "lucky" points (AVL trees do store data at various levels, so traversal might take from 1 to log2(N) parent->child retrievals).
Note that each measure consists of this[i], integer addition, and increment - to make sure neither compiler no JIT does eliminate the access to the list elements. 
See the [List/Index.cs](./List/Index.cs) for more detail.
Anyway, the benchmark provides good enough insight on the comparative performance of the implementations for the various collection sizes.
![Index](Atropos.Benchmarks.List.Index.png)
Note how Official implementation does feature a gradual degradation somewhere between 256 and 1024 - most likely attributed to the cache effects.
Also note the stair-like behavior of the Atropos and TunnelVision implementation, reflecting their branch factors. 
### Add 
The [List/Add.cs](./List/Add.cs) benchmark measures the efficiency of a single-item insertions. 
![Index](Atropos.Benchmarks.List.Add.png)
### AddRange
There is a more efficient way to add a bunch of items to an immutable list - the idea is to keep the intermediate results mutable until it is time to return the list to the user.
This saves some (but not all) copying.
The [List/AddRange.cs](./List/AddRange.cs) benchmark adds 10 items to the list of a given size.
![Index](Atropos.Benchmarks.List.AddRange.png)
