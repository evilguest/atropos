### [Atropos](./Atropos.md 'Atropos').[ImmutableList&lt;T&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')
## ImmutableList&lt;T&gt;.GetEnumerator(int) Method
Returns the list enumerator that starts at the specific index  
```csharp
public System.Collections.Generic.IEnumerator<T> GetEnumerator(int index);
```
#### Parameters
<a name='Atropos-ImmutableList-T--GetEnumerator(int)-index'></a>
`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Index where to start  
  
#### Returns
[System.Collections.Generic.IEnumerator&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1')[T](./ImmutableList-T-.md#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1')  
A new enumerator that is positioned immediately before the element at [index](#Atropos-ImmutableList-T--GetEnumerator(int)-index 'Atropos.ImmutableList&lt;T&gt;.GetEnumerator(int).index') position.  
#### Exceptions
[System.IndexOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.IndexOutOfRangeException 'System.IndexOutOfRangeException')  
Thrown if the index requested is outside of the list.  
