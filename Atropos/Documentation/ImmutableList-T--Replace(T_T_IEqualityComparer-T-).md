### [Atropos](./Atropos.md 'Atropos').[ImmutableList&lt;T&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')
## ImmutableList&lt;T&gt;.Replace(T, T, System.Collections.Generic.IEqualityComparer&lt;T&gt;) Method
Returns a new list with the first matching element in the list replaced with the specified element.  
```csharp
public Atropos.ImmutableList<T> Replace(T oldValue, T newValue, System.Collections.Generic.IEqualityComparer<T> equalityComparer=null);
```
#### Parameters
<a name='Atropos-ImmutableList-T--Replace(T_T_System-Collections-Generic-IEqualityComparer-T-)-oldValue'></a>
`oldValue` [T](./ImmutableList-T-.md#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')  
The element to be replaced.  
  
<a name='Atropos-ImmutableList-T--Replace(T_T_System-Collections-Generic-IEqualityComparer-T-)-newValue'></a>
`newValue` [T](./ImmutableList-T-.md#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')  
The element to replace the first occurrence of [oldValue](#Atropos-ImmutableList-T--Replace(T_T_System-Collections-Generic-IEqualityComparer-T-)-oldValue 'Atropos.ImmutableList&lt;T&gt;.Replace(T, T, System.Collections.Generic.IEqualityComparer&lt;T&gt;).oldValue') with  
  
<a name='Atropos-ImmutableList-T--Replace(T_T_System-Collections-Generic-IEqualityComparer-T-)-equalityComparer'></a>
`equalityComparer` [System.Collections.Generic.IEqualityComparer&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1')[T](./ImmutableList-T-.md#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1')  
The equality comparer to use for matching [oldValue](#Atropos-ImmutableList-T--Replace(T_T_System-Collections-Generic-IEqualityComparer-T-)-oldValue 'Atropos.ImmutableList&lt;T&gt;.Replace(T, T, System.Collections.Generic.IEqualityComparer&lt;T&gt;).oldValue').  
  
#### Returns
[Atropos.ImmutableList&lt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')[T](./ImmutableList-T-.md#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](./ImmutableList-T-.md 'Atropos.ImmutableList&lt;T&gt;')  
  
#### Exceptions
[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
[oldValue](#Atropos-ImmutableList-T--Replace(T_T_System-Collections-Generic-IEqualityComparer-T-)-oldValue 'Atropos.ImmutableList&lt;T&gt;.Replace(T, T, System.Collections.Generic.IEqualityComparer&lt;T&gt;).oldValue') does not exist in the list.  
