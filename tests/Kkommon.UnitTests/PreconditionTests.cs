using System;

using Xunit;

namespace Kkommon.UnitTests
{
    public sealed class PreconditionTests
    {
        [Fact]
        public void Not_Null()
        {
            Preconditions.NotNull(new object(), "");
            Assert.Throws<ArgumentNullException>(() => Preconditions.NotNull((object?) null, ""));
        }

        [Fact]
        public void In_Range()
        {
            Preconditions.InRange(3, 0, 4, "");
            Preconditions.InRange(0, 0, 4, "");
            Assert.Throws<ArgumentOutOfRangeException>(() => Preconditions.InRange(-1, 0, 4, ""));
            Assert.Throws<ArgumentOutOfRangeException>(() => Preconditions.InRange(4, 0, 4, ""));
            Assert.Throws<ArgumentOutOfRangeException>(() => Preconditions.InRange(5, 0, 4, ""));
        }
    }
}