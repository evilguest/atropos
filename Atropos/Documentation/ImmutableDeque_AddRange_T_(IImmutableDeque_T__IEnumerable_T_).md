### [Atropos](Atropos.md 'Atropos').[ImmutableDeque](ImmutableDeque.md 'Atropos.ImmutableDeque')
## ImmutableDeque.AddRange&lt;T&gt;(IImmutableDeque&lt;T&gt;, IEnumerable&lt;T&gt;) Method
Adds a range of item to the right of this queue  
```csharp
public static Atropos.IImmutableDeque<T> AddRange<T>(this Atropos.IImmutableDeque<T> deque, System.Collections.Generic.IEnumerable<T> items);
```
#### Type parameters
<a name='Atropos_ImmutableDeque_AddRange_T_(Atropos_IImmutableDeque_T__System_Collections_Generic_IEnumerable_T_)_T'></a>
`T`  
Type of the deque element
  
#### Parameters
<a name='Atropos_ImmutableDeque_AddRange_T_(Atropos_IImmutableDeque_T__System_Collections_Generic_IEnumerable_T_)_deque'></a>
`deque` [Atropos.IImmutableDeque&lt;](IImmutableDeque_T_.md 'Atropos.IImmutableDeque&lt;T&gt;')[T](ImmutableDeque_AddRange_T_(IImmutableDeque_T__IEnumerable_T_).md#Atropos_ImmutableDeque_AddRange_T_(Atropos_IImmutableDeque_T__System_Collections_Generic_IEnumerable_T_)_T 'Atropos.ImmutableDeque.AddRange&lt;T&gt;(Atropos.IImmutableDeque&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;T&gt;).T')[&gt;](IImmutableDeque_T_.md 'Atropos.IImmutableDeque&lt;T&gt;')  
The deque
  
<a name='Atropos_ImmutableDeque_AddRange_T_(Atropos_IImmutableDeque_T__System_Collections_Generic_IEnumerable_T_)_items'></a>
`items` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](ImmutableDeque_AddRange_T_(IImmutableDeque_T__IEnumerable_T_).md#Atropos_ImmutableDeque_AddRange_T_(Atropos_IImmutableDeque_T__System_Collections_Generic_IEnumerable_T_)_T 'Atropos.ImmutableDeque.AddRange&lt;T&gt;(Atropos.IImmutableDeque&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;T&gt;).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The list of items to enqueue on the right
  
#### Returns
[Atropos.IImmutableDeque&lt;](IImmutableDeque_T_.md 'Atropos.IImmutableDeque&lt;T&gt;')[T](ImmutableDeque_AddRange_T_(IImmutableDeque_T__IEnumerable_T_).md#Atropos_ImmutableDeque_AddRange_T_(Atropos_IImmutableDeque_T__System_Collections_Generic_IEnumerable_T_)_T 'Atropos.ImmutableDeque.AddRange&lt;T&gt;(Atropos.IImmutableDeque&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;T&gt;).T')[&gt;](IImmutableDeque_T_.md 'Atropos.IImmutableDeque&lt;T&gt;')  
If the [items](ImmutableDeque_AddRange_T_(IImmutableDeque_T__IEnumerable_T_).md#Atropos_ImmutableDeque_AddRange_T_(Atropos_IImmutableDeque_T__System_Collections_Generic_IEnumerable_T_)_items 'Atropos.ImmutableDeque.AddRange&lt;T&gt;(Atropos.IImmutableDeque&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;T&gt;).items') collection is empty, then the original [deque](ImmutableDeque_AddRange_T_(IImmutableDeque_T__IEnumerable_T_).md#Atropos_ImmutableDeque_AddRange_T_(Atropos_IImmutableDeque_T__System_Collections_Generic_IEnumerable_T_)_deque 'Atropos.ImmutableDeque.AddRange&lt;T&gt;(Atropos.IImmutableDeque&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;T&gt;).deque') is returned.  
            If the [items](ImmutableDeque_AddRange_T_(IImmutableDeque_T__IEnumerable_T_).md#Atropos_ImmutableDeque_AddRange_T_(Atropos_IImmutableDeque_T__System_Collections_Generic_IEnumerable_T_)_items 'Atropos.ImmutableDeque.AddRange&lt;T&gt;(Atropos.IImmutableDeque&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;T&gt;).items') is another [IImmutableDeque&lt;T&gt;](IImmutableDeque_T_.md 'Atropos.IImmutableDeque&lt;T&gt;'), then the [Concat(IImmutableDeque&lt;T&gt;)](IImmutableDeque_T__Concat(IImmutableDeque_T_).md 'Atropos.IImmutableDeque&lt;T&gt;.Concat(Atropos.IImmutableDeque&lt;T&gt;)') method is used.  
            Otherwise, [items](ImmutableDeque_AddRange_T_(IImmutableDeque_T__IEnumerable_T_).md#Atropos_ImmutableDeque_AddRange_T_(Atropos_IImmutableDeque_T__System_Collections_Generic_IEnumerable_T_)_items 'Atropos.ImmutableDeque.AddRange&lt;T&gt;(Atropos.IImmutableDeque&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;T&gt;).items') are fed one by one into the [EnqueueRight(T)](IImmutableDeque_T__EnqueueRight(T).md 'Atropos.IImmutableDeque&lt;T&gt;.EnqueueRight(T)') method.  
            
