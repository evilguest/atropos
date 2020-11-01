### [Atropos](./Atropos.md 'Atropos').[ImmutableList](./ImmutableList.md 'Atropos.ImmutableList')
## ImmutableList.AddRange&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;B&gt;) Method
Adds a range of items to the immutable list  
```csharp
public static Atropos.ImmutableList<B> AddRange<T,B>(this Atropos.ImmutableList<T> list, System.Collections.Generic.IEnumerable<B> items);
```
#### Type parameters
<a name='Atropos-ImmutableList-AddRange-T_B-(Atropos-ImmutableList-T-_System-Collections-Generic-IEnumerable-B-)-T'></a>
`T`  
Element type of the original list  
  
<a name='Atropos-ImmutableList-AddRange-T_B-(Atropos-ImmutableList-T-_System-Collections-Generic-IEnumerable-B-)-B'></a>
`B`  
Added item type  
  
#### Parameters
<a name='Atropos-ImmutableList-AddRange-T_B-(Atropos-ImmutableList-T-_System-Collections-Generic-IEnumerable-B-)-list'></a>
`list` [Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[T](#Atropos-ImmutableList-AddRange-T_B-(Atropos-ImmutableList-T-_System-Collections-Generic-IEnumerable-B-)-T 'Atropos.ImmutableList.AddRange&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;B&gt;).T')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
Original immutable list  
  
<a name='Atropos-ImmutableList-AddRange-T_B-(Atropos-ImmutableList-T-_System-Collections-Generic-IEnumerable-B-)-items'></a>
`items` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[B](#Atropos-ImmutableList-AddRange-T_B-(Atropos-ImmutableList-T-_System-Collections-Generic-IEnumerable-B-)-B 'Atropos.ImmutableList.AddRange&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;B&gt;).B')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The list of items to add  
  
#### Returns
[Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[B](#Atropos-ImmutableList-AddRange-T_B-(Atropos-ImmutableList-T-_System-Collections-Generic-IEnumerable-B-)-B 'Atropos.ImmutableList.AddRange&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;B&gt;).B')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
A new immutable list equal to the original list with the [items](#Atropos-ImmutableList-AddRange-T_B-(Atropos-ImmutableList-T-_System-Collections-Generic-IEnumerable-B-)-items 'Atropos.ImmutableList.AddRange&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;B&gt;).items') added at the end.  
