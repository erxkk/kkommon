using System;
using System.ComponentModel;

using JetBrains.Annotations;

namespace Kkommon.Extensions.String
{
    [PublicAPI]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class StringExtensions
    {
        public static string[] Chunk(this string @this, int chunkSize)
        {
            int chunkCount = Math.DivRem(@this.Length, chunkSize, out int lastChunkSize);
            string[] chunks = new string[lastChunkSize == 0 ? chunkCount : chunkCount + 1];
            int previous = 0;

            for (int i = 0; i < chunkCount; i++)
            {
                chunks[i] = @this[previous..(previous + chunkSize)];
                previous += chunkSize;
            }

            if (lastChunkSize != 0)
                chunks[chunkCount + 1] = @this[previous..(previous + lastChunkSize)];

            return chunks;
        }
    }
}