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
            var t = ImmutableList.Init(42, 5);
            t = t.Add(56);
            Assert.Equal(6, t.Count);

        }

        [Fact]
        public void TestAddBaseType()
        {
            var t1 = ImmutableList.Init(new DerivedElement("Foo", 5));
            var t2 = t1.Add(new BaseElement("Bar"));

            var s = string.Join(", ", t2);

            Assert.Equal("DerivedElement(Foo, 5), BaseElement(Bar)", s);
        }
    }
}
