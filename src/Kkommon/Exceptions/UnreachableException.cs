using System;

using JetBrains.Annotations;

namespace Kkommon.Exceptions
{
    /// <summary>
    ///     An exception to throw in unreachable code branches.
    /// </summary>
    [PublicAPI]
    public sealed class UnreachableException : Exception
    {
        /// <summary>
        ///     A field containing an invalid value in case the exception is thrown in pattern matching branches.
        /// </summary>
        public object? InvalidObject { get; }

        /// <inheritdoc />
        public UnreachableException() : base("This branch should not have been reached.") { }

        /// <inheritdoc />
        public UnreachableException(object? invalidObject)
            : base("An invalidObject caused an invalid branch to be reached.")
            => InvalidObject = invalidObject;

        /// <inheritdoc />
        public UnreachableException(string? message) : base(message) { }

        /// <inheritdoc />
        public UnreachableException(string? message, object? invalidObject) : base(message)
            => InvalidObject = invalidObject;
    }
}
