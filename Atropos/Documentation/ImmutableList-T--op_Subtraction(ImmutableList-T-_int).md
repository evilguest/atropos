### [Atropos](./Atropos.md 'Atropos').[ImmutableList&lt;T&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')
## ImmutableList&lt;T&gt;.operator -(Atropos.ImmutableList&lt;T&gt;, int) Operator
Removal operator - removes item at the specified position.   
Convenient in the compound assignment operator:  
list = list.RemoveAt(index) <=> list -= index;  
```csharp
public static Atropos.ImmutableList<T> operator -(Atropos.ImmutableList<T> list, int index);
```
#### Parameters
<a name='Atropos-ImmutableList-T--op_Subtraction(Atropos-ImmutableList-T-_int)-list'></a>
`list` [Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[T](./ImmutableList-T-.md#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
The immutable list  
  
<a name='Atropos-ImmutableList-T--op_Subtraction(Atropos-ImmutableList-T-_int)-index'></a>
`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Index of an item to remove from the list  
  
#### Returns
[Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[T](./ImmutableList-T-.md#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
A new [ImmutableList&lt;T&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;') with the specified item removed.  
### Remarks
Note that for ImmutableList<[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')> this operator overlaps with the [operator -(Atropos.ImmutableList&lt;T&gt;, T)](./ImmutableList-T--op_Subtraction(ImmutableList-T-_T).md 'Atropos.ImmutableList&lt;T&gt;.op_Subtraction(Atropos.ImmutableList&lt;T&gt;, T)') and wins.  
            To remove some value from an [ImmutableList&lt;T&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;') where T is [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32') use the [Remove(T, System.Collections.Generic.IEqualityComparer&lt;T&gt;)](./ImmutableList-T--Remove(T_IEqualityComparer-T-).md 'Atropos.ImmutableList&lt;T&gt;.Remove(T, System.Collections.Generic.IEqualityComparer&lt;T&gt;)') method explicitly.  
