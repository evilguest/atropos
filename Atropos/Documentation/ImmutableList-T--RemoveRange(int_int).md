### [Atropos](./Atropos.md 'Atropos').[ImmutableList&lt;T&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')
## ImmutableList&lt;T&gt;.RemoveRange(int, int) Method
Removes a range of elements from the [ImmutableList&lt;T&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
```csharp
public Atropos.ImmutableList<T> RemoveRange(int index, int count);
```
#### Parameters
<a name='Atropos-ImmutableList-T--RemoveRange(int_int)-index'></a>
`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The zero-based starting index of the range of elements to remove.  
  
<a name='Atropos-ImmutableList-T--RemoveRange(int_int)-count'></a>
`count` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The number of elements to remove.  
  
#### Returns
[Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[T](./ImmutableList-T-.md#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
A new immutable list with the elements removed.  
#### Exceptions
[System.IndexOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.IndexOutOfRangeException 'System.IndexOutOfRangeException')  
Thrown when the requested range crosses the list boundaries.  
