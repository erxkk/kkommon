using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

using Kkommon.Threading;

namespace Kkommon.Extensions
{
    /// <summary>
    ///     Useful extensions to enter a semaphore and automatically releasing it in case of an exception by use of a
    ///     <see cref="SemaphoreSlimSafeHandle"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class SemaphoreExtensions
    {
        public static SemaphoreSlimSafeHandle Enter(
            this SemaphoreSlim @this,
            CancellationToken cancellationToken = default
        )
        {
            @this.Wait(cancellationToken);
            return new SemaphoreSlimSafeHandle(@this);
        }

        public static SemaphoreSlimSafeHandle? TryEnter(
            this SemaphoreSlim @this,
            TimeSpan timeSpan,
            CancellationToken cancellationToken = default
        )
        {
            if (@this.Wait(timeSpan, cancellationToken))
                return new SemaphoreSlimSafeHandle(@this);

            return null;
        }

        public static SemaphoreSlimSafeHandle? TryEnter(
            this SemaphoreSlim @this,
            int milliseconds,
            CancellationToken cancellationToken = default
        )
        {
            if (@this.Wait(milliseconds, cancellationToken))
                return new SemaphoreSlimSafeHandle(@this);

            return null;
        }

        public static async Task<SemaphoreSlimSafeHandle> EnterAsync(
            this SemaphoreSlim @this,
            CancellationToken cancellationToken = default
        )
        {
            await @this.WaitAsync(cancellationToken);
            return new SemaphoreSlimSafeHandle(@this);
        }

        public static async Task<SemaphoreSlimSafeHandle?> TryEnterAsync(
            this SemaphoreSlim @this,
            TimeSpan timeSpan,
            CancellationToken cancellationToken = default
        )
        {
            if (await @this.WaitAsync(timeSpan, cancellationToken))
                return new SemaphoreSlimSafeHandle(@this);

            return null;
        }

        public static async Task<SemaphoreSlimSafeHandle?> TryEnterAsync(
            this SemaphoreSlim @this,
            int milliseconds,
            CancellationToken cancellationToken = default
        )
        {
            if (await @this.WaitAsync(milliseconds, cancellationToken))
                return new SemaphoreSlimSafeHandle(@this);

            return null;
        }
    }
}