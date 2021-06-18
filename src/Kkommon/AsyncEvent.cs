using System;
using System.Collections.Immutable;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace Kkommon
{
    /// <summary>
    ///     An event that allows asynchronous invocation.
    /// </summary>
    /// <typeparam name="TEventArgs">The type of event args to pass to the handlers.</typeparam>
    [PublicAPI]
    public sealed class AsyncEvent<TEventArgs> where TEventArgs : EventArgs
    {
        private ImmutableArray<Handler> _handlers = ImmutableArray<Handler>.Empty;

        /// <summary>
        ///     Adds a new handler to the invocation list.
        /// </summary>
        /// <param name="handler">The handler to add.</param>
        [CollectionAccess(CollectionAccessType.UpdatedContent)]
        public void Add(Handler handler)
        {
            lock (this)
            {
                _handlers = _handlers.Add(handler);
            }
        }

        /// <summary>
        ///     Removes a handler from the invocation list.
        /// </summary>
        /// <param name="handler">The handler to remove.</param>
        [CollectionAccess(CollectionAccessType.UpdatedContent)]
        public void Remove(Handler handler)
        {
            lock (this)
            {
                _handlers = _handlers.Remove(handler);
            }
        }

        /// <summary>
        ///     Invokes the event asynchronously.
        /// </summary>
        /// <param name="eventArgs">The event args to pass to the handlers.</param>
        [CollectionAccess(CollectionAccessType.Read)]
        public async Task InvokeAsync(TEventArgs eventArgs)
        {
            ImmutableArray<Handler> copy;

            lock (this)
            {
                copy = _handlers;
            }

            foreach (Handler handler in copy)
                await handler.Invoke(eventArgs);
        }

        /// <summary>
        ///     An asynchronous event handler delegate.
        /// </summary>
        public delegate ValueTask Handler(TEventArgs e);
    }

    public class Test
    {
        private readonly AsyncEvent<EventArgs> _event;
        public event AsyncEvent<EventArgs>.Handler Event { add => _event.Add(value); remove => _event.Remove(value); }
    }
}