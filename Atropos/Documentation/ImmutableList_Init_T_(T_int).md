### [Atropos](Atropos.md 'Atropos').[ImmutableList](ImmutableList.md 'Atropos.ImmutableList')
## ImmutableList.Init&lt;T&gt;(T, int) Method
Initializes a new instance of the [ImmutableList&lt;T&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;') class  
```csharp
public static Atropos.ImmutableList<T> Init<T>(T item, int count=1);
```
#### Type parameters
<a name='Atropos_ImmutableList_Init_T_(T_int)_T'></a>
`T`  
Immutable list element type, inferred automatically from the [item](ImmutableList_Init_T_(T_int).md#Atropos_ImmutableList_Init_T_(T_int)_item 'Atropos.ImmutableList.Init&lt;T&gt;(T, int).item')parameter
  
#### Parameters
<a name='Atropos_ImmutableList_Init_T_(T_int)_item'></a>
`item` [T](ImmutableList_Init_T_(T_int).md#Atropos_ImmutableList_Init_T_(T_int)_T 'Atropos.ImmutableList.Init&lt;T&gt;(T, int).T')  
value of the element(s) to repeat [count](ImmutableList_Init_T_(T_int).md#Atropos_ImmutableList_Init_T_(T_int)_count 'Atropos.ImmutableList.Init&lt;T&gt;(T, int).count') times
  
<a name='Atropos_ImmutableList_Init_T_(T_int)_count'></a>
`count` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The number of times to repeat the provided [item](ImmutableList_Init_T_(T_int).md#Atropos_ImmutableList_Init_T_(T_int)_item 'Atropos.ImmutableList.Init&lt;T&gt;(T, int).item')
  
#### Returns
[Atropos.ImmutableList&lt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')[T](ImmutableList_Init_T_(T_int).md#Atropos_ImmutableList_Init_T_(T_int)_T 'Atropos.ImmutableList.Init&lt;T&gt;(T, int).T')[&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')  
A new immutable list that contains [count](ImmutableList_Init_T_(T_int).md#Atropos_ImmutableList_Init_T_(T_int)_count 'Atropos.ImmutableList.Init&lt;T&gt;(T, int).count') instances of [item](ImmutableList_Init_T_(T_int).md#Atropos_ImmutableList_Init_T_(T_int)_item 'Atropos.ImmutableList.Init&lt;T&gt;(T, int).item')
