using System;

using Kkommon.Extensions.Enumerable;

using Xunit;

namespace Kkommon.Tests.Extensions
{
    public sealed class EnumerableTests
    {
        [Fact]
        public void HasAtLeast_Counts_Correctly()
        {
            const int n = 5;
            int[] intArray = new int[n];

            Assert.True(intArray.HasAtLeast(n - 1));
            Assert.True(intArray.HasAtLeast(n));
            Assert.False(intArray.HasAtLeast(n + 1));
        }

        [Fact]
        public void HasAtLeast_Throws_On_Invalid_Count()
        {
            const int n = 5;
            int[] intArray = new int[n];

            Assert.Throws<ArgumentOutOfRangeException>(() => intArray.HasAtLeast(n - n));
            Assert.Throws<ArgumentOutOfRangeException>(() => intArray.HasAtLeast(-n));
        }

        [Fact]
        public void HasAtMost_Counts_Correctly()
        {
            const int n = 5;
            int[] intArray = new int[n];

            Assert.False(intArray.HasAtMost(n - 1));
            Assert.True(intArray.HasAtMost(n));
            Assert.True(intArray.HasAtMost(n + 1));
        }

        [Fact]
        public void HasAtMost_Throws_On_Invalid_Count()
        {
            const int n = 5;
            int[] intArray = new int[n];

            Assert.Throws<ArgumentOutOfRangeException>(() => intArray.HasAtLeast(n - n));
            Assert.Throws<ArgumentOutOfRangeException>(() => intArray.HasAtLeast(-n));
        }
    }
}