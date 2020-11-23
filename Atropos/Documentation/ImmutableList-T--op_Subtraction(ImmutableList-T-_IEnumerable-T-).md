### [Atropos](./Atropos.md 'Atropos').[ImmutableList&lt;T&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')
## ImmutableList&lt;T&gt;.operator -(Atropos.ImmutableList&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;T&gt;) Operator
Removal operator - removes the specified items from the immutable list, using the default equality comparer  
```csharp
public static Atropos.ImmutableList<T> operator -(Atropos.ImmutableList<T> list, System.Collections.Generic.IEnumerable<T> items);
```
#### Parameters
<a name='Atropos-ImmutableList-T--op_Subtraction(Atropos-ImmutableList-T-_System-Collections-Generic-IEnumerable-T-)-list'></a>
`list` [Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[T](./ImmutableList-T-.md#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
Immutable list  
  
<a name='Atropos-ImmutableList-T--op_Subtraction(Atropos-ImmutableList-T-_System-Collections-Generic-IEnumerable-T-)-items'></a>
`items` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](./ImmutableList-T-.md#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
Items to remove  
  
#### Returns
[Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[T](./ImmutableList-T-.md#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
A new [ImmutableList&lt;T&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;') with the specified items excluded.  
