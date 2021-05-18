using System.Diagnostics;

namespace Kkommon
{
    /// <summary>
    ///     A special type of <see cref="Unions.Union{TSuccess,TError}"/> that represents the return type of a function that
    ///     might fail execution gracefully, returning  <typeparamref name="TSuccess"/> on success and
    ///     <typeparamref name="TError"/> on failure.
    /// </summary>
    public abstract class Result<TSuccess, TError>
    {
        private Result() { }

        /// <summary>
        ///     A <see cref="Result{TSuccess, TError}"/> that holds a success value.
        /// </summary>
        [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
        public sealed class Success : Result<TSuccess, TError>
        {
            /// <summary>
            ///     The success value.
            /// </summary>
            public TSuccess Value { get; }

            /// <inheritdoc/>
            /// <param name="value">The success value.</param>
            public Success(TSuccess value) => Value = value;

            /// <inheritdoc/>
            public override string ToString()
                => $"Result<{typeof(TSuccess).Name}, {typeof(TError).Name}> {{ Success: {Value} }}";

            private string DebuggerDisplay => $"Success {{ Value = {Value} }}";

            public static implicit operator TSuccess(Success @this) => @this.Value;
            public static implicit operator Success(TSuccess value) => new(value);
        }

        /// <summary>
        ///     A <see cref="Result{TSuccess, TError}"/> that holds an error value.
        /// </summary>
        [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
        public sealed class Error : Result<TSuccess, TError>
        {
            /// <summary>
            ///     The error value.
            /// </summary>
            public TError Value { get; }

            /// <inheritdoc/>
            /// <param name="value">The error value</param>
            public Error(TError value) => Value = value;

            /// <inheritdoc/>
            public override string ToString()
                => $"Result<{typeof(TSuccess).Name}, {typeof(TError).Name}> {{ Error: {Value} }}";

            private string DebuggerDisplay => $"Error {{ Value = {Value} }}";

            public static implicit operator TError(Error @this) => @this.Value;
            public static implicit operator Error(TError value) => new(value);
        }
    }
}