### [Atropos](Atropos.md 'Atropos').[ImmutableList](ImmutableList.md 'Atropos.ImmutableList')
## ImmutableList.SetItem&lt;T,B&gt;(ImmutableList&lt;T&gt;, int, B) Method
Makes a copy of the list, and replaces an element in the list at a given position with the specified element.  
```csharp
public static Atropos.ImmutableList<B> SetItem<T,B>(this Atropos.ImmutableList<T> list, int index, B value)
    where T : class, B;
```
#### Type parameters
<a name='Atropos_ImmutableList_SetItem_T_B_(Atropos_ImmutableList_T__int_B)_T'></a>
`T`  
Type of the original list items
  
<a name='Atropos_ImmutableList_SetItem_T_B_(Atropos_ImmutableList_T__int_B)_B'></a>
`B`  
Type of the new element
  
#### Parameters
<a name='Atropos_ImmutableList_SetItem_T_B_(Atropos_ImmutableList_T__int_B)_list'></a>
`list` [Atropos.ImmutableList&lt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')[T](ImmutableList_SetItem_T_B_(ImmutableList_T__int_B).md#Atropos_ImmutableList_SetItem_T_B_(Atropos_ImmutableList_T__int_B)_T 'Atropos.ImmutableList.SetItem&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).T')[&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')  
Original list
  
<a name='Atropos_ImmutableList_SetItem_T_B_(Atropos_ImmutableList_T__int_B)_index'></a>
`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The position in the list of the element to replace.
  
<a name='Atropos_ImmutableList_SetItem_T_B_(Atropos_ImmutableList_T__int_B)_value'></a>
`value` [B](ImmutableList_SetItem_T_B_(ImmutableList_T__int_B).md#Atropos_ImmutableList_SetItem_T_B_(Atropos_ImmutableList_T__int_B)_B 'Atropos.ImmutableList.SetItem&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).B')  
The element to replace the old element with.
  
#### Returns
[Atropos.ImmutableList&lt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')[B](ImmutableList_SetItem_T_B_(ImmutableList_T__int_B).md#Atropos_ImmutableList_SetItem_T_B_(Atropos_ImmutableList_T__int_B)_B 'Atropos.ImmutableList.SetItem&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).B')[&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')  
A new list that contains the new element
#### Exceptions
[System.IndexOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.IndexOutOfRangeException 'System.IndexOutOfRangeException')  
Thrown when [index](ImmutableList_SetItem_T_B_(ImmutableList_T__int_B).md#Atropos_ImmutableList_SetItem_T_B_(Atropos_ImmutableList_T__int_B)_index 'Atropos.ImmutableList.SetItem&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).index') is outside of the [list](ImmutableList_SetItem_T_B_(ImmutableList_T__int_B).md#Atropos_ImmutableList_SetItem_T_B_(Atropos_ImmutableList_T__int_B)_list 'Atropos.ImmutableList.SetItem&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).list') bounds.
### Remarks
Warning: the operation asymptotic is O([list](ImmutableList_SetItem_T_B_(ImmutableList_T__int_B).md#Atropos_ImmutableList_SetItem_T_B_(Atropos_ImmutableList_T__int_B)_list 'Atropos.ImmutableList.SetItem&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).list').Count), as we have to clone the list.  
            Reusing the nodes of the original list is impossible due to the limitations of the C# type system: Node<[T](ImmutableList_SetItem_T_B_(ImmutableList_T__int_B).md#Atropos_ImmutableList_SetItem_T_B_(Atropos_ImmutableList_T__int_B)_T 'Atropos.ImmutableList.SetItem&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).T')> cannot be made covariant, and   
            storing INode<[T](ImmutableList_SetItem_T_B_(ImmutableList_T__int_B).md#Atropos_ImmutableList_SetItem_T_B_(Atropos_ImmutableList_T__int_B)_T 'Atropos.ImmutableList.SetItem&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).T')> would kill the performance due to the indirect call.
