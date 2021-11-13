using System;
using System.Collections;
using System.Collections.Generic;

using JetBrains.Annotations;

namespace Kkommon.Collections
{
    /// <summary>
    ///     A class that represents a traversable history of items.
    /// </summary>
    /// <typeparam name="T">The type of items this history contains.</typeparam>
    [PublicAPI]
    public sealed class History<T> : IList<T>, IReadOnlyList<T>
    {
        private int _current = -1;
        private readonly List<T> _history = new();

        /// <summary>
        ///     Gets or sets the item at the given relative index.
        /// </summary>
        public T this[int index]
        {
            [CollectionAccess(CollectionAccessType.Read)]
            get => _history[_current + index];

            [CollectionAccess(CollectionAccessType.ModifyExistingContent)]
            set => _history[_current + index] = value;
        }

        /// <summary>
        ///     Gets the total number of items in this history.
        /// </summary>
        [CollectionAccess(CollectionAccessType.Read)]
        public int Count => _history.Count;

        /// <summary>
        ///     Gets the total number of items in this history before the current.
        /// </summary>
        [CollectionAccess(CollectionAccessType.Read)]
        public int CountPrevious => _current != -1 ? _current - 1 : 0;

        /// <summary>
        ///     Gets the number of items in this history after the current.
        /// </summary>
        [CollectionAccess(CollectionAccessType.Read)]
        public int CountNext => _current != -1 ? _history.Count - _current : 0;

        /// <summary>
        ///     Move to the given relative index in the history.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The index was outside of the bounds of this history.
        /// </exception>
        [CollectionAccess(CollectionAccessType.Read)]
        public void Move(int index)
        {
            Preconditions.InRange(_current + index, 0, _history.Count);

            _current += index;
        }

#region IList<T>

        /// <summary>
        ///     Returns the index of the first occurrence of a given value in a range of this history.
        /// </summary>
        /// <remarks>
        ///     Due to the nature of negative indexing for <see cref="History{T}"/> this will return
        ///     <see cref="int.MinValue"/> to indicate that the element was not found. <see cref="int.MinValue"/>
        ///     should realistically never be a valid index.
        /// </remarks>
        /// <param name="item">The item to get the relative index for.</param>
        /// <returns>
        ///     The index of the item if it was found; otherwise <see cref="int.MinValue"/>.
        /// </returns>
        [CollectionAccess(CollectionAccessType.Read)]
        public int IndexOf(T item)
        {
            int index = _history.IndexOf(item);

            return index != -1 ? index - _current : int.MinValue;
        }

        /// <summary>
        ///     Inserts a new item at the relative index.
        /// </summary>
        /// <param name="index">The relative index at which to insert the new item.</param>
        /// <param name="item">The item to insert.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The index was not within the bounds of this history.
        /// </exception>
        [CollectionAccess(CollectionAccessType.UpdatedContent | CollectionAccessType.ModifyExistingContent)]
        public void Insert(int index, T item) => _history.Insert(_current + index, item);

        /// <summary>
        ///     Removes an item at the relative index.
        /// </summary>
        /// <param name="index">The relative index at which to remove an item.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The index was not within the bounds of this history.
        /// </exception>
        [CollectionAccess(CollectionAccessType.ModifyExistingContent)]
        public void RemoveAt(int index)
        {
            _history.RemoveAt(_current + index);

            if (index <= 0)
                _current--;
        }

#endregion

#region ICollection<T>

        /// <summary>
        ///     Adds the given item to this history, making it the new current item and removing all items after the
        ///     previous current.
        /// </summary>
        /// <param name="item">The new current item.</param>
        [CollectionAccess(CollectionAccessType.UpdatedContent | CollectionAccessType.ModifyExistingContent)]
        public void Add(T item)
        {
            if (_current != -1 && _current + 1 < _history.Count)
                _history.RemoveRange(_current + 1, _history.Count - _current - 1);

            _history.Add(item);
            _current++;
        }

        /// <summary>
        ///     Removes all items form this history, including the current.
        /// </summary>
        [CollectionAccess(CollectionAccessType.ModifyExistingContent)]
        public void Clear()
        {
            _history.Clear();
            _current = -1;
        }

        /// <summary>
        ///     Removes the given item from this history..
        /// </summary>
        /// <param name="item">The new current item.</param>
        /// <returns>
        ///     <see langword="true"/> if the item was removed; otherwise <see langword="false"/>.
        /// </returns>
        [CollectionAccess(CollectionAccessType.UpdatedContent)]
        public bool Remove(T item)
        {
            int index = _history.IndexOf(item);

            if (index == -1)
                return false;

            _history.RemoveAt(index);

            if (index <= _current)
                _current--;

            return true;
        }

        /// <summary>
        ///     Checks whether or not this history contains the given item.
        /// </summary>
        [CollectionAccess(CollectionAccessType.Read)]
        public bool Contains(T item) => _history.Contains(item);

        /// <inheritdoc />
        [CollectionAccess(CollectionAccessType.Read)]
        public void CopyTo(T[] array, int arrayIndex) => _history.CopyTo(array, arrayIndex);

        bool ICollection<T>.IsReadOnly => false;

#endregion

#region IEnumerable<T>

        /// <inheritdoc />
        [CollectionAccess(CollectionAccessType.Read)]
        public IEnumerator<T> GetEnumerator() => _history.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

#endregion
    }
}
