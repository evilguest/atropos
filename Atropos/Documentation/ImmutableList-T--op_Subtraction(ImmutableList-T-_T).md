### [Atropos](./Atropos.md 'Atropos').[ImmutableList&lt;T&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')
## ImmutableList&lt;T&gt;.operator -(Atropos.ImmutableList&lt;T&gt;, T) Operator
Removal operator - removes the first occurence of the specified value from the list, using the default equality comparer.  
Convenient in the compound assignment operator:  
list = list.Remove(item, null) <=> list -= item;  
```csharp
public static Atropos.ImmutableList<T> operator -(Atropos.ImmutableList<T> list, T value);
```
#### Parameters
<a name='Atropos-ImmutableList-T--op_Subtraction(Atropos-ImmutableList-T-_T)-list'></a>
`list` [Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[T](./ImmutableList-T-.md#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
The immutable list  
  
<a name='Atropos-ImmutableList-T--op_Subtraction(Atropos-ImmutableList-T-_T)-value'></a>
`value` [T](./ImmutableList-T-.md#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')  
Value to remove from the list  
  
#### Returns
[Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[T](./ImmutableList-T-.md#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
A new list with the first occurence of [value](#Atropos-ImmutableList-T--op_Subtraction(Atropos-ImmutableList-T-_T)-value 'Atropos.ImmutableList&lt;T&gt;.op_Subtraction(Atropos.ImmutableList&lt;T&gt;, T).value') removed.  
### Remarks
Note that for ImmutableList<[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')> this operator overlaps with the [operator -(Atropos.ImmutableList&lt;T&gt;, int)](./ImmutableList-T--op_Subtraction(ImmutableList-T-_int).md 'Atropos.ImmutableList&lt;T&gt;.op_Subtraction(Atropos.ImmutableList&lt;T&gt;, int)') and loses.  
            To remove some value from an [ImmutableList&lt;T&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;') where T is [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32') use the [RemoveAt(int)](./ImmutableList-T--RemoveAt(int).md 'Atropos.ImmutableList&lt;T&gt;.RemoveAt(int)') method explicitly.  
