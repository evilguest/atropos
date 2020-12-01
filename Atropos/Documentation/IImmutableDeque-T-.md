### [Atropos](./Atropos.md 'Atropos')
## IImmutableDeque&lt;T&gt; Interface
Represents an immutable Deque - i.e. the two-ended queue that supports push/pop operations from both ends with an amortized cost ot O(1) per operation.  
```csharp
public interface IImmutableDeque<T>
```
Derived  
&#8627; [ImmutableDeque&lt;T&gt;](./ImmutableDeque-T-.md 'Atropos.ImmutableDeque&lt;T&gt;')  
#### Type parameters
<a name='Atropos-IImmutableDeque-T--T'></a>
`T`  
The type of the Deque elements  
  
### Properties
- [IsEmpty](./IImmutableDeque-T--IsEmpty.md 'Atropos.IImmutableDeque&lt;T&gt;.IsEmpty')
- [Left](./IImmutableDeque-T--Left.md 'Atropos.IImmutableDeque&lt;T&gt;.Left')
- [Right](./IImmutableDeque-T--Right.md 'Atropos.IImmutableDeque&lt;T&gt;.Right')
### Methods
- [DequeueLeft()](./IImmutableDeque-T--DequeueLeft().md 'Atropos.IImmutableDeque&lt;T&gt;.DequeueLeft()')
- [DequeueRight()](./IImmutableDeque-T--DequeueRight().md 'Atropos.IImmutableDeque&lt;T&gt;.DequeueRight()')
- [EnqueueLeft(T)](./IImmutableDeque-T--EnqueueLeft(T).md 'Atropos.IImmutableDeque&lt;T&gt;.EnqueueLeft(T)')
- [EnqueueRight(T)](./IImmutableDeque-T--EnqueueRight(T).md 'Atropos.IImmutableDeque&lt;T&gt;.EnqueueRight(T)')
