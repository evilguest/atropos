### [Atropos](Atropos.md 'Atropos')
## ImmutableDeque&lt;T&gt; Class
An efficient implementation of the [IImmutableDeque&lt;T&gt;](IImmutableDeque_T_.md 'Atropos.IImmutableDeque&lt;T&gt;') based on the Eric Lippert's deque, which is based on the Hughes lists.  
See also https://docs.microsoft.com/en-us/archive/blogs/ericlippert/immutability-in-c-part-eleven-a-working-double-ended-queue  
```csharp
public sealed class ImmutableDeque<T> :
Atropos.IImmutableDeque<T>,
System.Collections.Immutable.IImmutableQueue<T>,
System.Collections.Generic.IEnumerable<T>,
System.Collections.IEnumerable
```
#### Type parameters
<a name='Atropos_ImmutableDeque_T__T'></a>
`T`  
The type of deque elements
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ImmutableDeque&lt;T&gt;  

Implements [Atropos.IImmutableDeque&lt;](IImmutableDeque_T_.md 'Atropos.IImmutableDeque&lt;T&gt;')[T](ImmutableDeque_T_.md#Atropos_ImmutableDeque_T__T 'Atropos.ImmutableDeque&lt;T&gt;.T')[&gt;](IImmutableDeque_T_.md 'Atropos.IImmutableDeque&lt;T&gt;'), [System.Collections.Immutable.IImmutableQueue&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Immutable.IImmutableQueue-1 'System.Collections.Immutable.IImmutableQueue`1')[T](ImmutableDeque_T_.md#Atropos_ImmutableDeque_T__T 'Atropos.ImmutableDeque&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Immutable.IImmutableQueue-1 'System.Collections.Immutable.IImmutableQueue`1'), [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](ImmutableDeque_T_.md#Atropos_ImmutableDeque_T__T 'Atropos.ImmutableDeque&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1'), [System.Collections.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable 'System.Collections.IEnumerable')  

| Properties | |
| :--- | :--- |
| [Empty](ImmutableDeque_T__Empty.md 'Atropos.ImmutableDeque&lt;T&gt;.Empty') | An empty deque of [T](ImmutableDeque_T_.md#Atropos_ImmutableDeque_T__T 'Atropos.ImmutableDeque&lt;T&gt;.T') |
| [IsEmpty](ImmutableDeque_T__IsEmpty.md 'Atropos.ImmutableDeque&lt;T&gt;.IsEmpty') | Implements [System.Collections.Immutable.IImmutableQueue&lt;&gt;.IsEmpty](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Immutable.IImmutableQueue-1.IsEmpty 'System.Collections.Immutable.IImmutableQueue`1.IsEmpty'). Always false for this class - we have a separate internal class for an empty deque.<br/> |

| Methods | |
| :--- | :--- |
| [Clear()](ImmutableDeque_T__Clear().md 'Atropos.ImmutableDeque&lt;T&gt;.Clear()') | Returns a new queue with all the elements removed.<br/> |
| [Concat(IImmutableDeque&lt;T&gt;)](ImmutableDeque_T__Concat(IImmutableDeque_T_).md 'Atropos.ImmutableDeque&lt;T&gt;.Concat(Atropos.IImmutableDeque&lt;T&gt;)') | Concatenates the specified deque to the right of this one.<br/> |
| [Dequeue()](ImmutableDeque_T__Dequeue().md 'Atropos.ImmutableDeque&lt;T&gt;.Dequeue()') | Implements the [System.Collections.Immutable.IImmutableQueue&lt;&gt;.Dequeue](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Immutable.IImmutableQueue-1.Dequeue 'System.Collections.Immutable.IImmutableQueue`1.Dequeue'), synonym for [DequeueLeft()](IImmutableDeque_T__DequeueLeft().md 'Atropos.IImmutableDeque&lt;T&gt;.DequeueLeft()') |
| [DequeueLeft()](ImmutableDeque_T__DequeueLeft().md 'Atropos.ImmutableDeque&lt;T&gt;.DequeueLeft()') | Removes one element from deque's left<br/> |
| [DequeueRight()](ImmutableDeque_T__DequeueRight().md 'Atropos.ImmutableDeque&lt;T&gt;.DequeueRight()') | Removes one element from deque's right<br/> |
| [Enqueue(T)](ImmutableDeque_T__Enqueue(T).md 'Atropos.ImmutableDeque&lt;T&gt;.Enqueue(T)') | Implements the [System.Collections.Immutable.ImmutableQueue&lt;&gt;.Enqueue(@0)](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Immutable.ImmutableQueue-1.Enqueue#System_Collections_Immutable_ImmutableQueue_1_Enqueue__0_ 'System.Collections.Immutable.ImmutableQueue`1.Enqueue(`0)'), synonym for [EnqueueRight(T)](IImmutableDeque_T__EnqueueRight(T).md 'Atropos.IImmutableDeque&lt;T&gt;.EnqueueRight(T)') |
| [EnqueueLeft(T)](ImmutableDeque_T__EnqueueLeft(T).md 'Atropos.ImmutableDeque&lt;T&gt;.EnqueueLeft(T)') | Enqueues the specified element to the left of the deque<br/> |
| [EnqueueRight(T)](ImmutableDeque_T__EnqueueRight(T).md 'Atropos.ImmutableDeque&lt;T&gt;.EnqueueRight(T)') | Enqueues the specified element to the right of the deque<br/> |
| [GetEnumerator()](ImmutableDeque_T__GetEnumerator().md 'Atropos.ImmutableDeque&lt;T&gt;.GetEnumerator()') | Traverses this deque from left to right<br/> |
| [Peek()](ImmutableDeque_T__Peek().md 'Atropos.ImmutableDeque&lt;T&gt;.Peek()') | Peeks the element on the left of the queue without removing it<br/> |
| [PeekLeft()](ImmutableDeque_T__PeekLeft().md 'Atropos.ImmutableDeque&lt;T&gt;.PeekLeft()') | Peeks the leftmost element of the deque<br/> |
| [PeekRight()](ImmutableDeque_T__PeekRight().md 'Atropos.ImmutableDeque&lt;T&gt;.PeekRight()') | Peeks the rightmost element of the deque<br/> |
