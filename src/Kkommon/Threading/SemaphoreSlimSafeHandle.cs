using System;
using System.Threading;

namespace Kkommon.Threading
{
    /// <summary>
    ///     A <see cref="IDisposable"/> handle that releases the semaphore on disposal.
    /// </summary>
    public readonly struct SemaphoreSlimSafeHandle : IDisposable
    {
        private readonly SemaphoreSlim? _semaphore;

        internal SemaphoreSlimSafeHandle(SemaphoreSlim semaphore) => _semaphore = semaphore;

        /// <inheritdoc />
        public void Dispose()
        {
            if (_semaphore is null)
            {
                throw new InvalidOperationException(
                    $"No {nameof(SemaphoreSlim)} set, do not use default ctor for {nameof(SemaphoreSlimSafeHandle)}"
                );
            }

            _semaphore.Release();
        }
    }
}