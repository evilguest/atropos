### [Atropos](Atropos.md 'Atropos').[ImmutableList&lt;T&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')
## ImmutableList&lt;T&gt;.operator +(ImmutableList&lt;T&gt;, T) Operator
Addition operator - adds the specified value to the immutable list.  
Convenient in the compound assignment operator:  
list = list.Add(value) <=> list += value  
```csharp
public static Atropos.ImmutableList<T> operator +(Atropos.ImmutableList<T> list, T value);
```
#### Parameters
<a name='Atropos_ImmutableList_T__op_Addition(Atropos_ImmutableList_T__T)_list'></a>
`list` [Atropos.ImmutableList&lt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')[T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')  
The immutable list
  
<a name='Atropos_ImmutableList_T__op_Addition(Atropos_ImmutableList_T__T)_value'></a>
`value` [T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')  
The value to add to the end of the list
  
#### Returns
[Atropos.ImmutableList&lt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')[T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')  
The new immutable list with the [value](ImmutableList_T__operator+(ImmutableList_T__T).md#Atropos_ImmutableList_T__op_Addition(Atropos_ImmutableList_T__T)_value 'Atropos.ImmutableList&lt;T&gt;.op_Addition(Atropos.ImmutableList&lt;T&gt;, T).value') inserted at the end.
