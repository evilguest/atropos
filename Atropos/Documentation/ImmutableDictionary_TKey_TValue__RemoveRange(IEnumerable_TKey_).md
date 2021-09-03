### [Atropos](Atropos.md 'Atropos').[ImmutableDictionary&lt;TKey,TValue&gt;](ImmutableDictionary_TKey_TValue_.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;')
## ImmutableDictionary&lt;TKey,TValue&gt;.RemoveRange(IEnumerable&lt;TKey&gt;) Method
Removes the specified keys from the dictionary with their associated values.  
```csharp
public Atropos.ImmutableDictionary<TKey,TValue> RemoveRange(System.Collections.Generic.IEnumerable<TKey> keys);
```
#### Parameters
<a name='Atropos_ImmutableDictionary_TKey_TValue__RemoveRange(System_Collections_Generic_IEnumerable_TKey_)_keys'></a>
`keys` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[TKey](ImmutableDictionary_TKey_TValue_.md#Atropos_ImmutableDictionary_TKey_TValue__TKey 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TKey')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The keys to remove.
  
#### Returns
[Atropos.ImmutableDictionary&lt;](ImmutableDictionary_TKey_TValue_.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;')[TKey](ImmutableDictionary_TKey_TValue_.md#Atropos_ImmutableDictionary_TKey_TValue__TKey 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TKey')[,](ImmutableDictionary_TKey_TValue_.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;')[TValue](ImmutableDictionary_TKey_TValue_.md#Atropos_ImmutableDictionary_TKey_TValue__TValue 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TValue')[&gt;](ImmutableDictionary_TKey_TValue_.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;')  
A new dictionary with those keys removed; or this instance if those keys are not in the dictionary.

Implements [RemoveRange(IEnumerable<TKey>)](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Immutable.IImmutableDictionary-2.RemoveRange#System_Collections_Immutable_IImmutableDictionary_2_RemoveRange_System_Collections_Generic_IEnumerable{_0}_ 'System.Collections.Immutable.IImmutableDictionary`2.RemoveRange(System.Collections.Generic.IEnumerable{`0})')  
