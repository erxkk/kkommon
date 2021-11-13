using System;

namespace Kkommon.Extensions.Prototyping
{
    /// <summary>
    ///     Determines how data should be dumped.
    /// </summary>
    [Flags]
    public enum DumpConfig
    {
        /// <summary>
        ///     Dump with no meta.
        /// </summary>
        None = 0,

        /// <summary>
        ///     Dump pretty.
        /// </summary>
        Pretty = 1 << 0,

        /// <summary>
        ///     Dump the captured expression for identification.
        /// </summary>
        Expr = 1 << 1,

        /// <summary>
        ///     Dump type.
        /// </summary>
        Type = 1 << 2,

        /// <summary>
        ///     Dump the enumerable count if it's an enumerable.
        /// </summary>
        Count = 1 << 4,

        /// <summary>
        ///     Use all modifiers.
        /// </summary>
        All = ~DumpConfig.None,
    }
}
