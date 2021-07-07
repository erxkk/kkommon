using System;

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
        ///     This range check is always inclusive, and the given range must be satisfy a..b where a &lt;= b.
        /// </remarks>
        /// <param name="argument">The passed argument value.</param>
        /// <param name="lowerBound">The lower inclusive bound to check against.</param>
        /// <param name="upperBound">The upper inclusive bound to check against.</param>
        /// <param name="parameterName">The name of the caller parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The <paramref name="argument" /> is out side of the given range bounds.
        /// </exception>
        public static void InRange(
            int argument,
            int lowerBound,
            int upperBound,
            [InvokerParameterName] string parameterName
        )
        {
            if (!argument.IsInRange(lowerBound, upperBound))
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
        public static void Greater(
            int argument,
            int check,
            [InvokerParameterName] string parameterName
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
        public static void Less(
            int argument,
            int check,
            [InvokerParameterName] string parameterName
        )
        {
            if (argument >= check)
                Throw.ArgumentNotLess(argument, check, parameterName);
        }
    }
}