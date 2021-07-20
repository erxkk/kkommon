using Kkommon.Extensions.String;

using Xunit;

namespace Kkommon.Tests.Extensions
{
    public sealed class StringExtensions
    {
        [Fact]
        public void Chunks_Correctly()
        {
            string str = new('a', 12);

            string[] chunks = str.Chunk(5);

            Assert.Equal(3, chunks.Length);
            Assert.Equal(new[] { "aaaaa", "aaaaa", "aa" }, chunks);
        }
    }
}