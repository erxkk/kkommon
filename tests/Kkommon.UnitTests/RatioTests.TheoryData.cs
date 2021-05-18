using System.Collections;
using System.Collections.Generic;

namespace Kkommon.UnitTests
{
    public sealed partial class RatioTests
    {
        public class NegationTheoryData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new Ratio(3, 4), new Ratio(-3, 4) };
                yield return new object[] { new Ratio(3, 4), new Ratio(3, -4) };
                yield return new object[] { new Ratio(-3, 4), new Ratio(-3, -4) };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class AdditionTheoryData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new Ratio(3, 4), new Ratio(1, 1), new Ratio(7, 4) };
                yield return new object[] { new Ratio(3, 4), new Ratio(-1, 1), new Ratio(-1, 4) };
                yield return new object[] { new Ratio(3, 4), new Ratio(0, 4), new Ratio(12, 16) };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class IntegerAdditionTheoryData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new Ratio(3, 4), 1, new Ratio(7, 4) };
                yield return new object[] { new Ratio(3, 4), -1, new Ratio(-1, 4) };
                yield return new object[] { new Ratio(3, 4), 0, new Ratio(3, 4) };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class SubtractionTheoryData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new Ratio(3, 4), new Ratio(1, 1), new Ratio(-1, 4), new Ratio(1, 4) };
                yield return new object[] { new Ratio(3, 4), new Ratio(-1, 1), new Ratio(7, 4), new Ratio(-7, 4) };
                yield return new object[] { new Ratio(3, 4), new Ratio(0, 4), new Ratio(12, 16), new Ratio(-12, 16) };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class IntegerSubtractionTheoryData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new Ratio(3, 4), 1, new Ratio(-1, 4), new Ratio(1, 4) };
                yield return new object[] { new Ratio(3, 4), -1, new Ratio(7, 4), new Ratio(-7, 4) };
                yield return new object[] { new Ratio(3, 4), 0, new Ratio(3, 4), new Ratio(-3, 4) };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class MultiplicationTheoryData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new Ratio(3, 4), new Ratio(4, 3), new Ratio(12, 12) };
                yield return new object[] { new Ratio(3, 4), new Ratio(-3, 4), new Ratio(-9, 16) };
                yield return new object[] { new Ratio(3, 4), new Ratio(0, 4), new Ratio(0, 16) };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class IntegerMultiplicationTheoryData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new Ratio(3, 4), 3, new Ratio(9, 4) };
                yield return new object[] { new Ratio(3, 4), -3, new Ratio(-9, 4) };
                yield return new object[] { new Ratio(3, 4), 0, new Ratio(0, 4) };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class DivisionTheoryData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new Ratio(3, 4), new Ratio(4, 3), new Ratio(9, 16), new Ratio(16, 9) };
                yield return new object[] { new Ratio(3, 4), new Ratio(-4, 3), new Ratio(-9, 16), new Ratio(-16, 9) };
                yield return new object[] { new Ratio(3, 4), new Ratio(1, 4), new Ratio(12, 4), new Ratio(4, 12) };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class IntegerDivisionTheoryData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new Ratio(3, 4), 3, new Ratio(3, 12), new Ratio(12, 3) };
                yield return new object[] { new Ratio(3, 4), -3, new Ratio(-3, 12), new Ratio(-12, 3) };
                yield return new object[] { new Ratio(3, 4), 4, new Ratio(3, 16), new Ratio(16, 3) };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class SimplificationTheoryData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new Ratio(6, 8), new Ratio(3, 4) };
                yield return new object[] { new Ratio(1, 2), new Ratio(1, 2) };
                yield return new object[] { new Ratio(5, 7), new Ratio(5, 7) };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class ReciprocalTheoryData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new Ratio(3, 4), new Ratio(4, 3) };
                yield return new object[] { new Ratio(-2, 5), new Ratio(-5, 2) };
                yield return new object[] { new Ratio(6, -3), new Ratio(-3, 6) };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class ComponentPreservationTheoryData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new Ratio(3, 4), new Ratio(6, 8) };
                yield return new object[] { new Ratio(2, -4), new Ratio(-1, 2) };
                yield return new object[] { new Ratio(-6, -3), new Ratio(2, 1) };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class NegationNormalizationTheoryData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new Ratio(3, 4), new Ratio(-3, 4) };
                yield return new object[] { new Ratio(1, -2), new Ratio(1, 2) };
                yield return new object[] { new Ratio(-6, -3), new Ratio(6, -3) };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}