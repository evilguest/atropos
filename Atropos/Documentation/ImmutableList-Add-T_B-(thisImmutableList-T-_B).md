### [Atropos](./Atropos.md 'Atropos').[ImmutableList](./ImmutableList.md 'Atropos.ImmutableList')
## ImmutableList.Add&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, B) Method
Makes a copy of the list, and adds the specified [value](#Atropos-ImmutableList-Add-T_B-(Atropos-ImmutableList-T-_B)-value 'Atropos.ImmutableList.Add&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, B).value') to the end of the copied list.  
```csharp
public static Atropos.ImmutableList<B> Add<T,B>(this Atropos.ImmutableList<T> list, B value);
```
#### Type parameters
<a name='Atropos-ImmutableList-Add-T_B-(Atropos-ImmutableList-T-_B)-T'></a>
`T`  
Type of the original list items  
  
<a name='Atropos-ImmutableList-Add-T_B-(Atropos-ImmutableList-T-_B)-B'></a>
`B`  
Type of the value to add  
  
#### Parameters
<a name='Atropos-ImmutableList-Add-T_B-(Atropos-ImmutableList-T-_B)-list'></a>
`list` [Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[T](#Atropos-ImmutableList-Add-T_B-(Atropos-ImmutableList-T-_B)-T 'Atropos.ImmutableList.Add&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, B).T')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
Original list  
  
<a name='Atropos-ImmutableList-Add-T_B-(Atropos-ImmutableList-T-_B)-value'></a>
`value` [B](#Atropos-ImmutableList-Add-T_B-(Atropos-ImmutableList-T-_B)-B 'Atropos.ImmutableList.Add&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, B).B')  
The object to add to the list  
  
#### Returns
[Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[B](#Atropos-ImmutableList-Add-T_B-(Atropos-ImmutableList-T-_B)-B 'Atropos.ImmutableList.Add&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, B).B')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
A new list with the object added  
### Remarks
Warning: the operation asymptotic is O([list](#Atropos-ImmutableList-Add-T_B-(Atropos-ImmutableList-T-_B)-list 'Atropos.ImmutableList.Add&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, B).list').Count), as we have to clone the list.  
            Reusing the nodes of the original list is impossible due to the limitations of the C# type system: Node<[T](#Atropos-ImmutableList-Add-T_B-(Atropos-ImmutableList-T-_B)-T 'Atropos.ImmutableList.Add&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, B).T')> cannot be made covariant, and   
            storing INode<[T](#Atropos-ImmutableList-Add-T_B-(Atropos-ImmutableList-T-_B)-T 'Atropos.ImmutableList.Add&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, B).T')> would kill the performance due to the indirect call.  
