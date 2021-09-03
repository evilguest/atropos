### [Atropos](Atropos.md 'Atropos')
## IImmutableDeque&lt;T&gt; Interface
Represents an immutable Deque - i.e. the two-ended queue that supports push/pop operations from both ends with an amortized cost ot O(1) per operation.  
```csharp
public interface IImmutableDeque<T> :
System.Collections.Immutable.IImmutableQueue<T>,
System.Collections.Generic.IEnumerable<T>,
System.Collections.IEnumerable
```
#### Type parameters
<a name='Atropos_IImmutableDeque_T__T'></a>
`T`  
The type of the Deque elements
  

Derived  
&#8627; [ImmutableDeque&lt;T&gt;](ImmutableDeque_T_.md 'Atropos.ImmutableDeque&lt;T&gt;')  

Implements [System.Collections.Immutable.IImmutableQueue&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Immutable.IImmutableQueue-1 'System.Collections.Immutable.IImmutableQueue`1')[T](IImmutableDeque_T_.md#Atropos_IImmutableDeque_T__T 'Atropos.IImmutableDeque&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Immutable.IImmutableQueue-1 'System.Collections.Immutable.IImmutableQueue`1'), [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](IImmutableDeque_T_.md#Atropos_IImmutableDeque_T__T 'Atropos.IImmutableDeque&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1'), [System.Collections.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable 'System.Collections.IEnumerable')  

| Methods | |
| :--- | :--- |
| [Clear()](IImmutableDeque_T__Clear().md 'Atropos.IImmutableDeque&lt;T&gt;.Clear()') | Returns a new immutable deque with the same element type as this one, but empty<br/> |
| [Concat(IImmutableDeque&lt;T&gt;)](IImmutableDeque_T__Concat(IImmutableDeque_T_).md 'Atropos.IImmutableDeque&lt;T&gt;.Concat(Atropos.IImmutableDeque&lt;T&gt;)') | Concatenates two deques together.<br/> |
| [DequeueLeft()](IImmutableDeque_T__DequeueLeft().md 'Atropos.IImmutableDeque&lt;T&gt;.DequeueLeft()') | Removes one element from deque's left.<br/> |
| [DequeueRight()](IImmutableDeque_T__DequeueRight().md 'Atropos.IImmutableDeque&lt;T&gt;.DequeueRight()') | Removes one element from deque's right<br/> |
| [EnqueueLeft(T)](IImmutableDeque_T__EnqueueLeft(T).md 'Atropos.IImmutableDeque&lt;T&gt;.EnqueueLeft(T)') | Enqueues the specified element to the left of the deque<br/> |
| [EnqueueRight(T)](IImmutableDeque_T__EnqueueRight(T).md 'Atropos.IImmutableDeque&lt;T&gt;.EnqueueRight(T)') | Enqueues the specified element to the right of the deque<br/> |
| [PeekLeft()](IImmutableDeque_T__PeekLeft().md 'Atropos.IImmutableDeque&lt;T&gt;.PeekLeft()') | Peeks the leftmost element in the deque<br/> |
| [PeekRight()](IImmutableDeque_T__PeekRight().md 'Atropos.IImmutableDeque&lt;T&gt;.PeekRight()') | Peeks the rightmost element in the deque<br/> |
