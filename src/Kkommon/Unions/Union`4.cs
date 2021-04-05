using System.Diagnostics;

namespace Kkommon.Unions
{
    /// <summary>
    ///     A type that contains a value of one of the types from <typeparamref name="T1"/> to
    ///     <typeparamref name="T4"/>.
    /// </summary>
    public abstract class Union<T1, T2, T3, T4>
    {
        /// <summary>
        ///     Creates a new <see cref="Union{T1, T2, T3, T4}"/> that holds the given value.
        /// </summary>
        private Union() { }

        /// <summary>
        ///     A union of type that holds a value of type <typeparamref name="T1"/>.
        /// </summary>
        [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
        public sealed class Case1 : Union<T1, T2, T3, T4>
        {
            /// <summary>
            ///     The underlying value this <see cref="Union{T1, T2, T3, T4}"/> is holding.
            /// </summary>
            public T1 Value { get; }

            /// <inheritdoc/>
            /// <param name="value">The value.</param>
            public Case1(T1 value) => Value = value;

            /// <inheritdoc/>
            public override string ToString() => $"Union`4 {{ {typeof(T1).Name}: {Value} }}";

            private string DebuggerDisplay => $"Case1 {{ Value = {Value} }}";

            public static implicit operator T1(Case1 @this) => @this.Value;
            public static implicit operator Case1(T1 value) => new(value);
        }

        /// <summary>
        ///     A union of type that holds a value of type <typeparamref name="T2"/>.
        /// </summary>
        [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
        public sealed class Case2 : Union<T1, T2, T3, T4>
        {
            /// <summary>
            ///     The underlying value this <see cref="Union{T1, T2, T3, T4}"/> is holding.
            /// </summary>
            public T2 Value { get; }

            /// <inheritdoc/>
            /// <param name="value">The value.</param>
            public Case2(T2 value) => Value = value;

            /// <inheritdoc/>
            public override string ToString() => $"Union`4 {{ {typeof(T2).Name}: {Value} }}";

            private string DebuggerDisplay => $"Case2 {{ Value = {Value} }}";

            public static implicit operator T2(Case2 @this) => @this.Value;
            public static implicit operator Case2(T2 value) => new(value);
        }

        /// <summary>
        ///     A union of type that holds a value of type <typeparamref name="T3"/>.
        /// </summary>
        [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
        public sealed class Case3 : Union<T1, T2, T3, T4>
        {
            /// <summary>
            ///     The underlying value this <see cref="Union{T1, T2, T3, T4}"/> is holding.
            /// </summary>
            public T3 Value { get; }

            /// <inheritdoc/>
            /// <param name="value">The value.</param>
            public Case3(T3 value) => Value = value;

            /// <inheritdoc/>
            public override string ToString() => $"Union`4 {{ {typeof(T3).Name}: {Value} }}";

            private string DebuggerDisplay => $"Case3 {{ Value = {Value} }}";

            public static implicit operator T3(Case3 @this) => @this.Value;
            public static implicit operator Case3(T3 value) => new(value);
        }

        /// <summary>
        ///     A union of type that holds a value of type <typeparamref name="T4"/>.
        /// </summary>
        [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
        public sealed class Case4 : Union<T1, T2, T3, T4>
        {
            /// <summary>
            ///     The underlying value this <see cref="Union{T1, T2, T3, T4}"/> is holding.
            /// </summary>
            public T4 Value { get; }

            /// <inheritdoc/>
            /// <param name="value">The value.</param>
            public Case4(T4 value) => Value = value;

            /// <inheritdoc/>
            public override string ToString() => $"Union`4 {{ {typeof(T4).Name}: {Value} }}";

            private string DebuggerDisplay => $"Case4 {{ Value = {Value} }}";

            public static implicit operator T4(Case4 @this) => @this.Value;
            public static implicit operator Case4(T4 value) => new(value);
        }
    }
}