### [Atropos](Atropos.md 'Atropos')
## ImmutableList&lt;T&gt; Class
Immutable list  
```csharp
public class ImmutableList<T> :
System.Collections.Generic.IReadOnlyList<T>,
System.Collections.Generic.IEnumerable<T>,
System.Collections.IEnumerable,
System.Collections.Generic.IReadOnlyCollection<T>,
System.Collections.Immutable.IImmutableList<T>
```
#### Type parameters
<a name='Atropos_ImmutableList_T__T'></a>
`T`  
Type of the list elements
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ImmutableList&lt;T&gt;  

Implements [System.Collections.Generic.IReadOnlyList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyList-1 'System.Collections.Generic.IReadOnlyList`1')[T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyList-1 'System.Collections.Generic.IReadOnlyList`1'), [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1'), [System.Collections.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable 'System.Collections.IEnumerable'), [System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1'), [System.Collections.Immutable.IImmutableList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Immutable.IImmutableList-1 'System.Collections.Immutable.IImmutableList`1')[T](ImmutableList_T_.md#Atropos_ImmutableList_T__T 'Atropos.ImmutableList&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Immutable.IImmutableList-1 'System.Collections.Immutable.IImmutableList`1')  

| Constructors | |
| :--- | :--- |
| [ImmutableList()](ImmutableList_T__ImmutableList().md 'Atropos.ImmutableList&lt;T&gt;.ImmutableList()') | Creates a new empty immutable list<br/> |
| [ImmutableList(T, int)](ImmutableList_T__ImmutableList(T_int).md 'Atropos.ImmutableList&lt;T&gt;.ImmutableList(T, int)') | Constructs a list from the value<br/> |

| Properties | |
| :--- | :--- |
| [Count](ImmutableList_T__Count.md 'Atropos.ImmutableList&lt;T&gt;.Count') | Returns count of the elements in the [ImmutableList&lt;T&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;') |
| [Empty](ImmutableList_T__Empty.md 'Atropos.ImmutableList&lt;T&gt;.Empty') | Returns an empty [ImmutableList&lt;T&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;') |
| [this[int]](ImmutableList_T__this_int_.md 'Atropos.ImmutableList&lt;T&gt;.this[int]') | Returns an element from the list. Asympthotic is O(log([Count](ImmutableList_T__Count.md 'Atropos.ImmutableList&lt;T&gt;.Count'))).<br/> |

| Methods | |
| :--- | :--- |
| [Add(T)](ImmutableList_T__Add(T).md 'Atropos.ImmutableList&lt;T&gt;.Add(T)') | Makes a copy of the list, and adds the specified object to the end of the copied list.<br/> |
| [AddRange(IEnumerable&lt;T&gt;)](ImmutableList_T__AddRange(IEnumerable_T_).md 'Atropos.ImmutableList&lt;T&gt;.AddRange(System.Collections.Generic.IEnumerable&lt;T&gt;)') | Adds a range of items to the immutable list<br/> |
| [Clear()](ImmutableList_T__Clear().md 'Atropos.ImmutableList&lt;T&gt;.Clear()') | Clears the list<br/> |
| [GetEnumerator()](ImmutableList_T__GetEnumerator().md 'Atropos.ImmutableList&lt;T&gt;.GetEnumerator()') | Returns the list enumerator<br/> |
| [IndexOf(T, int, int, IEqualityComparer&lt;T&gt;)](ImmutableList_T__IndexOf(T_int_int_IEqualityComparer_T_).md 'Atropos.ImmutableList&lt;T&gt;.IndexOf(T, int, int, System.Collections.Generic.IEqualityComparer&lt;T&gt;)') | Searches for the specified object and returns the zero-based index of the first <br/>occurrence within the range of elements in the list<br/>that starts at the specified index and contains the specified number of elements.<br/> |
| [IndexOf(T, IEqualityComparer&lt;T&gt;)](ImmutableList_T__IndexOf(T_IEqualityComparer_T_).md 'Atropos.ImmutableList&lt;T&gt;.IndexOf(T, System.Collections.Generic.IEqualityComparer&lt;T&gt;)') | Searches for the specified object and returns the zero-based index of the first <br/>occurrence within the range of elements in the list<br/>that starts at the specified index and contains the specified number of elements.<br/> |
| [Insert(int, T)](ImmutableList_T__Insert(int_T).md 'Atropos.ImmutableList&lt;T&gt;.Insert(int, T)') | Inserts the specified value at the specified index<br/> |
| [InsertRange(int, IEnumerable&lt;T&gt;)](ImmutableList_T__InsertRange(int_IEnumerable_T_).md 'Atropos.ImmutableList&lt;T&gt;.InsertRange(int, System.Collections.Generic.IEnumerable&lt;T&gt;)') | Inserts the specified elements at the specified index in the immutable list.<br/> |
| [LastIndexOf(T, int, int, IEqualityComparer&lt;T&gt;)](ImmutableList_T__LastIndexOf(T_int_int_IEqualityComparer_T_).md 'Atropos.ImmutableList&lt;T&gt;.LastIndexOf(T, int, int, System.Collections.Generic.IEqualityComparer&lt;T&gt;)') | Searches for the specified object and returns the zero-based index of the last occurrence within <br/>the range of elements in the [ImmutableList&lt;T&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;')<br/>that contains the specified number of elements and ends at the specified index.<br/> |
| [LastIndexOf(T, IEqualityComparer&lt;T&gt;)](ImmutableList_T__LastIndexOf(T_IEqualityComparer_T_).md 'Atropos.ImmutableList&lt;T&gt;.LastIndexOf(T, System.Collections.Generic.IEqualityComparer&lt;T&gt;)') | Searches for the specified object and returns the zero-based index of the last occurrence within <br/>the [ImmutableList&lt;T&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;').<br/> |
| [Remove(T, IEqualityComparer&lt;T&gt;)](ImmutableList_T__Remove(T_IEqualityComparer_T_).md 'Atropos.ImmutableList&lt;T&gt;.Remove(T, System.Collections.Generic.IEqualityComparer&lt;T&gt;)') | Removes the first occurrence of a specified object from this immutable list.<br/> |
| [RemoveAll(Predicate&lt;T&gt;)](ImmutableList_T__RemoveAll(Predicate_T_).md 'Atropos.ImmutableList&lt;T&gt;.RemoveAll(System.Predicate&lt;T&gt;)') | Removes all the elements that match the conditions defined by the specified predicate.<br/> |
| [RemoveAt(int)](ImmutableList_T__RemoveAt(int).md 'Atropos.ImmutableList&lt;T&gt;.RemoveAt(int)') | Removes the element at the specified index of the immutable list.<br/> |
| [RemoveRange(int, int)](ImmutableList_T__RemoveRange(int_int).md 'Atropos.ImmutableList&lt;T&gt;.RemoveRange(int, int)') | Removes a range of elements from the [ImmutableList&lt;T&gt;](ImmutableList_T_.md 'Atropos.ImmutableList&lt;T&gt;') |
| [RemoveRange(IEnumerable&lt;T&gt;, IEqualityComparer&lt;T&gt;)](ImmutableList_T__RemoveRange(IEnumerable_T__IEqualityComparer_T_).md 'Atropos.ImmutableList&lt;T&gt;.RemoveRange(System.Collections.Generic.IEnumerable&lt;T&gt;, System.Collections.Generic.IEqualityComparer&lt;T&gt;)') | Removes the specified objects from the list.<br/> |
| [Replace(T, T, IEqualityComparer&lt;T&gt;)](ImmutableList_T__Replace(T_T_IEqualityComparer_T_).md 'Atropos.ImmutableList&lt;T&gt;.Replace(T, T, System.Collections.Generic.IEqualityComparer&lt;T&gt;)') | Returns a new list with the first matching element in the list replaced with the specified element.<br/> |
| [SetItem(int, T)](ImmutableList_T__SetItem(int_T).md 'Atropos.ImmutableList&lt;T&gt;.SetItem(int, T)') | Replaces an element in the list at a given position with the specified element.<br/> |

| Operators | |
| :--- | :--- |
| [operator +(ImmutableList&lt;T&gt;, IEnumerable&lt;T&gt;)](ImmutableList_T__operator+(ImmutableList_T__IEnumerable_T_).md 'Atropos.ImmutableList&lt;T&gt;.op_Addition(Atropos.ImmutableList&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;T&gt;)') | Addition operator - adds the specified range of items to the immutable list.<br/>Convenient in the compound assignment operator:<br/> |
| [operator +(ImmutableList&lt;T&gt;, T)](ImmutableList_T__operator+(ImmutableList_T__T).md 'Atropos.ImmutableList&lt;T&gt;.op_Addition(Atropos.ImmutableList&lt;T&gt;, T)') | Addition operator - adds the specified value to the immutable list.<br/>Convenient in the compound assignment operator:<br/>list = list.Add(value) <=> list += value<br/> |
| [operator -(ImmutableList&lt;T&gt;, int)](ImmutableList_T__operator-(ImmutableList_T__int).md 'Atropos.ImmutableList&lt;T&gt;.op_Subtraction(Atropos.ImmutableList&lt;T&gt;, int)') | Removal operator - removes item at the specified position. <br/>Convenient in the compound assignment operator:<br/>list = list.RemoveAt(index) <=> list -= index;<br/> |
| [operator -(ImmutableList&lt;T&gt;, IEnumerable&lt;T&gt;)](ImmutableList_T__operator-(ImmutableList_T__IEnumerable_T_).md 'Atropos.ImmutableList&lt;T&gt;.op_Subtraction(Atropos.ImmutableList&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;T&gt;)') | Removal operator - removes the specified items from the immutable list, using the default equality comparer<br/> |
| [operator -(ImmutableList&lt;T&gt;, T)](ImmutableList_T__operator-(ImmutableList_T__T).md 'Atropos.ImmutableList&lt;T&gt;.op_Subtraction(Atropos.ImmutableList&lt;T&gt;, T)') | Removal operator - removes the first occurence of the specified value from the list, using the default equality comparer.<br/>Convenient in the compound assignment operator:<br/>list = list.Remove(item, null) <=> list -= item;<br/> |
