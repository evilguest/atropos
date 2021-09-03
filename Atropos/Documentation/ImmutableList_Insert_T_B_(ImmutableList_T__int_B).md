### [Atropos](Atropos.md 'Atropos').[ImmutableList](ImmutableList.md 'Atropos.ImmutableList')
## ImmutableList.Insert&lt;T,B&gt;(ImmutableList&lt;T&gt;, int, B) Method
Makes a copy of the list, and inserts the specified [value](ImmutableList_Insert_T_B_(ImmutableList_T__int_B).md#Atropos_ImmutableList_Insert_T_B_(Atropos_ImmutableList_T__int_B)_value 'Atropos.ImmutableList.Insert&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).value') at the specified [index](ImmutableList_Insert_T_B_(ImmutableList_T__int_B).md#Atropos_ImmutableList_Insert_T_B_(Atropos_ImmutableList_T__int_B)_index 'Atropos.ImmutableList.Insert&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).index').  
```csharp
public static Atropos.ImmutableList<B> Insert<T,B>(this Atropos.ImmutableList<T> list, int index, B value)
    where T : class, B;
```
#### Type parameters
<a name='Atropos_ImmutableList_Insert_T_B_(Atropos_ImmutableList_T__int_B)_T'></a>
`T`  
Type of the original list items
  
<a name='Atropos_ImmutableList_Insert_T_B_(Atropos_ImmutableList_T__int_B)_B'></a>
`B`  
Type of the value to add
  
#### Parameters
<a name='Atropos_ImmutableList_Insert_T_B_(Atropos_ImmutableList_T__int_B)_list'></a>
`list` [Atropos.ImmutableList&lt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')[T](ImmutableList_Insert_T_B_(ImmutableList_T__int_B).md#Atropos_ImmutableList_Insert_T_B_(Atropos_ImmutableList_T__int_B)_T 'Atropos.ImmutableList.Insert&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).T')[&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')  
Original list
  
<a name='Atropos_ImmutableList_Insert_T_B_(Atropos_ImmutableList_T__int_B)_index'></a>
`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Position of the insertion
  
<a name='Atropos_ImmutableList_Insert_T_B_(Atropos_ImmutableList_T__int_B)_value'></a>
`value` [B](ImmutableList_Insert_T_B_(ImmutableList_T__int_B).md#Atropos_ImmutableList_Insert_T_B_(Atropos_ImmutableList_T__int_B)_B 'Atropos.ImmutableList.Insert&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).B')  
The object to insert into the list
  
#### Returns
[Atropos.ImmutableList&lt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')[B](ImmutableList_Insert_T_B_(ImmutableList_T__int_B).md#Atropos_ImmutableList_Insert_T_B_(Atropos_ImmutableList_T__int_B)_B 'Atropos.ImmutableList.Insert&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).B')[&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')  
A new list with the object added
#### Exceptions
[System.IndexOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.IndexOutOfRangeException 'System.IndexOutOfRangeException')  
Thrown when [index](ImmutableList_Insert_T_B_(ImmutableList_T__int_B).md#Atropos_ImmutableList_Insert_T_B_(Atropos_ImmutableList_T__int_B)_index 'Atropos.ImmutableList.Insert&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).index') is outside of the [list](ImmutableList_Insert_T_B_(ImmutableList_T__int_B).md#Atropos_ImmutableList_Insert_T_B_(Atropos_ImmutableList_T__int_B)_list 'Atropos.ImmutableList.Insert&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).list') bounds.
### Remarks
Warning: the operation asymptotic is O([list](ImmutableList_Insert_T_B_(ImmutableList_T__int_B).md#Atropos_ImmutableList_Insert_T_B_(Atropos_ImmutableList_T__int_B)_list 'Atropos.ImmutableList.Insert&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).list').Count), as we have to clone the list.  
            Reusing the nodes of the original list is impossible due to the limitations of the C# type system: Node<[T](ImmutableList_Insert_T_B_(ImmutableList_T__int_B).md#Atropos_ImmutableList_Insert_T_B_(Atropos_ImmutableList_T__int_B)_T 'Atropos.ImmutableList.Insert&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).T')> cannot be made covariant, and   
            storing INode<[T](ImmutableList_Insert_T_B_(ImmutableList_T__int_B).md#Atropos_ImmutableList_Insert_T_B_(Atropos_ImmutableList_T__int_B)_T 'Atropos.ImmutableList.Insert&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).T')> would kill the performance due to the indirect call.
