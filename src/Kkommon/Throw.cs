using System;

#nullable enable
namespace Kkommon
{
    /// <summary>
    ///     A static class with throw helper functions.
    /// </summary>
    public static class Throw
    {
        /// <summary>
        ///     Throws a <see cref="InvalidOperationException"/> with a given <paramref name="reason"/>.
        /// </summary>
        /// <param name="reason">The reason to pass to the <see cref="InvalidOperationException"/>.</param>
        /// <param name="innerException">An optional inner <see cref="Exception"/>.</param>
        /// <exception cref="InvalidOperationException">Always.</exception>
        public static void InvalidOperation(string reason, Exception? innerException = null)
            => throw new InvalidOperationException(reason, innerException);

        /// <summary>
        ///     Throws a <see cref="ArgumentNullException"/> with a given <paramref name="reason"/>.
        /// </summary>
        /// <param name="parameterName">The name of the parameter that was <see langword="null"/>.</param>
        /// <exception cref="ArgumentNullException">Always.</exception>
        public static void ArgumentNull(string parameterName)
            => throw new ArgumentNullException(parameterName, $"{parameterName} must not be null");

        /// <summary>
        ///     Throws a <see cref="ArgumentOutOfRangeException"/>.
        /// </summary>
        /// <param name="value">The actual value that was outside of the given range.</param>
        /// <param name="lowerBound">The lower bound of the given range.</param>
        /// <param name="upperBound">The upper bound of the given range.</param>
        /// <param name="parameterName">The name of the parameter that was empty.</param>
        /// <param name="leftInclusive">Whether ot not the lower bound is inclusive</param>
        /// <param name="rightExclusive">Whether ot not the upper bound is exclusive</param>
        /// <typeparam name="T">The type the <paramref name="value"/> is comparable to.</typeparam>
        /// <exception cref="ArgumentOutOfRangeException">Always.</exception>
        public static void ArgumentOutOfRange<T>(
            IComparable<T> value,
            T lowerBound,
            T upperBound,
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

        /// <summary>
        ///     Throws a <see cref="InvalidOperationException"/>.
        /// </summary>
        /// <param name="parameterName">The name of the collection parameter that was empty.</param>
        /// <param name="innerException">An optional inner <see cref="Exception"/>.</param>
        /// <exception cref="InvalidOperationException">Always.</exception>
        public static void CollectionEmpty(string parameterName, Exception? innerException = null)
            => throw new InvalidOperationException($"{parameterName} must not be empty", innerException);
    }
}