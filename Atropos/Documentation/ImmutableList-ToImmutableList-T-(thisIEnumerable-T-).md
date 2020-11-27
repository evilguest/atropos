### [Atropos](./Atropos.md 'Atropos').[ImmutableList](./ImmutableList.md 'Atropos.ImmutableList')
## ImmutableList.ToImmutableList&lt;T&gt;(System.Collections.Generic.IEnumerable&lt;T&gt;) Method
Creates an [ImmutableList&lt;T&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;') from [System.Collections.Generic.IEnumerable&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1').  
```csharp
public static Atropos.ImmutableList<T> ToImmutableList<T>(this System.Collections.Generic.IEnumerable<T> items);
```
#### Type parameters
<a name='Atropos-ImmutableList-ToImmutableList-T-(System-Collections-Generic-IEnumerable-T-)-T'></a>
`T`  
Type of the list items  
  
#### Parameters
<a name='Atropos-ImmutableList-ToImmutableList-T-(System-Collections-Generic-IEnumerable-T-)-items'></a>
`items` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](#Atropos-ImmutableList-ToImmutableList-T-(System-Collections-Generic-IEnumerable-T-)-T 'Atropos.ImmutableList.ToImmutableList&lt;T&gt;(System.Collections.Generic.IEnumerable&lt;T&gt;).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
Collection of items to initialize  
  
#### Returns
[Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[T](#Atropos-ImmutableList-ToImmutableList-T-(System-Collections-Generic-IEnumerable-T-)-T 'Atropos.ImmutableList.ToImmutableList&lt;T&gt;(System.Collections.Generic.IEnumerable&lt;T&gt;).T')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
An [ImmutableList&lt;T&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;') that contais all the elements of the input sequence.  
### Remarks
Implementation is eager. Do not call on the infinite sequences.  
