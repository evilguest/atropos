using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using NUnit.Framework;

namespace Atropos.Tests
{
    [TestFixture]
    public sealed class ImmutableDictionaryTests
    {
        [Test]
        public void ImmutableDictionary_WorksAsExpected_WhenValuesAreImmutableLists()
        {
            var dictionary = new ImmutableDictionary<int, ImmutableList<int>>()
                .Add(1, new ImmutableList<int>(10, 70))
                .Add(2, new ImmutableList<int>(20, 70))
                .Add(3, new ImmutableList<int>(30, 70))
                .Add(4, new ImmutableList<int>(40, 70))
                .Add(5, new ImmutableList<int>(50, 70));

            Assert.True(dictionary.Count == 5);

            foreach (var value in dictionary.Values)
            {
                Assert.True(value.Count == 70);
            }

            dictionary[3].Add(100);
            Assert.False(dictionary[3].Contains(100));

            dictionary = dictionary.SetItem(4, dictionary[4].Add(200));
            Assert.True(dictionary[4].Contains(200));
        }


        [Test]
        public void GetValue_Returns()
        {
            var dictionary = new ImmutableDictionary<int, int>().Add(1, 2);
            Assert.AreEqual(2, dictionary[1]);
        }

        [Test]
        public void GetValue_Throw_WhenAbsent()
        {
            var dictionary = new ImmutableDictionary<int, int>().Add(1, 2);
            Assert.Throws<KeyNotFoundException>(() =>
            {
                var _ = dictionary[100];
            });

            dictionary = new ImmutableDictionary<int, int>();
            Assert.Throws<KeyNotFoundException>(() =>
            {
                var _ = dictionary[100];
            });
        }

        [Test]
        public void AddValue_Overwritten_WhenValueExists()
        {
            var dictionary = new ImmutableDictionary<int, int>().Add(1, 2).Add(1, 3);
            Assert.AreEqual(3, dictionary[1]);
        }

        [Test]
        public void AddRange_Test()
        {
            var dictionary = new ImmutableDictionary<int, int>();
            var pairs = new[]
            {
                new KeyValuePair<int, int>(1, 2),
                new KeyValuePair<int, int>(2, 3),
                new KeyValuePair<int, int>(3, 4)
            };
            dictionary = dictionary.AddRange(pairs);
            Assert.AreEqual(2, dictionary[1]);
            Assert.AreEqual(3, dictionary[2]);
            Assert.AreEqual(4, dictionary[3]);
        }

        [Test]
        public void SetItem_AddElement_WhenNotExists()
        {
            var dictionary = new ImmutableDictionary<int, int>().SetItem(1, 2);
            Assert.AreEqual(2, dictionary[1]);
        }

        [Test]
        public void SetItem_Overwritten_WhenValueExists()
        {
            var dictionary = new ImmutableDictionary<int, int>().SetItem(1, 2).SetItem(1, 3);
            Assert.AreEqual(3, dictionary[1]);
        }

        [Test]
        public void SetItems_AddElements_WhenNotExists()
        {
            var dictionary = new ImmutableDictionary<int, int>();
            var pairs = new[]
            {
                new KeyValuePair<int, int>(1, 2),
                new KeyValuePair<int, int>(2, 3),
                new KeyValuePair<int, int>(3, 4)
            };
            dictionary = dictionary.SetItems(pairs);
            Assert.AreEqual(2, dictionary[1]);
            Assert.AreEqual(3, dictionary[2]);
            Assert.AreEqual(4, dictionary[3]);
        }

        [Test]
        public void SetItems_AddElements_WhenValuesExists()
        {
            var dictionary = new ImmutableDictionary<int, int>();
            var pairs = new[]
            {
                new KeyValuePair<int, int>(1, 2),
                new KeyValuePair<int, int>(2, 3),
                new KeyValuePair<int, int>(3, 4)
            };
            dictionary = dictionary.SetItems(pairs);

            var pairsWithNewValues = new[]
            {
                new KeyValuePair<int, int>(1, 5),
                new KeyValuePair<int, int>(2, 6),
                new KeyValuePair<int, int>(3, 7)
            };
            dictionary = dictionary.SetItems(pairsWithNewValues);

            Assert.AreEqual(5, dictionary[1]);
            Assert.AreEqual(6, dictionary[2]);
            Assert.AreEqual(7, dictionary[3]);
        }

        [Test]
        public void Clear_ReturnsEmpty_WhenHasElements()
        {
            var dictionary = new ImmutableDictionary<int, int>();
            var pairs = new[]
            {
                new KeyValuePair<int, int>(1, 2),
                new KeyValuePair<int, int>(2, 3),
                new KeyValuePair<int, int>(3, 4)
            };
            dictionary = dictionary.AddRange(pairs);
            dictionary = dictionary.Clear();

            Assert.True(dictionary.Count == 0);
        }

        [Test]
        public void Clear_ReturnsThis_WhenEmpty()
        {
            var dictionary = new ImmutableDictionary<int, int>();
            var clearDictionary = dictionary.Clear();

            Assert.AreSame(dictionary, clearDictionary);
        }

        [Test]
        public void RemoveRange_ReturnsEmpty_WhenRemoveAllElements()
        {
            var dictionary = new ImmutableDictionary<int, int>();
            var pairs = new[]
            {
                new KeyValuePair<int, int>(1, 2),
                new KeyValuePair<int, int>(2, 3),
                new KeyValuePair<int, int>(3, 4)
            };
            dictionary = dictionary.AddRange(pairs);
            dictionary = dictionary.RemoveRange(pairs.Select(it => it.Key));

            Assert.True(dictionary.Count == 0);
        }

        [Test]
        public void TryGetKey_ReturnsTrue_WhenExists()
        {
            var dictionary = new ImmutableDictionary<int, int>().Add(1, 2);
            Assert.True(dictionary.TryGetKey(1, out var actualKey));
            Assert.AreEqual(1, actualKey);
        }

        [Test]
        public void TryGetKey_ReturnsFalse_WhenNotExists()
        {
            var dictionary = new ImmutableDictionary<int, int>().Add(1, 2);
            Assert.False(dictionary.TryGetKey(3, out var actualKey));
            Assert.AreEqual(3, actualKey);
        }

        [Test]
        public void Contains_ReturnsTrue_WhenPairExists()
        {
            var dictionary = new ImmutableDictionary<int, int>().Add(1, 2).Add(2, 3);
            Assert.True(dictionary.Contains(new KeyValuePair<int, int>(1, 2)));
            Assert.True(dictionary.Contains(new KeyValuePair<int, int>(2, 3)));
        }

        [Test]
        public void Contains_ReturnsFalse_WhenPairNotExists()
        {
            var dictionary = new ImmutableDictionary<int, int>().Add(1, 2).Add(2, 3);
            Assert.False(dictionary.Contains(new KeyValuePair<int, int>(1, 3)));
            Assert.False(dictionary.Contains(new KeyValuePair<int, int>(2, 2)));
        }

        [Test]
        public void ContainsKey_ReturnsTrue_WhenKeyExists()
        {
            var dictionary = new ImmutableDictionary<int, int>().Add(1, 2).Add(2, 3);
            Assert.True(dictionary.ContainsKey(1));
            Assert.True(dictionary.ContainsKey(2));
        }

        [Test]
        public void ContainsKey_ReturnsFalse_WhenKeyNotExists()
        {
            var dictionary = new ImmutableDictionary<int, int>().Add(1, 2).Add(2, 3);
            Assert.False(dictionary.ContainsKey(3));
            Assert.False(dictionary.ContainsKey(4));
        }

        [Test]
        public void RemoveKey_Removed_WhenExists()
        {
            var dictionary = new ImmutableDictionary<int, int>()
                .Add(1, 2)
                .Add(2, 3)
                .Remove(1);

            Assert.False(dictionary.TryGetValue(1, out _));

            dictionary = dictionary.Remove(2);
            Assert.False(dictionary.TryGetValue(2, out _));
        }

        [Test]
        public void ModifyDictionary_OriginalNotChanged()
        {
            var empty = new ImmutableDictionary<int, int>();

            var map_1_10 = empty.Add(1, 10);
            var map_1_10_2_20 = map_1_10.Add(2, 20);
            var map_1_10_2_30 = map_1_10.Add(2, 30);
            var map_2_20 = map_1_10_2_20.Remove(1);

            Assert.False(empty.Any());
            Assert.False(empty.ContainsKey(1));
            Assert.False(empty.ContainsKey(2));
            Assert.True(map_1_10.Any());
            Assert.True(map_1_10.ContainsKey(1));
            Assert.False(map_1_10.ContainsKey(2));
            Assert.True(map_1_10_2_30.ContainsKey(1));
            Assert.True(map_1_10_2_30.ContainsKey(2));
            Assert.False(map_2_20.ContainsKey(1));
            Assert.True(map_1_10_2_20.Count == 2);
            Assert.True(map_1_10_2_30.Count == 2);
            Assert.True(map_1_10_2_20[2] == 20);
            Assert.True(map_1_10_2_30[2] == 30);
        }

        [Test]
        public void Enumerate_ContainsKeysAndValues()
        {
            var dictionary = new ImmutableDictionary<int, int>();
            for (var i = 0; i < 10; ++i)
            {
                dictionary = dictionary.Add(i, i);
            }

            CollectionAssert.AreEqual(Enumerable.Range(0, 10), dictionary.Values);
            CollectionAssert.AreEqual(Enumerable.Range(0, 10), dictionary.Keys);
            CollectionAssert.AreEqual(Enumerable.Range(0, 10), dictionary.Select(pair => pair.Key));
        }

        // [Test]
        // public void InterfaceMethods_WorksAsExpected()
        // {
        //     IImmutableDictionary<int, int> dictionary = new ImmutableDictionary<int, int>();
        //
        //     dictionary = dictionary.Add(1, 2);
        //     Assert.AreEqual(2, dictionary[1]);
        //
        //     dictionary = dictionary.AddRange(new List<KeyValuePair<int, int>>
        //     {
        //         new KeyValuePair<int, int>(3, 4),
        //         new KeyValuePair<int, int>(5, 6)
        //     });
        //
        //     Assert.AreEqual(4, dictionary[3]);
        //     Assert.AreEqual(6, dictionary[5]);
        //
        //     dictionary = dictionary.RemoveRange(new[] {1, 3});
        //
        //     Assert.AreEqual(6, dictionary[5]);
        //
        //     dictionary = dictionary.
        // }

        [Test]
        public void InterfaceAddValue_Overwritten_WhenValueExists()
        {
            IImmutableDictionary<int, int> dictionary = new ImmutableDictionary<int, int>().Add(1, 2);
            dictionary = dictionary.Add(1, 3);
            Assert.AreEqual(3, dictionary[1]);
        }

        [Test]
        public void InterfaceAddRange_Test()
        {
            IImmutableDictionary<int, int> dictionary = new ImmutableDictionary<int, int>();
            var pairs = new[]
            {
                new KeyValuePair<int, int>(1, 2),
                new KeyValuePair<int, int>(2, 3),
                new KeyValuePair<int, int>(3, 4)
            };
            dictionary = dictionary.AddRange(pairs);
            Assert.AreEqual(2, dictionary[1]);
            Assert.AreEqual(3, dictionary[2]);
            Assert.AreEqual(4, dictionary[3]);
        }

        [Test]
        public void InterfaceSetItem_AddElement_WhenNotExists()
        {
            IImmutableDictionary<int, int> dictionary = new ImmutableDictionary<int, int>();
            dictionary = dictionary.SetItem(1, 2);
            Assert.AreEqual(2, dictionary[1]);
        }

        [Test]
        public void InterfaceSetItem_Overwritten_WhenValueExists()
        {
            IImmutableDictionary<int, int> dictionary = new ImmutableDictionary<int, int>();
            dictionary = dictionary.SetItem(1, 2);
            dictionary = dictionary.SetItem(1, 3);
            Assert.AreEqual(3, dictionary[1]);
        }

        [Test]
        public void InterfaceSetItems_AddElements_WhenNotExists()
        {
            IImmutableDictionary<int, int> dictionary = new ImmutableDictionary<int, int>();
            var pairs = new[]
            {
                new KeyValuePair<int, int>(1, 2),
                new KeyValuePair<int, int>(2, 3),
                new KeyValuePair<int, int>(3, 4)
            };
            dictionary = dictionary.SetItems(pairs);
            Assert.AreEqual(2, dictionary[1]);
            Assert.AreEqual(3, dictionary[2]);
            Assert.AreEqual(4, dictionary[3]);
        }

        [Test]
        public void InterfaceSetItems_AddElements_WhenValuesExists()
        {
            IImmutableDictionary<int, int> dictionary = new ImmutableDictionary<int, int>();
            var pairs = new[]
            {
                new KeyValuePair<int, int>(1, 2),
                new KeyValuePair<int, int>(2, 3),
                new KeyValuePair<int, int>(3, 4)
            };
            dictionary = dictionary.SetItems(pairs);

            var pairsWithNewValues = new[]
            {
                new KeyValuePair<int, int>(1, 5),
                new KeyValuePair<int, int>(2, 6),
                new KeyValuePair<int, int>(3, 7)
            };
            dictionary = dictionary.SetItems(pairsWithNewValues);

            Assert.AreEqual(5, dictionary[1]);
            Assert.AreEqual(6, dictionary[2]);
            Assert.AreEqual(7, dictionary[3]);
        }

        [Test]
        public void InterfaceClear_ReturnsEmpty_WhenHasElements()
        {
            IImmutableDictionary<int, int> dictionary = new ImmutableDictionary<int, int>();
            var pairs = new[]
            {
                new KeyValuePair<int, int>(1, 2),
                new KeyValuePair<int, int>(2, 3),
                new KeyValuePair<int, int>(3, 4)
            };
            dictionary = dictionary.AddRange(pairs);
            dictionary = dictionary.Clear();

            Assert.True(dictionary.Count == 0);
        }

        [Test]
        public void InterfaceClear_ReturnsThis_WhenEmpty()
        {
            IImmutableDictionary<int, int> dictionary = new ImmutableDictionary<int, int>();
            var clearDictionary = dictionary.Clear();

            Assert.AreSame(dictionary, clearDictionary);
        }

        [Test]
        public void InterfaceRemoveRange_ReturnsEmpty_WhenRemoveAllElements()
        {
            IImmutableDictionary<int, int> dictionary = new ImmutableDictionary<int, int>();
            var pairs = new[]
            {
                new KeyValuePair<int, int>(1, 2),
                new KeyValuePair<int, int>(2, 3),
                new KeyValuePair<int, int>(3, 4)
            };
            dictionary = dictionary.AddRange(pairs);
            dictionary = dictionary.RemoveRange(pairs.Select(it => it.Key));

            Assert.True(dictionary.Count == 0);
        }

        [Test]
        public void InterfaceTryGetKey_ReturnsTrue_WhenExists()
        {
            IImmutableDictionary<int, int> dictionary = new ImmutableDictionary<int, int>();
            dictionary = dictionary.Add(1, 2);
            Assert.True(dictionary.TryGetKey(1, out var actualKey));
            Assert.AreEqual(1, actualKey);
        }

        [Test]
        public void InterfaceTryGetKey_ReturnsFalse_WhenNotExists()
        {
            IImmutableDictionary<int, int> dictionary = new ImmutableDictionary<int, int>();
            dictionary = dictionary.Add(1, 2);
            Assert.False(dictionary.TryGetKey(3, out var actualKey));
            Assert.AreEqual(3, actualKey);
        }

        [Test]
        public void InterfaceContains_ReturnsTrue_WhenPairExists()
        {
            IImmutableDictionary<int, int> dictionary = new ImmutableDictionary<int, int>();
            dictionary = dictionary.Add(1, 2);
            dictionary = dictionary.Add(2, 3);
            Assert.True(dictionary.Contains(new KeyValuePair<int, int>(1, 2)));
            Assert.True(dictionary.Contains(new KeyValuePair<int, int>(2, 3)));
        }

        [Test]
        public void InterfaceContains_ReturnsFalse_WhenPairNotExists()
        {
            IImmutableDictionary<int, int> dictionary = new ImmutableDictionary<int, int>();
            dictionary = dictionary.Add(1, 2);
            dictionary = dictionary.Add(2, 3);
            Assert.False(dictionary.Contains(new KeyValuePair<int, int>(1, 3)));
            Assert.False(dictionary.Contains(new KeyValuePair<int, int>(2, 2)));
        }
    }
}