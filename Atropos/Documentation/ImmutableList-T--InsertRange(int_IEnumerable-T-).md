### [Atropos](./Atropos.md 'Atropos').[ImmutableList&lt;T&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')
## ImmutableList&lt;T&gt;.InsertRange(int, System.Collections.Generic.IEnumerable&lt;T&gt;) Method
Inserts the specified elements at the specified index in the immutable list.  
```csharp
public Atropos.ImmutableList<T> InsertRange(int index, System.Collections.Generic.IEnumerable<T> items);
```
#### Parameters
<a name='Atropos-ImmutableList-T--InsertRange(int_System-Collections-Generic-IEnumerable-T-)-index'></a>
`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The zero-based index at which the new elements should be inserted.  
  
<a name='Atropos-ImmutableList-T--InsertRange(int_System-Collections-Generic-IEnumerable-T-)-items'></a>
`items` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](./ImmutableList-T-.md#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The elements to insert.  
  
#### Returns
[Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[T](./ImmutableList-T-.md#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
A new immutable list that includes the specified elements.  
#### Exceptions
[System.IndexOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.IndexOutOfRangeException 'System.IndexOutOfRangeException')  
Thrown when [index](#Atropos-ImmutableList-T--InsertRange(int_System-Collections-Generic-IEnumerable-T-)-index 'Atropos.ImmutableList&lt;T&gt;.InsertRange(int, System.Collections.Generic.IEnumerable&lt;T&gt;).index')is out of list bounds.  
