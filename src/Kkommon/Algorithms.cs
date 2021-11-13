using System;
using System.Runtime.CompilerServices;

using JetBrains.Annotations;

namespace Kkommon
{
    /// <summary>
    ///     A static class containing algorithms.
    /// </summary>
    public static class Algorithms
    {
        /// <summary>
        ///     A static class containing common mathematical algorithms.
        /// </summary>
        [PublicAPI]
        public static class Math
        {
            /// <summary>
            ///     Computes the greatest common denominator out of two unsigned 64-bit integers.
            /// </summary>
            /// <param name="a">The first given number.</param>
            /// <param name="b">The second given number.</param>
            /// <returns>
            ///     The greatest common denominator of <paramref name="a" /> and <paramref name="b"></paramref>.
            /// </returns>
            /// <exception cref="OverflowException">The operation resulted in an overflow.</exception>
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static ulong Gcd(ulong a, ulong b)
            {
                if (a < b)
                    (a, b) = (b, a);

                while (b != 0)
                {
                    ulong h = a % b;
                    a = b;
                    b = h;
                }

                return a;
            }

            /// <summary>
            ///     Computes the least common multiple of two unsigned 64-bit integers.
            /// </summary>
            /// <param name="a">The first given number.</param>
            /// <param name="b">The second given number.</param>
            /// <returns>
            ///     The least common multiple of <paramref name="a" /> and <paramref name="b" />.
            /// </returns>
            /// <exception cref="OverflowException">The operation resulted in an overflow.</exception>
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static ulong Lcm(ulong a, ulong b)
            {
                if (a < b)
                    (a, b) = (b, a);

                ulong initialA = a;
                ulong initialB = b;

                while (a != b)
                {
                    if (a > b)
                        (a, initialA, b, initialB) = (b, initialB, a, initialA);

                    ulong differenceMultiple = initialB * ((b - a) / initialB);
                    a += differenceMultiple;

                    if (a == b)
                        break;

                    a += initialA;
                }

                return a;
            }

            /// <summary>
            ///     Computes number binomial coefficient of two unsigned 64-bit integers.
            /// </summary>
            /// <param name="n">The number of n to choose k from.</param>
            /// <param name="k">The number k to choose from n.</param>
            /// <returns>
            ///     The binomial coefficient; n choose k.
            /// </returns>
            /// <exception cref="OverflowException">The operation resulted in an overflow.</exception>
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static ulong NChooseK(ulong n, ulong k)
            {
                // credit: http://blog.plover.com/math/choose.html
                ulong r = 1;

                if (k > n)
                    return 0;

                for (ulong d = 1; d <= k; d++)
                {
                    checked
                    {
                        r *= n--;
                        r /= d;
                    }
                }

                return r;
            }
        }
    }
}
