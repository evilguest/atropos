using Newtonsoft.Json.Bson;
using System.Linq;
using Xunit;

namespace Atropos.Tests
{
    public class ImmutableListTest
    {
        [Fact]
        public void TestInit()
        {
            var t = ImmutableList.Init(42, 5);
            Assert.Equal(Enumerable.Repeat(42, 5), t);
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
    }
}
