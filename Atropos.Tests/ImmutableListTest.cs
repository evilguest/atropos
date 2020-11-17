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

/*        [Fact]
        public void TestAddBaseType()
        {
            var t1 = ImmutableList.Init(new DerivedElement("Foo", 5));
            var t2 = t1.Add(new BaseElement("Bar"));

            var s = string.Join(", ", t2);

            Assert.Equal("DerivedElement(Foo, 5), BaseElement(Bar)", s);
        }
*/
        [Theory]
        [InlineData(100)]
        public void TestAddRange(int size)
        {
            var r = Enumerable.Range(0, size);
            var t = new ImmutableList<int>().AddRange(r);
            Assert.Equal(r, t);
        }

        [Fact]
        public void TestSetStructValue()
        {
            var len = 5;
            var oldVal = 42;
            var newVal = 56;
            var t = ImmutableList.Init(oldVal, len);
            t = t.SetItem(2, newVal);
            Assert.Equal(newVal, t[2]);
        }
        [Fact]
        public void TestSetRefValue()
        {
            var len = 5;
            var oldVal = new BaseElement("Foo");
            var newVal = new BaseElement("Bar");
            var t = ImmutableList.Init(oldVal, len);
            var t2 = t.SetItem(2, newVal);
            Assert.Equal(newVal, t2[2]);
        }

        /*
        [Fact]
        public void TestSetBaseValue()
        {
            var len = 5;
            var oldVal = new DerivedElement("Foo", 5);
            var newVal = new BaseElement("Bar");
            var t = ImmutableList.Init(oldVal, len);
            var t2 = t.SetItem(2, newVal);
            Assert.Equal(newVal, t2[2]);
        }*/

        [Theory]
        [InlineData(16, 5, 42)]
        public void InsertLast(int size, int iterations, int seed)
        {
            var t = ImmutableList.Init(seed, size);
            for (int i = 0; i < iterations; i++)
                t = t.Insert(t.Count, i);
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
            var t = new ImmutableList<int>();
            t = t.AddRange(Enumerable.Range(0, size));
            var r = new Random(seed);
            for(int i=0; i<iterations;i++)
            {
                var p = r.Next(size);
                var e = t[p];
                t = t.RemoveAt(p).Insert(r.Next(size - 1), e);
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

    }
}
