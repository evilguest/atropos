### [Atropos](./Atropos.md 'Atropos').[ImmutableList](./ImmutableList.md 'Atropos.ImmutableList')
## ImmutableList.SetItem&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B) Method
Replaces an element in the list at a given position with the specified element.  
```csharp
public static Atropos.ImmutableList<B> SetItem<T,B>(this Atropos.ImmutableList<T> list, int index, B value);
```
#### Type parameters
<a name='Atropos-ImmutableList-SetItem-T_B-(Atropos-ImmutableList-T-_int_B)-T'></a>
`T`  
Element type of the original list  
  
<a name='Atropos-ImmutableList-SetItem-T_B-(Atropos-ImmutableList-T-_int_B)-B'></a>
`B`  
The type of the replacement value. Must be an ancestor of [T](#Atropos-ImmutableList-SetItem-T_B-(Atropos-ImmutableList-T-_int_B)-T 'Atropos.ImmutableList.SetItem&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).T').  
  
#### Parameters
<a name='Atropos-ImmutableList-SetItem-T_B-(Atropos-ImmutableList-T-_int_B)-list'></a>
`list` [Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[T](#Atropos-ImmutableList-SetItem-T_B-(Atropos-ImmutableList-T-_int_B)-T 'Atropos.ImmutableList.SetItem&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).T')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
Original immutable list  
  
<a name='Atropos-ImmutableList-SetItem-T_B-(Atropos-ImmutableList-T-_int_B)-index'></a>
`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The position in the list of the element to replace.  
  
<a name='Atropos-ImmutableList-SetItem-T_B-(Atropos-ImmutableList-T-_int_B)-value'></a>
`value` [B](#Atropos-ImmutableList-SetItem-T_B-(Atropos-ImmutableList-T-_int_B)-B 'Atropos.ImmutableList.SetItem&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).B')  
The element to replace the old element with.  
  
#### Returns
[Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[B](#Atropos-ImmutableList-SetItem-T_B-(Atropos-ImmutableList-T-_int_B)-B 'Atropos.ImmutableList.SetItem&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).B')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
A new list that contains the new element, even if the element at the specified  
            location is the same as the new element.  
