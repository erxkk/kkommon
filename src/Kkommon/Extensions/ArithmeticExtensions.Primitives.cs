using System.Runtime.CompilerServices;

using JetBrains.Annotations;

namespace Kkommon.Extensions.Arithmetic
{
    public static partial class ArithmeticExtensions
    {
        /// <summary>
        ///     Checks if this value is inside a given range.
        /// </summary>
        /// <remarks>
        ///     This range check is always inclusive.
        /// </remarks>
        /// <param name="this">This value.</param>
        /// <param name="lowerBound">The lower bound to check against.</param>
        /// <param name="upperBound">The upper bound to check against.</param>
        /// <returns>
        ///     <see langword="true" /> if this value is in the given range; <see langword="false" /> if not.
        /// </returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInRange(
            this int @this,
            int lowerBound,
            int upperBound
        ) => @this >= lowerBound && @this <= upperBound;

        /// <summary>
        ///     Checks if this value is inside a given range.
        /// </summary>
        /// <remarks>
        ///     This range check is always inclusive.
        /// </remarks>
        /// <param name="this">This value.</param>
        /// <param name="lowerBound">The lower bound to check against.</param>
        /// <param name="upperBound">The upper bound to check against.</param>
        /// <returns>
        ///     <see langword="true" /> if this value is in the given range; <see langword="false" /> if not.
        /// </returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInRange(
            this ulong @this,
            ulong lowerBound,
            ulong upperBound
        ) => @this >= lowerBound && @this <= upperBound;
    }
}