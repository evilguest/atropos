### [Atropos](./Atropos.md 'Atropos')
## ImmutableDeque&lt;T&gt; Class
An efficient implementation of the [IImmutableDeque&lt;T&gt;](./IImmutableDeque-T-.md 'Atropos.IImmutableDeque&lt;T&gt;') based on the Eric Lippert's deque, which is based on the Hughes lists.  
See also https://docs.microsoft.com/en-us/archive/blogs/ericlippert/immutability-in-c-part-eleven-a-working-double-ended-queue  
```csharp
public sealed class ImmutableDeque<T> :
IImmutableDeque<T>,
IImmutableQueue<T>,
IEnumerable<T>,
IEnumerable
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ImmutableDeque&lt;T&gt;  

Implements [Atropos.IImmutableDeque&lt;](./IImmutableDeque-T-.md 'Atropos.IImmutableDeque&lt;T&gt;')[T](#Atropos-ImmutableDeque-T--T 'Atropos.ImmutableDeque&lt;T&gt;.T')[&gt;](./IImmutableDeque-T-.md 'Atropos.IImmutableDeque&lt;T&gt;'), [System.Collections.Immutable.IImmutableQueue&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Immutable.IImmutableQueue-1 'System.Collections.Immutable.IImmutableQueue`1')[T](#Atropos-ImmutableDeque-T--T 'Atropos.ImmutableDeque&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Immutable.IImmutableQueue-1 'System.Collections.Immutable.IImmutableQueue`1'), [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](#Atropos-ImmutableDeque-T--T 'Atropos.ImmutableDeque&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1'), [System.Collections.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable 'System.Collections.IEnumerable')  
#### Type parameters
<a name='Atropos-ImmutableDeque-T--T'></a>
`T`  
The type of deque elements  
  
### Properties
- [Empty](./ImmutableDeque-T--Empty.md 'Atropos.ImmutableDeque&lt;T&gt;.Empty')
- [IsEmpty](./ImmutableDeque-T--IsEmpty.md 'Atropos.ImmutableDeque&lt;T&gt;.IsEmpty')
- [Right](./ImmutableDeque-T--Right.md 'Atropos.ImmutableDeque&lt;T&gt;.Right')
### Methods
- [Clear()](./ImmutableDeque-T--Clear().md 'Atropos.ImmutableDeque&lt;T&gt;.Clear()')
- [Concat(Atropos.IImmutableDeque&lt;T&gt;)](./ImmutableDeque-T--Concat(IImmutableDeque-T-).md 'Atropos.ImmutableDeque&lt;T&gt;.Concat(Atropos.IImmutableDeque&lt;T&gt;)')
- [Dequeue()](./ImmutableDeque-T--Dequeue().md 'Atropos.ImmutableDeque&lt;T&gt;.Dequeue()')
- [DequeueLeft()](./ImmutableDeque-T--DequeueLeft().md 'Atropos.ImmutableDeque&lt;T&gt;.DequeueLeft()')
- [DequeueRight()](./ImmutableDeque-T--DequeueRight().md 'Atropos.ImmutableDeque&lt;T&gt;.DequeueRight()')
- [Enqueue(T)](./ImmutableDeque-T--Enqueue(T).md 'Atropos.ImmutableDeque&lt;T&gt;.Enqueue(T)')
- [EnqueueLeft(T)](./ImmutableDeque-T--EnqueueLeft(T).md 'Atropos.ImmutableDeque&lt;T&gt;.EnqueueLeft(T)')
- [EnqueueRight(T)](./ImmutableDeque-T--EnqueueRight(T).md 'Atropos.ImmutableDeque&lt;T&gt;.EnqueueRight(T)')
- [GetEnumerator()](./ImmutableDeque-T--GetEnumerator().md 'Atropos.ImmutableDeque&lt;T&gt;.GetEnumerator()')
- [Peek()](./ImmutableDeque-T--Peek().md 'Atropos.ImmutableDeque&lt;T&gt;.Peek()')
- [PeekLeft()](./ImmutableDeque-T--PeekLeft().md 'Atropos.ImmutableDeque&lt;T&gt;.PeekLeft()')
