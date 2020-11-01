### [Atropos](./Atropos.md 'Atropos').[ImmutableList](./ImmutableList.md 'Atropos.ImmutableList')
## ImmutableList.Init&lt;T&gt;(T, int) Method
Initializes a new instance of the [ImmutableList&lt;T&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;') class  
```csharp
public static Atropos.ImmutableList<T> Init<T>(T item, int count=1);
```
#### Type parameters
<a name='Atropos-ImmutableList-Init-T-(T_int)-T'></a>
`T`  
Immutable list element type, inferred automatically from the [item](#Atropos-ImmutableList-Init-T-(T_int)-item 'Atropos.ImmutableList.Init&lt;T&gt;(T, int).item')parameter  
  
#### Parameters
<a name='Atropos-ImmutableList-Init-T-(T_int)-item'></a>
`item` [T](#Atropos-ImmutableList-Init-T-(T_int)-T 'Atropos.ImmutableList.Init&lt;T&gt;(T, int).T')  
value of the element(s) to repeat [count](#Atropos-ImmutableList-Init-T-(T_int)-count 'Atropos.ImmutableList.Init&lt;T&gt;(T, int).count') times  
  
<a name='Atropos-ImmutableList-Init-T-(T_int)-count'></a>
`count` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The number of times to repeat the provided [item](#Atropos-ImmutableList-Init-T-(T_int)-item 'Atropos.ImmutableList.Init&lt;T&gt;(T, int).item')  
  
#### Returns
[Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[T](#Atropos-ImmutableList-Init-T-(T_int)-T 'Atropos.ImmutableList.Init&lt;T&gt;(T, int).T')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
A new immutable list that contains [count](#Atropos-ImmutableList-Init-T-(T_int)-count 'Atropos.ImmutableList.Init&lt;T&gt;(T, int).count') instances of [item](#Atropos-ImmutableList-Init-T-(T_int)-item 'Atropos.ImmutableList.Init&lt;T&gt;(T, int).item')  
