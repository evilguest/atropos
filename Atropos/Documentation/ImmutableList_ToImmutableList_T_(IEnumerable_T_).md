### [Atropos](Atropos.md 'Atropos').[ImmutableList](ImmutableList.md 'Atropos.ImmutableList')
## ImmutableList.ToImmutableList&lt;T&gt;(IEnumerable&lt;T&gt;) Method
Creates an [ImmutableList&lt;T&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;') from [System.Collections.Generic.IEnumerable&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1').  
```csharp
public static Atropos.ImmutableList<T> ToImmutableList<T>(this System.Collections.Generic.IEnumerable<T> items);
```
#### Type parameters
<a name='Atropos_ImmutableList_ToImmutableList_T_(System_Collections_Generic_IEnumerable_T_)_T'></a>
`T`  
Type of the list items
  
#### Parameters
<a name='Atropos_ImmutableList_ToImmutableList_T_(System_Collections_Generic_IEnumerable_T_)_items'></a>
`items` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](ImmutableList_ToImmutableList_T_(IEnumerable_T_).md#Atropos_ImmutableList_ToImmutableList_T_(System_Collections_Generic_IEnumerable_T_)_T 'Atropos.ImmutableList.ToImmutableList&lt;T&gt;(System.Collections.Generic.IEnumerable&lt;T&gt;).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
Collection of items to initialize
  
#### Returns
[Atropos.ImmutableList&lt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')[T](ImmutableList_ToImmutableList_T_(IEnumerable_T_).md#Atropos_ImmutableList_ToImmutableList_T_(System_Collections_Generic_IEnumerable_T_)_T 'Atropos.ImmutableList.ToImmutableList&lt;T&gt;(System.Collections.Generic.IEnumerable&lt;T&gt;).T')[&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')  
An [ImmutableList&lt;T&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;') that contais all the elements of the input sequence.
### Remarks
Implementation is eager. Do not call on the infinite sequences.
