### [Atropos](Atropos.md 'Atropos').[ImmutableList&lt;T&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')
## ImmutableList&lt;T&gt;.Replace(T, T, IEqualityComparer&lt;T&gt;) Method
Returns a new list with the first matching element in the list replaced with the specified element.  
```csharp
public Atropos.ImmutableList<T> Replace(T oldValue, T newValue, System.Collections.Generic.IEqualityComparer<T> equalityComparer=null);
```
#### Parameters
<a name='Atropos_ImmutableList_T__Replace(T_T_System_Collections_Generic_IEqualityComparer_T_)_oldValue'></a>
`oldValue` [T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')  
The element to be replaced.
  
<a name='Atropos_ImmutableList_T__Replace(T_T_System_Collections_Generic_IEqualityComparer_T_)_newValue'></a>
`newValue` [T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')  
The element to replace the first occurrence of [oldValue](ImmutableList_T__Replace(T_T_IEqualityComparer_T_).md#Atropos_ImmutableList_T__Replace(T_T_System_Collections_Generic_IEqualityComparer_T_)_oldValue 'Atropos.ImmutableList&lt;T&gt;.Replace(T, T, System.Collections.Generic.IEqualityComparer&lt;T&gt;).oldValue') with
  
<a name='Atropos_ImmutableList_T__Replace(T_T_System_Collections_Generic_IEqualityComparer_T_)_equalityComparer'></a>
`equalityComparer` [System.Collections.Generic.IEqualityComparer&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1')[T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1')  
The equality comparer to use for matching [oldValue](ImmutableList_T__Replace(T_T_IEqualityComparer_T_).md#Atropos_ImmutableList_T__Replace(T_T_System_Collections_Generic_IEqualityComparer_T_)_oldValue 'Atropos.ImmutableList&lt;T&gt;.Replace(T, T, System.Collections.Generic.IEqualityComparer&lt;T&gt;).oldValue').
  
#### Returns
[Atropos.ImmutableList&lt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')[T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')  
#### Exceptions
[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
[oldValue](ImmutableList_T__Replace(T_T_IEqualityComparer_T_).md#Atropos_ImmutableList_T__Replace(T_T_System_Collections_Generic_IEqualityComparer_T_)_oldValue 'Atropos.ImmutableList&lt;T&gt;.Replace(T, T, System.Collections.Generic.IEqualityComparer&lt;T&gt;).oldValue') does not exist in the list.

Implements [Replace(T, T, IEqualityComparer<T>)](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Immutable.IImmutableList-1.Replace#System_Collections_Immutable_IImmutableList_1_Replace__0,_0,System_Collections_Generic_IEqualityComparer{_0}_ 'System.Collections.Immutable.IImmutableList`1.Replace(`0,`0,System.Collections.Generic.IEqualityComparer{`0})')  
