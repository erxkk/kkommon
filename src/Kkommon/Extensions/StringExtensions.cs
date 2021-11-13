using System;
using System.ComponentModel;

using JetBrains.Annotations;

namespace Kkommon.Extensions.String
{
    [PublicAPI]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class StringExtensions
    {
        /// <summary>
        ///     Splits a string into even chunks of a given length.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="chunkSize"></param>
        /// <returns>An array of strings containing the chunks of the specified size.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The string is empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The <paramref name="chunkSize"/> is less than 0.</exception>
        public static string[] Chunk(this string @this, int chunkSize)
        {
            Preconditions.NotEmpty(@this);
            Preconditions.Greater(chunkSize, 1);

            int chunkCount = Math.DivRem(@this.Length, chunkSize, out int lastChunkSize);
            string[] chunks = new string[lastChunkSize == 0 ? chunkCount : chunkCount + 1];
            int previous = 0;

            for (int i = 0; i < chunkCount; i++)
            {
                chunks[i] = @this[previous..(previous + chunkSize)];
                previous += chunkSize;
            }

            if (lastChunkSize != 0)
                chunks[chunkCount] = @this[previous..];

            return chunks;
        }
    }
}
