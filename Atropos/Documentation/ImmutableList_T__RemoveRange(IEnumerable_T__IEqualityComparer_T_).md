### [Atropos](Atropos.md 'Atropos').[ImmutableList&lt;T&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')
## ImmutableList&lt;T&gt;.RemoveRange(IEnumerable&lt;T&gt;, IEqualityComparer&lt;T&gt;) Method
Removes the specified objects from the list.  
```csharp
public Atropos.ImmutableList<T> RemoveRange(System.Collections.Generic.IEnumerable<T> items, System.Collections.Generic.IEqualityComparer<T> equalityComparer=null);
```
#### Parameters
<a name='Atropos_ImmutableList_T__RemoveRange(System_Collections_Generic_IEnumerable_T__System_Collections_Generic_IEqualityComparer_T_)_items'></a>
`items` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The objects to remove from the list.
  
<a name='Atropos_ImmutableList_T__RemoveRange(System_Collections_Generic_IEnumerable_T__System_Collections_Generic_IEqualityComparer_T_)_equalityComparer'></a>
`equalityComparer` [System.Collections.Generic.IEqualityComparer&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1')[T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1')  
The comparer to use when searchign for [items](ImmutableList_T__RemoveRange(IEnumerable_T__IEqualityComparer_T_).md#Atropos_ImmutableList_T__RemoveRange(System_Collections_Generic_IEnumerable_T__System_Collections_Generic_IEqualityComparer_T_)_items 'Atropos.ImmutableList&lt;T&gt;.RemoveRange(System.Collections.Generic.IEnumerable&lt;T&gt;, System.Collections.Generic.IEqualityComparer&lt;T&gt;).items').
  
#### Returns
[Atropos.ImmutableList&lt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')[T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')  
A new immutable list with the specified objects removed, if items matched objects in the list.

Implements [RemoveRange(IEnumerable<T>, IEqualityComparer<T>)](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Immutable.IImmutableList-1.RemoveRange#System_Collections_Immutable_IImmutableList_1_RemoveRange_System_Collections_Generic_IEnumerable{_0},System_Collections_Generic_IEqualityComparer{_0}_ 'System.Collections.Immutable.IImmutableList`1.RemoveRange(System.Collections.Generic.IEnumerable{`0},System.Collections.Generic.IEqualityComparer{`0})')  
