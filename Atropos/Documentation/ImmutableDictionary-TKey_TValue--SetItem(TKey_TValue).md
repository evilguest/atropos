### [Atropos](./Atropos.md 'Atropos').[ImmutableDictionary&lt;TKey,TValue&gt;](./ImmutableDictionary-TKey_TValue-.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;')
## ImmutableDictionary&lt;TKey,TValue&gt;.SetItem(TKey, TValue) Method
Sets the specified key and value to the dictionary, possibly overwriting an existing value for the given key.  
```csharp
public Atropos.ImmutableDictionary<TKey,TValue> SetItem(TKey key, TValue value);
```
#### Parameters
<a name='Atropos-ImmutableDictionary-TKey_TValue--SetItem(TKey_TValue)-key'></a>
`key` [TKey](./ImmutableDictionary-TKey_TValue-.md#Atropos-ImmutableDictionary-TKey_TValue--TKey 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TKey')  
The key of the entry to add.  
  
<a name='Atropos-ImmutableDictionary-TKey_TValue--SetItem(TKey_TValue)-value'></a>
`value` [TValue](./ImmutableDictionary-TKey_TValue-.md#Atropos-ImmutableDictionary-TKey_TValue--TValue 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TValue')  
The value of the entry to add.  
  
#### Returns
[Atropos.ImmutableDictionary&lt;](./ImmutableDictionary-TKey_TValue-.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;')[TKey](./ImmutableDictionary-TKey_TValue-.md#Atropos-ImmutableDictionary-TKey_TValue--TKey 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TKey')[,](./ImmutableDictionary-TKey_TValue-.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;')[TValue](./ImmutableDictionary-TKey_TValue-.md#Atropos-ImmutableDictionary-TKey_TValue--TValue 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TValue')[&gt;](./ImmutableDictionary-TKey_TValue-.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;')  
The new dictionary containing the additional key-value pair.  
### Remarks
If the given key-value pair are already in the dictionary, the existing instance is returned.  
If the key already exists but with a different value, a new instance with the overwritten value will be returned.  
