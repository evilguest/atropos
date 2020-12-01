### [Atropos](./Atropos.md 'Atropos')
## ImmutableDictionary&lt;TKey,TValue&gt; Class
Represents an immutable key-value dictionary.  
```csharp
public class ImmutableDictionary<TKey,TValue> :
IImmutableDictionary<TKey, TValue>,
IEnumerable<KeyValuePair<TKey, TValue>>,
IEnumerable,
IReadOnlyCollection<KeyValuePair<TKey, TValue>>,
IReadOnlyDictionary<TKey, TValue>
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ImmutableDictionary&lt;TKey,TValue&gt;  

Implements [System.Collections.Immutable.IImmutableDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Immutable.IImmutableDictionary-2 'System.Collections.Immutable.IImmutableDictionary`2')[TKey](#Atropos-ImmutableDictionary-TKey_TValue--TKey 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TKey')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Immutable.IImmutableDictionary-2 'System.Collections.Immutable.IImmutableDictionary`2')[TValue](#Atropos-ImmutableDictionary-TKey_TValue--TValue 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Immutable.IImmutableDictionary-2 'System.Collections.Immutable.IImmutableDictionary`2'), [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[TKey](#Atropos-ImmutableDictionary-TKey_TValue--TKey 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TKey')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[TValue](#Atropos-ImmutableDictionary-TKey_TValue--TValue 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1'), [System.Collections.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable 'System.Collections.IEnumerable'), [System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[TKey](#Atropos-ImmutableDictionary-TKey_TValue--TKey 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TKey')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[TValue](#Atropos-ImmutableDictionary-TKey_TValue--TValue 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1'), [System.Collections.Generic.IReadOnlyDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyDictionary-2 'System.Collections.Generic.IReadOnlyDictionary`2')[TKey](#Atropos-ImmutableDictionary-TKey_TValue--TKey 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TKey')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyDictionary-2 'System.Collections.Generic.IReadOnlyDictionary`2')[TValue](#Atropos-ImmutableDictionary-TKey_TValue--TValue 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyDictionary-2 'System.Collections.Generic.IReadOnlyDictionary`2')  
#### Type parameters
<a name='Atropos-ImmutableDictionary-TKey_TValue--TKey'></a>
`TKey`  
Type of the key.  
  
<a name='Atropos-ImmutableDictionary-TKey_TValue--TValue'></a>
`TValue`  
Type of the value.  
  
### Constructors
- [ImmutableDictionary()](./ImmutableDictionary-TKey_TValue--ImmutableDictionary().md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.ImmutableDictionary()')
### Properties
- [Count](./ImmutableDictionary-TKey_TValue--Count.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.Count')
- [this[TKey]](./ImmutableDictionary-TKey_TValue--this-TKey-.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.this[TKey]')
- [Keys](./ImmutableDictionary-TKey_TValue--Keys.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.Keys')
- [Values](./ImmutableDictionary-TKey_TValue--Values.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.Values')
### Methods
- [Add(TKey, TValue)](./ImmutableDictionary-TKey_TValue--Add(TKey_TValue).md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.Add(TKey, TValue)')
- [AddRange(System.Collections.Generic.IEnumerable&lt;System.Collections.Generic.KeyValuePair&lt;TKey,TValue&gt;&gt;)](./ImmutableDictionary-TKey_TValue--AddRange(IEnumerable-KeyValuePair-TKey_TValue--).md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.AddRange(System.Collections.Generic.IEnumerable&lt;System.Collections.Generic.KeyValuePair&lt;TKey,TValue&gt;&gt;)')
- [Clear()](./ImmutableDictionary-TKey_TValue--Clear().md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.Clear()')
- [Contains(System.Collections.Generic.KeyValuePair&lt;TKey,TValue&gt;)](./ImmutableDictionary-TKey_TValue--Contains(KeyValuePair-TKey_TValue-).md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.Contains(System.Collections.Generic.KeyValuePair&lt;TKey,TValue&gt;)')
- [ContainsKey(TKey)](./ImmutableDictionary-TKey_TValue--ContainsKey(TKey).md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.ContainsKey(TKey)')
- [GetEnumerator()](./ImmutableDictionary-TKey_TValue--GetEnumerator().md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.GetEnumerator()')
- [Remove(TKey)](./ImmutableDictionary-TKey_TValue--Remove(TKey).md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.Remove(TKey)')
- [RemoveRange(System.Collections.Generic.IEnumerable&lt;TKey&gt;)](./ImmutableDictionary-TKey_TValue--RemoveRange(IEnumerable-TKey-).md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.RemoveRange(System.Collections.Generic.IEnumerable&lt;TKey&gt;)')
- [SetItem(TKey, TValue)](./ImmutableDictionary-TKey_TValue--SetItem(TKey_TValue).md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.SetItem(TKey, TValue)')
- [SetItems(System.Collections.Generic.IEnumerable&lt;System.Collections.Generic.KeyValuePair&lt;TKey,TValue&gt;&gt;)](./ImmutableDictionary-TKey_TValue--SetItems(IEnumerable-KeyValuePair-TKey_TValue--).md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.SetItems(System.Collections.Generic.IEnumerable&lt;System.Collections.Generic.KeyValuePair&lt;TKey,TValue&gt;&gt;)')
- [TryGetKey(TKey, TKey)](./ImmutableDictionary-TKey_TValue--TryGetKey(TKey_TKey).md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TryGetKey(TKey, TKey)')
- [TryGetValue(TKey, TValue)](./ImmutableDictionary-TKey_TValue--TryGetValue(TKey_TValue).md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TryGetValue(TKey, TValue)')
