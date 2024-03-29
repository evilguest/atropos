### [Atropos](Atropos.md 'Atropos').[ImmutableList&lt;T&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')
## ImmutableList&lt;T&gt;.IndexOf(T, IEqualityComparer&lt;T&gt;) Method
Searches for the specified object and returns the zero-based index of the first   
occurrence within the range of elements in the list  
that starts at the specified index and contains the specified number of elements.  
```csharp
public int IndexOf(T item, System.Collections.Generic.IEqualityComparer<T> equalityComparer=null);
```
#### Parameters
<a name='Atropos_ImmutableList_T__IndexOf(T_System_Collections_Generic_IEqualityComparer_T_)_item'></a>
`item` [T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')  
Object to find
  
<a name='Atropos_ImmutableList_T__IndexOf(T_System_Collections_Generic_IEqualityComparer_T_)_equalityComparer'></a>
`equalityComparer` [System.Collections.Generic.IEqualityComparer&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1')[T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1')  
The comparer to use for comparing items with [item](ImmutableList_T__IndexOf(T_IEqualityComparer_T_).md#Atropos_ImmutableList_T__IndexOf(T_System_Collections_Generic_IEqualityComparer_T_)_item 'Atropos.ImmutableList&lt;T&gt;.IndexOf(T, System.Collections.Generic.IEqualityComparer&lt;T&gt;).item')
  
#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The zero-based index of the first occurrence of item within the [ImmutableList&lt;T&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;') if found; otherwise -1.
