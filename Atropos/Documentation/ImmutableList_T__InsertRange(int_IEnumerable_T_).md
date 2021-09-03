### [Atropos](Atropos.md 'Atropos').[ImmutableList&lt;T&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')
## ImmutableList&lt;T&gt;.InsertRange(int, IEnumerable&lt;T&gt;) Method
Inserts the specified elements at the specified index in the immutable list.  
```csharp
public Atropos.ImmutableList<T> InsertRange(int index, System.Collections.Generic.IEnumerable<T> items);
```
#### Parameters
<a name='Atropos_ImmutableList_T__InsertRange(int_System_Collections_Generic_IEnumerable_T_)_index'></a>
`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The zero-based index at which the new elements should be inserted.
  
<a name='Atropos_ImmutableList_T__InsertRange(int_System_Collections_Generic_IEnumerable_T_)_items'></a>
`items` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The elements to insert.
  
#### Returns
[Atropos.ImmutableList&lt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')[T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')  
A new immutable list that includes the specified elements.
#### Exceptions
[System.IndexOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.IndexOutOfRangeException 'System.IndexOutOfRangeException')  
Thrown when [index](ImmutableList_T__InsertRange(int_IEnumerable_T_).md#Atropos_ImmutableList_T__InsertRange(int_System_Collections_Generic_IEnumerable_T_)_index 'Atropos.ImmutableList&lt;T&gt;.InsertRange(int, System.Collections.Generic.IEnumerable&lt;T&gt;).index')is out of list bounds.

Implements [InsertRange(int, IEnumerable<T>)](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Immutable.IImmutableList-1.InsertRange#System_Collections_Immutable_IImmutableList_1_InsertRange_System_Int32,System_Collections_Generic_IEnumerable{_0}_ 'System.Collections.Immutable.IImmutableList`1.InsertRange(System.Int32,System.Collections.Generic.IEnumerable{`0})')  
