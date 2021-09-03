### [Atropos](Atropos.md 'Atropos').[ImmutableDictionary&lt;TKey,TValue&gt;](ImmutableDictionary_TKey_TValue_.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;')
## ImmutableDictionary&lt;TKey,TValue&gt;.SetItems(IEnumerable&lt;KeyValuePair&lt;TKey,TValue&gt;&gt;) Method
Applies a given set of key=value pairs to an immutable dictionary, replacing any conflicting keys in the resulting dictionary.  
```csharp
public Atropos.ImmutableDictionary<TKey,TValue> SetItems(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TKey,TValue>> items);
```
#### Parameters
<a name='Atropos_ImmutableDictionary_TKey_TValue__SetItems(System_Collections_Generic_IEnumerable_System_Collections_Generic_KeyValuePair_TKey_TValue__)_items'></a>
`items` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[TKey](ImmutableDictionary_TKey_TValue_.md#Atropos_ImmutableDictionary_TKey_TValue__TKey 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TKey')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[TValue](ImmutableDictionary_TKey_TValue_.md#Atropos_ImmutableDictionary_TKey_TValue__TValue 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The key=value pairs to set on the dictionary.  Any keys that conflict with existing keys will overwrite the previous values.
  
#### Returns
[Atropos.ImmutableDictionary&lt;](ImmutableDictionary_TKey_TValue_.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;')[TKey](ImmutableDictionary_TKey_TValue_.md#Atropos_ImmutableDictionary_TKey_TValue__TKey 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TKey')[,](ImmutableDictionary_TKey_TValue_.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;')[TValue](ImmutableDictionary_TKey_TValue_.md#Atropos_ImmutableDictionary_TKey_TValue__TValue 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TValue')[&gt;](ImmutableDictionary_TKey_TValue_.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;')  
An immutable dictionary.

Implements [SetItems(IEnumerable<KeyValuePair<TKey,TValue>>)](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Immutable.IImmutableDictionary-2.SetItems#System_Collections_Immutable_IImmutableDictionary_2_SetItems_System_Collections_Generic_IEnumerable{System_Collections_Generic_KeyValuePair{_0,_1}}_ 'System.Collections.Immutable.IImmutableDictionary`2.SetItems(System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{`0,`1}})')  
