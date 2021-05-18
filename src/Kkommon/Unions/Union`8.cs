using System.Diagnostics;

namespace Kkommon.Unions
{
    /// <summary>
    ///     A type that contains a value of one of the types from <typeparamref name="T1"/> to
    ///     <typeparamref name="T8"/>.
    /// </summary>
    public abstract class Union<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        /// <summary>
        ///     Creates a new <see cref="Union{T1, T2, T3, T4, T5, T6, T7, T8}"/> that holds the given value.
        /// </summary>
        private Union() { }

        /// <summary>
        ///     A union of type that holds a value of type <typeparamref name="T1"/>.
        /// </summary>
        [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
        public sealed class Case1 : Union<T1, T2, T3, T4, T5, T6, T7, T8>
        {
            /// <summary>
            ///     The underlying value this <see cref="Union{T1, T2, T3, T4, T5, T6, T7, T8}"/> is holding.
            /// </summary>
            public T1 Value { get; }

            /// <inheritdoc/>
            /// <param name="value">The value.</param>
            public Case1(T1 value) => Value = value;

            /// <inheritdoc/>
            public override string ToString() => $"Union`8 {{ {typeof(T6).Name}: {Value} }}";

            private string DebuggerDisplay => $"Case1 {{ Value = {Value} }}";

            public static implicit operator T1(Case1 @this) => @this.Value;
            public static implicit operator Case1(T1 value) => new(value);
        }

        /// <summary>
        ///     A union of type that holds a value of type <typeparamref name="T2"/>.
        /// </summary>
        [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
        public sealed class Case2 : Union<T1, T2, T3, T4, T5, T6, T7, T8>
        {
            /// <summary>
            ///     The underlying value this <see cref="Union{T1, T2, T3, T4, T5, T6, T7, T8}"/> is holding.
            /// </summary>
            public T2 Value { get; }

            /// <inheritdoc/>
            /// <param name="value">The value.</param>
            public Case2(T2 value) => Value = value;

            /// <inheritdoc/>
            public override string ToString() => $"Union`8 {{ {typeof(T6).Name}: {Value} }}";

            private string DebuggerDisplay => $"Case2 {{ Value = {Value} }}";

            public static implicit operator T2(Case2 @this) => @this.Value;
            public static implicit operator Case2(T2 value) => new(value);
        }

        /// <summary>
        ///     A union of type that holds a value of type <typeparamref name="T3"/>.
        /// </summary>
        [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
        public sealed class Case3 : Union<T1, T2, T3, T4, T5, T6, T7, T8>
        {
            /// <summary>
            ///     The underlying value this <see cref="Union{T1, T2, T3, T4, T5, T6, T7, T8}"/> is holding.
            /// </summary>
            public T3 Value { get; }

            /// <inheritdoc/>
            /// <param name="value">The value.</param>
            public Case3(T3 value) => Value = value;

            /// <inheritdoc/>
            public override string ToString() => $"Union`8 {{ {typeof(T6).Name}: {Value} }}";

            private string DebuggerDisplay => $"Case3 {{ Value = {Value} }}";

            public static implicit operator T3(Case3 @this) => @this.Value;
            public static implicit operator Case3(T3 value) => new(value);
        }

        /// <summary>
        ///     A union of type that holds a value of type <typeparamref name="T4"/>.
        /// </summary>
        [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
        public sealed class Case4 : Union<T1, T2, T3, T4, T5, T6, T7, T8>
        {
            /// <summary>
            ///     The underlying value this <see cref="Union{T1, T2, T3, T4, T5, T6, T7, T8}"/> is holding.
            /// </summary>
            public T4 Value { get; }

            /// <inheritdoc/>
            /// <param name="value">The value.</param>
            public Case4(T4 value) => Value = value;

            /// <inheritdoc/>
            public override string ToString() => $"Union`8 {{ {typeof(T6).Name}: {Value} }}";

            private string DebuggerDisplay => $"Case4 {{ Value = {Value} }}";

            public static implicit operator T4(Case4 @this) => @this.Value;
            public static implicit operator Case4(T4 value) => new(value);
        }

        /// <summary>
        ///     A union of type that holds a value of type <typeparamref name="T5"/>.
        /// </summary>
        [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
        public sealed class Case5 : Union<T1, T2, T3, T4, T5, T6, T7, T8>
        {
            /// <summary>
            ///     The underlying value this <see cref="Union{T1, T2, T3, T4, T5, T6, T7, T8}"/> is holding.
            /// </summary>
            public T5 Value { get; }

            /// <inheritdoc/>
            /// <param name="value">The value.</param>
            public Case5(T5 value) => Value = value;

            /// <inheritdoc/>
            public override string ToString() => $"Union`8 {{ {typeof(T6).Name}: {Value} }}";

            private string DebuggerDisplay => $"Case5 {{ Value = {Value} }}";

            public static implicit operator T5(Case5 @this) => @this.Value;
            public static implicit operator Case5(T5 value) => new(value);
        }

        /// <summary>
        ///     A union of type that holds a value of type <typeparamref name="T6"/>.
        /// </summary>
        [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
        public sealed class Case6 : Union<T1, T2, T3, T4, T5, T6, T7, T8>
        {
            /// <summary>
            ///     The underlying value this <see cref="Union{T1, T2, T3, T4, T5, T6, T7, T8}"/> is holding.
            /// </summary>
            public T6 Value { get; }

            /// <inheritdoc/>
            /// <param name="value">The value.</param>
            public Case6(T6 value) => Value = value;

            /// <inheritdoc/>
            public override string ToString() => $"Union`8 {{ {typeof(T6).Name}: {Value} }}";

            private string DebuggerDisplay => $"Case6 {{ Value = {Value} }}";

            public static implicit operator T6(Case6 @this) => @this.Value;
            public static implicit operator Case6(T6 value) => new(value);
        }

        /// <summary>
        ///     A union of type that holds a value of type <typeparamref name="T7"/>.
        /// </summary>
        [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
        public sealed class Case7 : Union<T1, T2, T3, T4, T5, T6, T7, T8>
        {
            /// <summary>
            ///     The underlying value this <see cref="Union{T1, T2, T3, T4, T5, T6, T7, T8}"/> is holding.
            /// </summary>
            public T7 Value { get; }

            /// <inheritdoc/>
            /// <param name="value">The value.</param>
            public Case7(T7 value) => Value = value;

            /// <inheritdoc/>
            public override string ToString() => $"Union`8 {{ {typeof(T6).Name}: {Value} }}";

            private string DebuggerDisplay => $"Case7 {{ Value = {Value} }}";

            public static implicit operator T7(Case7 @this) => @this.Value;
            public static implicit operator Case7(T7 value) => new(value);
        }

        /// <summary>
        ///     A union of type that holds a value of type <typeparamref name="T8"/>.
        /// </summary>
        [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
        public sealed class Case8 : Union<T1, T2, T3, T4, T5, T6, T7, T8>
        {
            /// <summary>
            ///     The underlying value this <see cref="Union{T1, T2, T3, T4, T5, T6, T7, T8}"/> is holding.
            /// </summary>
            public T8 Value { get; }

            /// <inheritdoc/>
            /// <param name="value">The value.</param>
            public Case8(T8 value) => Value = value;

            /// <inheritdoc/>
            public override string ToString() => $"Union`8 {{ {typeof(T6).Name}: {Value} }}";

            private string DebuggerDisplay => $"Case8 {{ Value = {Value} }}";

            public static implicit operator T8(Case8 @this) => @this.Value;
            public static implicit operator Case8(T8 value) => new(value);
        }
    }
}