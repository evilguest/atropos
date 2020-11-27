### [Atropos](./Atropos.md 'Atropos').[ImmutableDictionary&lt;TKey,TValue&gt;](./ImmutableDictionary-TKey_TValue-.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;')
## ImmutableDictionary&lt;TKey,TValue&gt;.SetItems(System.Collections.Generic.IEnumerable&lt;System.Collections.Generic.KeyValuePair&lt;TKey,TValue&gt;&gt;) Method
Applies a given set of key=value pairs to an immutable dictionary, replacing any conflicting keys in the resulting dictionary.  
```csharp
public Atropos.ImmutableDictionary<TKey,TValue> SetItems(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TKey,TValue>> items);
```
#### Parameters
<a name='Atropos-ImmutableDictionary-TKey_TValue--SetItems(System-Collections-Generic-IEnumerable-System-Collections-Generic-KeyValuePair-TKey_TValue--)-items'></a>
`items` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[TKey](./ImmutableDictionary-TKey_TValue-.md#Atropos-ImmutableDictionary-TKey_TValue--TKey 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TKey')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[TValue](./ImmutableDictionary-TKey_TValue-.md#Atropos-ImmutableDictionary-TKey_TValue--TValue 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The key=value pairs to set on the dictionary.  Any keys that conflict with existing keys will overwrite the previous values.  
  
#### Returns
[Atropos.ImmutableDictionary&lt;](./ImmutableDictionary-TKey_TValue-.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;')[TKey](./ImmutableDictionary-TKey_TValue-.md#Atropos-ImmutableDictionary-TKey_TValue--TKey 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TKey')[,](./ImmutableDictionary-TKey_TValue-.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;')[TValue](./ImmutableDictionary-TKey_TValue-.md#Atropos-ImmutableDictionary-TKey_TValue--TValue 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TValue')[&gt;](./ImmutableDictionary-TKey_TValue-.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;')  
An immutable dictionary.  
