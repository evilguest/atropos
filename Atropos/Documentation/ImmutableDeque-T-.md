### [Atropos](./Atropos.md 'Atropos')
## ImmutableDeque&lt;T&gt; Class
An efficient implementation of the [IImmutableDeque&lt;T&gt;](./IImmutableDeque-T-.md 'Atropos.IImmutableDeque&lt;T&gt;') based on the Eric Lippert's deque, which is based on the Hughes lists.  
See also https://docs.microsoft.com/en-us/archive/blogs/ericlippert/immutability-in-c-part-eleven-a-working-double-ended-queue  
```csharp
public sealed class ImmutableDeque<T> :
IImmutableDeque<T>
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ImmutableDeque&lt;T&gt;  

Implements [Atropos.IImmutableDeque&lt;](./IImmutableDeque-T-.md 'Atropos.IImmutableDeque&lt;T&gt;')[T](#Atropos-ImmutableDeque-T--T 'Atropos.ImmutableDeque&lt;T&gt;.T')[&gt;](./IImmutableDeque-T-.md 'Atropos.IImmutableDeque&lt;T&gt;')  
#### Type parameters
<a name='Atropos-ImmutableDeque-T--T'></a>
`T`  
The type of deque elements  
  
### Properties
- [Empty](./ImmutableDeque-T--Empty.md 'Atropos.ImmutableDeque&lt;T&gt;.Empty')
- [IsEmpty](./ImmutableDeque-T--IsEmpty.md 'Atropos.ImmutableDeque&lt;T&gt;.IsEmpty')
- [Left](./ImmutableDeque-T--Left.md 'Atropos.ImmutableDeque&lt;T&gt;.Left')
- [Right](./ImmutableDeque-T--Right.md 'Atropos.ImmutableDeque&lt;T&gt;.Right')
### Methods
- [DequeueLeft()](./ImmutableDeque-T--DequeueLeft().md 'Atropos.ImmutableDeque&lt;T&gt;.DequeueLeft()')
- [DequeueRight()](./ImmutableDeque-T--DequeueRight().md 'Atropos.ImmutableDeque&lt;T&gt;.DequeueRight()')
- [EnqueueLeft(T)](./ImmutableDeque-T--EnqueueLeft(T).md 'Atropos.ImmutableDeque&lt;T&gt;.EnqueueLeft(T)')
- [EnqueueRight(T)](./ImmutableDeque-T--EnqueueRight(T).md 'Atropos.ImmutableDeque&lt;T&gt;.EnqueueRight(T)')
