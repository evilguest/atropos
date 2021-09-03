### [Atropos](Atropos.md 'Atropos').[ImmutableDictionary&lt;TKey,TValue&gt;](ImmutableDictionary_TKey_TValue_.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;')
## ImmutableDictionary&lt;TKey,TValue&gt;.TryGetValue(TKey, TValue) Method
Searches the dictionary for the value by the given key.  
```csharp
public bool TryGetValue(TKey key, out TValue value);
```
#### Parameters
<a name='Atropos_ImmutableDictionary_TKey_TValue__TryGetValue(TKey_TValue)_key'></a>
`key` [TKey](ImmutableDictionary_TKey_TValue_.md#Atropos_ImmutableDictionary_TKey_TValue__TKey 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TKey')  
The key.
  
<a name='Atropos_ImmutableDictionary_TKey_TValue__TryGetValue(TKey_TValue)_value'></a>
`value` [TValue](ImmutableDictionary_TKey_TValue_.md#Atropos_ImmutableDictionary_TKey_TValue__TValue 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TValue')  
The value.
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
A value indicating whether the search was successful.

Implements [TryGetValue(TKey, TValue)](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyDictionary-2.TryGetValue#System_Collections_Generic_IReadOnlyDictionary_2_TryGetValue__0,_1@_ 'System.Collections.Generic.IReadOnlyDictionary`2.TryGetValue(`0,`1@)')  
