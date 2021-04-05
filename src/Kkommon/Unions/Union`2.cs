namespace Kkommon.Unions
{
    /// <summary>
    ///     A type that contains a value of the types <typeparamref name="T1"/> or <typeparamref name="T2"/>.
    /// </summary>
    public abstract class Union<T1, T2>
    {
        /// <summary>
        ///     Creates a new <see cref="Union{T1, T2}"/> that holds the given value.
        /// </summary>
        private Union() { }

        /// <summary>
        ///     A union of type that holds a value of type <typeparamref name="T1"/>.
        /// </summary>
        public sealed class Case1 : Union<T1, T2>
        {
            /// <summary>
            ///     The underlying value this <see cref="Union{T1, T2}"/> is holding.
            /// </summary>
            public T1 Value { get; }

            /// <inheritdoc/>
            /// <param name="value">The value.</param>
            public Case1(T1 value) => Value = value;

            /// <inheritdoc/>
            public override string ToString() => $"Union`2 {{ {typeof(T1).Name}: {Value} }}";

            public static implicit operator T1(Case1 @this) => @this.Value;
            public static implicit operator Case1(T1 value) => new(value);
        }

        /// <summary>
        ///     A union of type that holds a value of type <typeparamref name="T2"/>.
        /// </summary>
        public sealed class Case2 : Union<T1, T2>
        {
            /// <summary>
            ///     The underlying value this <see cref="Union{T1, T2}"/> is holding.
            /// </summary>
            public T2 Value { get; }

            /// <inheritdoc/>
            /// <param name="value">The value.</param>
            public Case2(T2 value) => Value = value;

            /// <inheritdoc/>
            public override string ToString() => $"Union`2 {{ {typeof(T2).Name}: {Value} }}";

            public static implicit operator T2(Case2 @this) => @this.Value;
            public static implicit operator Case2(T2 value) => new(value);
        }
    }
}