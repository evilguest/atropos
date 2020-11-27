### [Atropos](./Atropos.md 'Atropos').[ImmutableDictionary&lt;TKey,TValue&gt;](./ImmutableDictionary-TKey_TValue-.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;')
## ImmutableDictionary&lt;TKey,TValue&gt;.RemoveRange(System.Collections.Generic.IEnumerable&lt;TKey&gt;) Method
Removes the specified keys from the dictionary with their associated values.  
```csharp
public Atropos.ImmutableDictionary<TKey,TValue> RemoveRange(System.Collections.Generic.IEnumerable<TKey> keys);
```
#### Parameters
<a name='Atropos-ImmutableDictionary-TKey_TValue--RemoveRange(System-Collections-Generic-IEnumerable-TKey-)-keys'></a>
`keys` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[TKey](./ImmutableDictionary-TKey_TValue-.md#Atropos-ImmutableDictionary-TKey_TValue--TKey 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TKey')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The keys to remove.  
  
#### Returns
[Atropos.ImmutableDictionary&lt;](./ImmutableDictionary-TKey_TValue-.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;')[TKey](./ImmutableDictionary-TKey_TValue-.md#Atropos-ImmutableDictionary-TKey_TValue--TKey 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TKey')[,](./ImmutableDictionary-TKey_TValue-.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;')[TValue](./ImmutableDictionary-TKey_TValue-.md#Atropos-ImmutableDictionary-TKey_TValue--TValue 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TValue')[&gt;](./ImmutableDictionary-TKey_TValue-.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;')  
A new dictionary with those keys removed; or this instance if those keys are not in the dictionary.  
