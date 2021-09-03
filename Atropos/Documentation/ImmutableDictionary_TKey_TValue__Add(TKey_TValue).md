### [Atropos](Atropos.md 'Atropos').[ImmutableDictionary&lt;TKey,TValue&gt;](ImmutableDictionary_TKey_TValue_.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;')
## ImmutableDictionary&lt;TKey,TValue&gt;.Add(TKey, TValue) Method
Adds an element with the specified key and value to the immutable dictionary.  
```csharp
public Atropos.ImmutableDictionary<TKey,TValue> Add(TKey key, TValue value);
```
#### Parameters
<a name='Atropos_ImmutableDictionary_TKey_TValue__Add(TKey_TValue)_key'></a>
`key` [TKey](ImmutableDictionary_TKey_TValue_.md#Atropos_ImmutableDictionary_TKey_TValue__TKey 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TKey')  
The key of the element to add.
  
<a name='Atropos_ImmutableDictionary_TKey_TValue__Add(TKey_TValue)_value'></a>
`value` [TValue](ImmutableDictionary_TKey_TValue_.md#Atropos_ImmutableDictionary_TKey_TValue__TValue 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TValue')  
The value of the element to add. The value can be null for reference types.
  
#### Returns
[Atropos.ImmutableDictionary&lt;](ImmutableDictionary_TKey_TValue_.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;')[TKey](ImmutableDictionary_TKey_TValue_.md#Atropos_ImmutableDictionary_TKey_TValue__TKey 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TKey')[,](ImmutableDictionary_TKey_TValue_.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;')[TValue](ImmutableDictionary_TKey_TValue_.md#Atropos_ImmutableDictionary_TKey_TValue__TValue 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TValue')[&gt;](ImmutableDictionary_TKey_TValue_.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;')  
A new immutable dictionary that contains the additional key/value pair.
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown when the given key is null

Implements [Add(TKey, TValue)](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Immutable.IImmutableDictionary-2.Add#System_Collections_Immutable_IImmutableDictionary_2_Add__0,_1_ 'System.Collections.Immutable.IImmutableDictionary`2.Add(`0,`1)')  
