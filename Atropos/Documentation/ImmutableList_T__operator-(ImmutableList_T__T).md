### [Atropos](Atropos.md 'Atropos').[ImmutableList&lt;T&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')
## ImmutableList&lt;T&gt;.operator -(ImmutableList&lt;T&gt;, T) Operator
Removal operator - removes the first occurence of the specified value from the list, using the default equality comparer.  
Convenient in the compound assignment operator:  
list = list.Remove(item, null) <=> list -= item;  
```csharp
public static Atropos.ImmutableList<T> operator -(Atropos.ImmutableList<T> list, T value);
```
#### Parameters
<a name='Atropos_ImmutableList_T__op_Subtraction(Atropos_ImmutableList_T__T)_list'></a>
`list` [Atropos.ImmutableList&lt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')[T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')  
The immutable list
  
<a name='Atropos_ImmutableList_T__op_Subtraction(Atropos_ImmutableList_T__T)_value'></a>
`value` [T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')  
Value to remove from the list
  
#### Returns
[Atropos.ImmutableList&lt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')[T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')  
A new list with the first occurence of [value](ImmutableList_T__operator-(ImmutableList_T__T).md#Atropos_ImmutableList_T__op_Subtraction(Atropos_ImmutableList_T__T)_value 'Atropos.ImmutableList&lt;T&gt;.op_Subtraction(Atropos.ImmutableList&lt;T&gt;, T).value') removed.
### Remarks
Note that for ImmutableList<[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')> this operator overlaps with the [operator -(ImmutableList&lt;T&gt;, int)](ImmutableList_T__operator-(ImmutableList_T__int).md 'Atropos.ImmutableList&lt;T&gt;.op_Subtraction(Atropos.ImmutableList&lt;T&gt;, int)') and loses.  
            To remove some value from an [ImmutableList&lt;T&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;') where T is [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32') use the [Remove(T, IEqualityComparer&lt;T&gt;)](ImmutableList_T__Remove(T_IEqualityComparer_T_).md 'Atropos.ImmutableList&lt;T&gt;.Remove(T, System.Collections.Generic.IEqualityComparer&lt;T&gt;)') method explicitly.  
            
