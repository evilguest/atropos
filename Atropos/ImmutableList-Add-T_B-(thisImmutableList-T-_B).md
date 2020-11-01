### [Atropos](./Atropos.md 'Atropos').[ImmutableList](./ImmutableList.md 'Atropos.ImmutableList')
## ImmutableList.Add&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, B) Method
Makes a copy of the list, and adds the specified object to the end of the copied  
    list.  
```csharp
public static Atropos.ImmutableList<B> Add<T,B>(this Atropos.ImmutableList<T> list, B value);
```
#### Type parameters
<a name='Atropos-ImmutableList-Add-T_B-(Atropos-ImmutableList-T-_B)-T'></a>
`T`  
Element type of the original list  
  
<a name='Atropos-ImmutableList-Add-T_B-(Atropos-ImmutableList-T-_B)-B'></a>
`B`  
Added item type  
  
#### Parameters
<a name='Atropos-ImmutableList-Add-T_B-(Atropos-ImmutableList-T-_B)-list'></a>
`list` [Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[T](#Atropos-ImmutableList-Add-T_B-(Atropos-ImmutableList-T-_B)-T 'Atropos.ImmutableList.Add&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, B).T')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
Original immutable list  
  
<a name='Atropos-ImmutableList-Add-T_B-(Atropos-ImmutableList-T-_B)-value'></a>
`value` [B](#Atropos-ImmutableList-Add-T_B-(Atropos-ImmutableList-T-_B)-B 'Atropos.ImmutableList.Add&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, B).B')  
The object to add to the list  
  
#### Returns
[Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[B](#Atropos-ImmutableList-Add-T_B-(Atropos-ImmutableList-T-_B)-B 'Atropos.ImmutableList.Add&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, B).B')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
A new list with the object added  
