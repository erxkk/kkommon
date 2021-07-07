using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

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
        /// <exception cref="ArgumentOutOfRangeException">Always.</exception>
        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentOutOfRange(
            int value,
            int lowerBound,
            int upperBound,
            [InvokerParameterName] string parameterName
        ) => throw new ArgumentOutOfRangeException(
            parameterName,
            value,
            $"{parameterName} must not be less than {lowerBound} or greater than {upperBound}."
        );

        /// <summary>
        ///     Throws a <see cref="ArgumentOutOfRangeException" />.
        /// </summary>
        /// <param name="value">The actual value that was less than or equal to the check.</param>
        /// <param name="check">The value to check against.</param>
        /// <param name="parameterName">The name of the parameter that was empty.</param>
        /// <exception cref="ArgumentOutOfRangeException">Always.</exception>
        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentNotGreater(
            int value,
            int check,
            [InvokerParameterName] string parameterName
        ) => throw new ArgumentOutOfRangeException(
            parameterName,
            value,
            $"{parameterName} must not be greater than or equal to {check}."
        );

        /// <summary>
        ///     Throws a <see cref="ArgumentOutOfRangeException" />.
        /// </summary>
        /// <param name="value">The actual value that was greater than or equal to the check.</param>
        /// <param name="check">The value to check against.</param>
        /// <param name="parameterName">The name of the parameter that was empty.</param>
        /// <exception cref="ArgumentOutOfRangeException">Always.</exception>
        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentNotLess(
            int value,
            int check,
            [InvokerParameterName] string parameterName
        ) => throw new ArgumentOutOfRangeException(
            parameterName,
            value,
            $"{parameterName} must not be less than or equal to {check}."
        );
    }
}