using System;

namespace Kkommon
{
    /// <summary>
    ///     An <see cref="Exception"/> type that is thrown when unwrapping a <see cref="Try"/> or <see cref="Try{T}"/>
    ///     fails.
    /// </summary>
    public class UnwrapException : Exception
    {
        /// <summary>
        ///     Initializes a new <see cref="UnwrapException"/> with the given error message.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        public UnwrapException(string? errorMessage) : base(errorMessage) { }

        /// <summary>
        ///     Initializes a new <see cref="UnwrapException"/> with the given error message and the given inner
        ///     <see cref="Exception"/>.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="innerException">The inner <see cref="Exception"/>.</param>
        public UnwrapException(string? errorMessage, Exception? innerException) : base(errorMessage, innerException) { }
    }
}