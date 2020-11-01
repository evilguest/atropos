### [Atropos](./Atropos.md 'Atropos').[ImmutableList&lt;T&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')
## ImmutableList&lt;T&gt;.IndexOf(T, int, int) Method
Searches for the specified object and returns the zero-based index of the first   
occurrence within the range of elements in the list  
that starts at the specified index and contains the specified number of elements.  
```csharp
public int IndexOf(T item, int index, int count);
```
#### Parameters
<a name='Atropos-ImmutableList-T--IndexOf(T_int_int)-item'></a>
`item` [T](./ImmutableList-T-.md#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')  
Object to find  
  
<a name='Atropos-ImmutableList-T--IndexOf(T_int_int)-index'></a>
`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Zero-based start index  
  
<a name='Atropos-ImmutableList-T--IndexOf(T_int_int)-count'></a>
`count` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The length of the search range  
  
#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The zero-based index of the first occurrence of item within the range of elements  
            in the [ImmutableList&lt;T&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;') that starts at [index](#Atropos-ImmutableList-T--IndexOf(T_int_int)-index 'Atropos.ImmutableList&lt;T&gt;.IndexOf(T, int, int).index') and contains [count](#Atropos-ImmutableList-T--IndexOf(T_int_int)-count 'Atropos.ImmutableList&lt;T&gt;.IndexOf(T, int, int).count') number   
            of elements if found; otherwise -1.  
