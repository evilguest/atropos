### [Atropos](Atropos.md 'Atropos').[ImmutableList](ImmutableList.md 'Atropos.ImmutableList')
## ImmutableList.Add&lt;T,B&gt;(ImmutableList&lt;T&gt;, B) Method
Makes a copy of the list, and adds the specified [value](ImmutableList_Add_T_B_(ImmutableList_T__B).md#Atropos_ImmutableList_Add_T_B_(Atropos_ImmutableList_T__B)_value 'Atropos.ImmutableList.Add&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, B).value') to the end of the copied list.  
```csharp
public static Atropos.ImmutableList<B> Add<T,B>(this Atropos.ImmutableList<T> list, B value)
    where T : class, B;
```
#### Type parameters
<a name='Atropos_ImmutableList_Add_T_B_(Atropos_ImmutableList_T__B)_T'></a>
`T`  
Type of the original list items
  
<a name='Atropos_ImmutableList_Add_T_B_(Atropos_ImmutableList_T__B)_B'></a>
`B`  
Type of the value to add
  
#### Parameters
<a name='Atropos_ImmutableList_Add_T_B_(Atropos_ImmutableList_T__B)_list'></a>
`list` [Atropos.ImmutableList&lt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')[T](ImmutableList_Add_T_B_(ImmutableList_T__B).md#Atropos_ImmutableList_Add_T_B_(Atropos_ImmutableList_T__B)_T 'Atropos.ImmutableList.Add&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, B).T')[&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')  
Original list
  
<a name='Atropos_ImmutableList_Add_T_B_(Atropos_ImmutableList_T__B)_value'></a>
`value` [B](ImmutableList_Add_T_B_(ImmutableList_T__B).md#Atropos_ImmutableList_Add_T_B_(Atropos_ImmutableList_T__B)_B 'Atropos.ImmutableList.Add&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, B).B')  
The object to add to the list
  
#### Returns
[Atropos.ImmutableList&lt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')[B](ImmutableList_Add_T_B_(ImmutableList_T__B).md#Atropos_ImmutableList_Add_T_B_(Atropos_ImmutableList_T__B)_B 'Atropos.ImmutableList.Add&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, B).B')[&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')  
A new list with the object added
### Remarks
Warning: the operation asymptotic is O([list](ImmutableList_Add_T_B_(ImmutableList_T__B).md#Atropos_ImmutableList_Add_T_B_(Atropos_ImmutableList_T__B)_list 'Atropos.ImmutableList.Add&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, B).list').Count), as we have to clone the list.  
            Reusing the nodes of the original list is impossible due to the limitations of the C# type system: Node<[T](ImmutableList_Add_T_B_(ImmutableList_T__B).md#Atropos_ImmutableList_Add_T_B_(Atropos_ImmutableList_T__B)_T 'Atropos.ImmutableList.Add&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, B).T')> cannot be made covariant, and   
            storing INode<[T](ImmutableList_Add_T_B_(ImmutableList_T__B).md#Atropos_ImmutableList_Add_T_B_(Atropos_ImmutableList_T__B)_T 'Atropos.ImmutableList.Add&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, B).T')> would kill the performance due to the indirect call.
