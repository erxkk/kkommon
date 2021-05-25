using Xunit;

namespace Kkommon.UnitTests
{
    public sealed class MathematicsTests
    {
        [Theory]
        [InlineData(20, 6, 2), InlineData(4, 20, 4), InlineData(2, 7, 1)]
        public void Finds_Greatest_Common_Denominator(int a, int b, int gcd)
        {
            Assert.Equal(Mathematics.GreatestCommonDenominator(a, b), gcd);
        }
        
        [Theory]
        [InlineData(20, 6, 60), InlineData(4, 20, 20), InlineData(2, 7, 14)]
        public void Finds_Least_Common_Multiple(int a, int b, int lcm)
        {
            Assert.Equal(Mathematics.LeastCommonMultiple(a, b), lcm);
        }
    }
}