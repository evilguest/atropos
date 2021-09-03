### [Atropos](Atropos.md 'Atropos').[ImmutableList&lt;T&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')
## ImmutableList&lt;T&gt;.Insert(int, T) Method
Inserts the specified value at the specified index  
```csharp
public Atropos.ImmutableList<T> Insert(int index, T value);
```
#### Parameters
<a name='Atropos_ImmutableList_T__Insert(int_T)_index'></a>
`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Location of the element to insert
  
<a name='Atropos_ImmutableList_T__Insert(int_T)_value'></a>
`value` [T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')  
Value of the element to insert
  
#### Returns
[Atropos.ImmutableList&lt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')[T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')  
a new [ImmutableList&lt;T&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;') with the specified [value](ImmutableList_T__Insert(int_T).md#Atropos_ImmutableList_T__Insert(int_T)_value 'Atropos.ImmutableList&lt;T&gt;.Insert(int, T).value') inserted at the specified [index](ImmutableList_T__Insert(int_T).md#Atropos_ImmutableList_T__Insert(int_T)_index 'Atropos.ImmutableList&lt;T&gt;.Insert(int, T).index')
#### Exceptions
[System.IndexOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.IndexOutOfRangeException 'System.IndexOutOfRangeException')  
Thrown in case [index](ImmutableList_T__Insert(int_T).md#Atropos_ImmutableList_T__Insert(int_T)_index 'Atropos.ImmutableList&lt;T&gt;.Insert(int, T).index') is outside of the list bounds.

Implements [Insert(int, T)](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Immutable.IImmutableList-1.Insert#System_Collections_Immutable_IImmutableList_1_Insert_System_Int32,_0_ 'System.Collections.Immutable.IImmutableList`1.Insert(System.Int32,`0)')  
