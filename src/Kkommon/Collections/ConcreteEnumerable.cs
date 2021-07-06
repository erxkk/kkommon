using System.Collections;
using System.Collections.Generic;

namespace Kkommon.Collections
{
    /// <summary>
    ///     A class that only implements <see cref="IEnumerable{T}"/>, used for unit testing collection type checks.
    /// </summary>
    /// <typeparam name="T">The type of elements the underlying <see cref="IEnumerable{T}"/> contains.</typeparam>
    internal sealed class ConcreteEnumerable<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> _enumerable;

        public ConcreteEnumerable(IEnumerable<T> enumerable) => _enumerable = enumerable;

        public IEnumerator<T> GetEnumerator() => _enumerable.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}