using System.Threading;
using System.Threading.Tasks;

using Kkommon.Exceptions;
using Kkommon.Extensions.Semaphore;

using Xunit;

namespace Kkommon.Tests.Threading
{
    public sealed class SemaphoreSlimSafeHandleTests
    {
        [Fact]
        public async Task Releases_SemaphoreSlim()
        {
            SemaphoreSlim slim = new(1, 1);

            // The semaphore can be entered once
            Assert.Equal(1, slim.CurrentCount);

            using (_ = await slim.EnterAsync())
            {
                // the semaphore is entered
                Assert.Equal(0, slim.CurrentCount);
            }

            // the semaphore was released
            Assert.Equal(1, slim.CurrentCount);
        }

        [Fact]
        public async Task Releases_SemaphoreSlim_On_Exception()
        {
            SemaphoreSlim slim = new(1, 1);

            // The semaphore can be entered once
            Assert.Equal(1, slim.CurrentCount);

            await Assert.ThrowsAsync<UnitTestException>(
                async () =>
                {
                    using (_ = await slim.EnterAsync())
                    {
                        // the semaphore is entered
                        Assert.Equal(0, slim.CurrentCount);
                        throw new UnitTestException();
                    }
                }
            );

            // the semaphore was released
            Assert.Equal(1, slim.CurrentCount);
        }
    }
}
