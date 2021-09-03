### [Atropos](Atropos.md 'Atropos').[ImmutableDeque&lt;T&gt;](ImmutableDeque_T_.md 'Atropos.ImmutableDeque&lt;T&gt;')
## ImmutableDeque&lt;T&gt;.EnqueueLeft(T) Method
Enqueues the specified element to the left of the deque  
```csharp
public Atropos.IImmutableDeque<T> EnqueueLeft(T value);
```
#### Parameters
<a name='Atropos_ImmutableDeque_T__EnqueueLeft(T)_value'></a>
`value` [T](ImmutableDeque_T_.md#Atropos_ImmutableDeque_T__T 'Atropos.ImmutableDeque&lt;T&gt;.T')  
The value to enqueue
  
#### Returns
[Atropos.IImmutableDeque&lt;](IImmutableDeque_T_.md 'Atropos.IImmutableDeque&lt;T&gt;')[T](ImmutableDeque_T_.md#Atropos_ImmutableDeque_T__T 'Atropos.ImmutableDeque&lt;T&gt;.T')[&gt;](IImmutableDeque_T_.md 'Atropos.IImmutableDeque&lt;T&gt;')  
A new [ImmutableDeque&lt;T&gt;](ImmutableDeque_T_.md 'Atropos.ImmutableDeque&lt;T&gt;') that contains the same elements as this deque, plus the [value](ImmutableDeque_T__EnqueueLeft(T).md#Atropos_ImmutableDeque_T__EnqueueLeft(T)_value 'Atropos.ImmutableDeque&lt;T&gt;.EnqueueLeft(T).value') pushed from the left

Implements [EnqueueLeft(T)](IImmutableDeque_T__EnqueueLeft(T).md 'Atropos.IImmutableDeque&lt;T&gt;.EnqueueLeft(T)')  
### Remarks
The cost of this operation varies depending on the deque size; but the amortized cost is O(1).  
