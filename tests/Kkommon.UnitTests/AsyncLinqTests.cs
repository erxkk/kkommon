using System.Collections.Generic;
using System.Threading.Tasks;

using Kkommon.Extensions.AsyncLinq;

using Xunit;

namespace Kkommon.UnitTests
{
    public sealed class AsyncLinqTest
    {
        [Fact]
        public async Task Filters_Uneven_Asynchronously()
        {
            // the list to asynchronously filter
            List<int> list = new() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // asynchronously filters and returns IAsyncEnumerable
            IAsyncEnumerable<int> asyncEnumerable = list.WhereAsync(
                async i =>
                {
                    await Task.Yield();

                    return i % 2 == 0;
                }
            );

            // filter was applied
            await foreach (int item in asyncEnumerable)
                Assert.True(item % 2 == 0);
        }

        [Fact]
        public async Task Collects_IAsyncEnumerable_Asynchronously()
        {
            // the list to asynchronously filter
            List<int> list = new() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // asynchronously filters and collects IAsyncEnumerable
            IEnumerable<int> enumerable = await list.WhereAsync(
                    async i =>
                    {
                        await Task.Yield();

                        return i % 2 == 0;
                    }
                )
                .CollectAsync();

            // filter was applied
            foreach (int item in enumerable)
                Assert.True(item % 2 == 0);
        }
    }
}