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
            var d = ImmutableDeque.CreateRange(items);
            Assert.Equal<int>(items, d);
            var d2 = ImmutableDeque.CreateRange(d);
            Assert.Equal<int>(d, d2);
        }

        [Fact]
        public void InitRangeNull() => Assert.Throws<ArgumentNullException>("items", () => ImmutableDeque.CreateRange((int[])null));

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
            Assert.True(d.IsEmpty);
            // 0
            d = d.EnqueueRight(0);
            Assert.False(d.IsEmpty);
            Assert.Equal(0, d.Left); Assert.Equal(0, d.Right);

            // 0, 1
            d = d.EnqueueRight(1);
            Assert.False(d.IsEmpty);
            Assert.Equal(0, d.Left); Assert.Equal(1, d.Right);

            // 0, 1, 2
            d = d.EnqueueRight(2);
            Assert.False(d.IsEmpty);
            Assert.Equal(0, d.Left); Assert.Equal(2, d.Right);

            // 0, 1, 2, 3
            d = d.EnqueueRight(3);
            Assert.False(d.IsEmpty);
            Assert.Equal(0, d.Left); Assert.Equal(3, d.Right);

            // 0, 1, 2, 3, 4
            d = d.EnqueueRight(4);
            Assert.False(d.IsEmpty);
            Assert.Equal(0, d.Left); Assert.Equal(4, d.Right);

            // 1, 2, 3, 4
            d = d.DequeueLeft();
            Assert.False(d.IsEmpty);
            Assert.Equal(1, d.Left); Assert.Equal(4, d.Right);

            // 2, 3, 4
            d = d.DequeueLeft();
            Assert.False(d.IsEmpty);
            Assert.Equal(2, d.Left); Assert.Equal(4, d.Right);

            // 3, 4
            d = d.DequeueLeft();
            Assert.False(d.IsEmpty);
            Assert.Equal(3, d.Left); Assert.Equal(4, d.Right);

            // 4
            d = d.DequeueLeft();
            Assert.False(d.IsEmpty);
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
        [Fact]
        public void RightToRight()
        {
            var d = ImmutableDeque<int>.Empty;
            Assert.True(d.IsEmpty);
            // 0
            d = d.EnqueueRight(0);
            Assert.False(d.IsEmpty);
            Assert.Equal(0, d.Left); Assert.Equal(0, d.Right);

            // 0, 1
            d = d.EnqueueRight(1);
            Assert.False(d.IsEmpty);
            Assert.Equal(0, d.Left); Assert.Equal(1, d.Right);

            // 0, 1, 2
            d = d.EnqueueRight(2);
            Assert.False(d.IsEmpty);
            Assert.Equal(0, d.Left); Assert.Equal(2, d.Right);

            // 0, 1, 2, 3
            d = d.EnqueueRight(3);
            Assert.False(d.IsEmpty);
            Assert.Equal(0, d.Left); Assert.Equal(3, d.Right);

            // 0, 1, 2, 3, 4
            d = d.EnqueueRight(4);
            Assert.False(d.IsEmpty);
            Assert.Equal(0, d.Left); Assert.Equal(4, d.Right);

            // 0, 1, 2, 3
            d = d.DequeueRight();
            Assert.False(d.IsEmpty);
            Assert.Equal(0, d.Left); Assert.Equal(3, d.Right);

            // 0, 1, 2 
            d = d.DequeueRight();
            Assert.False(d.IsEmpty);
            Assert.Equal(0, d.Left); Assert.Equal(2, d.Right);

            // 0, 1
            d = d.DequeueRight();
            Assert.False(d.IsEmpty);
            Assert.Equal(0, d.Left); Assert.Equal(1, d.Right);

            // 0
            d = d.DequeueRight();
            Assert.False(d.IsEmpty);
            Assert.Equal(0, d.Left); Assert.Equal(0, d.Right);

            //
            d = d.DequeueRight();
            Assert.True(d.IsEmpty);
        }
        [Fact]
        public void LeftToLeft()
        {
            var d = ImmutableDeque<int>.Empty;
            Assert.True(d.IsEmpty);
            // 0
            d = d.EnqueueLeft(0);
            Assert.False(d.IsEmpty);
            Assert.Equal(0, d.Right); Assert.Equal(0, d.Left);

            // 1, 0
            d = d.EnqueueLeft(1);
            Assert.False(d.IsEmpty);
            Assert.Equal(0, d.Right); Assert.Equal(1, d.Left);

            // 2, 1, 0
            d = d.EnqueueLeft(2);
            Assert.False(d.IsEmpty);
            Assert.Equal(0, d.Right); Assert.Equal(2, d.Left);

            // 3, 2, 1, 0
            d = d.EnqueueLeft(3);
            Assert.False(d.IsEmpty);
            Assert.Equal(0, d.Right); Assert.Equal(3, d.Left);

            // 4, 3, 2, 1, 0
            d = d.EnqueueLeft(4);
            Assert.False(d.IsEmpty);
            Assert.Equal(0, d.Right); Assert.Equal(4, d.Left);

            // 3, 2, 1, 0
            d = d.DequeueLeft();
            Assert.False(d.IsEmpty);
            Assert.Equal(0, d.Right); Assert.Equal(3, d.Left);

            // 2, 1, 0
            d = d.DequeueLeft();
            Assert.False(d.IsEmpty);
            Assert.Equal(0, d.Right); Assert.Equal(2, d.Left);

            // 1, 0
            d = d.DequeueLeft();
            Assert.False(d.IsEmpty);
            Assert.Equal(0, d.Right); Assert.Equal(1, d.Left);

            // 0
            d = d.DequeueLeft();
            Assert.False(d.IsEmpty);
            Assert.Equal(0, d.Right); Assert.Equal(0, d.Left);

            //
            d = d.DequeueLeft();
            Assert.True(d.IsEmpty);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        [InlineData(1, 3)]
        [InlineData(2, 2)]
        [InlineData(3, 1)]
        [InlineData(1, 4)]
        [InlineData(2, 3)]
        [InlineData(3, 2)]
        [InlineData(4, 1)]
        [InlineData(1, 5)]
        [InlineData(2, 4)]
        [InlineData(3, 3)]
        [InlineData(4, 2)]
        [InlineData(5, 1)]
        [InlineData(1, 6)]
        [InlineData(2, 5)]
        [InlineData(3, 4)]
        [InlineData(4, 3)]
        [InlineData(5, 2)]
        [InlineData(6, 1)]
        [InlineData(1, 100)]
        [InlineData(100, 1)]
        [InlineData(100, 2)]
        [InlineData(2, 100)]
        public void Concat(int leftSize, int rightSize)
        {
            var l = Enumerable.Range(0, leftSize);
            var r = Enumerable.Range(0, rightSize);
            var d = ImmutableDeque.CreateRange(l).Concat(ImmutableDeque.CreateRange(r));
            Assert.Equal<int>(d, l.Concat(r));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        void AddRange(int size)
        {
            var r = Enumerable.Range(0, size);
            var d = ImmutableDeque.CreateRange(r);
            var d1 = d.AddRange(r);
            Assert.Equal<int>(r.Concat(r), d1);
            var d2 = d.AddRange(d);
            Assert.Equal<int>(r.Concat(r), d2);
        }
    }
}
