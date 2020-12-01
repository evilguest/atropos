### [Atropos](./Atropos.md 'Atropos').[ImmutableDictionary&lt;TKey,TValue&gt;](./ImmutableDictionary-TKey_TValue-.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;')
## ImmutableDictionary&lt;TKey,TValue&gt;.Add(TKey, TValue) Method
Adds an element with the specified key and value to the immutable dictionary.  
```csharp
public Atropos.ImmutableDictionary<TKey,TValue> Add(TKey key, TValue value);
```
#### Parameters
<a name='Atropos-ImmutableDictionary-TKey_TValue--Add(TKey_TValue)-key'></a>
`key` [TKey](./ImmutableDictionary-TKey_TValue-.md#Atropos-ImmutableDictionary-TKey_TValue--TKey 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TKey')  
The key of the element to add.  
  
<a name='Atropos-ImmutableDictionary-TKey_TValue--Add(TKey_TValue)-value'></a>
`value` [TValue](./ImmutableDictionary-TKey_TValue-.md#Atropos-ImmutableDictionary-TKey_TValue--TValue 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TValue')  
The value of the element to add. The value can be null for reference types.  
  
#### Returns
[Atropos.ImmutableDictionary&lt;](./ImmutableDictionary-TKey_TValue-.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;')[TKey](./ImmutableDictionary-TKey_TValue-.md#Atropos-ImmutableDictionary-TKey_TValue--TKey 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TKey')[,](./ImmutableDictionary-TKey_TValue-.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;')[TValue](./ImmutableDictionary-TKey_TValue-.md#Atropos-ImmutableDictionary-TKey_TValue--TValue 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TValue')[&gt;](./ImmutableDictionary-TKey_TValue-.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;')  
A new immutable dictionary that contains the additional key/value pair.  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown when the given key is null  
