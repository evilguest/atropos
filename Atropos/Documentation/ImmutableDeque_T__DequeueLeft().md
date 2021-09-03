### [Atropos](Atropos.md 'Atropos').[ImmutableDeque&lt;T&gt;](ImmutableDeque_T_.md 'Atropos.ImmutableDeque&lt;T&gt;')
## ImmutableDeque&lt;T&gt;.DequeueLeft() Method
Removes one element from deque's left  
```csharp
public Atropos.IImmutableDeque<T> DequeueLeft();
```
#### Returns
[Atropos.IImmutableDeque&lt;](IImmutableDeque_T_.md 'Atropos.IImmutableDeque&lt;T&gt;')[T](ImmutableDeque_T_.md#Atropos_ImmutableDeque_T__T 'Atropos.ImmutableDeque&lt;T&gt;.T')[&gt;](IImmutableDeque_T_.md 'Atropos.IImmutableDeque&lt;T&gt;')  
A new [IImmutableDeque&lt;T&gt;](IImmutableDeque_T_.md 'Atropos.IImmutableDeque&lt;T&gt;') that contains all the elements of this deque, except for the leftmost one

Implements [DequeueLeft()](IImmutableDeque_T__DequeueLeft().md 'Atropos.IImmutableDeque&lt;T&gt;.DequeueLeft()')  
### Remarks
The cost of this operation varies depending on the deque size; but the amortized cost is O(1).  
