using System;
using System.Linq;
using Xunit;

namespace Atropos.Tests
{
    public class ImmutableListTest
    {
        [Fact]
        public void BasicTest()
        {
            var t = ImmutableList.Init(42, 5);
            Assert.Equal(Enumerable.Repeat(42, 5), t);

            t = t.Add(56);
            Assert.Equal(6, t.Count);

            var t2 = t.Add((object)"test");
            Assert.Equal(7, t2.Count);

        }
    }
}
