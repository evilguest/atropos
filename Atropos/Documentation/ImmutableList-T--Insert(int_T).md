### [Atropos](./Atropos.md 'Atropos').[ImmutableList&lt;T&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')
## ImmutableList&lt;T&gt;.Insert(int, T) Method
Inserts the specified value at the specified index  
```csharp
public Atropos.ImmutableList<T> Insert(int index, T value);
```
#### Parameters
<a name='Atropos-ImmutableList-T--Insert(int_T)-index'></a>
`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Location of the element to insert  
  
<a name='Atropos-ImmutableList-T--Insert(int_T)-value'></a>
`value` [T](./ImmutableList-T-.md#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')  
Value of the element to insert  
  
#### Returns
[Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[T](./ImmutableList-T-.md#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
a new [ImmutableList&lt;T&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;') with the specified [value](#Atropos-ImmutableList-T--Insert(int_T)-value 'Atropos.ImmutableList&lt;T&gt;.Insert(int, T).value') inserted at the specified [index](#Atropos-ImmutableList-T--Insert(int_T)-index 'Atropos.ImmutableList&lt;T&gt;.Insert(int, T).index')  
#### Exceptions
[System.IndexOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.IndexOutOfRangeException 'System.IndexOutOfRangeException')  
Thrown in case [index](#Atropos-ImmutableList-T--Insert(int_T)-index 'Atropos.ImmutableList&lt;T&gt;.Insert(int, T).index') is outside of the list bounds.  
