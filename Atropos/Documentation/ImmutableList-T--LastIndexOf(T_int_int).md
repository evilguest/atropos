### [Atropos](./Atropos.md 'Atropos').[ImmutableList&lt;T&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')
## ImmutableList&lt;T&gt;.LastIndexOf(T, int, int) Method
Searches for the specified object and returns the zero-based index of the last occurrence within   
the range of elements in the [ImmutableList&lt;T&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
that contains the specified number of elements and ends at the specified index.  
```csharp
public int LastIndexOf(T item, int index, int count);
```
#### Parameters
<a name='Atropos-ImmutableList-T--LastIndexOf(T_int_int)-item'></a>
`item` [T](./ImmutableList-T-.md#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')  
The object to locate in the list. The value can be null for reference types.  
  
<a name='Atropos-ImmutableList-T--LastIndexOf(T_int_int)-index'></a>
`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The zero-based starting index of the search. 0 (zero) is valid in an empty list.  
  
<a name='Atropos-ImmutableList-T--LastIndexOf(T_int_int)-count'></a>
`count` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The number of elements in the section to search.  
  
#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The zero-based index of the last occurrence of item within the range of elements  
            in the [ImmutableList&lt;T&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;') that starts at [index](#Atropos-ImmutableList-T--LastIndexOf(T_int_int)-index 'Atropos.ImmutableList&lt;T&gt;.LastIndexOf(T, int, int).index') and contains [count](#Atropos-ImmutableList-T--LastIndexOf(T_int_int)-count 'Atropos.ImmutableList&lt;T&gt;.LastIndexOf(T, int, int).count') number   
            of elements if found; otherwise -1.  
#### Exceptions
[System.IndexOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.IndexOutOfRangeException 'System.IndexOutOfRangeException')  
Thrown when requested [index](#Atropos-ImmutableList-T--LastIndexOf(T_int_int)-index 'Atropos.ImmutableList&lt;T&gt;.LastIndexOf(T, int, int).index') is below zero or ([index](#Atropos-ImmutableList-T--LastIndexOf(T_int_int)-index 'Atropos.ImmutableList&lt;T&gt;.LastIndexOf(T, int, int).index')+[count](#Atropos-ImmutableList-T--LastIndexOf(T_int_int)-count 'Atropos.ImmutableList&lt;T&gt;.LastIndexOf(T, int, int).count')) is above [Count](./ImmutableList-T--Count.md 'Atropos.ImmutableList&lt;T&gt;.Count')-1.  
