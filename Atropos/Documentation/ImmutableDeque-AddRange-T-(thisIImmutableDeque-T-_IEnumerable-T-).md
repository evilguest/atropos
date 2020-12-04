### [Atropos](./Atropos.md 'Atropos').[ImmutableDeque](./ImmutableDeque.md 'Atropos.ImmutableDeque')
## ImmutableDeque.AddRange&lt;T&gt;(Atropos.IImmutableDeque&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;T&gt;) Method
Adds a range of item to the right of this queue  
```csharp
public static Atropos.IImmutableDeque<T> AddRange<T>(this Atropos.IImmutableDeque<T> deque, System.Collections.Generic.IEnumerable<T> items);
```
#### Type parameters
<a name='Atropos-ImmutableDeque-AddRange-T-(Atropos-IImmutableDeque-T-_System-Collections-Generic-IEnumerable-T-)-T'></a>
`T`  
Type of the deque element  
  
#### Parameters
<a name='Atropos-ImmutableDeque-AddRange-T-(Atropos-IImmutableDeque-T-_System-Collections-Generic-IEnumerable-T-)-deque'></a>
`deque` [Atropos.IImmutableDeque&lt;](./IImmutableDeque-T-.md 'Atropos.IImmutableDeque&lt;T&gt;')[T](#Atropos-ImmutableDeque-AddRange-T-(Atropos-IImmutableDeque-T-_System-Collections-Generic-IEnumerable-T-)-T 'Atropos.ImmutableDeque.AddRange&lt;T&gt;(Atropos.IImmutableDeque&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;T&gt;).T')[&gt;](./IImmutableDeque-T-.md 'Atropos.IImmutableDeque&lt;T&gt;')  
The deque  
  
<a name='Atropos-ImmutableDeque-AddRange-T-(Atropos-IImmutableDeque-T-_System-Collections-Generic-IEnumerable-T-)-items'></a>
`items` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](#Atropos-ImmutableDeque-AddRange-T-(Atropos-IImmutableDeque-T-_System-Collections-Generic-IEnumerable-T-)-T 'Atropos.ImmutableDeque.AddRange&lt;T&gt;(Atropos.IImmutableDeque&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;T&gt;).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The list of items to enqueue on the right  
  
#### Returns
[Atropos.IImmutableDeque&lt;](./IImmutableDeque-T-.md 'Atropos.IImmutableDeque&lt;T&gt;')[T](#Atropos-ImmutableDeque-AddRange-T-(Atropos-IImmutableDeque-T-_System-Collections-Generic-IEnumerable-T-)-T 'Atropos.ImmutableDeque.AddRange&lt;T&gt;(Atropos.IImmutableDeque&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;T&gt;).T')[&gt;](./IImmutableDeque-T-.md 'Atropos.IImmutableDeque&lt;T&gt;')  
If the [items](#Atropos-ImmutableDeque-AddRange-T-(Atropos-IImmutableDeque-T-_System-Collections-Generic-IEnumerable-T-)-items 'Atropos.ImmutableDeque.AddRange&lt;T&gt;(Atropos.IImmutableDeque&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;T&gt;).items') collection is empty, then the original [deque](#Atropos-ImmutableDeque-AddRange-T-(Atropos-IImmutableDeque-T-_System-Collections-Generic-IEnumerable-T-)-deque 'Atropos.ImmutableDeque.AddRange&lt;T&gt;(Atropos.IImmutableDeque&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;T&gt;).deque') is returned.  
            If the [items](#Atropos-ImmutableDeque-AddRange-T-(Atropos-IImmutableDeque-T-_System-Collections-Generic-IEnumerable-T-)-items 'Atropos.ImmutableDeque.AddRange&lt;T&gt;(Atropos.IImmutableDeque&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;T&gt;).items') is another [IImmutableDeque&lt;T&gt;](./IImmutableDeque-T-.md 'Atropos.IImmutableDeque&lt;T&gt;'), then the [Concat(Atropos.IImmutableDeque&lt;T&gt;)](./IImmutableDeque-T--Concat(IImmutableDeque-T-).md 'Atropos.IImmutableDeque&lt;T&gt;.Concat(Atropos.IImmutableDeque&lt;T&gt;)') method is used.  
            Otherwise, [items](#Atropos-ImmutableDeque-AddRange-T-(Atropos-IImmutableDeque-T-_System-Collections-Generic-IEnumerable-T-)-items 'Atropos.ImmutableDeque.AddRange&lt;T&gt;(Atropos.IImmutableDeque&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;T&gt;).items') are fed one by one into the [EnqueueRight(T)](./IImmutableDeque-T--EnqueueRight(T).md 'Atropos.IImmutableDeque&lt;T&gt;.EnqueueRight(T)') method.  
