### [Atropos](Atropos.md 'Atropos').[ImmutableList&lt;T&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')
## ImmutableList&lt;T&gt;.LastIndexOf(T, IEqualityComparer&lt;T&gt;) Method
Searches for the specified object and returns the zero-based index of the last occurrence within   
the [ImmutableList&lt;T&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;').  
```csharp
public int LastIndexOf(T item, System.Collections.Generic.IEqualityComparer<T> equalityComparer=null);
```
#### Parameters
<a name='Atropos_ImmutableList_T__LastIndexOf(T_System_Collections_Generic_IEqualityComparer_T_)_item'></a>
`item` [T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')  
The object to locate in the list. The value can be null for reference types.
  
<a name='Atropos_ImmutableList_T__LastIndexOf(T_System_Collections_Generic_IEqualityComparer_T_)_equalityComparer'></a>
`equalityComparer` [System.Collections.Generic.IEqualityComparer&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1')[T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1')  
The equality comparer to use when searching for the [item](ImmutableList_T__LastIndexOf(T_IEqualityComparer_T_).md#Atropos_ImmutableList_T__LastIndexOf(T_System_Collections_Generic_IEqualityComparer_T_)_item 'Atropos.ImmutableList&lt;T&gt;.LastIndexOf(T, System.Collections.Generic.IEqualityComparer&lt;T&gt;).item').
  
#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The zero-based index of the last occurrence of item within the [ImmutableList&lt;T&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;') if found; otherwise -1.
