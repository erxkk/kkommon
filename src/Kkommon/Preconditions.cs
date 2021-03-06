using System;
using System.Runtime.CompilerServices;

using JetBrains.Annotations;

using Kkommon.Extensions.Arithmetic;

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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NotNull<T>(
            [NoEnumeration] T? argument,
            [CallerArgumentExpression("argument")] string parameterName = null!
        )
        {
            if (argument is null)
                throw new ArgumentNullException(parameterName);
        }

        /// <summary>
        ///     Throws a default <see cref="ArgumentOutOfRangeException" /> if the given string argument is empty.
        /// </summary>
        /// <param name="argument">The passed argument value.</param>
        /// <param name="parameterName">The name of the caller parameter.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="argument" /> is null.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NotEmpty(
            [NoEnumeration] string argument,
            [CallerArgumentExpression("argument")] string parameterName = null!
        )
        {
            if (argument.Length == 0)
                throw new ArgumentOutOfRangeException(parameterName, "The given string must not be empty.");
        }

        /// <summary>
        ///     Throws a default <see cref="ArgumentOutOfRangeException" /> if the given argument is outside of the
        ///     given range bounds.
        /// </summary>
        /// <remarks>
        ///     This range check is always inclusive, and the given range must be satisfy a..b where a &lt;= b.
        /// </remarks>
        /// <param name="argument">The passed argument value.</param>
        /// <param name="lowerBound">The lower inclusive bound to check against.</param>
        /// <param name="upperBound">The upper inclusive bound to check against.</param>
        /// <param name="parameterName">The name of the caller parameter.</param>
        /// <param name="leftInclusive">Whether the given range check is left inclusive; defaults to true.</param>
        /// <param name="rightInclusive">Whether the given range check is right inclusive; defaults to false.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The <paramref name="argument" /> is out side of the given range bounds.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InRange(
            int argument,
            int lowerBound,
            int upperBound,
            bool leftInclusive = true,
            bool rightInclusive = false,
            [CallerArgumentExpression("argument")] string parameterName = null!
        )
        {
            if (!argument.IsInRange(lowerBound, upperBound, leftInclusive, rightInclusive))
                Throw.ArgumentOutOfRange(argument, lowerBound, upperBound, parameterName);
        }

        /// <summary>
        ///     Throws a default <see cref="ArgumentOutOfRangeException" /> if the given argument is less than or equal
        ///     to the check value.
        /// </summary>
        /// <param name="argument">The passed argument value.</param>
        /// <param name="check">The value to check against.</param>
        /// <param name="parameterName">The name of the caller parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The <paramref name="argument" /> is less than or equal to the check value.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Greater(
            int argument,
            int check,
            [CallerArgumentExpression("argument")] string parameterName = null!
        )
        {
            if (argument <= check)
                Throw.ArgumentNotGreater(argument, check, parameterName);
        }

        /// <summary>
        ///     Throws a default <see cref="ArgumentOutOfRangeException" /> if the given argument is greater than or
        ///     equal to the check value.
        /// </summary>
        /// <param name="argument">The passed argument value.</param>
        /// <param name="check">The value to check against.</param>
        /// <param name="parameterName">The name of the caller parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The <paramref name="argument" /> is greater than or equal to the check value.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Less(
            int argument,
            int check,
            [CallerArgumentExpression("argument")] string parameterName = null!
        )
        {
            if (argument >= check)
                Throw.ArgumentNotLess(argument, check, parameterName);
        }

        /// <summary>
        ///     Throws a default <see cref="ArgumentOutOfRangeException" /> if the given argument is equal to the  check
        ///     value.
        /// </summary>
        /// <param name="argument">The passed argument value.</param>
        /// <param name="check">The value to check against.</param>
        /// <param name="parameterName">The name of the caller parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The <paramref name="argument" /> is equal to the check value.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NotEqual(
            int argument,
            int check,
            [CallerArgumentExpression("argument")] string parameterName = null!
        )
        {
            if (argument == check)
                Throw.ArgumentNotLess(argument, check, parameterName);
        }
    }
}
