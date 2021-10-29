using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using JetBrains.Annotations;

namespace Kkommon.Extensions.Arithmetic
{
    [PublicAPI]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ArithmeticExtensions
    {
        /// <summary>
        ///     Checks whether or not a value is greater than a given value.
        /// </summary>
        /// <param name="this">The value to check for.</param>
        /// <param name="other">The other value to check against.</param>
        /// <typeparam name="TThis">The type of the value to check against.</typeparam>
        /// <typeparam name="TBound">The type of the value can be checked against.</typeparam>
        /// <returns>
        ///     <see langword="true" /> if this value is greater than the given value; <see langword="false" /> if not.
        /// </returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsGreaterThan<TThis, TBound>(this TThis @this, TBound other)
            where TThis : IComparable<TBound>
            => @this.CompareTo(other) > 0;

        /// <summary>
        ///     Checks whether or not a value is greater than or equal to a given value.
        /// </summary>
        /// <param name="this">The value to check for.</param>
        /// <param name="other">The other value to check against.</param>
        /// <typeparam name="TThis">The type of the value to check against.</typeparam>
        /// <typeparam name="TBound">The type of the value can be checked against.</typeparam>
        /// <returns>
        ///     <see langword="true" /> if this value is greater than or equal to the given value;
        ///     <see langword="false" /> if not.
        /// </returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsGreaterThanOrEqual<TThis, TBound>(this TThis @this, TBound other)
            where TThis : IComparable<TBound>
            => @this.CompareTo(other) >= 0;

        /// <summary>
        ///     Checks whether or not a value is less than a given value.
        /// </summary>
        /// <param name="this">The value to check for.</param>
        /// <param name="other">The other value to check against.</param>
        /// <typeparam name="TThis">The type of the value to check against.</typeparam>
        /// <typeparam name="TBound">The type of the value can be checked against.</typeparam>
        /// <returns>
        ///     <see langword="true" /> if this value is less than the given value; <see langword="false" /> if not.
        /// </returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLessThan<TThis, TBound>(this TThis @this, TBound other)
            where TThis : IComparable<TBound>
            => @this.CompareTo(other) < 0;

        /// <summary>
        ///     Checks whether or not a value is less than or equal to a given value.
        /// </summary>
        /// <param name="this">The value to check for.</param>
        /// <param name="other">The other value to check against.</param>
        /// <typeparam name="TThis">The type of the value to check against.</typeparam>
        /// <typeparam name="TBound">The type of the value can be checked against.</typeparam>
        /// <returns>
        ///     <see langword="true" /> if this value is less than or equal to the given value;
        ///     <see langword="false" /> if not.
        /// </returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLessThanOrEqual<TThis, TBound>(this TThis @this, TBound other)
            where TThis : IComparable<TBound>
            => @this.CompareTo(other) <= 0;

        /// <summary>
        ///     Checks whether or not a value is inside a given range.
        /// </summary>
        /// <param name="this">The value to check for.</param>
        /// <param name="lowerBound">The lower bound to check against.</param>
        /// <param name="upperBound">The upper bound to check against.</param>
        /// <param name="leftInclusive">Whether the given range is left inclusive; defaults to true.</param>
        /// <param name="rightInclusive">Whether the given range is right inclusive; defaults to false.</param>
        /// <typeparam name="TThis">The type of the value to check against.</typeparam>
        /// <typeparam name="TBound">The type of the value can be checked against.</typeparam>
        /// <returns>
        ///     <see langword="true" /> if this value is in the given range; <see langword="false" /> if not.
        /// </returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInRange<TThis, TBound>(
            this TThis @this,
            TBound lowerBound,
            TBound upperBound,
            bool leftInclusive = true,
            bool rightInclusive = false
        ) where TThis : IComparable<TBound>
            => (leftInclusive ? @this.IsGreaterThanOrEqual(lowerBound) : @this.IsGreaterThan(lowerBound))
                && (rightInclusive ? @this.IsLessThanOrEqual(upperBound) : @this.IsLessThan(upperBound));
    }
}