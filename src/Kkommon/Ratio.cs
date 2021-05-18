using System;
using System.Collections.Generic;
using System.Globalization;

using Kkommon.Extensions;

namespace Kkommon
{
    /// <summary>
    ///     A 64-bit struct that encapsulates a ratio of two 32-bit integers.
    /// </summary>
    public readonly partial struct Ratio : IEquatable<Ratio>, IComparable<Ratio>
    {
        /// <summary>
        ///     The numerator of the <see cref="Ratio"/>.
        /// </summary>
        public int Numerator { get; }

        /// <summary>
        ///     The denominator of the <see cref="Ratio"/>.
        /// </summary>
        public int Denominator { get; }

        /// <summary>
        ///     The <see langword="decimal"/> value of the <see cref="Ratio"/>.
        /// </summary>
        public decimal Value => (decimal) Numerator / Denominator;

        /// <summary>
        ///     The <see langword="float"/> value of the <see cref="Ratio"/>.
        /// </summary>
        public float FValue => (float) Numerator / Denominator;

        /// <summary>
        ///     The <see langword="double"/> value of the <see cref="Ratio"/>.
        /// </summary>
        public double DValue => (double) Numerator / Denominator;

        /// <summary>
        ///     Creates a new <see cref="Ratio"/> with the given <paramref name="numerator"/> and
        ///     <paramref name="denominator"/>.
        /// </summary>
        /// <param name="numerator">The numerator of this <see cref="Ratio"/>.</param>
        /// <param name="denominator">The denominator of this <see cref="Ratio"/>.</param>
        /// <exception cref="ArgumentOutOfRangeException">The denominator is 0.</exception>
        public Ratio(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(denominator),
                    denominator,
                    "The denominator must not be zero."
                );
            }

            // normalize all ratios to have sign at numerator if at all
            // this allows for easier equality
            Numerator = numerator * denominator.Sign();
            Denominator = denominator.Abs();
        }

        /// <summary>
        ///     Returns a simplified <see cref="Ratio"/>, that is, it eliminates the greatest common denominator.
        /// </summary>
        /// <example>20/40 => 1/2</example>
        /// <returns>
        ///     A new simplified <see cref="Ratio"/>.
        /// </returns>
        public Ratio Simplify() => Ratio.GetSimplifiedRatio(Numerator, Denominator);

        /// <summary>
        ///     Returns the reciprocal of this <see cref="Ratio"/>, that is, a <see cref="Ratio"/> with the numerator
        ///     and denominator flipped.
        /// </summary>
        /// <remarks>
        ///     If this <see cref="Ratio"/> was negative then the sign will be kept on the numerator after switching.
        /// </remarks>
        /// <returns>
        ///     The a new reciprocal <see cref="Ratio"/>.
        /// </returns>
        public Ratio Reciprocal() => new(Denominator, Numerator);

        /// <summary>
        ///     Returns a simplified reciprocal <see cref="Ratio"/>, see <see cref="Simplify"/> and
        ///     <see cref="Reciprocal"/> for more information.
        /// </summary>
        /// <returns>
        ///     A new simplified reciprocal <see cref="Ratio"/>.
        /// </returns>
        public Ratio SimplifiedReciprocal() => Ratio.GetSimplifiedRatio(Denominator, Numerator);

        public void Deconstruct(out int numerator, out int denominator)
        {
            numerator = Numerator;
            denominator = Denominator;
        }

        /// <inheritdoc />
        public int CompareTo(Ratio other)
        {
            if (FValue < other.FValue) return -1;
            if (FValue > other.FValue) return 1;

            return 0;
        }

        /// <inheritdoc />
        public bool Equals(Ratio other) => Numerator == other.Numerator && Denominator == other.Denominator;

        /// <inheritdoc />
        public override bool Equals(object obj) => obj is Ratio ratio && Equals(ratio);

        /// <inheritdoc />
        public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);

        /// <inheritdoc />
        public override string ToString() => $"{Numerator}/{Denominator}";

        /// <summary>
        ///     Returns a string object representing this <see cref="Ratio"/>.
        /// </summary>
        /// <param name="format">The format to pass to the numerator and denominator.</param>
        /// <returns>
        ///     The string representation of this <see cref="Ratio"/>.
        /// </returns>
        public string ToString(string format) => $"{Numerator.ToString(format)}/{Denominator.ToString(format)}";

        /// <summary>
        ///     Creates a simplified <see cref="Ratio"/> from the given <paramref name="numerator"/> and
        ///     <paramref name="denominator"/>.
        /// </summary>
        /// <remarks>
        ///     The simplified <see cref="Ratio"/> is found by using the
        ///     <see cref="Mathematics.GreatestCommonDenominator"/> function for elimination.
        /// </remarks>
        /// <param name="numerator">The given numerator.</param>
        /// <param name="denominator">The given denominator.</param>
        /// <returns>
        ///     Returns a new simplified <see cref="Ratio"/>.
        /// </returns>
        /// <exception cref="OverflowException">The internal gcd-computation resulted in an overflow.</exception>
        public static Ratio GetSimplifiedRatio(int numerator, int denominator)
        {
            int gcd = (int) Mathematics.GreatestCommonDenominator(numerator, denominator);

            return new(numerator / gcd, denominator / gcd);
        }

        /// <summary>
        ///     An <see cref="IEqualityComparer{T}"/> implementation for <see cref="Ratio"/>s.
        /// </summary>
        public class Comparer : IEqualityComparer<Ratio>
        {
            /// <summary>
            ///     The singleton <see cref="Ratio.Comparer"/> instance.
            /// </summary>
            public static readonly Comparer INSTANCE = new();

            private Comparer() { }

            /// <inheritdoc />
            public bool Equals(Ratio x, Ratio y) => x.Equals(y);

            /// <inheritdoc />
            public int GetHashCode(Ratio obj) => obj.GetHashCode();
        }
    }
}