using System;
using System.Threading.Tasks;

using Kkommon.Exceptions;

using Xunit;

namespace Kkommon.Tests
{
    public sealed class AsyncEventTests
    {
        private bool _eventFired;
        private string? _eventData;

        [Fact]
        public async Task Invokes_Event()
        {
            EventInvoker invoker = new();

            invoker.Event += args =>
            {
                _eventFired = true;
                _eventData = args.Data;
                return default;
            };

            await invoker.InvokeAsync(new() { Data = "Invoked" });
            Assert.True(_eventFired);
            Assert.Equal("Invoked", _eventData);
        }

        [Fact]
        public async Task Invokes_ErrorHandler()
        {
            EventInvoker unhandledInvoker = new();
            EventInvoker handledInvoker = new((_, _) => default);

            unhandledInvoker.Event += _ => throw new UnitTestException();
            handledInvoker.Event += _ => throw new UnitTestException();

            await Assert.ThrowsAsync<UnitTestException>(() => unhandledInvoker.InvokeAsync(new()));
            await handledInvoker.InvokeAsync(new());
        }

        private sealed class EventInvoker
        {
            private readonly AsyncEvent<TestEventArgs> _event;

            public event AsyncEvent<TestEventArgs>.Handler Event
            {
                add => _event.Add(value);
                remove => _event.Remove(value);
            }

            public EventInvoker() => _event = new();

            public EventInvoker(AsyncEvent<TestEventArgs>.ErrorHandler handler) => _event = new(handler);

            public Task InvokeAsync(TestEventArgs eventArgs) => _event.InvokeAsync(eventArgs);

            public sealed class TestEventArgs : EventArgs
            {
                public string? Data { get; init; }
            }
        }
    }
}