### [Atropos](./Atropos.md 'Atropos').[ImmutableDeque&lt;T&gt;](./ImmutableDeque-T-.md 'Atropos.ImmutableDeque&lt;T&gt;')
## ImmutableDeque&lt;T&gt;.EnqueueRight(T) Method
Enqueues the specified element to the right of the deque  
```csharp
public Atropos.IImmutableDeque<T> EnqueueRight(T value);
```
#### Parameters
<a name='Atropos-ImmutableDeque-T--EnqueueRight(T)-value'></a>
`value` [T](./ImmutableDeque-T-.md#Atropos-ImmutableDeque-T--T 'Atropos.ImmutableDeque&lt;T&gt;.T')  
The value to enqueue  
  
#### Returns
[Atropos.IImmutableDeque&lt;](./IImmutableDeque-T-.md 'Atropos.IImmutableDeque&lt;T&gt;')[T](./ImmutableDeque-T-.md#Atropos-ImmutableDeque-T--T 'Atropos.ImmutableDeque&lt;T&gt;.T')[&gt;](./IImmutableDeque-T-.md 'Atropos.IImmutableDeque&lt;T&gt;')  
A new [ImmutableDeque&lt;T&gt;](./ImmutableDeque-T-.md 'Atropos.ImmutableDeque&lt;T&gt;') that contains the same elements as this deque, plus the [value](#Atropos-ImmutableDeque-T--EnqueueRight(T)-value 'Atropos.ImmutableDeque&lt;T&gt;.EnqueueRight(T).value') pushed from the right  
### Remarks
The cost of this operation varies depending on the deque size; but the amortized cost is O(1).  
