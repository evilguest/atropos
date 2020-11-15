### [Atropos](./Atropos.md 'Atropos').[ImmutableList&lt;T&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')
## ImmutableList&lt;T&gt;.IndexOf(T, int, int, System.Collections.Generic.IEqualityComparer&lt;T&gt;) Method
Searches for the specified object and returns the zero-based index of the first   
occurrence within the range of elements in the list  
that starts at the specified index and contains the specified number of elements.  
```csharp
public int IndexOf(T item, int index, int count, System.Collections.Generic.IEqualityComparer<T> equalityComparer=null);
```
#### Parameters
<a name='Atropos-ImmutableList-T--IndexOf(T_int_int_System-Collections-Generic-IEqualityComparer-T-)-item'></a>
`item` [T](./ImmutableList-T-.md#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')  
Object to find  
  
<a name='Atropos-ImmutableList-T--IndexOf(T_int_int_System-Collections-Generic-IEqualityComparer-T-)-index'></a>
`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Zero-based start index  
  
<a name='Atropos-ImmutableList-T--IndexOf(T_int_int_System-Collections-Generic-IEqualityComparer-T-)-count'></a>
`count` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The length of the search range  
  
<a name='Atropos-ImmutableList-T--IndexOf(T_int_int_System-Collections-Generic-IEqualityComparer-T-)-equalityComparer'></a>
`equalityComparer` [System.Collections.Generic.IEqualityComparer&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1')[T](./ImmutableList-T-.md#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1')  
The comparer to use for comparing items with [item](#Atropos-ImmutableList-T--IndexOf(T_int_int_System-Collections-Generic-IEqualityComparer-T-)-item 'Atropos.ImmutableList&lt;T&gt;.IndexOf(T, int, int, System.Collections.Generic.IEqualityComparer&lt;T&gt;).item')  
  
#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The zero-based index of the first occurrence of item within the range of elements  
            in the [ImmutableList&lt;T&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;') that starts at [index](#Atropos-ImmutableList-T--IndexOf(T_int_int_System-Collections-Generic-IEqualityComparer-T-)-index 'Atropos.ImmutableList&lt;T&gt;.IndexOf(T, int, int, System.Collections.Generic.IEqualityComparer&lt;T&gt;).index') and contains [count](#Atropos-ImmutableList-T--IndexOf(T_int_int_System-Collections-Generic-IEqualityComparer-T-)-count 'Atropos.ImmutableList&lt;T&gt;.IndexOf(T, int, int, System.Collections.Generic.IEqualityComparer&lt;T&gt;).count') number   
            of elements if found; otherwise -1.  
#### Exceptions
[System.IndexOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.IndexOutOfRangeException 'System.IndexOutOfRangeException')  
Thrown when requested [index](#Atropos-ImmutableList-T--IndexOf(T_int_int_System-Collections-Generic-IEqualityComparer-T-)-index 'Atropos.ImmutableList&lt;T&gt;.IndexOf(T, int, int, System.Collections.Generic.IEqualityComparer&lt;T&gt;).index') is below zero or ([index](#Atropos-ImmutableList-T--IndexOf(T_int_int_System-Collections-Generic-IEqualityComparer-T-)-index 'Atropos.ImmutableList&lt;T&gt;.IndexOf(T, int, int, System.Collections.Generic.IEqualityComparer&lt;T&gt;).index')+[count](#Atropos-ImmutableList-T--IndexOf(T_int_int_System-Collections-Generic-IEqualityComparer-T-)-count 'Atropos.ImmutableList&lt;T&gt;.IndexOf(T, int, int, System.Collections.Generic.IEqualityComparer&lt;T&gt;).count')) is above [Count](./ImmutableList-T--Count.md 'Atropos.ImmutableList&lt;T&gt;.Count')-1.  
