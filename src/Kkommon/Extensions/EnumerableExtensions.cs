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
        ///     Filters elements of the source by distinctness of the return value of a selector.
        /// </summary>
        /// <param name="source">The source collection.</param>
        /// <param name="selector">The selector that selects what to filter by.</param>
        /// <param name="equalityComparer">An optional comparer for the selected values.</param>
        /// <typeparam name="TSource">The type of the elements in the source <see cref="IEnumerable{T}"/>.</typeparam>
        /// <typeparam name="TSelector">The return type of the <paramref name="selector"/>.</typeparam>
        /// <returns>
        ///     An <see cref="IEnumerable{T}"/> containing the elements where the selector was distinct.
        /// </returns>
        public static IEnumerable<TSource> DistinctSelect<TSource, TSelector>(
            this IEnumerable<TSource> source,
            Func<TSource, TSelector> selector,
            IEqualityComparer<TSelector>? equalityComparer = null
        )
        {
            Preconditions.NotNull(source, nameof(source));
            Preconditions.NotNull(selector, nameof(selector));

            HashSet<TSelector> set = new(equalityComparer);

            foreach (TSource item in source)
            {
                if (set.Add(selector(item)))
                    yield return item;
            }
        }

        /// <summary>
        ///     Enumerates the <see cref="IEnumerable{T}"/> while exposing the index of each element.
        /// </summary>
        /// <param name="source">The source collection.</param>
        /// <typeparam name="TSource">The type of the elements in the source <see cref="IEnumerable{T}"/>.</typeparam>
        /// <returns>
        ///     An <see cref="IEnumerable{T}"/> containing the elements and their respective indices.
        /// </returns>
        /// <exception cref="OverflowException">The count operation resulted in an overflow.</exception>
        public static IEnumerable<(int Index, TSource Item)> Enumerate<TSource>(this IEnumerable<TSource> source)
        {
            Preconditions.NotNull(source, nameof(source));

            int index = -1;

            foreach (TSource item in source)
            {
                checked
                {
                    yield return (++index, item);
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
        public static bool Maximum<TSource>(this IEnumerable<TSource> source, int count)
        {
            Preconditions.NotNull(source, nameof(source));
            Preconditions.InRange(count, 1, int.MaxValue, nameof(count));

            return source is ICollection<TSource> collection ? collection.Count <= count : !source.Skip(count).Any();
        }
    }
}