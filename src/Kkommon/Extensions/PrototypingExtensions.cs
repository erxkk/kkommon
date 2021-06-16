using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

using JetBrains.Annotations;

namespace Kkommon.Extensions.Prototyping
{
    [PublicAPI]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class PrototypingExtensions
    {
        /// <summary>
        ///     Pass through method for dumping an object to the standard output.
        /// </summary>
        /// <remarks>
        ///     <see langword="null" /> will be passed through, possibly throwing a
        ///     <see cref="NullReferenceException" /> on any subsequent call.
        /// </remarks>
        /// <param name="this">The object to dump to stdout.</param>
        /// <param name="annotation">An optional annotation.</param>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <returns>
        ///     The object itself.
        /// </returns>
        [Pure]
        [CollectionAccess(CollectionAccessType.Read)]
        [return: MaybeNull]
        public static T Dump<T>([MaybeNull] this T @this, string? annotation = null)
        {
            string representation = @this?.ToString() ?? "<null>";

            Console.WriteLine(
                annotation is null
                    ? representation
                    : $"{annotation} {{{Environment.NewLine}{representation}{Environment.NewLine}}}"
            );

            return @this;
        }
    }
}