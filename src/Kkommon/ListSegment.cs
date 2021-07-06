using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Kkommon
{
    /// <summary>
    ///     A type similar to <see cref="ArraySegment{T}"/>, that works for any <see cref="IList{T}"/> implementation.
    /// </summary>
    /// <typeparam name="T">The type of items the underlying <see cref="IList{T}"/> contains.</typeparam>
    public readonly struct ListSegment<T> : IList<T>, IReadOnlyList<T>
    {
        public IList<T> List { get; }
        public int Index { get; }
        public int Count { get; }
        public bool IsReadOnly => List.IsReadOnly;

        public T this[int index] { get => List[Index + index]; set => List[Index + index] = value; }

        public ListSegment(IList<T> list, int index, int count)
        {
            List = list;
            Index = index;
            Count = count;
        }

        public bool Contains(T item) => IndexOf(item) != -1;

        public int IndexOf(T item)
        {
            _throwInvalidOperationIfDefault();

            for (var i = 0; i < Count; i++)
            {
                T? current = this[i];

                if (item?.Equals(current) ?? current is null)
                    return i;
            }

            return -1;
        }

        public ListSegment<T> Slice(int index)
        {
            _throwInvalidOperationIfDefault();

            if (index > Count)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(index),
                    index,
                    "The new index cannot be greater than the current segment's count."
                );
            }

            return new(List, Index + index, Count - index);
        }

        public ListSegment<T> Slice(int index, int count)
        {
            _throwInvalidOperationIfDefault();

            if (index > Count)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(index),
                    index,
                    "The new index cannot be greater than the current segment's count."
                );
            }

            if (count > Count - index)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(count),
                    count,
                    "The new count cannot be greater than the current segment's count."
                );
            }

            return new(List, Index + index, (Count - index) + count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            int end = Index + Count;

            for (int i = Index; i < end; i++)
                yield return List[i];
        }

        void IList<T>.Insert(int index, T item) => throw new NotSupportedException(NOT_SUPPORTED);
        void IList<T>.RemoveAt(int index) => throw new NotSupportedException(NOT_SUPPORTED);

        void ICollection<T>.Add(T item) => throw new NotSupportedException(NOT_SUPPORTED);
        void ICollection<T>.Clear() => throw new NotSupportedException(NOT_SUPPORTED);
        bool ICollection<T>.Remove(T item) => throw new NotSupportedException(NOT_SUPPORTED);

        void ICollection<T>.CopyTo(T[] array, int arrayIndex) => throw new NotSupportedException(NOT_SUPPORTED);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _throwInvalidOperationIfDefault()
        {
            if (List is null)
                throw new InvalidOperationException("This ListSegment<T> does not have a valid IList<T>.");
        }

        private const string NOT_SUPPORTED = "This operation is not supported by ListSegment<T>.";
    }
}