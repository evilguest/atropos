using System;
using System.Linq;
using NUnit.Framework;

namespace Atropos.Tests
{
    [TestFixture]
    public class TreeNodeTests
    {
        private const int Seed = 100;

        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(10000)]
        [TestCase(100000)]
        public void InsertCountNodes_HeightIsLogCount(int count)
        {
            var random = new Random(Seed);
            var node = new TreeNode<int>(random.Next());
            for (var i = 0; i < count; ++i)
            {
                node = node.Insert(random.Next());
            }

            //max AVL-tree height
            Assert.True(node.Height < 1.45 * Math.Log(count + 2, 2));
        }

        [Test]
        public void InsertValue_ThrowsException_WhenExists()
        {
            Assert.Throws<NotSupportedException>(() =>
            {
                var unused = new TreeNode<int>(10).Insert(10);
            });
        }

        [Test]
        public void ToString_Test()
        {
            Assert.True(new TreeNode<int>(1).ToString().Contains("1"));
        }

        [Test]
        public void InsertValues_ReturnedInSortedOrder_WhenEnumerate()
        {
            var random = new Random(Seed);
            var node = new TreeNode<int>(random.Next());
            for (var i = 0; i < 100000; ++i)
            {
                node = node.Insert(random.Next());
            }

            var prevValue = int.MinValue;
            foreach (var value in node)
            {
                Assert.True(value > prevValue);
                prevValue = value;
            }
        }

        [Test]
        public void RemoveMin_ReturnsNull_WhenHeightIsOne()
        {
            var node = new TreeNode<int>(100);
            Assert.Null(node.RemoveMin(out var min));
            Assert.AreEqual(100, min);
        }

        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(10000)]
        [TestCase(100000)]
        public void RemoveMin_ReturnNodeWithRemovedMin_WhenHeightMoreThanOne(int count)
        {
            var random = new Random(Seed);
            var node = new TreeNode<int>(random.Next());
            for (var i = 0; i < count; ++i)
            {
                node = node.Insert(random.Next());
            }

            var values = node.ToList();
            var valuesAfterRemove = node.RemoveMin(out var min)?.ToList();

            Assert.NotNull(valuesAfterRemove);
            Assert.AreEqual(values[0], min);
            CollectionAssert.AreEqual(values.Skip(1), valuesAfterRemove);
            CollectionAssert.AreEqual(node.Skip(1), node.RemoveMin(out _));
        }

        [Test]
        public void Remove_ReturnNull_WhenHeightIsOne()
        {
            var node = new TreeNode<int>(100);
            Assert.Null(node.Remove(100, out var success));
            Assert.True(success);
        }

        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(10000)]
        [TestCase(100000)]
        public void Remove_ReturnNodeWithRemoved_WhenValuesExist(int count)
        {
            var random = new Random(Seed);
            var node = new TreeNode<int>(random.Next());
            for (var i = 0; i < count; ++i)
            {
                node = node.Insert(random.Next());
            }

            var values = node.ToList();
            var withoutFirst = node.Remove(values[0], out var success1);
            var withoutMiddle = node.Remove(values[count / 2], out var success2);
            var withoutLast = node.Remove(values[count], out var success3);

            Assert.True(success1);
            Assert.True(success2);
            Assert.True(success3);
            CollectionAssert.AreEqual(node.Skip(1), withoutFirst);
            CollectionAssert.AreEqual(node.Take(count / 2).Union(node.Skip(count / 2 + 1)), withoutMiddle);
            CollectionAssert.AreEqual(node.Take(count), withoutLast);
        }

        [Test]
        public void Remove_ReturnSameWithFalse_WhenValueIsAbsent()
        {
            var node = new TreeNode<int>(0);
            for (var i = 1; i < 100; ++i)
            {
                node = node.Insert(i * 2);
            }

            for (var i = 0; i < 101; ++i)
            {
                var newNode = node.Remove(i * 2 - 1, out var success);
                Assert.AreSame(node, newNode);
                Assert.False(success);
            }
        }
    }
}