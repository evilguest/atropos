### [Atropos](Atropos.md 'Atropos').[ImmutableList&lt;T&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')
## ImmutableList&lt;T&gt;.operator -(ImmutableList&lt;T&gt;, IEnumerable&lt;T&gt;) Operator
Removal operator - removes the specified items from the immutable list, using the default equality comparer  
```csharp
public static Atropos.ImmutableList<T> operator -(Atropos.ImmutableList<T> list, System.Collections.Generic.IEnumerable<T> items);
```
#### Parameters
<a name='Atropos_ImmutableList_T__op_Subtraction(Atropos_ImmutableList_T__System_Collections_Generic_IEnumerable_T_)_list'></a>
`list` [Atropos.ImmutableList&lt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')[T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')  
Immutable list
  
<a name='Atropos_ImmutableList_T__op_Subtraction(Atropos_ImmutableList_T__System_Collections_Generic_IEnumerable_T_)_items'></a>
`items` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
Items to remove
  
#### Returns
[Atropos.ImmutableList&lt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')[T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')  
A new [ImmutableList&lt;T&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;') with the specified items excluded.
