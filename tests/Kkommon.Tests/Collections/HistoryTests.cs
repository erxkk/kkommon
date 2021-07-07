using System;

using Kkommon.Collections;

using Xunit;

namespace Kkommon.Tests.Collections
{
    public sealed class HistoryTests
    {
        [Fact]
        public void Traversal_No_Collection_Change()
        {
            History<int> history = new() { 1, 2, 3, 4 };

            history.Move(-1);
            Assert.Equal(new[] { 1, 2, 3, 4 }, history);

            history.Move(1);
            Assert.Equal(new[] { 1, 2, 3, 4 }, history);
        }

        [Fact]
        public void Changes_Current_Index_On_Move()
        {
            History<int> history = new() { 1, 2, 3, 4 };

            history.Move(0);

            Assert.Equal(4, history[0]);

            history.Move(-1);

            Assert.Equal(3, history[0]);

            history.Move(-1);

            Assert.Equal(2, history[0]);

            history.Move(1);

            Assert.Equal(3, history[0]);
        }

        [Fact]
        public void Is_Relative_Indexable()
        {
            History<int> history = new() { 1, 2, 3, 4 };

            history.Move(-2);

            Assert.Equal(1, history[-1]);
            Assert.Equal(2, history[0]);
            Assert.Equal(3, history[1]);
            Assert.Equal(4, history[2]);
        }

        [Fact]
        public void Throws_On_Out_Of_Bounds_Index()
        {
            History<int> history = new() { 1, 2, 3, 4 };

            Assert.Throws<ArgumentOutOfRangeException>(() => history[1]);
            Assert.Throws<ArgumentOutOfRangeException>(() => history[-4]);
        }

        [Fact]
        public void Throws_If_Immovable()
        {
            History<int> history = new() { 1 };

            history.Move(0);

            Assert.Throws<ArgumentOutOfRangeException>(() => history.Move(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => history.Move(1));
        }

        [Fact]
        public void Add_Removes_After_Current()
        {
            History<int> history = new() { 1, 2, 3 };

            history.Move(-2);
            history.Add(4);

            Assert.Equal(4, history[0]);
            Assert.Equal(new[] { 1, 4 }, history);
        }
    }
}