### [Atropos](./Atropos.md 'Atropos')
## ImmutableList&lt;T&gt; Class
Immutable list  
```csharp
public class ImmutableList<T> :
IReadOnlyList<T>,
IEnumerable<T>,
IEnumerable,
IReadOnlyCollection<T>,
IImmutableList<T>
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ImmutableList&lt;T&gt;  

Implements [System.Collections.Generic.IReadOnlyList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyList-1 'System.Collections.Generic.IReadOnlyList`1')[T](#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyList-1 'System.Collections.Generic.IReadOnlyList`1'), [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1'), [System.Collections.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable 'System.Collections.IEnumerable'), [System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[T](#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1'), [System.Collections.Immutable.IImmutableList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Immutable.IImmutableList-1 'System.Collections.Immutable.IImmutableList`1')[T](#Atropos-ImmutableList-T--T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Immutable.IImmutableList-1 'System.Collections.Immutable.IImmutableList`1')  
#### Type parameters
<a name='Atropos-ImmutableList-T--T'></a>
`T`  
Type of the list elements  
  
### Constructors
- [ImmutableList()](./ImmutableList-T--ImmutableList().md 'Atropos.ImmutableList&lt;T&gt;.ImmutableList()')
- [ImmutableList(T, int)](./ImmutableList-T--ImmutableList(T_int).md 'Atropos.ImmutableList&lt;T&gt;.ImmutableList(T, int)')
### Properties
- [Count](./ImmutableList-T--Count.md 'Atropos.ImmutableList&lt;T&gt;.Count')
- [Empty](./ImmutableList-T--Empty.md 'Atropos.ImmutableList&lt;T&gt;.Empty')
- [this[int]](./ImmutableList-T--this-int-.md 'Atropos.ImmutableList&lt;T&gt;.this[int]')
### Methods
- [Add(T)](./ImmutableList-T--Add(T).md 'Atropos.ImmutableList&lt;T&gt;.Add(T)')
- [AddRange(System.Collections.Generic.IEnumerable&lt;T&gt;)](./ImmutableList-T--AddRange(IEnumerable-T-).md 'Atropos.ImmutableList&lt;T&gt;.AddRange(System.Collections.Generic.IEnumerable&lt;T&gt;)')
- [Clear()](./ImmutableList-T--Clear().md 'Atropos.ImmutableList&lt;T&gt;.Clear()')
- [GetEnumerator()](./ImmutableList-T--GetEnumerator().md 'Atropos.ImmutableList&lt;T&gt;.GetEnumerator()')
- [IndexOf(T, int, int, System.Collections.Generic.IEqualityComparer&lt;T&gt;)](./ImmutableList-T--IndexOf(T_int_int_IEqualityComparer-T-).md 'Atropos.ImmutableList&lt;T&gt;.IndexOf(T, int, int, System.Collections.Generic.IEqualityComparer&lt;T&gt;)')
- [Insert(int, T)](./ImmutableList-T--Insert(int_T).md 'Atropos.ImmutableList&lt;T&gt;.Insert(int, T)')
- [InsertRange(int, System.Collections.Generic.IEnumerable&lt;T&gt;)](./ImmutableList-T--InsertRange(int_IEnumerable-T-).md 'Atropos.ImmutableList&lt;T&gt;.InsertRange(int, System.Collections.Generic.IEnumerable&lt;T&gt;)')
- [LastIndexOf(T, int, int, System.Collections.Generic.IEqualityComparer&lt;T&gt;)](./ImmutableList-T--LastIndexOf(T_int_int_IEqualityComparer-T-).md 'Atropos.ImmutableList&lt;T&gt;.LastIndexOf(T, int, int, System.Collections.Generic.IEqualityComparer&lt;T&gt;)')
- [Remove(T, System.Collections.Generic.IEqualityComparer&lt;T&gt;)](./ImmutableList-T--Remove(T_IEqualityComparer-T-).md 'Atropos.ImmutableList&lt;T&gt;.Remove(T, System.Collections.Generic.IEqualityComparer&lt;T&gt;)')
- [RemoveAll(System.Predicate&lt;T&gt;)](./ImmutableList-T--RemoveAll(Predicate-T-).md 'Atropos.ImmutableList&lt;T&gt;.RemoveAll(System.Predicate&lt;T&gt;)')
- [RemoveAt(int)](./ImmutableList-T--RemoveAt(int).md 'Atropos.ImmutableList&lt;T&gt;.RemoveAt(int)')
- [RemoveRange(System.Collections.Generic.IEnumerable&lt;T&gt;, System.Collections.Generic.IEqualityComparer&lt;T&gt;)](./ImmutableList-T--RemoveRange(IEnumerable-T-_IEqualityComparer-T-).md 'Atropos.ImmutableList&lt;T&gt;.RemoveRange(System.Collections.Generic.IEnumerable&lt;T&gt;, System.Collections.Generic.IEqualityComparer&lt;T&gt;)')
- [RemoveRange(int, int)](./ImmutableList-T--RemoveRange(int_int).md 'Atropos.ImmutableList&lt;T&gt;.RemoveRange(int, int)')
- [Replace(T, T, System.Collections.Generic.IEqualityComparer&lt;T&gt;)](./ImmutableList-T--Replace(T_T_IEqualityComparer-T-).md 'Atropos.ImmutableList&lt;T&gt;.Replace(T, T, System.Collections.Generic.IEqualityComparer&lt;T&gt;)')
- [SetItem(int, T)](./ImmutableList-T--SetItem(int_T).md 'Atropos.ImmutableList&lt;T&gt;.SetItem(int, T)')
### Operators
- [operator +(Atropos.ImmutableList&lt;T&gt;, T)](./ImmutableList-T--op_Addition(ImmutableList-T-_T).md 'Atropos.ImmutableList&lt;T&gt;.op_Addition(Atropos.ImmutableList&lt;T&gt;, T)')
- [operator +(Atropos.ImmutableList&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;T&gt;)](./ImmutableList-T--op_Addition(ImmutableList-T-_IEnumerable-T-).md 'Atropos.ImmutableList&lt;T&gt;.op_Addition(Atropos.ImmutableList&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;T&gt;)')
- [operator -(Atropos.ImmutableList&lt;T&gt;, T)](./ImmutableList-T--op_Subtraction(ImmutableList-T-_T).md 'Atropos.ImmutableList&lt;T&gt;.op_Subtraction(Atropos.ImmutableList&lt;T&gt;, T)')
- [operator -(Atropos.ImmutableList&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;T&gt;)](./ImmutableList-T--op_Subtraction(ImmutableList-T-_IEnumerable-T-).md 'Atropos.ImmutableList&lt;T&gt;.op_Subtraction(Atropos.ImmutableList&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;T&gt;)')
