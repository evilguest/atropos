### [Atropos](Atropos.md 'Atropos').[IImmutableDeque&lt;T&gt;](IImmutableDeque_T_.md 'Atropos.IImmutableDeque&lt;T&gt;')
## IImmutableDeque&lt;T&gt;.DequeueRight() Method
Removes one element from deque's right  
```csharp
Atropos.IImmutableDeque<T> DequeueRight();
```
#### Returns
[Atropos.IImmutableDeque&lt;](IImmutableDeque_T_.md 'Atropos.IImmutableDeque&lt;T&gt;')[T](IImmutableDeque_T_.md#Atropos_IImmutableDeque_T__T 'Atropos.IImmutableDeque&lt;T&gt;.T')[&gt;](IImmutableDeque_T_.md 'Atropos.IImmutableDeque&lt;T&gt;')  
A new [IImmutableDeque&lt;T&gt;](IImmutableDeque_T_.md 'Atropos.IImmutableDeque&lt;T&gt;') that contains all the elements of this deque, except for the rightmost one
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Thrown when the deque is empty
