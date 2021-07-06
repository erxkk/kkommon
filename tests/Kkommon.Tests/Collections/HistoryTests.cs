using Kkommon.Collections;

using Xunit;

namespace Kkommon.Tests.Collections
{
    public sealed class HistoryTests
    {
        [Fact]
        public void Is_Enumerable()
        {
            History<int> history = new() { 1, 2, 3, 4 };

            Assert.Equal(new[] { 1, 2, 3, 4 }, history);
        }

        [Fact]
        public void Traversal_No_State_Change()
        {
            History<int> history = new() { 1, 2, 3, 4 };

            history.GoBack();
            Assert.Equal(3, history.Current);
            Assert.Equal(new[] { 1, 2, 3, 4 }, history);

            history.GoForward();
            Assert.Equal(4, history.Current);
            Assert.Equal(new[] { 1, 2, 3, 4 }, history);
        }

        [Fact]
        public void Goes_Until_End()
        {
            History<int> history = new() { 1 };

            Assert.False(history.TryGoBack());
            Assert.Equal(new[] { 1 }, history);

            Assert.False(history.TryGoForward());
            Assert.Equal(new[] { 1 }, history);
        }

        [Fact]
        public void Overrides_Next()
        {
            History<int> history = new() { 1, 2 };

            history.GoBack();
            history.Add(3);
            Assert.Equal(3, history.Current);
            Assert.Equal(new[] { 1, 3 }, history);
        }

        [Fact]
        public void Counts_Correctly()
        {
            const int n = 2;
            History<int> history = new() { 1, 2 };

            Assert.Equal(n, history.Count);
            history.Add(3);
            Assert.Equal(n + 1, history.Count);
        }
    }
}