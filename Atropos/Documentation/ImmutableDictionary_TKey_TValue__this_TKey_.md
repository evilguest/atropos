### [Atropos](Atropos.md 'Atropos').[ImmutableDictionary&lt;TKey,TValue&gt;](ImmutableDictionary_TKey_TValue_.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;')
## ImmutableDictionary&lt;TKey,TValue&gt;.this[TKey] Property
Returns the value by the given key.  
```csharp
public TValue this[TKey key] { get; }
```
#### Parameters
<a name='Atropos_ImmutableDictionary_TKey_TValue__this_TKey__key'></a>
`key` [TKey](ImmutableDictionary_TKey_TValue_.md#Atropos_ImmutableDictionary_TKey_TValue__TKey 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TKey')  
The key.
  
#### Property Value
[TValue](ImmutableDictionary_TKey_TValue_.md#Atropos_ImmutableDictionary_TKey_TValue__TValue 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TValue')
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown when the given key is null.
[System.Collections.Generic.KeyNotFoundException](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyNotFoundException 'System.Collections.Generic.KeyNotFoundException')  
Thrown when the given key is not present in the dictionary.

Implements [this[TKey]](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyDictionary-2.Item#System_Collections_Generic_IReadOnlyDictionary_2_Item__0_ 'System.Collections.Generic.IReadOnlyDictionary`2.Item(`0)')  
