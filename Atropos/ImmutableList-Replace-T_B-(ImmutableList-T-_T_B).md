### [Atropos](./Atropos.md 'Atropos').[ImmutableList](./ImmutableList.md 'Atropos.ImmutableList')
## ImmutableList.Replace&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, T, B) Method
Returns a new list with the first matching element in the list replaced with   
the specified element.  
```csharp
public static Atropos.ImmutableList<B> Replace<T,B>(Atropos.ImmutableList<T> list, T oldValue, B newValue);
```
#### Type parameters
<a name='Atropos-ImmutableList-Replace-T_B-(Atropos-ImmutableList-T-_T_B)-T'></a>
`T`  
Element type of the original list  
  
<a name='Atropos-ImmutableList-Replace-T_B-(Atropos-ImmutableList-T-_T_B)-B'></a>
`B`  
Added item type  
  
#### Parameters
<a name='Atropos-ImmutableList-Replace-T_B-(Atropos-ImmutableList-T-_T_B)-list'></a>
`list` [Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[T](#Atropos-ImmutableList-Replace-T_B-(Atropos-ImmutableList-T-_T_B)-T 'Atropos.ImmutableList.Replace&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, T, B).T')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
Original immutable list  
  
<a name='Atropos-ImmutableList-Replace-T_B-(Atropos-ImmutableList-T-_T_B)-oldValue'></a>
`oldValue` [T](#Atropos-ImmutableList-Replace-T_B-(Atropos-ImmutableList-T-_T_B)-T 'Atropos.ImmutableList.Replace&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, T, B).T')  
The element to be replaced.  
  
<a name='Atropos-ImmutableList-Replace-T_B-(Atropos-ImmutableList-T-_T_B)-newValue'></a>
`newValue` [B](#Atropos-ImmutableList-Replace-T_B-(Atropos-ImmutableList-T-_T_B)-B 'Atropos.ImmutableList.Replace&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, T, B).B')  
The element to replace the first occurrence of oldValue with  
  
#### Returns
[Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[B](#Atropos-ImmutableList-Replace-T_B-(Atropos-ImmutableList-T-_T_B)-B 'Atropos.ImmutableList.Replace&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, T, B).B')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
A new list that contains newValue, even if oldvalue is the same as newValue.  
