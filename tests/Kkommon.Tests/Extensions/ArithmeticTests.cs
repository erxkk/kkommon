using Kkommon.Extensions.Arithmetic;

using Xunit;

namespace Kkommon.Tests.Extensions
{
    public sealed class ArithmeticTests
    {
        [Fact]
        public void InRange()
        {
            Assert.True(5.IsInRange(4, 5));
            Assert.True(5.IsInRange(5, 6));
            Assert.False(7.IsInRange(4, 5));
            Assert.False(7.IsInRange(5, 6));
            Assert.False(3.IsInRange(4, 5));
            Assert.False(3.IsInRange(5, 6));
        }
    }
}