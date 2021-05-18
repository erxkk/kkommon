using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Kkommon.Extensions.AsyncLinq
{
    /// <summary>
    ///     A collection of common linq methods with async delegates <see cref="IEnumerable{T}"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class EnumerableAsyncExtensions
    {
        /// <summary>
        ///     Asynchronous checks if all elements in this <see cref="IEnumerable{T}"/> pass a given
        ///     <paramref name="predicate"/>.
        /// </summary>
        /// <remarks>
        ///     Using <paramref name="runParallel"/> = <see langword="true"/> will result in at least 3 enumerations.
        /// </remarks>
        /// <param name="source">The source <see cref="IEnumerable{T}"/>.</param>
        /// <param name="predicate">The asynchronous predicate.</param>
        /// <param name="runParallel">Whether or not the predicate tasks should be run in parallel.</param>
        /// <typeparam name="TSource">The type of the source elements.</typeparam>
        /// <returns>
        ///     A <see cref="Task{T}"/> with a result indicating if all elements passed the predicate.
        /// </returns>
        public static async Task<bool> AllAsync<TSource>(
            this IEnumerable<TSource> source,
            AsyncPredicate<TSource> predicate,
            bool runParallel = false
        )
        {
            Preconditions.NotNull(source, nameof(source));
            Preconditions.NotNull(predicate, nameof(predicate));

            if (runParallel)
            {
                List<Task<bool>> tasks = source.Select(item => predicate(item)).ToList();

                return (await Task.WhenAll(tasks)).All(result => result);
            }
            else
            {
                foreach (TSource item in source)
                {
                    if (!await predicate(item))
                        return false;
                }

                return true;
            }
        }

        /// <summary>
        ///     Asynchronous aggregates all elements in this <see cref="IEnumerable{T}"/> with a given
        ///     <paramref name="aggregator"/>.
        /// </summary>
        /// <param name="source">The source <see cref="IEnumerable{T}"/>.</param>
        /// <param name="aggregator">The asynchronous aggregator that is invoked with each element.</param>
        /// <typeparam name="TSource">The type of the source elements.</typeparam>
        /// <returns>
        ///     A <see cref="Task{T}"/> with the aggregated result.
        /// </returns>
        public static async Task<TSource> AggregateAsync<TSource>(
            this IEnumerable<TSource> source,
            AsyncFunc<TSource, TSource, TSource> aggregator
        )
        {
            Preconditions.NotNull(source, nameof(source));
            Preconditions.NotNull(aggregator, nameof(aggregator));

            using IEnumerator<TSource> e = source.GetEnumerator();

            if (!e.MoveNext())
                Throw.CollectionEmpty(nameof(source));

            TSource aggregate = e.Current;

            while (e.MoveNext())
                aggregate = await aggregator(aggregate, e.Current);

            return aggregate;
        }

        /// <summary>
        ///     Asynchronous aggregates all elements in this <see cref="IEnumerable{T}"/> with a given
        ///     <paramref name="aggregator"/> as a given <paramref name="initial"/> value.
        /// </summary>
        /// <param name="source">The source <see cref="IEnumerable{T}"/>.</param>
        /// <param name="initial">The initial value for the aggregator.</param>
        /// <param name="aggregator">The asynchronous aggregator that is invoked with each element.</param>
        /// <typeparam name="TSource">The type of the source elements.</typeparam>
        /// <typeparam name="TAggregate">The result type.</typeparam>
        /// <returns>
        ///     A <see cref="Task{T}"/> with the aggregated result.
        /// </returns>
        public static async Task<TAggregate> AggregateAsync<TSource, TAggregate>(
            this IEnumerable<TSource> source,
            TAggregate initial,
            AsyncFunc<TAggregate, TSource, TAggregate> aggregator
        )
        {
            Preconditions.NotNull(source, nameof(source));
            Preconditions.NotNull(aggregator, nameof(aggregator));

            TAggregate aggregate = initial;

            foreach (TSource item in source)
                aggregate = await aggregator(aggregate, item);

            return aggregate;
        }

        /// <summary>
        ///     Asynchronous checks if any element in this <see cref="IEnumerable{T}"/> passes a given
        ///     <paramref name="predicate"/>.
        /// </summary>
        /// <remarks>
        ///     Using <paramref name="runParallel"/> = <see langword="true"/> will result in at least 3 enumerations.
        /// </remarks>
        /// <param name="source">The source <see cref="IEnumerable{T}"/>.</param>
        /// <param name="predicate">The asynchronous predicate.</param>
        /// <param name="runParallel">Whether or not the predicate tasks should be run in parallel.</param>
        /// <typeparam name="TSource">The type of the source elements.</typeparam>
        /// <returns>
        ///     A <see cref="Task{T}"/> with a result indicating if any element passed the predicate.
        /// </returns>
        public static async Task<bool> AnyAsync<TSource>(
            this IEnumerable<TSource> source,
            AsyncPredicate<TSource> predicate,
            bool runParallel = false
        )
        {
            if (runParallel)
            {
                List<Task<bool>> tasks = source.Select(item => predicate(item)).ToList();

                return (await Task.WhenAll(tasks)).Any(result => result);
            }
            else
            {
                foreach (TSource item in source)
                {
                    if (await predicate(item))
                        return true;
                }

                return false;
            }
        }

        /// <summary>
        ///     Asynchronous checks how many element in this <see cref="IEnumerable{T}"/> pass a given
        ///     <paramref name="predicate"/>.
        /// </summary>
        /// <remarks>
        ///     Using <paramref name="runParallel"/> = <see langword="true"/> will result in at least 3 enumerations.
        /// </remarks>
        /// <param name="source">The source <see cref="IEnumerable{T}"/>.</param>
        /// <param name="predicate">The asynchronous predicate.</param>
        /// <param name="runParallel">Whether or not the predicate tasks should be run in parallel.</param>
        /// <typeparam name="TSource">The type of the source elements.</typeparam>
        /// <returns>
        ///     A <see cref="Task{T}"/> with a result how many elements passed the predicate.
        /// </returns>
        public static async Task<int> CountAsync<TSource>(
            this IEnumerable<TSource> source,
            AsyncPredicate<TSource> predicate,
            bool runParallel = false
        )
        {
            Preconditions.NotNull(source, nameof(source));
            Preconditions.NotNull(predicate, nameof(predicate));

            int count = 0;

            if (runParallel)
            {
                List<Task<bool>> tasks = source.Select(item => predicate(item)).ToList();

                return (await Task.WhenAll(tasks)).Count(result => result);
            }
            else
            {
                foreach (TSource item in source)
                {
                    checked
                    {
                        if (await predicate(item))
                            count++;
                    }
                }
            }

            return count;
        }

        /// <summary>
        ///     Asynchronous selects all elements in this <see cref="IEnumerable{T}"/> that pass a given
        ///     <paramref name="selector"/>.
        /// </summary>
        /// <param name="source">The source <see cref="IEnumerable{T}"/>.</param>
        /// <param name="selector">The asynchronous selector producing the values to check for distinctness.</param>
        /// <param name="equalityComparer">An optional equality comparer.</param>
        /// <typeparam name="TSource">The type of the source elements.</typeparam>
        /// <typeparam name="TSelector">The return type of the selector.</typeparam>
        /// <returns>
        ///     An <see cref="IAsyncEnumerable{T}"/> containing only the items that resulted in a distinct selector.
        /// </returns>
        public static async IAsyncEnumerable<TSource> DistinctSelectAsync<TSource, TSelector>(
            this IEnumerable<TSource> source,
            AsyncFunc<TSource, TSelector> selector,
            IEqualityComparer<TSelector>? equalityComparer = null
        )
        {
            Preconditions.NotNull(source, nameof(source));
            Preconditions.NotNull(selector, nameof(selector));

            HashSet<TSelector> set = new(equalityComparer);

            foreach (TSource item in source)
            {
                if (set.Add(await selector(item)))
                    yield return item;
            }
        }

        /// <summary>
        ///     Asynchronous returns the first element in this <see cref="IEnumerable{T}"/> that passes a given
        ///     <paramref name="predicate"/>.
        /// </summary>
        /// <param name="source">The source <see cref="IEnumerable{T}"/>.</param>
        /// <param name="predicate">The asynchronous predicate.</param>
        /// <typeparam name="TSource">The type of the source elements.</typeparam>
        /// <returns>
        ///     A <see cref="Task{T}"/> with a result containing the first passing element; default if none is found.
        /// </returns>
        public static async Task<TSource?> FirstOrDefaultAsync<TSource>(
            this IEnumerable<TSource> source,
            AsyncPredicate<TSource> predicate
        )
        {
            Preconditions.NotNull(source, nameof(source));
            Preconditions.NotNull(predicate, nameof(predicate));

            foreach (TSource item in source)
            {
                if (await predicate(item))
                    return item;
            }

            return default(TSource);
        }

        /// <summary>
        ///     Asynchronously applies a given <see cref="selector"/> to all elements in this
        ///     <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <param name="source">The source <see cref="IEnumerable{T}"/>.</param>
        /// <param name="selector">The asynchronous selector.</param>
        /// <typeparam name="TSource">The type of the source elements.</typeparam>
        /// <typeparam name="TSelector">The return type of the selector.</typeparam>
        /// <returns>
        ///     An <see cref="IAsyncEnumerable{T}"/> containing the selected elements.
        /// </returns>
        public static async IAsyncEnumerable<TSelector> SelectAsync<TSource, TSelector>(
            this IEnumerable<TSource> source,
            AsyncFunc<TSource, TSelector> selector
        )
        {
            Preconditions.NotNull(source, nameof(source));
            Preconditions.NotNull(selector, nameof(selector));

            foreach (TSource item in source)
                yield return await selector(item);
        }

        /// <summary>
        ///     Asynchronously applies a given <see cref="selector"/> to all elements in this
        ///     <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <remarks>
        ///     Using <paramref name="runParallel"/> = <see langword="true"/> will result in at least 3 enumerations.
        /// </remarks>
        /// <param name="source">The source <see cref="IEnumerable{T}"/>.</param>
        /// <param name="selector">The asynchronous selector.</param>
        /// <param name="runParallel">Whether or not the selector tasks should be run in parallel.</param>
        /// <typeparam name="TSource">The type of the source elements.</typeparam>
        /// <typeparam name="TSelector">The return type of the selector.</typeparam>
        /// <returns>
        ///     A <see cref="Task{T}"/> with a <see cref="IEnumerable{T}"/> result containing the selected elements.
        /// </returns>
        public static async Task<IEnumerable<TSelector>> SelectAsync<TSource, TSelector>(
            this IEnumerable<TSource> source,
            AsyncFunc<TSource, TSelector> selector,
            bool runParallel
        )
        {
            Preconditions.NotNull(source, nameof(source));
            Preconditions.NotNull(selector, nameof(selector));

            if (runParallel)
            {
                List<Task<TSelector>> tasks = source.Select(item => selector(item)).ToList();

                return (await Task.WhenAll(tasks)).Select(result => result);
            }
            else
            {
                List<TSelector> returnValue = new();

                foreach (TSource item in source)
                    returnValue.Add(await selector(item));

                return returnValue;
            }
        }

        /// <summary>
        ///     Asynchronous returns the all elements in this <see cref="IEnumerable{T}"/> that pass a given
        ///     <paramref name="predicate"/>.
        /// </summary>
        /// <param name="source">The source <see cref="IEnumerable{T}"/>.</param>
        /// <param name="predicate">The asynchronous predicate.</param>
        /// <typeparam name="TSource">The type of the source elements.</typeparam>
        /// <returns>
        ///     An <see cref="IAsyncEnumerable{T}"/> containing the elements that passed <see cref="predicate"/>.
        /// </returns>
        public static async IAsyncEnumerable<TSource> WhereAsync<TSource>(
            this IEnumerable<TSource> source,
            AsyncPredicate<TSource> predicate
        )
        {
            Preconditions.NotNull(source, nameof(source));
            Preconditions.NotNull(predicate, nameof(predicate));

            foreach (TSource item in source)
            {
                if (await predicate(item))
                    yield return item;
            }
        }

        /// <summary>
        ///     Asynchronous returns the all elements in this <see cref="IEnumerable{T}"/> that pass a given
        ///     <paramref name="predicate"/>.
        /// </summary>
        /// <remarks>
        ///     Using <paramref name="runParallel"/> = <see langword="true"/> will result in at least 4 enumerations.
        /// </remarks>
        /// <param name="source">The source <see cref="IEnumerable{T}"/>.</param>
        /// <param name="predicate">The asynchronous predicate.</param>
        /// <param name="runParallel">Whether or not the selector tasks should be run in parallel.</param>
        /// <typeparam name="TSource">The type of the source elements.</typeparam>
        /// <returns>
        ///     A <see cref="Task{T}"/> with a <see cref="IEnumerable{T}"/> result containing the selected elements.
        /// </returns>
        public static async Task<IEnumerable<TSource>> WhereAsync<TSource>(
            this IEnumerable<TSource> source,
            AsyncPredicate<TSource> predicate,
            bool runParallel
        )
        {
            Preconditions.NotNull(source, nameof(source));
            Preconditions.NotNull(predicate, nameof(predicate));

            if (runParallel)
            {
                List<(TSource, Task<bool>)> tasks = source.Select(item => (item, predicate(item))).ToList();
                await Task.WhenAll(tasks.Select(x => x.Item2));

                return tasks.Where(x => x.Item2.Result).Select(x => x.Item1);
            }
            else
            {
                List<TSource> returnValue = new();

                foreach (TSource item in source)
                {
                    if (await predicate(item))
                        returnValue.Add(item);
                }

                return returnValue;
            }
        }
    }
}