### [Atropos](./Atropos.md 'Atropos').[ImmutableList&lt;T&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')
## ImmutableList&lt;T&gt;.this[int] Property
Returns an element from the list. Asympthotic is O(log([Count](./ImmutableList-T--Count.md 'Atropos.ImmutableList&lt;T&gt;.Count'))).  
```csharp
public T this[int index] { get; }
```
#### Parameters
<a name='Atropos-ImmutableList-T--this-int--index'></a>
`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The zero-based index of the element to return  
  
#### Property Value
[T](./ImmutableList-T-.md#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')  
#### Exceptions
[System.IndexOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.IndexOutOfRangeException 'System.IndexOutOfRangeException')  
Thrown when requested [index](#Atropos-ImmutableList-T--this-int--index 'Atropos.ImmutableList&lt;T&gt;.this[int].index')  is below zero or above [Count](./ImmutableList-T--Count.md 'Atropos.ImmutableList&lt;T&gt;.Count')-1.  
