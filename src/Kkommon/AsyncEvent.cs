using System;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace Kkommon
{
    /// <summary>
    ///     An event that allows asynchronous invocation.
    /// </summary>
    /// <remarks>
    ///     If an exception occurs during an event handler invocation the asyncEventErrorHandler is called if one exists
    ///     and the event handler execution is continued after it's execution, if non was passed the exception is
    ///     bubbled up.
    ///     Internal access to IsConcurrent on event execution is synchronized via <see langword="lock"/>.
    /// </remarks>
    /// <typeparam name="TEventArgs">The type of event args to pass to the handlers.</typeparam>
    [PublicAPI]
    public sealed class AsyncEvent<TEventArgs> where TEventArgs : EventArgs
    {
        private readonly ErrorHandler? _asyncEventErrorHandler;
        private ImmutableArray<Handler> _handlers = ImmutableArray<Handler>.Empty;

        /// <summary>
        ///     Whether or not this EventHandler executes Events in parallel.
        /// </summary>
        public bool IsConcurrent { get; private set; }

        /// <summary>
        ///     Creates a new async event with no concurrency and no specified error handler.
        /// </summary>
        public AsyncEvent() : this(false) { }

        /// <summary>
        ///     Creates a new async event with the specified error handler.
        /// </summary>
        /// <param name="asyncEventErrorHandler">The handler to invoke on handler exceptions.</param>
        public AsyncEvent(ErrorHandler? asyncEventErrorHandler = null) : this(false, asyncEventErrorHandler) { }

        /// <summary>
        ///     Creates a new async event with the specified concurrency and the specified error handler.
        /// </summary>
        /// <param name="concurrent">Whether or not the events should be processed in parallel.</param>
        /// <param name="asyncEventErrorHandler">The handler to invoke on handler exceptions.</param>
        public AsyncEvent(bool concurrent = false, ErrorHandler? asyncEventErrorHandler = null)
        {
            IsConcurrent = concurrent;
            _asyncEventErrorHandler = asyncEventErrorHandler;
        }

        /// <summary>
        ///     Adds a new handler to the invocation list.
        /// </summary>
        /// <param name="asyncEventHandler">The handler to add.</param>
        [CollectionAccess(CollectionAccessType.UpdatedContent)]
        public void Add(Handler asyncEventHandler)
        {
            lock (this)
            {
                _handlers = _handlers.Add(asyncEventHandler);
            }
        }

        /// <summary>
        ///     Removes a handler from the invocation list.
        /// </summary>
        /// <param name="asyncEventHandler">The handler to remove.</param>
        [CollectionAccess(CollectionAccessType.UpdatedContent)]
        public void Remove(Handler asyncEventHandler)
        {
            lock (this)
            {
                _handlers = _handlers.Remove(asyncEventHandler);
            }
        }

        /// <summary>
        ///     Sets whether or not this event handler should execute events concurrently.
        /// </summary>
        /// <param name="value">The new value.</param>
        [CollectionAccess(CollectionAccessType.None)]
        public void SetConcurrency(bool value)
        {
            lock (this)
            {
                IsConcurrent = value;
            }
        }

        /// <summary>
        ///     Invokes the event asynchronously.
        /// </summary>
        /// <param name="args">The event args to pass to the handlers.</param>
        [CollectionAccess(CollectionAccessType.Read)]
        public async Task InvokeAsync(TEventArgs args)
        {
            ImmutableArray<Handler> copy;
            bool parallel;

            lock (this)
            {
                copy = _handlers;
                parallel = IsConcurrent;
            }

            if (parallel)
            {
                await Task.WhenAll(
                    copy.Select(
                        handler => Task.Run(
                            async () =>
                            {
                                try
                                {
                                    await handler.Invoke(args);
                                }
                                catch (Exception ex)
                                {
                                    if (_asyncEventErrorHandler is null)
                                        throw;

                                    await _asyncEventErrorHandler(args, ex);
                                }
                            }
                        )
                    )
                );
            }
            else
            {
                foreach (Handler handler in copy)
                {
                    try
                    {
                        await handler.Invoke(args);
                    }
                    catch (Exception ex)
                    {
                        if (_asyncEventErrorHandler is null)
                            throw;

                        await _asyncEventErrorHandler(args, ex);
                    }
                }
            }
        }

        /// <summary>
        ///     An asynchronous event handler delegate.
        /// </summary>
        public delegate ValueTask Handler(TEventArgs args);

        /// <summary>
        ///     An asynchronous event error handler delegate.
        /// </summary>
        public delegate ValueTask ErrorHandler(TEventArgs args, Exception exception);
    }
}
