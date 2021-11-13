using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using JetBrains.Annotations;

namespace Kkommon.Extensions.Enumerable
{
    [PublicAPI]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ChunkingEnumerableExtensions
    {
        /// <summary>
        ///     Returns chunks of a given size for the given <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <param name="source">The source enumerable to chunk.</param>
        /// <param name="chunkSize">The size of the chunks.</param>
        /// <typeparam name="TSource">The type of the elements in the source <see cref="IEnumerable{T}" />.</typeparam>
        /// <returns>
        ///     An <see cref="IEnumerable{T}"/> containing the chunks of the given <see cref="IEnumerable{T}"/>.
        /// </returns>
        [Pure]
        [Obsolete("use built in IEnumerable.Chunk()")]
        public static IEnumerable<TSource[]> ChunkOld<TSource>(
            [InstantHandle] this IEnumerable<TSource> source,
            int chunkSize
        )
        {
            Preconditions.NotNull(source);
            Preconditions.Greater(chunkSize, 1);

            return source switch
            {
                TSource[] a => a.ChunkArray(chunkSize),
                ICollection<TSource> c => c.ChunkCollection(chunkSize),
                _ => source.ChunkEnumerable(chunkSize),
            };
        }

        private static IEnumerable<TSource[]> ChunkEnumerable<TSource>(this IEnumerable<TSource> source, int chunkSize)
        {
            TSource[]? chunk = null;
            int chunkIndex = 0;

            foreach ((int index, TSource item) in source.Enumerate())
            {
                chunkIndex = index % chunkSize;

                if (chunkIndex == 0)
                    chunk = new TSource[chunkSize];

                chunk![chunkIndex] = item;

                if (chunkIndex == chunkSize - 1)
                    yield return chunk;
            }

            if (chunk is null)
            {
                yield break;
            }

            if (chunkIndex != 0 && chunkIndex < chunkSize - 1)
            {
                Array.Resize(ref chunk, chunkIndex - 1);
                yield return chunk;
            }
        }

        private static IEnumerable<TSource[]> ChunkCollection<TSource>(
            [InstantHandle] this ICollection<TSource> source,
            int chunkSize
        )
        {
            if (source.Count <= chunkSize)
            {
                yield return source.ToArray();
            }
            else
            {
                TSource[] chunk = null!;
                int lastChunkSize = source.Count % chunkSize;

                foreach ((int index, TSource item) in source.Enumerate())
                {
                    int chunkIndex = index % chunkSize;

                    if (chunkIndex == 0)
                        chunk = new TSource[index >= source.Count - lastChunkSize ? lastChunkSize : chunkSize];

                    chunk[chunkIndex] = item;

                    if (chunkIndex == chunkSize - 1)
                        yield return chunk;
                }

                if (lastChunkSize != 0)
                    yield return chunk;
            }
        }

        private static IEnumerable<TSource[]> ChunkArray<TSource>(
            [NoEnumeration] this TSource[] source,
            int chunkSize
        )
        {
            if (source.Length == 0)
            {
                yield break;
            }

            if (source.Length <= chunkSize)
            {
                yield return source;
            }
            else
            {
                int chunkCount = Math.DivRem(source.Length, chunkSize, out int lastChunkSize);

                for (int i = 0; i < chunkCount; i++)
                {
                    TSource[] chunk = new TSource[chunkSize];
                    Array.Copy(source, chunkSize * i, chunk, 0, chunkSize);
                    yield return chunk;
                }

                if (lastChunkSize != 0)
                {
                    TSource[] chunk = new TSource[lastChunkSize];
                    Array.Copy(source, chunkSize * chunkCount, chunk, 0, lastChunkSize);
                    yield return chunk;
                }
            }
        }
    }
}
