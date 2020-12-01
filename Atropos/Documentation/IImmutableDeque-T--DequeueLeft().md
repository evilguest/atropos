### [Atropos](./Atropos.md 'Atropos').[IImmutableDeque&lt;T&gt;](./IImmutableDeque-T-.md 'Atropos.IImmutableDeque&lt;T&gt;')
## IImmutableDeque&lt;T&gt;.DequeueLeft() Method
Removes one element from deque's left.  
```csharp
Atropos.IImmutableDeque<T> DequeueLeft();
```
#### Returns
[Atropos.IImmutableDeque&lt;](./IImmutableDeque-T-.md 'Atropos.IImmutableDeque&lt;T&gt;')[T](./IImmutableDeque-T-.md#Atropos-IImmutableDeque-T--T 'Atropos.IImmutableDeque&lt;T&gt;.T')[&gt;](./IImmutableDeque-T-.md 'Atropos.IImmutableDeque&lt;T&gt;')  
A new [IImmutableDeque&lt;T&gt;](./IImmutableDeque-T-.md 'Atropos.IImmutableDeque&lt;T&gt;') that contains all the elements of this deque, except for the leftmost one  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Thrown when the deque is empty  
