using System;

using JetBrains.Annotations;

using Kkommon.ArithmeticExtensions;

namespace Kkommon
{
    /// <summary>
    ///     A static class with common preconditions.
    /// </summary>
    [PublicAPI]
    public static class Preconditions
    {
        /// <summary>
        ///     Throws a default <see cref="ArgumentNullException" /> if the given argument is <see langword="null" />.
        /// </summary>
        /// <param name="argument">The passed argument value.</param>
        /// <param name="parameterName">The name of the caller parameter.</param>
        /// <typeparam name="T">The type of the <paramref name="argument" />.</typeparam>
        /// <exception cref="ArgumentNullException">The <paramref name="argument" /> is null.</exception>
        public static void NotNull<T>([NoEnumeration] T? argument, [InvokerParameterName] string parameterName)
        {
            if (argument is null)
                throw new ArgumentNullException(parameterName);
        }

        /// <summary>
        ///     Throws a default <see cref="ArgumentOutOfRangeException" /> if the given argument is outside of the
        ///     given range bounds.
        /// </summary>
        /// <remarks>
        ///     The given range is interpreted as left-inclusive and right-exclusive.
        /// </remarks>
        /// <param name="argument">The passed argument value.</param>
        /// <param name="lowerBound">The lower inclusive bound to check against.</param>
        /// <param name="upperBound">The upper exclusive bound to check against.</param>
        /// <param name="parameterName">The name of the caller parameter.</param>
        /// <param name="leftExclusive">Whether the given range is left exclusive; defaults to false.</param>
        /// <param name="rightExclusive">Whether the given range is right inclusive; defaults to true.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The <paramref name="argument" /> is out side of the given range bounds.
        /// </exception>
        public static void InRange(
            int argument,
            int lowerBound,
            int upperBound,
            [InvokerParameterName] string parameterName,
            bool leftExclusive = false,
            bool rightExclusive = true
        )
        {
            if (!argument.IsInRange(lowerBound, upperBound, leftExclusive, rightExclusive))
                Throw.ArgumentOutOfRange(argument, lowerBound, upperBound, parameterName);
        }
    }
}