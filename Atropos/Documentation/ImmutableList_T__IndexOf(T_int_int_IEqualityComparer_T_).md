### [Atropos](Atropos.md 'Atropos').[ImmutableList&lt;T&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')
## ImmutableList&lt;T&gt;.IndexOf(T, int, int, IEqualityComparer&lt;T&gt;) Method
Searches for the specified object and returns the zero-based index of the first   
occurrence within the range of elements in the list  
that starts at the specified index and contains the specified number of elements.  
```csharp
public int IndexOf(T item, int index, int count, System.Collections.Generic.IEqualityComparer<T> equalityComparer=null);
```
#### Parameters
<a name='Atropos_ImmutableList_T__IndexOf(T_int_int_System_Collections_Generic_IEqualityComparer_T_)_item'></a>
`item` [T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')  
Object to find
  
<a name='Atropos_ImmutableList_T__IndexOf(T_int_int_System_Collections_Generic_IEqualityComparer_T_)_index'></a>
`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Zero-based start index
  
<a name='Atropos_ImmutableList_T__IndexOf(T_int_int_System_Collections_Generic_IEqualityComparer_T_)_count'></a>
`count` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The length of the search range
  
<a name='Atropos_ImmutableList_T__IndexOf(T_int_int_System_Collections_Generic_IEqualityComparer_T_)_equalityComparer'></a>
`equalityComparer` [System.Collections.Generic.IEqualityComparer&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1')[T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1')  
The comparer to use for comparing items with [item](ImmutableList_T__IndexOf(T_int_int_IEqualityComparer_T_).md#Atropos_ImmutableList_T__IndexOf(T_int_int_System_Collections_Generic_IEqualityComparer_T_)_item 'Atropos.ImmutableList&lt;T&gt;.IndexOf(T, int, int, System.Collections.Generic.IEqualityComparer&lt;T&gt;).item')
  
#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The zero-based index of the first occurrence of item within the range of elements  
            in the [ImmutableList&lt;T&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;') that starts at [index](ImmutableList_T__IndexOf(T_int_int_IEqualityComparer_T_).md#Atropos_ImmutableList_T__IndexOf(T_int_int_System_Collections_Generic_IEqualityComparer_T_)_index 'Atropos.ImmutableList&lt;T&gt;.IndexOf(T, int, int, System.Collections.Generic.IEqualityComparer&lt;T&gt;).index') and contains [count](ImmutableList_T__IndexOf(T_int_int_IEqualityComparer_T_).md#Atropos_ImmutableList_T__IndexOf(T_int_int_System_Collections_Generic_IEqualityComparer_T_)_count 'Atropos.ImmutableList&lt;T&gt;.IndexOf(T, int, int, System.Collections.Generic.IEqualityComparer&lt;T&gt;).count') number   
            of elements if found; otherwise -1.
#### Exceptions
[System.IndexOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.IndexOutOfRangeException 'System.IndexOutOfRangeException')  
Thrown when requested [index](ImmutableList_T__IndexOf(T_int_int_IEqualityComparer_T_).md#Atropos_ImmutableList_T__IndexOf(T_int_int_System_Collections_Generic_IEqualityComparer_T_)_index 'Atropos.ImmutableList&lt;T&gt;.IndexOf(T, int, int, System.Collections.Generic.IEqualityComparer&lt;T&gt;).index') is below zero or ([index](ImmutableList_T__IndexOf(T_int_int_IEqualityComparer_T_).md#Atropos_ImmutableList_T__IndexOf(T_int_int_System_Collections_Generic_IEqualityComparer_T_)_index 'Atropos.ImmutableList&lt;T&gt;.IndexOf(T, int, int, System.Collections.Generic.IEqualityComparer&lt;T&gt;).index')+[count](ImmutableList_T__IndexOf(T_int_int_IEqualityComparer_T_).md#Atropos_ImmutableList_T__IndexOf(T_int_int_System_Collections_Generic_IEqualityComparer_T_)_count 'Atropos.ImmutableList&lt;T&gt;.IndexOf(T, int, int, System.Collections.Generic.IEqualityComparer&lt;T&gt;).count')) is above [Count](ImmutableList_T__Count.md 'Atropos.ImmutableList&lt;T&gt;.Count')-1.

Implements [IndexOf(T, int, int, IEqualityComparer<T>)](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Immutable.IImmutableList-1.IndexOf#System_Collections_Immutable_IImmutableList_1_IndexOf__0,System_Int32,System_Int32,System_Collections_Generic_IEqualityComparer{_0}_ 'System.Collections.Immutable.IImmutableList`1.IndexOf(`0,System.Int32,System.Int32,System.Collections.Generic.IEqualityComparer{`0})')  
