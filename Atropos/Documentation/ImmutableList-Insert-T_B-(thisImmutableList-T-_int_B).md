### [Atropos](./Atropos.md 'Atropos').[ImmutableList](./ImmutableList.md 'Atropos.ImmutableList')
## ImmutableList.Insert&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B) Method
Makes a copy of the list, and inserts the specified [value](#Atropos-ImmutableList-Insert-T_B-(Atropos-ImmutableList-T-_int_B)-value 'Atropos.ImmutableList.Insert&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).value') at the specified [index](#Atropos-ImmutableList-Insert-T_B-(Atropos-ImmutableList-T-_int_B)-index 'Atropos.ImmutableList.Insert&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).index').  
```csharp
public static Atropos.ImmutableList<B> Insert<T,B>(this Atropos.ImmutableList<T> list, int index, B value);
```
#### Type parameters
<a name='Atropos-ImmutableList-Insert-T_B-(Atropos-ImmutableList-T-_int_B)-T'></a>
`T`  
Type of the original list items  
  
<a name='Atropos-ImmutableList-Insert-T_B-(Atropos-ImmutableList-T-_int_B)-B'></a>
`B`  
Type of the value to add  
  
#### Parameters
<a name='Atropos-ImmutableList-Insert-T_B-(Atropos-ImmutableList-T-_int_B)-list'></a>
`list` [Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[T](#Atropos-ImmutableList-Insert-T_B-(Atropos-ImmutableList-T-_int_B)-T 'Atropos.ImmutableList.Insert&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).T')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
Original list  
  
<a name='Atropos-ImmutableList-Insert-T_B-(Atropos-ImmutableList-T-_int_B)-index'></a>
`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Position of the insertion  
  
<a name='Atropos-ImmutableList-Insert-T_B-(Atropos-ImmutableList-T-_int_B)-value'></a>
`value` [B](#Atropos-ImmutableList-Insert-T_B-(Atropos-ImmutableList-T-_int_B)-B 'Atropos.ImmutableList.Insert&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).B')  
The object to insert into the list  
  
#### Returns
[Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[B](#Atropos-ImmutableList-Insert-T_B-(Atropos-ImmutableList-T-_int_B)-B 'Atropos.ImmutableList.Insert&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).B')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
A new list with the object added  
#### Exceptions
[System.IndexOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.IndexOutOfRangeException 'System.IndexOutOfRangeException')  
Thrown when [index](#Atropos-ImmutableList-Insert-T_B-(Atropos-ImmutableList-T-_int_B)-index 'Atropos.ImmutableList.Insert&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).index') is outside of the [list](#Atropos-ImmutableList-Insert-T_B-(Atropos-ImmutableList-T-_int_B)-list 'Atropos.ImmutableList.Insert&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).list') bounds.  
### Remarks
Warning: the operation asymptotic is O([list](#Atropos-ImmutableList-Insert-T_B-(Atropos-ImmutableList-T-_int_B)-list 'Atropos.ImmutableList.Insert&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).list').Count), as we have to clone the list.  
            Reusing the nodes of the original list is impossible due to the limitations of the C# type system: Node<[T](#Atropos-ImmutableList-Insert-T_B-(Atropos-ImmutableList-T-_int_B)-T 'Atropos.ImmutableList.Insert&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).T')> cannot be made covariant, and   
            storing INode<[T](#Atropos-ImmutableList-Insert-T_B-(Atropos-ImmutableList-T-_int_B)-T 'Atropos.ImmutableList.Insert&lt;T,B&gt;(Atropos.ImmutableList&lt;T&gt;, int, B).T')> would kill the performance due to the indirect call.  
