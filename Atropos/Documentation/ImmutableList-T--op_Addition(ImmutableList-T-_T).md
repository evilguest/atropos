### [Atropos](./Atropos.md 'Atropos').[ImmutableList&lt;T&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')
## ImmutableList&lt;T&gt;.operator +(Atropos.ImmutableList&lt;T&gt;, T) Operator
Addition operator - adds the specified value to the immutable list.  
Convenient in the compound assignment operator:  
list = list.Add(value) <=> list += value  
```csharp
public static Atropos.ImmutableList<T> operator +(Atropos.ImmutableList<T> list, T value);
```
#### Parameters
<a name='Atropos-ImmutableList-T--op_Addition(Atropos-ImmutableList-T-_T)-list'></a>
`list` [Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[T](./ImmutableList-T-.md#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
The immutable list  
  
<a name='Atropos-ImmutableList-T--op_Addition(Atropos-ImmutableList-T-_T)-value'></a>
`value` [T](./ImmutableList-T-.md#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')  
The value to add to the end of the list  
  
#### Returns
[Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[T](./ImmutableList-T-.md#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
The new immutable list with the [value](#Atropos-ImmutableList-T--op_Addition(Atropos-ImmutableList-T-_T)-value 'Atropos.ImmutableList&lt;T&gt;.op_Addition(Atropos.ImmutableList&lt;T&gt;, T).value') inserted at the end.  
