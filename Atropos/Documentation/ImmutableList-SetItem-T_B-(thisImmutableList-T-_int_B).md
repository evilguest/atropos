### [Atropos](./Atropos.md 'Atropos').[ImmutableList](./ImmutableList.md 'Atropos.ImmutableList')
## ImmutableList.SetItem&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B) Method
Makes a copy of the list, and replaces an element in the list at a given position with the specified element.  
```csharp
public static Atropos.ImmutableList<B> SetItem<T,B>(this Atropos.ImmutableList<T> list, int index, B value);
```
#### Type parameters
<a name='Atropos-ImmutableList-SetItem-T_B-(Atropos-ImmutableList-T-_int_B)-T'></a>
`T`  
Type of the original list items  
  
<a name='Atropos-ImmutableList-SetItem-T_B-(Atropos-ImmutableList-T-_int_B)-B'></a>
`B`  
Type of the new element  
  
#### Parameters
<a name='Atropos-ImmutableList-SetItem-T_B-(Atropos-ImmutableList-T-_int_B)-list'></a>
`list` [Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[T](#Atropos-ImmutableList-SetItem-T_B-(Atropos-ImmutableList-T-_int_B)-T 'Atropos.ImmutableList.SetItem&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).T')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
Original list  
  
<a name='Atropos-ImmutableList-SetItem-T_B-(Atropos-ImmutableList-T-_int_B)-index'></a>
`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The position in the list of the element to replace.  
  
<a name='Atropos-ImmutableList-SetItem-T_B-(Atropos-ImmutableList-T-_int_B)-value'></a>
`value` [B](#Atropos-ImmutableList-SetItem-T_B-(Atropos-ImmutableList-T-_int_B)-B 'Atropos.ImmutableList.SetItem&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).B')  
The element to replace the old element with.  
  
#### Returns
[Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[B](#Atropos-ImmutableList-SetItem-T_B-(Atropos-ImmutableList-T-_int_B)-B 'Atropos.ImmutableList.SetItem&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).B')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
A new list that contains the new element  
#### Exceptions
[System.IndexOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.IndexOutOfRangeException 'System.IndexOutOfRangeException')  
Thrown when [index](#Atropos-ImmutableList-SetItem-T_B-(Atropos-ImmutableList-T-_int_B)-index 'Atropos.ImmutableList.SetItem&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).index') is outside of the [list](#Atropos-ImmutableList-SetItem-T_B-(Atropos-ImmutableList-T-_int_B)-list 'Atropos.ImmutableList.SetItem&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).list') bounds.  
### Remarks
Warning: the operation asymptotic is O([list](#Atropos-ImmutableList-SetItem-T_B-(Atropos-ImmutableList-T-_int_B)-list 'Atropos.ImmutableList.SetItem&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).list').Count), as we have to clone the list.  
            Reusing the nodes of the original list is impossible due to the limitations of the C# type system: Node<[T](#Atropos-ImmutableList-SetItem-T_B-(Atropos-ImmutableList-T-_int_B)-T 'Atropos.ImmutableList.SetItem&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).T')> cannot be made covariant, and   
            storing INode<[T](#Atropos-ImmutableList-SetItem-T_B-(Atropos-ImmutableList-T-_int_B)-T 'Atropos.ImmutableList.SetItem&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).T')> would kill the performance due to the indirect call.  
