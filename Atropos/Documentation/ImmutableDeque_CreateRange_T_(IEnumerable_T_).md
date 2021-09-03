### [Atropos](Atropos.md 'Atropos').[ImmutableDeque](ImmutableDeque.md 'Atropos.ImmutableDeque')
## ImmutableDeque.CreateRange&lt;T&gt;(IEnumerable&lt;T&gt;) Method
Initializes a new immutable deque to the list of items passed  
```csharp
public static Atropos.IImmutableDeque<T> CreateRange<T>(System.Collections.Generic.IEnumerable<T> items);
```
#### Type parameters
<a name='Atropos_ImmutableDeque_CreateRange_T_(System_Collections_Generic_IEnumerable_T_)_T'></a>
`T`  
Type of the deque element
  
#### Parameters
<a name='Atropos_ImmutableDeque_CreateRange_T_(System_Collections_Generic_IEnumerable_T_)_items'></a>
`items` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](ImmutableDeque_CreateRange_T_(IEnumerable_T_).md#Atropos_ImmutableDeque_CreateRange_T_(System_Collections_Generic_IEnumerable_T_)_T 'Atropos.ImmutableDeque.CreateRange&lt;T&gt;(System.Collections.Generic.IEnumerable&lt;T&gt;).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The collection to use for initialization
  
#### Returns
[Atropos.IImmutableDeque&lt;](IImmutableDeque_T_.md 'Atropos.IImmutableDeque&lt;T&gt;')[T](ImmutableDeque_CreateRange_T_(IEnumerable_T_).md#Atropos_ImmutableDeque_CreateRange_T_(System_Collections_Generic_IEnumerable_T_)_T 'Atropos.ImmutableDeque.CreateRange&lt;T&gt;(System.Collections.Generic.IEnumerable&lt;T&gt;).T')[&gt;](IImmutableDeque_T_.md 'Atropos.IImmutableDeque&lt;T&gt;')  
If the passed argument is [IImmutableDeque&lt;T&gt;](IImmutableDeque_T_.md 'Atropos.IImmutableDeque&lt;T&gt;') then returns it without change.  
            Otherwise a new [ImmutableDeque&lt;T&gt;](ImmutableDeque_T_.md 'Atropos.ImmutableDeque&lt;T&gt;')  created from the items passed in the [items](ImmutableDeque_CreateRange_T_(IEnumerable_T_).md#Atropos_ImmutableDeque_CreateRange_T_(System_Collections_Generic_IEnumerable_T_)_items 'Atropos.ImmutableDeque.CreateRange&lt;T&gt;(System.Collections.Generic.IEnumerable&lt;T&gt;).items') argument.
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown when the [items](ImmutableDeque_CreateRange_T_(IEnumerable_T_).md#Atropos_ImmutableDeque_CreateRange_T_(System_Collections_Generic_IEnumerable_T_)_items 'Atropos.ImmutableDeque.CreateRange&lt;T&gt;(System.Collections.Generic.IEnumerable&lt;T&gt;).items') is null
