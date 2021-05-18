namespace Kkommon.Extensions
{
    public static partial class ArithmeticExtensions
    {
        /// <summary>
        ///     Checks if this value is inside a given range.
        /// </summary>
        /// <param name="this">This value.</param>
        /// <param name="lowerBound">The lower bound to check against.</param>
        /// <param name="upperBound">The upper bound to check against.</param>
        /// <param name="leftExclusive">Whether the given range is left exclusive; defaults to false.</param>
        /// <param name="rightExclusive">Whether the given range is right inclusive; defaults to true.</param>
        /// <returns>
        ///     <see langword="true"/> if this value is in the given range; <see langword="false"/> if not.
        /// </returns>
        public static bool IsInRange(
            this char @this,
            char lowerBound,
            char upperBound,
            bool leftExclusive = false,
            bool rightExclusive = true
        ) => (leftExclusive ? @this > lowerBound : @this >= lowerBound)
            && (rightExclusive ? @this < upperBound : @this <= upperBound);

        /// <summary>
        ///     Checks if this value is inside a given range.
        /// </summary>
        /// <param name="this">This value.</param>
        /// <param name="lowerBound">The lower bound to check against.</param>
        /// <param name="upperBound">The upper bound to check against.</param>
        /// <param name="leftExclusive">Whether the given range is left exclusive; defaults to false.</param>
        /// <param name="rightExclusive">Whether the given range is right inclusive; defaults to true.</param>
        /// <returns>
        ///     <see langword="true"/> if this value is in the given range; <see langword="false"/> if not.
        /// </returns>
        public static bool IsInRange(
            this sbyte @this,
            sbyte lowerBound,
            sbyte upperBound,
            bool leftExclusive = false,
            bool rightExclusive = true
        ) => (leftExclusive ? @this > lowerBound : @this >= lowerBound)
            && (rightExclusive ? @this < upperBound : @this <= upperBound);

        /// <summary>
        ///     Checks if this value is inside a given range.
        /// </summary>
        /// <param name="this">This value.</param>
        /// <param name="lowerBound">The lower bound to check against.</param>
        /// <param name="upperBound">The upper bound to check against.</param>
        /// <param name="leftExclusive">Whether the given range is left exclusive; defaults to false.</param>
        /// <param name="rightExclusive">Whether the given range is right inclusive; defaults to true.</param>
        /// <returns>
        ///     <see langword="true"/> if this value is in the given range; <see langword="false"/> if not.
        /// </returns>
        public static bool IsInRange(
            this short @this,
            short lowerBound,
            short upperBound,
            bool leftExclusive = false,
            bool rightExclusive = true
        ) => (leftExclusive ? @this > lowerBound : @this >= lowerBound)
            && (rightExclusive ? @this < upperBound : @this <= upperBound);

        /// <summary>
        ///     Checks if this value is inside a given range.
        /// </summary>
        /// <param name="this">This value.</param>
        /// <param name="lowerBound">The lower bound to check against.</param>
        /// <param name="upperBound">The upper bound to check against.</param>
        /// <param name="leftExclusive">Whether the given range is left exclusive; defaults to false.</param>
        /// <param name="rightExclusive">Whether the given range is right inclusive; defaults to true.</param>
        /// <returns>
        ///     <see langword="true"/> if this value is in the given range; <see langword="false"/> if not.
        /// </returns>
        public static bool IsInRange(
            this int @this,
            int lowerBound,
            int upperBound,
            bool leftExclusive = false,
            bool rightExclusive = true
        ) => (leftExclusive ? @this > lowerBound : @this >= lowerBound)
            && (rightExclusive ? @this < upperBound : @this <= upperBound);

        /// <summary>
        ///     Checks if this value is inside a given range.
        /// </summary>
        /// <param name="this">This value.</param>
        /// <param name="lowerBound">The lower bound to check against.</param>
        /// <param name="upperBound">The upper bound to check against.</param>
        /// <param name="leftExclusive">Whether the given range is left exclusive; defaults to false.</param>
        /// <param name="rightExclusive">Whether the given range is right inclusive; defaults to true.</param>
        /// <returns>
        ///     <see langword="true"/> if this value is in the given range; <see langword="false"/> if not.
        /// </returns>
        public static bool IsInRange(
            this long @this,
            long lowerBound,
            long upperBound,
            bool leftExclusive = false,
            bool rightExclusive = true
        ) => (leftExclusive ? @this > lowerBound : @this >= lowerBound)
            && (rightExclusive ? @this < upperBound : @this <= upperBound);

        /// <summary>
        ///     Checks if this value is inside a given range.
        /// </summary>
        /// <param name="this">This value.</param>
        /// <param name="lowerBound">The lower bound to check against.</param>
        /// <param name="upperBound">The upper bound to check against.</param>
        /// <param name="leftExclusive">Whether the given range is left exclusive; defaults to false.</param>
        /// <param name="rightExclusive">Whether the given range is right inclusive; defaults to true.</param>
        /// <returns>
        ///     <see langword="true"/> if this value is in the given range; <see langword="false"/> if not.
        /// </returns>
        public static bool IsInRange(
            this byte @this,
            byte lowerBound,
            byte upperBound,
            bool leftExclusive = false,
            bool rightExclusive = true
        ) => (leftExclusive ? @this > lowerBound : @this >= lowerBound)
            && (rightExclusive ? @this < upperBound : @this <= upperBound);

        /// <summary>
        ///     Checks if this value is inside a given range.
        /// </summary>
        /// <param name="this">This value.</param>
        /// <param name="lowerBound">The lower bound to check against.</param>
        /// <param name="upperBound">The upper bound to check against.</param>
        /// <param name="leftExclusive">Whether the given range is left exclusive; defaults to false.</param>
        /// <param name="rightExclusive">Whether the given range is right inclusive; defaults to true.</param>
        /// <returns>
        ///     <see langword="true"/> if this value is in the given range; <see langword="false"/> if not.
        /// </returns>
        public static bool IsInRange(
            this ushort @this,
            ushort lowerBound,
            ushort upperBound,
            bool leftExclusive = false,
            bool rightExclusive = true
        ) => (leftExclusive ? @this > lowerBound : @this >= lowerBound)
            && (rightExclusive ? @this < upperBound : @this <= upperBound);

        /// <summary>
        ///     Checks if this value is inside a given range.
        /// </summary>
        /// <param name="this">This value.</param>
        /// <param name="lowerBound">The lower bound to check against.</param>
        /// <param name="upperBound">The upper bound to check against.</param>
        /// <param name="leftExclusive">Whether the given range is left exclusive; defaults to false.</param>
        /// <param name="rightExclusive">Whether the given range is right inclusive; defaults to true.</param>
        /// <returns>
        ///     <see langword="true"/> if this value is in the given range; <see langword="false"/> if not.
        /// </returns>
        public static bool IsInRange(
            this uint @this,
            uint lowerBound,
            uint upperBound,
            bool leftExclusive = false,
            bool rightExclusive = true
        ) => (leftExclusive ? @this > lowerBound : @this >= lowerBound)
            && (rightExclusive ? @this < upperBound : @this <= upperBound);

        /// <summary>
        ///     Checks if this value is inside a given range.
        /// </summary>
        /// <param name="this">This value.</param>
        /// <param name="lowerBound">The lower bound to check against.</param>
        /// <param name="upperBound">The upper bound to check against.</param>
        /// <param name="leftExclusive">Whether the given range is left exclusive; defaults to false.</param>
        /// <param name="rightExclusive">Whether the given range is right inclusive; defaults to true.</param>
        /// <returns>
        ///     <see langword="true"/> if this value is in the given range; <see langword="false"/> if not.
        /// </returns>
        public static bool IsInRange(
            this ulong @this,
            ulong lowerBound,
            ulong upperBound,
            bool leftExclusive = false,
            bool rightExclusive = true
        ) => (leftExclusive ? @this > lowerBound : @this >= lowerBound)
            && (rightExclusive ? @this < upperBound : @this <= upperBound);

        /// <summary>
        ///     Returns a factor containing the sign of this value.
        /// </summary>
        /// <param name="this">This value.</param>
        /// <returns>
        ///     1 if the number is 0 or positive, -1 if it is negative.
        /// </returns>
        public static sbyte Sign(this sbyte @this) => @this >= 0 ? (sbyte) 1 : (sbyte) -1;

        /// <summary>
        ///     Returns a factor containing the sign of this value.
        /// </summary>
        /// <param name="this">This value.</param>
        /// <returns>
        ///     1 if the number is 0 or positive, -1 if it is negative.
        /// </returns>
        public static short Sign(this short @this) => @this >= 0 ? (short) 1 : (short) -1;

        /// <summary>
        ///     Returns a factor containing the sign of this value.
        /// </summary>
        /// <param name="this">This value.</param>
        /// <returns>
        ///     1 if the number is 0 or positive, -1 if it is negative.
        /// </returns>
        public static int Sign(this int @this) => @this >= 0 ? 1 : -1;

        /// <summary>
        ///     Returns a factor containing the sign of this value.
        /// </summary>
        /// <param name="this">This value.</param>
        /// <returns>
        ///     1 if the number is 0 or positive, -1 if it is negative.
        /// </returns>
        public static long Sign(this long @this) => @this >= 0 ? 1 : -1;

        /// <summary>
        ///     The underlying value regardless of sign.
        /// </summary>
        /// <param name="this">This value.</param>
        /// <returns>
        ///     The absolute value of this value.
        /// </returns>
        public static sbyte Abs(this sbyte @this) => (sbyte) (@this * @this.Sign());

        /// <summary>
        ///     The underlying value regardless of sign.
        /// </summary>
        /// <param name="this">This value.</param>
        /// <returns>
        ///     The absolute value of this value.
        /// </returns>
        public static short Abs(this short @this) => (short) (@this * @this.Sign());

        /// <summary>
        ///     The underlying value regardless of sign.
        /// </summary>
        /// <param name="this">This value.</param>
        /// <returns>
        ///     The absolute value of this value.
        /// </returns>
        public static int Abs(this int @this) => @this * @this.Sign();

        /// <summary>
        ///     The underlying value regardless of sign.
        /// </summary>
        /// <param name="this">This value.</param>
        /// <returns>
        ///     The absolute value of this value.
        /// </returns>
        public static long Abs(this long @this) => @this * @this.Sign();
    }
}