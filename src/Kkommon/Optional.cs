using System.Diagnostics;

#nullable enable
namespace Kkommon
{
    /// <summary>
    ///     A type that may contain a value of type <typeparamref name="T"/>.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public readonly struct Optional<T>
    {
        /// <summary>
        ///     Whether or not <see cref="Value"/> is holding a value.
        /// </summary>
        public bool HasValue { get; }

        /// <summary>
        ///     The underlying value this <see cref="Optional{T}"/> is holding, check if it is set via
        ///     <see cref="HasValue"/>.
        /// </summary>
        public T Value { get; }

        /// <summary>
        ///     Creates a new <see cref="Optional{T}"/> with the given <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The underlying value.</param>
        public Optional(T value)
        {
            HasValue = true;
            Value    = value;
        }

        public static implicit operator Optional<T>(T? value)
            => value is not null ? new Optional<T>(value) : new Optional<T>();

        /// <summary>
        ///     Returns a string representation of this optional and it's state and value.
        /// </summary>
        /// <returns>
        ///     A string representing the current object.
        /// </returns>
        public override string ToString()
            => $"Optional<{typeof(T).Name}> {{ {(HasValue ? $"Value: {Value}" : "Empty")} }}";

        private string DebuggerDisplay => $"Optional<{typeof(T).Name}> {{ HasValue = {HasValue}, Value = {Value} }}";
    }
}