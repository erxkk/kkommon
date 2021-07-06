using Xunit;

namespace Kkommon.Tests.Math
{
    public sealed class AlgorithmMathTests
    {
        [Theory]
        [InlineData(20, 6, 2)][InlineData(4, 20, 4)][InlineData(2, 7, 1)]
        public void Finds_Greatest_Common_Denominator(ulong a, ulong b, ulong gcd)
        {
            Assert.Equal(Algorithms.Math.Gcd(a, b), gcd);
        }

        [Theory]
        [InlineData(20, 6, 60)][InlineData(4, 20, 20)][InlineData(2, 7, 14)]
        public void Finds_Least_Common_Multiple(ulong a, ulong b, ulong lcm)
        {
            Assert.Equal(Algorithms.Math.Lcm(a, b), lcm);
        }
    }
}