using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Atropos.Tests
{
    public class ImmutableDequeTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(30)]
        [InlineData(100)]
        public void InitRange(int size)
        {
            var items = Enumerable.Range(0, size);
            var d = ImmutableDeque.InitRange(items);
            Assert.Equal<int>(items, d);
        }

        [Fact]
        public void Empty()
        {
            IImmutableDeque<int> d = ImmutableDeque<int>.Empty;
            Assert.True(d.IsEmpty);
            Assert.Throws<InvalidOperationException>(() => d.DequeueLeft());
            Assert.Throws<InvalidOperationException>(() => d.DequeueRight());
            Assert.Throws<InvalidOperationException>(() => d.Left);
            Assert.Throws<InvalidOperationException>(() => d.Right);
        }
        [Fact]
        public void RightToLeft()
        {
            var d = ImmutableDeque<int>.Empty;
            // 0
            d = d.EnqueueRight(0);
            Assert.Equal(0, d.Left); Assert.Equal(0, d.Right);

            // 0, 1
            d = d.EnqueueRight(1); 
            Assert.Equal(0, d.Left); Assert.Equal(1, d.Right);

            // 0, 1, 2
            d = d.EnqueueRight(2);

            Assert.Equal(0, d.Left); Assert.Equal(2, d.Right);

            // 0, 1, 2, 3
            d = d.EnqueueRight(3);
            Assert.Equal(0, d.Left); Assert.Equal(3, d.Right);

            // 0, 1, 2, 3, 4
            d = d.EnqueueRight(4);
            Assert.Equal(0, d.Left); Assert.Equal(4, d.Right);

            // 1, 2, 3, 4
            d = d.DequeueLeft();
            Assert.Equal(1, d.Left); Assert.Equal(4, d.Right);

            // 2, 3, 4
            d = d.DequeueLeft();
            Assert.Equal(2, d.Left); Assert.Equal(4, d.Right);

            // 3, 4
            d = d.DequeueLeft();
            Assert.Equal(3, d.Left); Assert.Equal(4, d.Right);

            // 4
            d = d.DequeueLeft();
            Assert.Equal(4, d.Left); Assert.Equal(4, d.Right);

            //
            d = d.DequeueLeft();
            Assert.True(d.IsEmpty);
        }
        [Fact]
        public void LeftToRight()
        {
            var d = ImmutableDeque<int>.Empty;
            // 0
            d = d.EnqueueLeft(0);
            Assert.Equal(0, d.Right); Assert.Equal(0, d.Left);

            // 1, 0
            d = d.EnqueueLeft(1);
            Assert.Equal(0, d.Right); Assert.Equal(1, d.Left);

            // 2, 1, 0
            d = d.EnqueueLeft(2);

            Assert.Equal(0, d.Right); Assert.Equal(2, d.Left);

            // 3, 2, 1, 0
            d = d.EnqueueLeft(3);
            Assert.Equal(0, d.Right); Assert.Equal(3, d.Left);

            // 4, 3, 2, 1, 0
            d = d.EnqueueLeft(4);
            Assert.Equal(0, d.Right); Assert.Equal(4, d.Left);

            // 4, 3, 2, 1
            d = d.DequeueRight();
            Assert.Equal(1, d.Right); Assert.Equal(4, d.Left);

            // 4, 3, 2
            d = d.DequeueRight();
            Assert.Equal(2, d.Right); Assert.Equal(4, d.Left);

            // 4, 3
            d = d.DequeueRight();
            Assert.Equal(3, d.Right); Assert.Equal(4, d.Left);

            // 4
            d = d.DequeueRight();
            Assert.Equal(4, d.Right); Assert.Equal(4, d.Left);

            //
            d = d.DequeueRight();
            Assert.True(d.IsEmpty);
        }
    }
}
