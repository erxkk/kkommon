using System;
using System.Diagnostics.CodeAnalysis;

using JetBrains.Annotations;

namespace Kkommon
{
    /// <summary>
    ///     A static class with throw helper functions.
    /// </summary>
    [PublicAPI]
    public static class Throw
    {
        /// <summary>
        ///     Throws a <see cref="ArgumentOutOfRangeException" />.
        /// </summary>
        /// <param name="value">The actual value that was outside of the given range.</param>
        /// <param name="lowerBound">The lower bound of the given range.</param>
        /// <param name="upperBound">The upper bound of the given range.</param>
        /// <param name="parameterName">The name of the parameter that was empty.</param>
        /// <param name="leftInclusive">Whether ot not the lower bound is inclusive</param>
        /// <param name="rightExclusive">Whether ot not the upper bound is exclusive</param>
        /// <typeparam name="T">The type the <paramref name="value" /> is comparable to.</typeparam>
        /// <exception cref="ArgumentOutOfRangeException">Always.</exception>
        [DoesNotReturn]
        public static void ArgumentOutOfRange(
            int value,
            int lowerBound,
            int upperBound,
            string parameterName,
            bool leftInclusive = true,
            bool rightExclusive = true
        ) => throw new ArgumentOutOfRangeException(
            parameterName,
            value,
            string.Format(
                "{0} must not be less than {1}{2} or greater than {3}{4}",
                parameterName,
                leftInclusive ? "or equal to " : "",
                lowerBound,
                rightExclusive ? "" : "or equal to ",
                upperBound
            )
        );
    }
}