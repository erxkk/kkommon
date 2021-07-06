using System;
using System.Collections.Generic;
using System.Linq;

using Kkommon.Collections;
using Kkommon.Extensions.Enumerable;

using Xunit;

namespace Kkommon.Tests.Extensions
{
    public sealed class EnumerableChunkingTests
    {
        [Fact]
        public void Chunks_Divisible_Correctly()
        {
            const int n = 3;

            int[] intArray =
            {
                0, 1, 2,
                3, 4, 5,
                6, 7, 8,
            };

            IEnumerable<IList<int>> chunks = intArray.Chunk(n);

            Assert.Equal(n, chunks.Count());

            Assert.Equal(new[] { 0, 1, 2 }, chunks.ElementAt(0));
            Assert.Equal(new[] { 3, 4, 5 }, chunks.ElementAt(1));
            Assert.Equal(new[] { 6, 7, 8 }, chunks.ElementAt(2));
        }

        [Fact]
        public void Chunks_Indivisible_Correctly()
        {
            const int n = 3;

            int[] intArray =
            {
                0, 1, 2,
                3, 4, 5,
                6, 7, 8,
                9,
            };

            IEnumerable<IList<int>> chunks = intArray.Chunk(n);

            Assert.Equal(n + 1, chunks.Count());

            Assert.Equal(new[] { 0, 1, 2 }, chunks.ElementAt(0));
            Assert.Equal(new[] { 3, 4, 5 }, chunks.ElementAt(1));
            Assert.Equal(new[] { 6, 7, 8 }, chunks.ElementAt(2));
            Assert.Equal(new[] { 9 }, chunks.ElementAt(3));
        }

        [Fact]
        public void Doesnt_Chunk_Empty()
        {
            const int n = 3;
            int[] intArray = Array.Empty<int>();
            IEnumerable<IList<int>> chunks = intArray.Chunk(n);

            Assert.Empty(chunks);
        }

        [Fact]
        public void Chunks_Array_Into_Segments()
        {
            const int n = 3;

            int[] intArray =
            {
                0, 1, 2,
                3, 4, 5,
                6, 7, 8,
            };

            IEnumerable<IList<int>> chunks = intArray.Chunk(n);

            Assert.Equal(n, chunks.Count());
            Assert.Equal(n, chunks.OfType<ArraySegment<int>>().Count());
        }

        [Fact]
        public void Chunks_List_Into_Segments()
        {
            const int n = 3;

            List<int> intArray = new(n * n)
            {
                0, 1, 2,
                3, 4, 5,
                6, 7, 8,
            };

            IEnumerable<IList<int>> chunks = intArray.Chunk(n);

            Assert.Equal(n, chunks.Count());
            Assert.Equal(n, chunks.OfType<ListSegment<int>>().Count());
        }

        [Fact]
        public void Chunks_Collection_Into_Arrays()
        {
            const int n = 3;

            LinkedList<int> intCollection = new(
                new[]
                {
                    0, 1, 2,
                    3, 4, 5,
                    6, 7, 8,
                }
            );

            IEnumerable<IList<int>> chunks = intCollection.Chunk(n);

            Assert.Equal(n, chunks.Count());
            Assert.Equal(n, chunks.OfType<int[]>().Count());
        }

        [Fact]
        public void Chunks_Enumerable_Into_Arrays()
        {
            const int n = 3;

            ConcreteEnumerable<int> intCollection = new(
                new[]
                {
                    0, 1, 2,
                    3, 4, 5,
                    6, 7, 8,
                }
            );

            IEnumerable<IList<int>> chunks = intCollection.Chunk(n);

            Assert.Equal(n, chunks.Count());
            Assert.Equal(n, chunks.OfType<int[]>().Count());
        }
    }
}