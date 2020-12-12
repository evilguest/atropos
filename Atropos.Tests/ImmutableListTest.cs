using Newtonsoft.Json.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Xunit;

namespace Atropos.Tests
{
    public class ImmutableListTest
    {
        public static IEnumerable<object[]> Sizes()
        {
            foreach(var i in Enumerable.Range(1, 10))
            {
                yield return new object[] { (1 << i) - 1};
                yield return new object[] { (1 << i) };
                yield return new object[] { (1 << i) + 1 };
            }
        }

        [Theory]
        [MemberData(nameof(Sizes))]
        public void TestInit(int size)
        {
            var t = ImmutableList.Init(42, size);
            Assert.Equal(Enumerable.Repeat(42, size), t);
        }
        [Theory]
        [MemberData(nameof(Sizes))]
        public void TestInitNegative(int size)
        {
            Assert.Throws<ArgumentOutOfRangeException>("count", () => ImmutableList.Init(42, -size));
        }
        [Fact]
        public void TestClear()
        {
            var t = ImmutableList.Init(42, 10000);
            var c = t.Clear();
            Assert.Empty(c);
        }

        [Theory]
        [InlineData(5, 2)]
        [InlineData(15, 6)]
        [InlineData(31, 19)]
        [InlineData(63, 60)]
        [InlineData(127, 100)]
        public void TestIndexOfInt(int size, int value)
        {
            var c = Enumerable.Range(0, size);
            var t = ImmutableList.CreateRange(c);
            t += c;
            Assert.Equal(value, t.IndexOf(value));
            Assert.Equal(-1, t.IndexOf(size + value));
            Assert.Throws<IndexOutOfRangeException>(() => t.IndexOf(value, -1, 2 * size));
            Assert.Throws<IndexOutOfRangeException>(() => t.IndexOf(value, 0, 2 * size + 1));
        }
        [Theory]
        [InlineData(5, 2)]
        [InlineData(15, 6)]
        [InlineData(31, 19)]
        [InlineData(63, 60)]
        [InlineData(127, 100)]
        public void TestLastIndexOfInt(int size, int value)
        {
            var c = Enumerable.Range(0, size);
            var t = ImmutableList.CreateRange(c);
            t += c;
            Assert.Equal(size+value, t.LastIndexOf(value));
            Assert.Equal(-1, t.LastIndexOf(size + value));
            Assert.Throws<IndexOutOfRangeException>(() => t.LastIndexOf(value, 2 * size, 2 * size + 1));
            Assert.Throws<IndexOutOfRangeException>(() => t.LastIndexOf(value, 2 * size + 1, 2 * size));
        }
        [Fact]
        public void TestIndexOfString()
        {
            var t = ImmutableList.CreateRange(new[] {"Zero", "One", "Two", "Three", "Four", "Zero", "One", "Two", "Three", "Four" });
            Assert.Equal(2, t.IndexOf("Two"));
            Assert.Equal(-1, t.IndexOf("two"));
            Assert.Equal(3, t.IndexOf("three", StringComparer.InvariantCultureIgnoreCase));
        }

        [Fact]
        public void TestLastIndexOfString()
        {
            var t = ImmutableList.CreateRange(new[] { "Zero", "One", "Two", "Three", "Four", "Zero", "One", "Two", "Three", "Four" });
            Assert.Equal(2, t.IndexOf("Two"));
        }

        [Fact]
        public void TestAddSameType()
        {
            var len = 5;
            var oldVal = 42;
            var t = ImmutableList.Init(oldVal, len);
            var newVal = 56;
            t = t.Add(newVal);
            Assert.Equal(len+1, t.Count);
            Assert.Equal(newVal, t[len]);
        }

        [Fact]
        public void TestAddBaseType()
        {
            var t1 = ImmutableList.Init(new DerivedElement("Foo", 5));
            var t2 = t1.Add(new BaseElement("Bar"));

            var s = string.Join(", ", t2);

            Assert.Equal("DerivedElement(Foo, 5), BaseElement(Bar)", s);
        }

        [Fact]
        void TestInsertOutOfRange()
        {
            var t = (new[] { 0, 1, 2 }).ToImmutableList();
            Assert.Throws<IndexOutOfRangeException>(() => t + (-1, -1));
            Assert.Throws<IndexOutOfRangeException>(() => t + (4, 4));
        }


        [Fact]
        public void TestInsertBaseType()
        {
            var t1 = ImmutableList.Init(new DerivedElement("Foo", 5));
            var t2 = t1.Insert(0, new BaseElement("Bar"));

            var s = string.Join(", ", t2);

            Assert.Equal("BaseElement(Bar), DerivedElement(Foo, 5)", s);
        }

        [Theory]
        [MemberData(nameof(Sizes))]
        public void TestIndex(int size)
        {
            var t = Enumerable.Range(0, size).ToImmutableList();
            Assert.Throws<IndexOutOfRangeException>(() => t[-1]);
            for (int i = 0; i < size; i++)
                Assert.Equal(i, t[i]);
            Assert.Throws<IndexOutOfRangeException>(() => t[size]);
        }

        [Theory]
        [MemberData(nameof(Sizes))]
        public void TestAddRange(int size)
        {
            var r = Enumerable.Range(0, size);
            var t = ImmutableList<int>.Empty.AddRange(r);
            Assert.Equal(r, t);
        }

        [Fact]
        public void TestSetIntValue()
        {
            var newVal = 56;
            var t = ImmutableList.Init(42, 5);
            t |= (2, newVal);
            Assert.Equal(newVal, t[2]);
            Assert.Equal(t, t | (2, newVal)); // re-assignment should preserve the list 
        }
        [Fact]
        public void TestSetRefValue()
        {
            var len = 5;
            var oldVal = new BaseElement("Foo");
            var newVal = new BaseElement("Bar");
            var t = ImmutableList.Init(oldVal, len);
            t |= (2, newVal);
            Assert.Equal(newVal, t[2]);
        }

        
        [Fact]
        public void TestSetBaseValue()
        {
            var len = 5;
            var oldVal = new DerivedElement("Foo", 5);
            var newVal = new BaseElement("Bar");
            var t = ImmutableList.Init(oldVal, len);
            var t2 = t.SetItem(2, newVal);
            Assert.Equal(newVal, t2[2]);
        }

        [Theory]
        [InlineData(16, 5, 42)]
        public void InsertLast(int size, int iterations, int seed)
        {
            var t = ImmutableList.Init(seed, size);
            for (int i = 0; i < iterations; i++)
                t += i;
        }


        [Theory]
        [InlineData(10, 50, 42)]
        [InlineData(15, 5, 42)]
        [InlineData(16, 5, 42)]
        [InlineData(17, 5, 42)]
        [InlineData(33, 5, 42)]
        [InlineData(129, 5, 42)]
        [InlineData(524288, 100000, 42)]
        public void TestIntegerListContinuously(int size, int iterations, int seed)
        {
            var t = ImmutableList<int>.Empty.AddRange(Enumerable.Range(0, size));
            var r = new Random(seed);
            for(int i=0; i<iterations;i++)
            {
                var p = r.Next(size);
                var e = t[p];
                try
                {
                    t = t - p + (r.Next(size - 1), e);
                }
                catch(Exception exc)
                {
                    throw new InvalidOperationException($"Failed at i={i}", exc);
                }
            }
            Assert.Equal((long)size * (size - 1) / 2, t.LongSum());
        }
        [Theory]
        [InlineData(524288, 100000, 42)]
        public void TestIntegerListIndexContinuously(int size, int iterations, int value)
        {
            // 1. Init
            var t = ImmutableList<int>.Empty.AddRange(Enumerable.Range(0, size));
            t = t.SetItem(size / 2, value);
            var s = 0;
            // 2. Test
            for (int i = 0; i < iterations; i++)
                s += t[size / 2];
            Assert.Equal(iterations * value, s);
        }
        [Fact]
        public void TestRemoveAt()
        {
            var t = ImmutableList.CreateRange(Enumerable.Range(5, 5));
            t -= 2;
            Assert.Equal(new[] { 5, 6, 8, 9 }, t);
        }
        [Theory]
        [MemberData(nameof(Sizes))]
        public void TestRemoveAll(int size)
        {
            var t = ImmutableList.CreateRange(Enumerable.Range(0, size));
            t = t.RemoveAll(p => p % 2 == 1); // remove all odds
            Assert.Equal(from a in Enumerable.Range(0, (size + 1) / 2) select 2 * a, t);
        }

        [Fact]
        public void TestRemoveInt()
        {
            var t = Enumerable.Range(0, 100).ToImmutableList();
            t = t.Remove(2);
            Assert.Equal(-1, t.IndexOf(2));
            var t2 = t.Remove(2);
            Assert.Equal(t, t2);
        }
        [Fact] 
        public void TestRemoveString()
        {
            var t = (new[] { "Zero", "One", "Two", "Three", "Four", "Zero", "One", "Two", "Three", "Four" }).ToImmutableList();
            t -= "One";
            Assert.Equal(new[] { "Zero", "Two", "Three", "Four", "Zero", "One", "Two", "Three", "Four" }, t);
            t -= ("one", StringComparer.InvariantCultureIgnoreCase);
            Assert.Equal(new[] { "Zero", "Two", "Three", "Four", "Zero", "Two", "Three", "Four" }, t);
            t -= "One";
            Assert.Equal(new[] { "Zero", "Two", "Three", "Four", "Zero", "Two", "Three", "Four" }, t);
        }

        [Fact]
        public void TestReplace()
        {
            var t = (new[] { "Zero", "One", "Two", "Three", "Four", "Zero", "One", "Two", "Three", "Four" }).ToImmutableList();
            t = t.Replace("Zero", "Nothing");
            Assert.Equal(new[] { "Nothing", "One", "Two", "Three", "Four", "Zero", "One", "Two", "Three", "Four" }, t);
            
            t = t.Replace("zero", "Nothing", StringComparer.InvariantCultureIgnoreCase);
            Assert.Equal(new[] { "Nothing", "One", "Two", "Three", "Four", "Nothing", "One", "Two", "Three", "Four" }, t);

            Assert.Throws<ArgumentException>("oldValue", ()=>t.Replace("Zero", "Nothing"));

        }
        [Theory]
        [MemberData(nameof(Sizes))]
        public void TestInsertRange(int size)
        {
            var t = Enumerable.Range(0, size).ToImmutableList();
            int[] items = new[] { 8, 15, 16, 23, 42 };
            Assert.Throws<IndexOutOfRangeException>(() => t.InsertRange(-1, items));
            Assert.Throws<IndexOutOfRangeException>(() => t.InsertRange(size, items));
            t = t.InsertRange(size / 2, items);
            for (var i = 0; i < items.Length; i++)
                Assert.Equal(items[i], t[size / 2 + i]);
        }
        [Fact]
        public void TestRemoveRangeEmpty()
        {
            var t = Enumerable.Range(0, 512).ToImmutableList();
            Assert.Equal(t, t - Enumerable.Empty<int>());
        }
        [Theory]
        [MemberData(nameof(Sizes))]
        public void TestRemoveRangeInt(int size)
        {
            var t = Enumerable.Range(0, size).ToImmutableList();
            var t2 = t -= Enumerable.Range(-1, 2);
            Assert.Equal(t2.Count, size - 1); // we've removed 0, and skipped -1, so net delta of Count should be -1.
            Assert.Equal(-1, t2.IndexOf(0));
        }
        [Theory]
        [InlineData(10, 5, 5)]
        [InlineData(10, 0, 5)]
        [InlineData(100, 0, 100)]
        public void TestRemoveCountSuccess(int size, int index, int count)
        {
            var t = Enumerable.Range(0, size).ToImmutableList();
            var t2 = t.RemoveRange(index, count);
            Assert.Equal(t2.Count, size - count);
        }
        [Theory]
        [InlineData(10, 5, 6)]
        [InlineData(10, -1, 5)]
        public void TestRemoveCountFail(int size, int index, int count)
        {
            var t = Enumerable.Range(0, size).ToImmutableList();
            Assert.Throws<IndexOutOfRangeException>(()=>t.RemoveRange(index, count));
        }
        [Theory]
        [InlineData(10, 5, 5, 1)]
        [InlineData(10, 0, 5, 2)]
        [InlineData(100, 19, 8, 10)]
        [InlineData(100, 0, 8, 12)]
        public void TestRemoveCountBatch(int size, int index, int count, int batches)
        {
            var t = Enumerable.Range(0, size).ToImmutableList();
            for(var i=0; i<batches;i++)
                t = t.RemoveRange(index, count);
            Assert.Equal(t.Count, size - count * batches);
        }
        [Fact]
        public void TestClone()
        {
            var t = Enumerable.Range(0, 5).ToImmutableList();
            var l = ImmutableList.CreateRange(t);
            Assert.Equal(t, l);
        }
        [Fact]
        public void TestInterface()
        {
            IImmutableList<int> k = ImmutableList<int>.Empty;
            k = k.Add(43);
            Assert.Same(ImmutableList<int>.Empty, k.Clear());
            k = k.AddRange(new[] { 46, 47 });
            Assert.Equal(3, k.Count);
            k = k.Insert(0, 42);
            Assert.Equal(42, k[0]);
            Assert.Equal(4, k.Count);
            k = k.InsertRange(2, new[] { 44, 45 });
            Assert.Equal(Enumerable.Range(42, 6), k);
            k = k.SetItem(0, 46);
            Assert.Equal(46, k[0]);
            Assert.Equal(0, k.IndexOf(46));
            Assert.Equal(4, k.LastIndexOf(46));
            k = k.RemoveAll(i => i % 2 == 1);
            Assert.Equal(new[] { 46, 44, 46 }, k);
            k = k.Remove(46);
            Assert.Equal(new[] { 44, 46 }, k);
            Assert.Equal(ImmutableList<int>.Empty, k.RemoveRange(0, 2));
            k = k.RemoveRange(new[] { 46 });
            Assert.Equal(new[] { 44 }, k);
            k = k.Replace(44, 42);
            Assert.Equal(42, k[0]);
            k = k.RemoveAt(0);
            Assert.Equal(0, k.Count);
        }
    }
}
