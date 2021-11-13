using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

using JetBrains.Annotations;

namespace Kkommon.Extensions.Prototyping
{
    [PublicAPI]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class PrototypingExtensions
    {
        /// <summary>
        ///     Pass through method for dumping an object to the standard output.
        /// </summary>
        /// <remarks>
        ///     <see langword="null" /> will be passed through, possibly throwing a
        ///     <see cref="NullReferenceException" /> on any subsequent call.
        /// </remarks>
        /// <param name="value">The object to dump to stdout.</param>
        /// <param name="annotation">An optional annotation.</param>
        /// <param name="config">The object to dump to stdout.</param>
        /// <param name="expr">The captured expression of this.</param>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <returns>
        ///     The object itself.
        /// </returns>
        [Pure]
        [return: NotNullIfNotNull("value")]
        public static T? Dump<T>(
            [NoEnumeration] this T? value,
            string? annotation = null,
            DumpConfig config = DumpConfig.None,
            [CallerArgumentExpression("value")] string? expr = null
        )
        {
            bool pretty = config.HasFlag(DumpConfig.Pretty);
            string representation = $"{(value?.ToString() ?? "<null>")}";
            StringBuilder meta = new();

            if (value is { })
            {
                if (config.HasFlag(DumpConfig.Expr))
                {
                    meta.Append(pretty ? "  " : " ")
                        .Append("expr: ")
                        .Append('`')
                        .Append(expr)
                        .Append('`')
                        .Append(pretty ? '\n' : ' ');
                }

                if (config.HasFlag(DumpConfig.Type))
                {
                    meta.Append(pretty ? "  " : " ")
                        .Append("type: ")
                        .Append('`')
                        .Append(value.GetType().Name)
                        .Append('`')
                        .Append(pretty ? '\n' : ' ');
                }

                if (config.HasFlag(DumpConfig.Count)
                    && ((value as ICollection)?.Count ?? (value as Array)?.Length) is { } count)
                {
                    meta.Append(pretty ? "  " : " ")
                        .Append("count: ")
                        .Append('`')
                        .Append(count)
                        .Append('`')
                        .Append(pretty ? '\n' : ' ');
                }
            }

            Console.WriteLine(
                annotation is null
                    ? representation
                    : config.HasFlag(DumpConfig.Pretty)
                        ? $"{annotation}:\n  {representation}\n{meta}"
                        : $"{annotation}: {representation}\n{meta}"
            );

            return value;
        }
    }
}
