### [Atropos](./Atropos.md 'Atropos').[ImmutableList&lt;T&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')
## ImmutableList&lt;T&gt;.LastIndexOf(T, int, int, System.Collections.Generic.IEqualityComparer&lt;T&gt;) Method
Searches for the specified object and returns the zero-based index of the last occurrence within   
the range of elements in the [ImmutableList&lt;T&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
that contains the specified number of elements and ends at the specified index.  
```csharp
public int LastIndexOf(T item, int index, int count, System.Collections.Generic.IEqualityComparer<T> equalityComparer=null);
```
#### Parameters
<a name='Atropos-ImmutableList-T--LastIndexOf(T_int_int_System-Collections-Generic-IEqualityComparer-T-)-item'></a>
`item` [T](./ImmutableList-T-.md#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')  
The object to locate in the list. The value can be null for reference types.  
  
<a name='Atropos-ImmutableList-T--LastIndexOf(T_int_int_System-Collections-Generic-IEqualityComparer-T-)-index'></a>
`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The zero-based starting index of the search. 0 (zero) is valid in an empty list.  
  
<a name='Atropos-ImmutableList-T--LastIndexOf(T_int_int_System-Collections-Generic-IEqualityComparer-T-)-count'></a>
`count` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The number of elements in the section to search.  
  
<a name='Atropos-ImmutableList-T--LastIndexOf(T_int_int_System-Collections-Generic-IEqualityComparer-T-)-equalityComparer'></a>
`equalityComparer` [System.Collections.Generic.IEqualityComparer&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1')[T](./ImmutableList-T-.md#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1')  
The equality comparer to use when searching for the [item](#Atropos-ImmutableList-T--LastIndexOf(T_int_int_System-Collections-Generic-IEqualityComparer-T-)-item 'Atropos.ImmutableList&lt;T&gt;.LastIndexOf(T, int, int, System.Collections.Generic.IEqualityComparer&lt;T&gt;).item').  
  
#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The zero-based index of the last occurrence of item within the range of elements  
            in the [ImmutableList&lt;T&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;') that starts at [index](#Atropos-ImmutableList-T--LastIndexOf(T_int_int_System-Collections-Generic-IEqualityComparer-T-)-index 'Atropos.ImmutableList&lt;T&gt;.LastIndexOf(T, int, int, System.Collections.Generic.IEqualityComparer&lt;T&gt;).index') and contains [count](#Atropos-ImmutableList-T--LastIndexOf(T_int_int_System-Collections-Generic-IEqualityComparer-T-)-count 'Atropos.ImmutableList&lt;T&gt;.LastIndexOf(T, int, int, System.Collections.Generic.IEqualityComparer&lt;T&gt;).count') number   
            of elements if found; otherwise -1.  
#### Exceptions
[System.IndexOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.IndexOutOfRangeException 'System.IndexOutOfRangeException')  
Thrown when requested [index](#Atropos-ImmutableList-T--LastIndexOf(T_int_int_System-Collections-Generic-IEqualityComparer-T-)-index 'Atropos.ImmutableList&lt;T&gt;.LastIndexOf(T, int, int, System.Collections.Generic.IEqualityComparer&lt;T&gt;).index') is below zero or ([index](#Atropos-ImmutableList-T--LastIndexOf(T_int_int_System-Collections-Generic-IEqualityComparer-T-)-index 'Atropos.ImmutableList&lt;T&gt;.LastIndexOf(T, int, int, System.Collections.Generic.IEqualityComparer&lt;T&gt;).index')+[count](#Atropos-ImmutableList-T--LastIndexOf(T_int_int_System-Collections-Generic-IEqualityComparer-T-)-count 'Atropos.ImmutableList&lt;T&gt;.LastIndexOf(T, int, int, System.Collections.Generic.IEqualityComparer&lt;T&gt;).count')) is above [Count](./ImmutableList-T--Count.md 'Atropos.ImmutableList&lt;T&gt;.Count')-1.  
