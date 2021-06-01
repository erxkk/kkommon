using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Kkommon.Extensions.Linq
{
    /// <summary>
    ///     A collection of extension methods as syntactic sugar for <see cref="IEnumerable{T}"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class EnumerableExtensions
    {
        /// <summary>
        ///     Enumerates the <see cref="IEnumerable{T}"/> while exposing the index of each element.
        /// </summary>
        /// <param name="source">The source collection.</param>
        /// <typeparam name="TSource">The type of the elements in the source <see cref="IEnumerable{T}"/>.</typeparam>
        /// <returns>
        ///     An <see cref="IEnumerable{T}"/> containing the elements and their respective indices.
        /// </returns>
        /// <exception cref="OverflowException">The count operation resulted in an overflow.</exception>
        public static IEnumerable<EnumerationItem<TSource>> Enumerate<TSource>(this IEnumerable<TSource> source)
        {
            Preconditions.NotNull(source, nameof(source));

            int index = -1;

            foreach (TSource item in source)
            {
                checked
                {
                    yield return new EnumerationItem<TSource>(++index, item);
                }
            }
        }

        /// <summary>
        ///     Checks whether or not an <see cref="IEnumerable{T}"/> contains at least <paramref name="count"/>
        ///     elements.
        /// </summary>
        /// <param name="source">The source collection.</param>
        /// <param name="count">The number of elements to check for.</param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns>
        ///     <see langword="true"/> if the <see cref="source"/> <see cref="IEnumerable{T}"/> contained at least
        ///     <paramref name="count"/> elements; otherwise <see langowrd="false"/>.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">The count is less than 1.</exception>
        public static bool Minimum<TSource>(this IEnumerable<TSource> source, int count)
        {
            Preconditions.NotNull(source, nameof(source));
            Preconditions.InRange(count, 1, int.MaxValue, nameof(count));

            return source is ICollection<TSource> collection ? collection.Count >= count : source.Skip(count - 1).Any();
        }

        /// <summary>
        ///     Checks whether or not an <see cref="IEnumerable{T}"/> contains at most <paramref name="count"/>
        ///     elements.
        /// </summary>
        /// <param name="source">The source collection.</param>
        /// <param name="count">The number of elements to check for.</param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns>
        ///     <see langword="true"/> if the <see cref="source"/> <see cref="IEnumerable{T}"/> contained at most
        ///     <paramref name="count"/> elements; otherwise <see langowrd="false"/>.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">The count is less than 1.</exception>
        public static bool Maximum<TSource>(this IEnumerable<TSource> source, int count)
        {
            Preconditions.NotNull(source, nameof(source));
            Preconditions.InRange(count, 1, int.MaxValue, nameof(count));

            return source is ICollection<TSource> collection ? collection.Count <= count : !source.Skip(count).Any();
        }
    }
}