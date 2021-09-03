### [Atropos](Atropos.md 'Atropos').[ImmutableDeque&lt;T&gt;](ImmutableDeque_T_.md 'Atropos.ImmutableDeque&lt;T&gt;')
## ImmutableDeque&lt;T&gt;.DequeueRight() Method
Removes one element from deque's right  
```csharp
public Atropos.IImmutableDeque<T> DequeueRight();
```
#### Returns
[Atropos.IImmutableDeque&lt;](IImmutableDeque_T_.md 'Atropos.IImmutableDeque&lt;T&gt;')[T](ImmutableDeque_T_.md#Atropos_ImmutableDeque_T__T 'Atropos.ImmutableDeque&lt;T&gt;.T')[&gt;](IImmutableDeque_T_.md 'Atropos.IImmutableDeque&lt;T&gt;')  
A new [IImmutableDeque&lt;T&gt;](IImmutableDeque_T_.md 'Atropos.IImmutableDeque&lt;T&gt;') that contains all the elements of this deque, except for the rightmost one

Implements [DequeueRight()](IImmutableDeque_T__DequeueRight().md 'Atropos.IImmutableDeque&lt;T&gt;.DequeueRight()')  
### Remarks
The cost of this operation varies depending on the deque size; but the amortized cost is O(1).  
