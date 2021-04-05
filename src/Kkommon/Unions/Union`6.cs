namespace Kkommon.Unions
{
    /// <summary>
    ///     A type that contains a value of one of the types from <typeparamref name="T1"/> to
    ///     <typeparamref name="T6"/>.
    /// </summary>
    public abstract class Union<T1, T2, T3, T4, T5, T6>
    {
        /// <summary>
        ///     Creates a new <see cref="Union{T1, T2, T3, T4, T5, T6}"/> that holds the given value.
        /// </summary>
        private Union() { }

        /// <summary>
        ///     A union of type that holds a value of type <typeparamref name="T1"/>.
        /// </summary>
        public sealed class Case1 : Union<T1, T2, T3, T4, T5, T6>
        {
            /// <summary>
            ///     The underlying value this <see cref="Union{T1, T2, T3, T4, T5, T6}"/> is holding.
            /// </summary>
            public T1 Value { get; }

            /// <inheritdoc/>
            /// <param name="value">The value.</param>
            public Case1(T1 value) => Value = value;

            /// <inheritdoc/>
            public override string ToString() => $"Union`6 {{ {typeof(T1).Name}: {Value} }}";

            public static implicit operator T1(Case1 @this) => @this.Value;
            public static implicit operator Case1(T1 value) => new(value);
        }

        /// <summary>
        ///     A union of type that holds a value of type <typeparamref name="T2"/>.
        /// </summary>
        public sealed class Case2 : Union<T1, T2, T3, T4, T5, T6>
        {
            /// <summary>
            ///     The underlying value this <see cref="Union{T1, T2, T3, T4, T5, T6}"/> is holding.
            /// </summary>
            public T2 Value { get; }

            /// <inheritdoc/>
            /// <param name="value">The value.</param>
            public Case2(T2 value) => Value = value;

            /// <inheritdoc/>
            public override string ToString() => $"Union`6 {{ {typeof(T2).Name}: {Value} }}";

            public static implicit operator T2(Case2 @this) => @this.Value;
            public static implicit operator Case2(T2 value) => new(value);
        }

        /// <summary>
        ///     A union of type that holds a value of type <typeparamref name="T3"/>.
        /// </summary>
        public sealed class Case3 : Union<T1, T2, T3, T4, T5, T6>
        {
            /// <summary>
            ///     The underlying value this <see cref="Union{T1, T2, T3, T4, T5, T6}"/> is holding.
            /// </summary>
            public T3 Value { get; }

            /// <inheritdoc/>
            /// <param name="value">The value.</param>
            public Case3(T3 value) => Value = value;

            /// <inheritdoc/>
            public override string ToString() => $"Union`6 {{ {typeof(T3).Name}: {Value} }}";

            public static implicit operator T3(Case3 @this) => @this.Value;
            public static implicit operator Case3(T3 value) => new(value);
        }

        /// <summary>
        ///     A union of type that holds a value of type <typeparamref name="T4"/>.
        /// </summary>
        public sealed class Case4 : Union<T1, T2, T3, T4, T5, T6>
        {
            /// <summary>
            ///     The underlying value this <see cref="Union{T1, T2, T3, T4, T5, T6}"/> is holding.
            /// </summary>
            public T4 Value { get; }

            /// <inheritdoc/>
            /// <param name="value">The value.</param>
            public Case4(T4 value) => Value = value;

            /// <inheritdoc/>
            public override string ToString() => $"Union`6 {{ {typeof(T4).Name}: {Value} }}";

            public static implicit operator T4(Case4 @this) => @this.Value;
            public static implicit operator Case4(T4 value) => new(value);
        }

        /// <summary>
        ///     A union of type that holds a value of type <typeparamref name="T5"/>.
        /// </summary>
        public sealed class Case5 : Union<T1, T2, T3, T4, T5, T6>
        {
            /// <summary>
            ///     The underlying value this <see cref="Union{T1, T2, T3, T4, T5, T6}"/> is holding.
            /// </summary>
            public T5 Value { get; }

            /// <inheritdoc/>
            /// <param name="value">The value.</param>
            public Case5(T5 value) => Value = value;

            /// <inheritdoc/>
            public override string ToString() => $"Union`6 {{ {typeof(T5).Name}: {Value} }}";

            public static implicit operator T5(Case5 @this) => @this.Value;
            public static implicit operator Case5(T5 value) => new(value);
        }

        /// <summary>
        ///     A union of type that holds a value of type <typeparamref name="T6"/>.
        /// </summary>
        public sealed class Case6 : Union<T1, T2, T3, T4, T5, T6>
        {
            /// <summary>
            ///     The underlying value this <see cref="Union{T1, T2, T3, T4, T5, T6}"/> is holding.
            /// </summary>
            public T6 Value { get; }

            /// <inheritdoc/>
            /// <param name="value">The value.</param>
            public Case6(T6 value) => Value = value;

            /// <inheritdoc/>
            public override string ToString() => $"Union`6 {{ {typeof(T6).Name}: {Value} }}";

            public static implicit operator T6(Case6 @this) => @this.Value;
            public static implicit operator Case6(T6 value) => new(value);
        }
    }
}