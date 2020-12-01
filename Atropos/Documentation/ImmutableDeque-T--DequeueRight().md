### [Atropos](./Atropos.md 'Atropos').[ImmutableDeque&lt;T&gt;](./ImmutableDeque-T-.md 'Atropos.ImmutableDeque&lt;T&gt;')
## ImmutableDeque&lt;T&gt;.DequeueRight() Method
Removes one element from deque's right  
```csharp
public Atropos.IImmutableDeque<T> DequeueRight();
```
#### Returns
[Atropos.IImmutableDeque&lt;](./IImmutableDeque-T-.md 'Atropos.IImmutableDeque&lt;T&gt;')[T](./ImmutableDeque-T-.md#Atropos-ImmutableDeque-T--T 'Atropos.ImmutableDeque&lt;T&gt;.T')[&gt;](./IImmutableDeque-T-.md 'Atropos.IImmutableDeque&lt;T&gt;')  
A new [IImmutableDeque&lt;T&gt;](./IImmutableDeque-T-.md 'Atropos.IImmutableDeque&lt;T&gt;') that contains all the elements of this deque, except for the rightmost one  
### Remarks
The cost of this operation varies depending on the deque size; but the amortized cost is O(1).  
