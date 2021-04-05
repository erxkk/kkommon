using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Kkommon.Threading
{
    /// <summary>
    ///     A <see cref="Guard"/> that encapsulates the object it guards, using <see cref="Access"/> to wait for
    ///     and to release an underlying <see cref="SemaphoreSlim"/> via <see cref="IDisposable"/>.
    /// </summary>
    /// <remarks>
    ///     Setting the value of a <see cref="Guarded{T}"/> implicitly will default to 1 initial count and
    ///     <see cref="int.MaxValue"/> max count.
    /// </remarks>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class Guarded<T> : IDisposable
    {
        private readonly SemaphoreSlim _semaphoreSlim;
        private bool _isDisposed;
        private T _value;

        /// <summary>
        ///     Gets the number of remaining threads that can enter the guard.
        /// </summary>
        public int CurrentCount => _semaphoreSlim.CurrentCount;

        /// <summary>
        ///     Initializes a new <see cref="Guarded{T}"/>, specifying the initial value and maximum count of concurrent
        ///     accesses.
        /// </summary>
        /// <param name="value">The underlying value.</param>
        /// <param name="maxCount">The maximum allowed concurrent accesses.</param>
        /// <exception cref="ArgumentOutOfRangeException">The maximum count less than or equal to 0.</exception>
        public Guarded(T value = default, int maxCount = int.MaxValue)
        {
            if (maxCount < 0)
                throw new ArgumentOutOfRangeException(nameof(maxCount), "The maximum count must be greater than 0.");

            _value         = value;
            _semaphoreSlim = new SemaphoreSlim(0, maxCount);
        }

        /// <summary>
        ///     Asynchronously waits to enter the <see cref="Guarded{T}"/>, while observing a
        ///     <see cref="CancellationToken"/>.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to observe.</param>
        /// <returns>
        ///     A task that will complete when the <see cref="Guarded{T}"/> has been entered with the disposable
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
        ///     Blocks the current thread until it can enter the <see cref="Guarded{T}"/>, while observing a
        ///     <see cref="CancellationToken"/>.
        /// </summary>
        /// <returns>
        ///     The disposable <see cref="Access"/>.
        /// </returns>
        /// <exception cref="ObjectDisposedException">The current instance has already been disposed.</exception>
        public Access GetAccess()
        {
            ThrowIfDisposed();

            return Access.CreateAccess(this);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _semaphoreSlim.Dispose();
            _isDisposed = true;
        }

        private void ThrowIfDisposed()
        {
            if (_isDisposed)
                throw new ObjectDisposedException(nameof(Guarded<T>), "This instance has already been disposed.");
        }

        public static implicit operator Guarded<T>(T value) => new(value, 1);

        /// <summary>
        ///     Represents access to a <see cref="Guarded{T}"/> for the current thread.
        /// </summary>
        /// <remarks>
        ///     This struct should only be created with the static factory methods, if not all it's instance methods
        ///     will throw a <see cref="NullReferenceException"/>.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public readonly struct Access : IDisposable
        {
            private readonly Guarded<T> _guard;

            /// <summary>
            ///     The underlying value of the <see cref="Guarded{T}"/>
            /// </summary>
            public T Value { get => _guard._value; set => _guard._value = value; }

            private Access(Guarded<T> guard) => _guard = guard;

            /// <summary>
            ///     Asynchronously waits to enter the <see cref="Guard"/>.
            /// </summary>
            /// <param name="guard">The <see cref="Guarded{T}"/> to get access from.</param>
            /// <param name="cancellationToken">The <see cref="CancellationToken"/> to observe.</param>
            /// <returns>
            ///     A task that will complete when the <see cref="Guarded{T}"/> has been entered.
            /// </returns>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static async Task<Access> CreateAccessAsync(
                Guarded<T> guard,
                CancellationToken cancellationToken
            )
            {
                await guard._semaphoreSlim.WaitAsync(cancellationToken);

                return new Access(guard);
            }

            /// <summary>
            ///     Blocks the current thread until it can enter the <see cref="Guard"/>.
            /// </summary>
            /// <param name="guard">The <see cref="Guarded{T}"/> to get access from.</param>
            /// <returns>
            ///     A new disposable <see cref="Access"/>.
            /// </returns>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static Access CreateAccess(Guarded<T> guard)
            {
                guard._semaphoreSlim.Wait();

                return new Access(guard);
            }

            /// <summary>
            ///     Releases the underlying <see cref="Guarded{T}"/> once.
            /// </summary>
            public void Dispose() => _guard._semaphoreSlim.Release();
        }

        /// <summary>
        ///     Returns a string representation of this <see cref="Guarded{T}"/> and it's value.
        /// </summary>
        /// <returns>
        ///     A string representing the current object.
        /// </returns>
        public override string ToString() => $"Guarded<{typeof(T).Name}> {{ Value: {_value?.ToString() ?? "null"} }}";
        private string DebuggerDisplay
            => $"Guarded<{typeof(T).Name}> {{ CurrentCount = {CurrentCount}, Value = {_value} }}";
    }
}