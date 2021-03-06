# Benchmarks
The goal of the Atropos project is to provide a reasonable performance.
In order to verify that the implementation is not utterly bad, we're comparing Atropos with the reference sources, mostly with the 
default implementation provided by the [System.Collections.Immutable] (https://docs.microsoft.com/dotnet/api/system.collections.immutable) library.
Some existing work by TunnelVisionLabs published at https://github.com/tunnelvisionlabs/dotnet-trees/ is based on the very same idea.
## [ImmutableList](../Atropos/Documentation/ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')
The immutable list is partially inspired by the [Use B+-trees instead of AVL trees for Immutable Collections](https://github.com/dotnet/runtime/issues/14477) proposal for the dotnet/runtime project.
We use the B+ tree with index page size and data page size = 16. When using the sequential population, this leads to the branch factor of approximately 8, providing a good base for the 
logarithm in the operations complexity asymptotics. 
The benchmarks below were taken with the different list sizes - see the [List/ImmutableListBenchmarkBase.cs](./List/ImmutableListBenchmarkBase.cs#L39).
In most cases we used 1000 repetitions per invocation (to avoid jitter and noise related to the single operation), so the Y axis displays the single-op execution time measured in nanoseconds. 
### Index ([this[i]](../Atropos/Documentation/ImmutableList-T--this-int-.md) operation)
This is the most common operation for the lists. 
The results of running the benchmarks for the this[i] operation over the ImmutableList&lt;int&gt; are provided on the chart below. The Y axis is the single request time in nanoseconds; X axis is the collection size (with log2 scale).
Each test iteration involves 1000 requests at different indices to avoid measuring "lucky" points (AVL trees do store data at various levels, so traversal might take from 1 to log2(N) parent->child retrievals).
Note that each measure consists of this[i], integer addition, and increment - to make sure neither compiler no JIT does eliminate the access to the list elements. 
See the [List/Index.cs](./List/Index.cs) for more detail.
Anyway, the benchmark provides good enough insight on the comparative performance of the implementations for the various collection sizes.
| Time (ns) | RAM consumption (bytes) | 
| - | - |
| ![Index Speed](Atropos.Benchmarks.List.IndexInt.png) | ![Index Size](Atropos.Benchmarks.List.IndexInt.alloc.png) | 

Note how Official implementation does feature a gradual degradation somewhere between 256 and 1024 - most likely attributed to the cache effects.
Also note the stair-like behavior of the Atropos and TunnelVision implementation, reflecting their branch factors.
### Init
This benchmark measures the time to init the list to a specified size, feeding an IEnumerable&lt;T&gt; into it one element by one.
| Time (ns) | RAM consumption (bytes) | 
| - | - |
| ![Init Speed](Atropos.Benchmarks.List.InitInt.png) | ![Init Size](Atropos.Benchmarks.List.InitInt.png) |
### Add 
The [List/Add.cs](./List/Add.cs) benchmark measures the efficiency of a single-item additions to the end of the list. 
| Time (ns) | RAM consumption (bytes) | 
| - | - |
| ![Index](Atropos.Benchmarks.List.AddInt.png) | ![Index](Atropos.Benchmarks.List.AddInt.alloc.png) | 
### Insert
The [List/Insert.cs](./List/Insert.cs) benchmark measures the efficiency of a single-item insertions into the middle of the list. 
We expect approximately the same behavior as for additions at the end.
| Time (ns) | RAM consumption (bytes) | 
| - | - |
| ![Insert](Atropos.Benchmarks.List.InsertInt.png) | ![Insert](Atropos.Benchmarks.List.InsertInt.alloc.png) |
### AddRange
There is a more efficient way to add a bunch of items to an immutable list - the idea is to keep the intermediate results mutable until it is time to return the list to the user.
This saves some (but not all) copying.
The [List/AddRange.cs](./List/AddRange.cs) benchmark adds 10 items to the list of a given size.
| Time (ns) | RAM consumption (bytes) | 
| - | - |
| ![AddRange](Atropos.Benchmarks.List.AddRangeInt.png) | ![AddRange](Atropos.Benchmarks.List.AddRangeInt.alloc.png) |
## [ImmutableDeque](../Atropos/Documentation/ImmutableDeque-T-.md 'Atropos.ImmutableDeque&lt;T&gt;')
The immutable deque is does extend the functionality of the System.Collections.ImmutableQueue by allowing enqueuing and dequeuing from both ends. 
Since the operations are perfectly symmetric, the benchmarks compare the behavior against the IImmutableQueue implementations offered by the "Official" code from .Net Core and the TunnelVision's ImmutableTreeQueue. Note that the latter does internally rely on the same IImmutableList discussed above, obviously counting on the B+-tree performance that covers the insertions-at-the-end and removals-at-the-start just as well as any other operations.
Our implementation does attempt to benefit from the fact that the deque is never accessed "in the middle"; so we could choose a different layout than the traditional tree, to improve the asymptotics of the enqueue/dequeue operations over O(log(Size)). This is possible via the finger trees described by Okasaki. 
Benchmarks for the tree operations are listed below.
A possible future performance improvement would be to consider a bit larger structures for Dequelette class, to benefit from the cache-friendly alignment. 
I.e. since each object in .Net contains a header of 12 bytes (8 bytes on x86), and the cache line size is 64 bytes, we should try fitting exactly 52/56 bytes of data, or 116/120 bytes if we're ready to spare 2 cache lines. 
52 bytes give us space for six 8-byte references + 4 bytes for int32 count; 56 bytes give us space for 13 4-byte references + 4 bytes for int32 count.
These seem to be the numbers to consider. Note that we'd need to adjust the layout for the value types that can take any number of bytes.
### Enqueue single element
The [Deque/EnqueueInt.cs](./Deque/Enqueue.cs) benchmark enqueues a single integer to the queue of the specified Size.
| Time (ns) | RAM consumption (bytes) | 
| - | - |
| ![Enqueue](Atropos.Benchmarks.Deque.EnqueueInt.png) | ![Enqueue](Atropos.Benchmarks.Deque.EnqueueInt.alloc.png) |
### Dequeue single element
The [Deque/DequeueInt.cs](./Deque/Dequeue.cs) benchmark dequeues a single element from the integer queue of the specified Size.
| Time (ns) | RAM consumption (bytes) | 
| - | - |
| ![DequeueSpeed](Atropos.Benchmarks.Deque.DequeueInt.png) | ![DequeueSize](Atropos.Benchmarks.Deque.DequeueInt.alloc.png) |
### Enqueue Size elements to an empty queue
The [Deque/AmortizedEnqueueInt.cs](./Deque/AmortizedEnqueueInt.cs) benchmark enqueues a single integer to the queue of the specified Size.
| Time (ns) | RAM consumption (bytes) | 
| - | - |
| ![Enqueue](Atropos.Benchmarks.Deque.AmortizedEnqueueInt.png) | ![Enqueue](Atropos.Benchmarks.Deque.AmortizedEnqueueInt.alloc.png) |
### Dequeue all elements from the queue of length Size
The [Deque/AmortizedDequeueInt.cs](./Deque/AmortizedDequeue.cs) benchmark dequeues a single element from the integer queue of the specified Size.
| Time (ns) | RAM consumption (bytes) | 
| - | - |
| ![DequeueSpeed](Atropos.Benchmarks.Deque.DequeueInt.png) | ![DequeueSize](Atropos.Benchmarks.Deque.DequeueInt.alloc.png) |

## [ImmutableDictionary](../Atropos/Documentation/ImmutableDictionary-TKey_TValue-.md 'Atropos.ImmutableDictionary&lt;T&gt;')
The ImmutableDictionary<TKey, TValue> type uses a balanced binary tree to represent the dictionary.
### Index ([this[key]](../Atropos/Documentation/ImmutableDictionary-TKey_TValue--this-TKey-.md) operation)
Through the use of a balanced binary tree getting value by key works with O(log(N)) complexity.
The [Dictionary/IndexIntString.cs](./Dictionary/Index.cs) benchmark getting string value by integer key.
| Time (ns) | RAM consumption (bytes) | 
| - | - |
| ![IndexSpeed](Atropos.Benchmarks.Dictionary.IndexIntString.png) | ![IndexSize](Atropos.Benchmarks.Dictionary.IndexIntString.alloc.png) |
### Add
After adding the key-value pair into the dictionary we check and balance tree if it needs.
The [Dictionary/Add.cs](./Dictionary/Add.cs) benchmark measures the efficiency of a single key-value pair insertions into the dictionary. 
| Time (ns) | RAM consumption (bytes) | 
| - | - |
| ![Add](Atropos.Benchmarks.Dictionary.AddIntString.png) | ![Add](Atropos.Benchmarks.Dictionary.AddIntString.alloc.png) |
### AddRange
The [Dictionary/AddRange.cs](./Dictionary/AddRange.cs) benchmark measures the efficiency of a range key-value pairs insertions into the dictionary. 
| Time (ns) | RAM consumption (bytes) | 
| - | - |
| ![AddRange](Atropos.Benchmarks.Dictionary.AddRangeIntString.png) | ![AddRange](Atropos.Benchmarks.Dictionary.AddRangeIntString.alloc.png) |
### SetItem 
The [Dictionary/Set.cs](./Dictionary/Set.cs) benchmark measures the efficiency of overwriting value with existing key or inserting new key-value pair into the dictionary. 
| Time (ns) | RAM consumption (bytes) | 
| - | - |
| ![SetItem](Atropos.Benchmarks.Dictionary.SetIntString.png) | ![SetItem](Atropos.Benchmarks.Dictionary.SetIntString.alloc.png) |
### TryGetKey
The [Dictionary/TryGetKey.cs](./Dictionary/TryGetKey.cs) benchmark measures the efficiency of getting key from the dictionary. 
| Time (ns) | RAM consumption (bytes) | 
| - | - |
| ![TryGetKey](Atropos.Benchmarks.Dictionary.TryGetKeyIntString.png) | ![TryGetKey](Atropos.Benchmarks.Dictionary.TryGetKeyIntString.alloc.png) |
### TryGetValue
The [Dictionary/TryGetValue.cs](./Dictionary/TryGetValue.cs) benchmark measures the efficiency of getting value from the dictionary. 
| Time (ns) | RAM consumption (bytes) | 
| - | - |
| ![TryGetValue](Atropos.Benchmarks.Dictionary.TryGetValueIntString.png) | ![TryGetValue](Atropos.Benchmarks.Dictionary.TryGetValueIntString.alloc.png) |