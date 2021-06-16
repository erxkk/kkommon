using Xunit;

namespace Kkommon.Math.Tests
{
    public sealed class MathTests
    {
        [Theory]
        [InlineData(20, 6, 2)][InlineData(4, 20, 4)][InlineData(2, 7, 1)]
        public void Finds_Greatest_Common_Denominator(int a, int b, int gcd)
        {
            Assert.Equal(Math.Gcd(a, b), gcd);
        }

        [Theory]
        [InlineData(20, 6, 60)][InlineData(4, 20, 20)][InlineData(2, 7, 14)]
        public void Finds_Least_Common_Multiple(int a, int b, int lcm)
        {
            Assert.Equal(Math.Lcm(a, b), lcm);
        }
    }
}