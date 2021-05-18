using System;

using Xunit;
using Xunit.Abstractions;

namespace Kkommon.UnitTests
{
    public class TryTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public TryTests(ITestOutputHelper testOutputHelper) => _testOutputHelper = testOutputHelper;

        [Fact]
        public void Logs()
        {
            static void action() { }
            static void actionThrows() => throw new Exception();

            Assert.Equal(
                1,
                Try.Do(action).Log(res => _testOutputHelper.WriteLine(res.ToString())).Match(_ => 1, _ => 2)
            );

            Assert.Equal(
                2,
                Try.Do(actionThrows).Log(res => _testOutputHelper.WriteLine(res.ToString())).Match(_ => 1, _ => 2)
            );
        }

        [Fact]
        public void Match()
        {
            static void action() { }
            static void actionThrows() => throw new Exception();

            Assert.Equal(1, Try.Do(action).Match(_ => 1, _ => 2));
            Assert.Equal(2, Try.Do(actionThrows).Match(_ => 1, _ => 2));
        }

        [Fact]
        public void Expect()
        {
            static void action() { }

            Try.Do(action).ExpectSuccess("This message will not be thrown.");
        }

        [Fact]
        public void Expect_Exception()
        {
            static void actionThrows() => throw new Exception();

            Try.Do(actionThrows).ExpectError("This message will not be thrown.");
        }

        [Fact]
        public void Generic_Logs()
        {
            static void action() { }
            static void actionThrows() => throw new Exception();

            Assert.Equal(
                1,
                Try.Do(action).Log(res => _testOutputHelper.WriteLine(res.ToString())).Match(_ => 1, _ => 2)
            );

            Assert.Equal(
                2,
                Try.Do(actionThrows).Log(res => _testOutputHelper.WriteLine(res.ToString())).Match(_ => 1, _ => 2)
            );
        }

        [Fact]
        public void Generic_Match()
        {
            static int function() => -1;
            static int functionThrows() => throw new Exception();

            Assert.Equal(1, Try<int>.Return(function).Match(_ => 1, _ => 2));
            Assert.Equal(2, Try<int>.Return(functionThrows).Match(_ => 1, _ => 2));
        }

        [Fact]
        public void Generic_Expect()
        {
            static int function() => -1;

            Try<int>.Return(function).ExpectSuccess("This message will not be thrown.");
            Assert.Throws<UnwrapException>(() => Try<int>.Return(function).ExpectError("This message will be thrown."));
        }

        [Fact]
        public void Generic_Expect_Exception()
        {
            static int functionThrows() => throw new Exception();

            Assert.Throws<UnwrapException>(
                () => Try<int>.Return(functionThrows).ExpectSuccess("This message will be thrown.")
            );

            Try<int>.Return(functionThrows).ExpectError("This message will not be thrown.");
        }

        [Fact]
        public void Unwrap()
        {
            static int function() => -1;
            static int functionThrows() => throw new Exception();

            Assert.Equal(-1, Try<int>.Return(function).Unwrap());
            Assert.Throws<UnwrapException>(() => Try<int>.Return(functionThrows).Unwrap());
        }
    }
}