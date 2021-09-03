### [Atropos](Atropos.md 'Atropos').[ImmutableList&lt;T&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')
## ImmutableList&lt;T&gt;.operator +(ImmutableList&lt;T&gt;, IEnumerable&lt;T&gt;) Operator
Addition operator - adds the specified range of items to the immutable list.  
Convenient in the compound assignment operator:  
```csharp
list = list.AddRange(items) <=> list += items;```
```csharp
public static Atropos.ImmutableList<T> operator +(Atropos.ImmutableList<T> list, System.Collections.Generic.IEnumerable<T> items);
```
#### Parameters
<a name='Atropos_ImmutableList_T__op_Addition(Atropos_ImmutableList_T__System_Collections_Generic_IEnumerable_T_)_list'></a>
`list` [Atropos.ImmutableList&lt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')[T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')  
Immutable list
  
<a name='Atropos_ImmutableList_T__op_Addition(Atropos_ImmutableList_T__System_Collections_Generic_IEnumerable_T_)_items'></a>
`items` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The items to add 
  
#### Returns
[Atropos.ImmutableList&lt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')[T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')  
A new [ImmutableList&lt;T&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;') with the [items](ImmutableList_T__operator+(ImmutableList_T__IEnumerable_T_).md#Atropos_ImmutableList_T__op_Addition(Atropos_ImmutableList_T__System_Collections_Generic_IEnumerable_T_)_items 'Atropos.ImmutableList&lt;T&gt;.op_Addition(Atropos.ImmutableList&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;T&gt;).items') appended to the end of the [list](ImmutableList_T__operator+(ImmutableList_T__IEnumerable_T_).md#Atropos_ImmutableList_T__op_Addition(Atropos_ImmutableList_T__System_Collections_Generic_IEnumerable_T_)_list 'Atropos.ImmutableList&lt;T&gt;.op_Addition(Atropos.ImmutableList&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;T&gt;).list').
