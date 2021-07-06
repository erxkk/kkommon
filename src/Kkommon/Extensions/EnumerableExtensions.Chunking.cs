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
        /// <remarks>
        ///     Since enumeration cannot be avoided for types that don't implement <see cref="IList{T}"/>, the return
        ///     type exposes <see cref="IList{T}"/> potentially allocating copies of the content, this is avoided where
        ///     possible, but exposes new information like chunk size (for the last chunk) and new functionality like
        ///     indexing for all chunks.
        ///     <b>Do not</b> try to mutate the chunks other than indexing, those operations are not supported.
        /// </remarks>
        /// <param name="source">The source enumerable to chunk.</param>
        /// <param name="chunkSize">The size of the chunks.</param>
        /// <typeparam name="TSource">The type of the elements in the source <see cref="IEnumerable{T}" />.</typeparam>
        /// <returns>
        ///     An <see cref="IEnumerable{T}"/> containing the chunks of the given <see cref="IEnumerable{T}"/>.
        /// </returns>
        [Pure]
        public static IEnumerable<IList<TSource>> Chunk<TSource>(
            [InstantHandle] this IEnumerable<TSource> source,
            int chunkSize
        )
        {
            Preconditions.NotNull(source, nameof(source));
            Preconditions.InRange(chunkSize, 1.., nameof(chunkSize));

            return source switch
            {
                TSource[] a => a.ChunkArray(chunkSize),
                IList<TSource> l => l.ChunkList(chunkSize),
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

        private static IEnumerable<IList<TSource>> ChunkList<TSource>(
            [NoEnumeration] this IList<TSource> source,
            int chunkSize
        )
        {
            if (source.Count == 0)
            {
                yield break;
            }

            if (source.Count <= chunkSize)
            {
                yield return source;
            }
            else
            {
                int chunkCount = Math.DivRem(source.Count, chunkSize, out int lastChunkSize);
                int previous = 0;

                for (int i = 0; i < chunkCount; i++)
                {
                    yield return new ListSegment<TSource>(source, previous, chunkSize);

                    previous += chunkSize;
                }

                if (lastChunkSize != 0)
                    yield return new ListSegment<TSource>(source, previous, lastChunkSize);
            }
        }

        private static IEnumerable<IList<TSource>> ChunkArray<TSource>(
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
                int previous = 0;

                for (int i = 0; i < chunkCount; i++)
                {
                    yield return new ArraySegment<TSource>(source, previous, chunkSize);

                    previous += chunkSize;
                }

                if (lastChunkSize != 0)
                    yield return new ArraySegment<TSource>(source, previous, lastChunkSize);
            }
        }
    }
}