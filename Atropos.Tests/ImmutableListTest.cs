using Newtonsoft.Json.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Atropos.Tests
{
    public class ImmutableListTest
    {
        public static IEnumerable<object[]> Sizes()
        {
            foreach(var i in Enumerable.Range(1, 20))
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
            var t = ImmutableList.InitRange(c);
            t += c;
            Assert.Equal(value, t.IndexOf(value));
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
            var t = ImmutableList.InitRange(c);
            t += c;
            Assert.Equal(size+value, t.LastIndexOf(value));
        }
        [Fact]
        public void TestIndexOfString()
        {
            var t = ImmutableList.InitRange(new[] {"Zero", "One", "Two", "Three", "Four", "Zero", "One", "Two", "Three", "Four" });
            Assert.Equal(2, t.IndexOf("Two"));
            Assert.Equal(-1, t.IndexOf("two"));
            Assert.Equal(3, t.IndexOf("three", StringComparer.InvariantCultureIgnoreCase));
        }

        [Fact]
        public void TestLastIndexOfString()
        {
            var t = ImmutableList.InitRange(new[] { "Zero", "One", "Two", "Three", "Four", "Zero", "One", "Two", "Three", "Four" });
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
        public void TestInsertBaseType()
        {
            var t1 = ImmutableList.Init(new DerivedElement("Foo", 5));
            var t2 = t1.Insert(0, new BaseElement("Bar"));

            var s = string.Join(", ", t2);

            Assert.Equal("BaseElement(Bar), DerivedElement(Foo, 5)", s);
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
            var len = 5;
            var oldVal = 42;
            var newVal = 56;
            var t = ImmutableList.Init(oldVal, len);
            t |= (2, newVal);
            Assert.Equal(newVal, t[2]);
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
            var t = ImmutableList.InitRange(Enumerable.Range(5, 5));
            t -= 2;
            Assert.Equal(new[] { 5, 6, 8, 9 }, t);
        }
        [Theory]
        [MemberData(nameof(Sizes))]
        public void TestRemoveAll(int size)
        {
            var t = ImmutableList.InitRange(Enumerable.Range(0, size));
            t = t.RemoveAll(p => p % 2 == 1); // remove all odds
            Assert.Equal(from a in Enumerable.Range(0, (size + 1) / 2) select 2 * a, t);
        }

    }
}
