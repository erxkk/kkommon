using Xunit;

namespace Kkommon.Tests
{
    public sealed class HistoryTests
    {
        [Fact]
        public void Is_Enumerable()
        {
            History<string> history = new() { "1", "2", "3", "4" };

            Assert.Equal(new[] { "1", "2", "3", "4" }, history);
        }

        [Fact]
        public void Traversal_No_State_Change()
        {
            History<string> history = new() { "1", "2", "3", "4" };

            history.GoBack();
            Assert.Equal("3", history.Current);
            Assert.Equal(new[] { "1", "2", "3", "4" }, history);

            history.GoForward();
            Assert.Equal("4", history.Current);
            Assert.Equal(new[] { "1", "2", "3", "4" }, history);
        }

        [Fact]
        public void Goes_Until_End()
        {
            History<string> history = new() { "1" };

            Assert.False(history.TryGoBack());
            Assert.Equal(new[] { "1" }, history);

            Assert.False(history.TryGoForward());
            Assert.Equal(new[] { "1" }, history);
        }

        [Fact]
        public void Overrides_Next()
        {
            History<string> history = new() { "1", "2" };

            history.GoBack();
            history.Add("3");
            Assert.Equal("3", history.Current);
            Assert.Equal(new[] { "1", "3" }, history);
        }
    }
}