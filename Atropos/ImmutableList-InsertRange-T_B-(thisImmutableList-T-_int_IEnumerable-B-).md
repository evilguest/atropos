### [Atropos](./Atropos.md 'Atropos').[ImmutableList](./ImmutableList.md 'Atropos.ImmutableList')
## ImmutableList.InsertRange&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, System.Collections.Generic.IEnumerable&lt;B&gt;) Method
Inserts the specified elements at the specified index in the immutable list.  
```csharp
public static Atropos.ImmutableList<B> InsertRange<T,B>(this Atropos.ImmutableList<T> list, int index, System.Collections.Generic.IEnumerable<B> items);
```
#### Type parameters
<a name='Atropos-ImmutableList-InsertRange-T_B-(Atropos-ImmutableList-T-_int_System-Collections-Generic-IEnumerable-B-)-T'></a>
`T`  
Element type of the original list  
  
<a name='Atropos-ImmutableList-InsertRange-T_B-(Atropos-ImmutableList-T-_int_System-Collections-Generic-IEnumerable-B-)-B'></a>
`B`  
Added item type  
  
#### Parameters
<a name='Atropos-ImmutableList-InsertRange-T_B-(Atropos-ImmutableList-T-_int_System-Collections-Generic-IEnumerable-B-)-list'></a>
`list` [Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[T](#Atropos-ImmutableList-InsertRange-T_B-(Atropos-ImmutableList-T-_int_System-Collections-Generic-IEnumerable-B-)-T 'Atropos.ImmutableList.InsertRange&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, System.Collections.Generic.IEnumerable&lt;B&gt;).T')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
Original immutable list  
  
<a name='Atropos-ImmutableList-InsertRange-T_B-(Atropos-ImmutableList-T-_int_System-Collections-Generic-IEnumerable-B-)-index'></a>
`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The zero-based index at which the new elements should be inserted.  
  
<a name='Atropos-ImmutableList-InsertRange-T_B-(Atropos-ImmutableList-T-_int_System-Collections-Generic-IEnumerable-B-)-items'></a>
`items` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[B](#Atropos-ImmutableList-InsertRange-T_B-(Atropos-ImmutableList-T-_int_System-Collections-Generic-IEnumerable-B-)-B 'Atropos.ImmutableList.InsertRange&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, System.Collections.Generic.IEnumerable&lt;B&gt;).B')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The elements to insert.  
  
#### Returns
[Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[B](#Atropos-ImmutableList-InsertRange-T_B-(Atropos-ImmutableList-T-_int_System-Collections-Generic-IEnumerable-B-)-B 'Atropos.ImmutableList.InsertRange&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, System.Collections.Generic.IEnumerable&lt;B&gt;).B')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
A new immutable list that includes the specified elements.  
