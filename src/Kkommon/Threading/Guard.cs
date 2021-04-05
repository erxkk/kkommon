using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Kkommon.Threading
{
    /// <summary>
    ///     A simple wrapper around a <see cref="SemaphoreSlim"/> that uses <see cref="Access"/> to wait for and to
    ///     release the semaphore via <see cref="IDisposable"/>.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public struct Guard : IDisposable
    {
        private readonly SemaphoreSlim _semaphoreSlim;
        private bool _isDisposed;

        /// <summary>
        ///     Gets the number of remaining threads that can enter the <see cref="Guard"/>.
        /// </summary>
        public int CurrentCount => _semaphoreSlim.CurrentCount;

        /// <summary>
        ///     Initializes a new <see cref="Guard"/>, specifying the initial count and maximum count of concurrent
        ///     accesses.
        /// </summary>
        /// <param name="maxCount">The maximum allowed concurrent accesses</param>
        /// <exception cref="ArgumentOutOfRangeException">The maximum count less than or equal to 0.</exception>
        public Guard(int maxCount = int.MaxValue)
        {
            if (maxCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxCount), "The maximum count must be greater than 0.");

            _semaphoreSlim = new SemaphoreSlim(maxCount, maxCount);
            _isDisposed    = false;
        }

        /// <summary>
        ///     Asynchronously waits to enter the <see cref="Guard"/>, while observing a
        ///     <see cref="CancellationToken"/>.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to observe.</param>
        /// <returns>
        ///     A task that will complete when the <see cref="Guard"/> has been entered with the disposable
        ///     <see cref="Access"/> as result.
        /// </returns>
        /// <exception cref="OperationCanceledException">The cancellationToken was canceled.</exception>
        /// <exception cref="ObjectDisposedException">The current instance has already been disposed.</exception>
        public Task<Access> GetAccessAsync(CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();

            return Access.CreateAccessAsync(this, cancellationToken);
        }

        /// <summary>
        ///     Blocks the current thread until it can enter the <see cref="Guard"/>.
        /// </summary>
        /// <returns>
        ///     The disposable <see cref="Access"/>.
        /// </returns>
        /// <exception cref="OperationCanceledException">The timeout was exceeded.</exception>
        /// <exception cref="ObjectDisposedException">The current instance has already been disposed.</exception>
        public Access GetAccess()
        {
            ThrowIfDisposed();

            return Access.CreateAccess(this);
        }

        private void ThrowIfDisposed()
        {
            if (_isDisposed)
                throw new ObjectDisposedException(nameof(Guard), "The instance is already disposed.");
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _semaphoreSlim.Dispose();
            _isDisposed = true;
        }

        /// <summary>
        ///     Represents access to a <see cref="Guard"/> for the current thread.
        /// </summary>
        /// <remarks>
        ///     This struct should only be created with the static factory methods, if not all it's instance methods
        ///     will throw a <see cref="NullReferenceException"/>.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public readonly struct Access : IDisposable
        {
            private readonly Guard _guard;
            private Access(Guard guard) => _guard = guard;

            /// <summary>
            ///     Asynchronously waits to enter the <see cref="Guard"/>.
            /// </summary>
            /// <param name="guard">The <see cref="Guard"/> to get access from.</param>
            /// <param name="cancellationToken">The <see cref="CancellationToken"/> to observe.</param>
            /// <returns>
            ///     A task that will complete when the <see cref="Guard"/> has been entered.
            /// </returns>
            /// <exception cref="OperationCanceledException">The cancellationToken was canceled.</exception>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static async Task<Access> CreateAccessAsync(
                Guard guard,
                CancellationToken cancellationToken
            )
            {
                await guard._semaphoreSlim.WaitAsync(cancellationToken);

                return new Access(guard);
            }

            /// <summary>
            ///     Blocks the current thread until it can enter the <see cref="Guard"/>.
            /// </summary>
            /// <param name="guard">The <see cref="Guard"/> to get access from</param>
            /// <returns>
            ///     A new disposable <see cref="Access"/>.
            /// </returns>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static Access CreateAccess(Guard guard)
            {
                guard._semaphoreSlim.Wait();

                return new Access(guard);
            }

            /// <summary>
            ///     Releases the underlying <see cref="Guard"/> once.
            /// </summary>
            public void Dispose() => _guard._semaphoreSlim.Release();
        }

        private string DebuggerDisplay => $"Guard {{ CurrentCount = {CurrentCount} }}";
    }
}