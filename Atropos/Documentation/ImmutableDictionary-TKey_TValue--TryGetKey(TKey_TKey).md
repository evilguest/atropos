### [Atropos](./Atropos.md 'Atropos').[ImmutableDictionary&lt;TKey,TValue&gt;](./ImmutableDictionary-TKey_TValue-.md 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;')
## ImmutableDictionary&lt;TKey,TValue&gt;.TryGetKey(TKey, TKey) Method
Searches the dictionary for a given key and returns the equal key it finds, if any.  
```csharp
public bool TryGetKey(TKey equalKey, out TKey actualKey);
```
#### Parameters
<a name='Atropos-ImmutableDictionary-TKey_TValue--TryGetKey(TKey_TKey)-equalKey'></a>
`equalKey` [TKey](./ImmutableDictionary-TKey_TValue-.md#Atropos-ImmutableDictionary-TKey_TValue--TKey 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TKey')  
The key to search for.  
  
<a name='Atropos-ImmutableDictionary-TKey_TValue--TryGetKey(TKey_TKey)-actualKey'></a>
`actualKey` [TKey](./ImmutableDictionary-TKey_TValue-.md#Atropos-ImmutableDictionary-TKey_TValue--TKey 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TKey')  
The key from the dictionary that the search found, or [equalKey](#Atropos-ImmutableDictionary-TKey_TValue--TryGetKey(TKey_TKey)-equalKey 'Atropos.ImmutableDictionary&lt;TKey,TValue&gt;.TryGetKey(TKey, TKey).equalKey') if the search yielded no match.  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
A value indicating whether the search was successful.  
### Remarks
This can be useful when you want to reuse a previously stored reference instead of  
a newly constructed one (so that more sharing of references can occur) or to look up  
the canonical value, or a value that has more complete data than the value you currently have,  
although their comparer functions indicate they are equal.  
