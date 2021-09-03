### [Atropos](Atropos.md 'Atropos').[ImmutableList&lt;T&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')
## ImmutableList&lt;T&gt;.this[int] Property
Returns an element from the list. Asympthotic is O(log([Count](ImmutableList_T__Count.md 'Atropos.ImmutableList&lt;T&gt;.Count'))).  
```csharp
public T this[int index] { get; }
```
#### Parameters
<a name='Atropos_ImmutableList_T__this_int__index'></a>
`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The zero-based index of the element to return
  
#### Property Value
[T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')
#### Exceptions
[System.IndexOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.IndexOutOfRangeException 'System.IndexOutOfRangeException')  
Thrown when requested [index](ImmutableList_T__this_int_.md#Atropos_ImmutableList_T__this_int__index 'Atropos.ImmutableList&lt;T&gt;.this[int].index')  is below zero or above [Count](ImmutableList_T__Count.md 'Atropos.ImmutableList&lt;T&gt;.Count')-1.

Implements [this[int]](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyList-1.Item#System_Collections_Generic_IReadOnlyList_1_Item_System_Int32_ 'System.Collections.Generic.IReadOnlyList`1.Item(System.Int32)')  
