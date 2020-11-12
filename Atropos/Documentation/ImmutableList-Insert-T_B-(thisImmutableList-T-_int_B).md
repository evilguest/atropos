### [Atropos](./Atropos.md 'Atropos').[ImmutableList](./ImmutableList.md 'Atropos.ImmutableList')
## ImmutableList.Insert&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B) Method
Inserts the specified element at the specified index in the immutable list.  
```csharp
public static Atropos.ImmutableList<B> Insert<T,B>(this Atropos.ImmutableList<T> list, int index, B element);
```
#### Type parameters
<a name='Atropos-ImmutableList-Insert-T_B-(Atropos-ImmutableList-T-_int_B)-T'></a>
`T`  
Element type of the original list  
  
<a name='Atropos-ImmutableList-Insert-T_B-(Atropos-ImmutableList-T-_int_B)-B'></a>
`B`  
Added item type  
  
#### Parameters
<a name='Atropos-ImmutableList-Insert-T_B-(Atropos-ImmutableList-T-_int_B)-list'></a>
`list` [Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[T](#Atropos-ImmutableList-Insert-T_B-(Atropos-ImmutableList-T-_int_B)-T 'Atropos.ImmutableList.Insert&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).T')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
Original immutable list  
  
<a name='Atropos-ImmutableList-Insert-T_B-(Atropos-ImmutableList-T-_int_B)-index'></a>
`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The zero-based index at which to insert the value.  
  
<a name='Atropos-ImmutableList-Insert-T_B-(Atropos-ImmutableList-T-_int_B)-element'></a>
`element` [B](#Atropos-ImmutableList-Insert-T_B-(Atropos-ImmutableList-T-_int_B)-B 'Atropos.ImmutableList.Insert&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).B')  
The object to insert.  
  
#### Returns
[Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[B](#Atropos-ImmutableList-Insert-T_B-(Atropos-ImmutableList-T-_int_B)-B 'Atropos.ImmutableList.Insert&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).B')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
A new immutable list that includes the specified element.  
