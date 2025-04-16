using System;
using System.Collections.Generic;
using Xunit;
using ListOperationsLib;
using System.Numerics;

namespace ListOperationsLib.Tests
{
    public class ListOperationsTests
    {
        [Fact]
        public void AddUnique_AddsItemToEmptyList()
        {
            var list = new List<int>();
            bool result = ListOperations.AddUnique(list, 1);

            Assert.True(result);
            Assert.Single(list);
            Assert.Equal(1, list[0]);
        }

        [Fact]
        public void AddUnique_DoesNotAddDuplicateItem()
        {
            var list = new List<int> { 1, 2, 3 };
            bool result = ListOperations.AddUnique(list, 2);

            Assert.False(result);
            Assert.Equal(3, list.Count);
        }

        [Fact]
        public void AddUnique_ThrowsOnNullList()
        {
            Assert.Throws<ArgumentNullException>(() => ListOperations.AddUnique<int>(null, 1));
        }

        [Fact]
        public void RemoveAllOccurrences_RemovesAllMatches()
        {
            var list = new List<int> { 1, 2, 3, 2, 4, 2 };
            int removed = ListOperations.RemoveAllOccurrences(list, 2);

            Assert.Equal(3, removed);
            Assert.Equal(3, list.Count);
            Assert.DoesNotContain(2, list);
        }

        [Fact]
        public void RemoveAllOccurrences_ReturnsZeroWhenNoMatches()
        {
            var list = new List<int> { 1, 3, 5 };
            int removed = ListOperations.RemoveAllOccurrences(list, 2);

            Assert.Equal(0, removed);
            Assert.Equal(3, list.Count);
        }

        [Fact]
        public void RemoveAllOccurrences_ThrowsOnNullList()
        {
            Assert.Throws<ArgumentNullException>(() => ListOperations.RemoveAllOccurrences<int>(null, 1));
        }

        [Fact]
        public void FindIndex_ReturnsCorrectIndex()
        {
            var list = new List<string> { "apple", "banana", "cherry" };
            int index = ListOperations.FindIndex(list, s => s.StartsWith("b"));

            Assert.Equal(1, index);
        }

        [Fact]
        public void FindIndex_ReturnsMinusOneWhenNotFound()
        {
            var list = new List<string> { "apple", "banana", "cherry" };
            int index = ListOperations.FindIndex(list, s => s.StartsWith("d"));

            Assert.Equal(-1, index);
        }

        [Fact]
        public void FindIndex_ThrowsOnNullList()
        {
            Assert.Throws<ArgumentNullException>(() => ListOperations.FindIndex<int>(null, x => x == 1));
        }

        [Fact]
        public void FindIndex_ThrowsOnNullPredicate()
        {
            var list = new List<int> { 1, 2, 3 };
            Assert.Throws<ArgumentNullException>(() => ListOperations.FindIndex(list, null));
        }

        [Fact]
        public void GetDistinct_ReturnsUniqueItems()
        {
            var list = new List<int> { 1, 2, 2, 3, 3, 3 };
            var distinct = ListOperations.GetDistinct(list);

            Assert.Equal(3, distinct.Count);
            Assert.Contains(1, distinct);
            Assert.Contains(2, distinct);
            Assert.Contains(3, distinct);
        }

        [Fact]
        public void GetDistinct_ThrowsOnNullList()
        {
            Assert.Throws<ArgumentNullException>(() => ListOperations.GetDistinct<int>(null));
        }
    }
}