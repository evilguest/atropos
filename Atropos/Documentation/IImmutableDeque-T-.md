### [Atropos](./Atropos.md 'Atropos')
## IImmutableDeque&lt;T&gt; Interface
Represents an immutable Deque - i.e. the two-ended queue that supports push/pop operations from both ends with an amortized cost ot O(1) per operation.  
```csharp
public interface IImmutableDeque<T> :
IImmutableQueue<T>,
IEnumerable<T>,
IEnumerable
```
Derived  
&#8627; [ImmutableDeque&lt;T&gt;](./ImmutableDeque-T-.md 'Atropos.ImmutableDeque&lt;T&gt;')  

Implements [System.Collections.Immutable.IImmutableQueue&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Immutable.IImmutableQueue-1 'System.Collections.Immutable.IImmutableQueue`1')[T](#Atropos-IImmutableDeque-T--T 'Atropos.IImmutableDeque&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Immutable.IImmutableQueue-1 'System.Collections.Immutable.IImmutableQueue`1'), [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](#Atropos-IImmutableDeque-T--T 'Atropos.IImmutableDeque&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1'), [System.Collections.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable 'System.Collections.IEnumerable')  
#### Type parameters
<a name='Atropos-IImmutableDeque-T--T'></a>
`T`  
The type of the Deque elements  
  
### Properties
- [Right](./IImmutableDeque-T--Right.md 'Atropos.IImmutableDeque&lt;T&gt;.Right')
### Methods
- [Clear()](./IImmutableDeque-T--Clear().md 'Atropos.IImmutableDeque&lt;T&gt;.Clear()')
- [Concat(Atropos.IImmutableDeque&lt;T&gt;)](./IImmutableDeque-T--Concat(IImmutableDeque-T-).md 'Atropos.IImmutableDeque&lt;T&gt;.Concat(Atropos.IImmutableDeque&lt;T&gt;)')
- [DequeueLeft()](./IImmutableDeque-T--DequeueLeft().md 'Atropos.IImmutableDeque&lt;T&gt;.DequeueLeft()')
- [DequeueRight()](./IImmutableDeque-T--DequeueRight().md 'Atropos.IImmutableDeque&lt;T&gt;.DequeueRight()')
- [EnqueueLeft(T)](./IImmutableDeque-T--EnqueueLeft(T).md 'Atropos.IImmutableDeque&lt;T&gt;.EnqueueLeft(T)')
- [EnqueueRight(T)](./IImmutableDeque-T--EnqueueRight(T).md 'Atropos.IImmutableDeque&lt;T&gt;.EnqueueRight(T)')
- [PeekLeft()](./IImmutableDeque-T--PeekLeft().md 'Atropos.IImmutableDeque&lt;T&gt;.PeekLeft()')
