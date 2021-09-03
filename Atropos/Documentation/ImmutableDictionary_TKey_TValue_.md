### [Atropos](Atropos.md 'Atropos')
## ImmutableDictionary&lt;TKey,TValue&gt; Class
Represents an immutable key-value dictionary.  
```csharp
public class ImmutableDictionary<TKey,TValue> :
System.Collections.Immutable.IImmutableDictionary<TKey, TValue>,
System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TKey, TValue>>,
System.Collections.IEnumerable,
System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<TKey, TValue>>,
System.Collections.Generic.IReadOnlyDictionary<TKey, TValue>
    where TKey : System.IComparable<TKey>
```
#### Type parameters
<a name='Atropos_ImmutableDictionary_TKey_TValue__TKey'></a>
`TKey`  
Type of the key.
  
<a name='Atropos_ImmutableDictionary_TKey_TValue__TValue'></a>
`TValue`  
Type of the value.
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ImmutableDictionary&lt;TKey,TValue&gt;  

Implements [System.Collections.Immutable.IImmutableDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Immutable.IImmutableDictionary-2 'System.Collections.Immutable.IImmutableDictionary`2')[TKey](ImmutableDictionary_TKey_TValue_.md#Atropos_ImmutableDictionary_TKey_TValue__TKey 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TKey')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Immutable.IImmutableDictionary-2 'System.Collections.Immutable.IImmutableDictionary`2')[TValue](ImmutableDictionary_TKey_TValue_.md#Atropos_ImmutableDictionary_TKey_TValue__TValue 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Immutable.IImmutableDictionary-2 'System.Collections.Immutable.IImmutableDictionary`2'), [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[TKey](ImmutableDictionary_TKey_TValue_.md#Atropos_ImmutableDictionary_TKey_TValue__TKey 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TKey')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[TValue](ImmutableDictionary_TKey_TValue_.md#Atropos_ImmutableDictionary_TKey_TValue__TValue 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1'), [System.Collections.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable 'System.Collections.IEnumerable'), [System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[TKey](ImmutableDictionary_TKey_TValue_.md#Atropos_ImmutableDictionary_TKey_TValue__TKey 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TKey')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[TValue](ImmutableDictionary_TKey_TValue_.md#Atropos_ImmutableDictionary_TKey_TValue__TValue 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1'), [System.Collections.Generic.IReadOnlyDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyDictionary-2 'System.Collections.Generic.IReadOnlyDictionary`2')[TKey](ImmutableDictionary_TKey_TValue_.md#Atropos_ImmutableDictionary_TKey_TValue__TKey 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TKey')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyDictionary-2 'System.Collections.Generic.IReadOnlyDictionary`2')[TValue](ImmutableDictionary_TKey_TValue_.md#Atropos_ImmutableDictionary_TKey_TValue__TValue 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyDictionary-2 'System.Collections.Generic.IReadOnlyDictionary`2')  

| Constructors | |
| :--- | :--- |
| [ImmutableDictionary()](ImmutableDictionary_TKey_TValue__ImmutableDictionary().md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.ImmutableDictionary()') | Constructs an immutable dictionary.<br/> |

| Properties | |
| :--- | :--- |
| [Count](ImmutableDictionary_TKey_TValue__Count.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.Count') | Returns count of the elements in the [ImmutableDictionary&lt;TKey,TValue&gt;](ImmutableDictionary_TKey_TValue_.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;') |
| [Keys](ImmutableDictionary_TKey_TValue__Keys.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.Keys') | Returns an enumeration of all the keys in this dictionary.<br/> |
| [this[TKey]](ImmutableDictionary_TKey_TValue__this_TKey_.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.this[TKey]') | Returns the value by the given key.<br/> |
| [Values](ImmutableDictionary_TKey_TValue__Values.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.Values') | Returns an enumeration of all the values in this dictionary.<br/> |

| Methods | |
| :--- | :--- |
| [Add(TKey, TValue)](ImmutableDictionary_TKey_TValue__Add(TKey_TValue).md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.Add(TKey, TValue)') | Adds an element with the specified key and value to the immutable dictionary.<br/> |
| [AddRange(IEnumerable&lt;KeyValuePair&lt;TKey,TValue&gt;&gt;)](ImmutableDictionary_TKey_TValue__AddRange(IEnumerable_KeyValuePair_TKey_TValue__).md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.AddRange(System.Collections.Generic.IEnumerable&lt;System.Collections.Generic.KeyValuePair&lt;TKey,TValue&gt;&gt;)') | Adds the specified key/value pairs to the immutable dictionary.<br/> |
| [Clear()](ImmutableDictionary_TKey_TValue__Clear().md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.Clear()') | Retrieves an empty immutable dictionary.<br/> |
| [Contains(KeyValuePair&lt;TKey,TValue&gt;)](ImmutableDictionary_TKey_TValue__Contains(KeyValuePair_TKey_TValue_).md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.Contains(System.Collections.Generic.KeyValuePair&lt;TKey,TValue&gt;)') | Determines whether this immutable dictionary contains the specified key/value pair.<br/> |
| [ContainsKey(TKey)](ImmutableDictionary_TKey_TValue__ContainsKey(TKey).md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.ContainsKey(TKey)') | Determines whether the immutable dictionary contains an element with the specified key.<br/> |
| [GetEnumerator()](ImmutableDictionary_TKey_TValue__GetEnumerator().md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.GetEnumerator()') | Returns an enumerator that iterates through the immutable dictionary.<br/> |
| [Remove(TKey)](ImmutableDictionary_TKey_TValue__Remove(TKey).md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.Remove(TKey)') | Removes the specified key from the dictionary with its associated value.<br/> |
| [RemoveRange(IEnumerable&lt;TKey&gt;)](ImmutableDictionary_TKey_TValue__RemoveRange(IEnumerable_TKey_).md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.RemoveRange(System.Collections.Generic.IEnumerable&lt;TKey&gt;)') | Removes the specified keys from the dictionary with their associated values.<br/> |
| [SetItem(TKey, TValue)](ImmutableDictionary_TKey_TValue__SetItem(TKey_TValue).md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.SetItem(TKey, TValue)') | Sets the specified key and value to the dictionary, possibly overwriting an existing value for the given key.<br/> |
| [SetItems(IEnumerable&lt;KeyValuePair&lt;TKey,TValue&gt;&gt;)](ImmutableDictionary_TKey_TValue__SetItems(IEnumerable_KeyValuePair_TKey_TValue__).md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.SetItems(System.Collections.Generic.IEnumerable&lt;System.Collections.Generic.KeyValuePair&lt;TKey,TValue&gt;&gt;)') | Applies a given set of key=value pairs to an immutable dictionary, replacing any conflicting keys in the resulting dictionary.<br/> |
| [TryGetKey(TKey, TKey)](ImmutableDictionary_TKey_TValue__TryGetKey(TKey_TKey).md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TryGetKey(TKey, TKey)') | Searches the dictionary for a given key and returns the equal key it finds, if any.<br/> |
| [TryGetValue(TKey, TValue)](ImmutableDictionary_TKey_TValue__TryGetValue(TKey_TValue).md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TryGetValue(TKey, TValue)') | Searches the dictionary for the value by the given key.<br/> |
