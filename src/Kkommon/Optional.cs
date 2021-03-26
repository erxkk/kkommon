#nullable enable
namespace Kkommon
{
    /// <summary>
    /// A type that can contain a value of type <typeparamref name="T"/>
    /// </summary>
    public readonly struct Optional<T>
    {
        /// <summary>
        /// Whether or not <see cref="Optional{T}.Value"/> is holding a value
        /// </summary>
        public bool HasValue { get; }

        /// <summary>
        /// The underlying value this <see cref="Optional{T}"/> is holding, check if it is set via <see cref="Optional{T}.HasValue"/>
        /// </summary>
        public T Value { get; }

        /// <summary>
        /// Creates a new <see cref="Optional{T}"/> with the given value
        /// </summary>
        /// <param name="value">The underlying value</param>
        public Optional(T value)
        {
            HasValue = true;
            Value    = value;
        }

        public static implicit operator Optional<T>(T? value) => value is not null ? new Optional<T>(value) : new Optional<T>();

        /// <inheritdoc/>
        public override string ToString() => $"Optional<{typeof(T).Name}> {{ {(HasValue ? $"Value: {Value}" : "Empty")} }}";
    }
}