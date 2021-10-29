using System;

using Xunit;

namespace Kkommon.Tests
{
    public sealed partial class RatioTests
    {
        [Fact]
        public void Throws_If_Invalid() => Assert.Throws<ArgumentOutOfRangeException>(() => new Ratio(3, 0));

        [Theory]
        [ClassData(typeof(NegationTheoryData))]
        public void Negation(Ratio ratio, Ratio negated) => Assert.Equal(-ratio, negated, Ratio.Comparer.INSTANCE);

        [Theory]
        [ClassData(typeof(AdditionTheoryData))]
        public void Addition(Ratio addend1, Ratio addend2, Ratio sum)
        {
            Assert.Equal(sum, addend1 + addend2, Ratio.Comparer.INSTANCE);
            Assert.Equal(sum, addend2 + addend1, Ratio.Comparer.INSTANCE);
        }

        [Theory]
        [ClassData(typeof(IntegerAdditionTheoryData))]
        public void Integer_Addition(Ratio addend1, int addend2, Ratio sum)
        {
            Assert.Equal(sum, addend1 + addend2, Ratio.Comparer.INSTANCE);
            Assert.Equal(sum, addend2 + addend1, Ratio.Comparer.INSTANCE);
        }

        [Theory]
        [ClassData(typeof(SubtractionTheoryData))]
        public void Subtraction(Ratio minuend, Ratio subtrahend, Ratio difference, Ratio inverseDifference)
        {
            Assert.Equal(difference, minuend - subtrahend, Ratio.Comparer.INSTANCE);
            Assert.Equal(inverseDifference, subtrahend - minuend, Ratio.Comparer.INSTANCE);
        }

        [Theory]
        [ClassData(typeof(IntegerSubtractionTheoryData))]
        public void Integer_Subtraction(Ratio minuend, int subtrahend, Ratio difference, Ratio inverseDifference)
        {
            Assert.Equal(difference, minuend - subtrahend, Ratio.Comparer.INSTANCE);
            Assert.Equal(inverseDifference, subtrahend - minuend, Ratio.Comparer.INSTANCE);
        }

        [Theory]
        [ClassData(typeof(MultiplicationTheoryData))]
        public void Multiplication(Ratio multiplier, Ratio multiplicand, Ratio result)
        {
            Assert.Equal(result, multiplier * multiplicand, Ratio.Comparer.INSTANCE);
            Assert.Equal(result, multiplicand * multiplier, Ratio.Comparer.INSTANCE);
        }

        [Theory]
        [ClassData(typeof(IntegerMultiplicationTheoryData))]
        public void Integer_Multiplication(Ratio multiplier, int multiplicand, Ratio result)
        {
            Assert.Equal(result, multiplier * multiplicand, Ratio.Comparer.INSTANCE);
            Assert.Equal(result, multiplicand * multiplier, Ratio.Comparer.INSTANCE);
        }

        [Theory]
        [ClassData(typeof(DivisionTheoryData))]
        public void Division(Ratio dividend, Ratio divisor, Ratio result, Ratio inverseResult)
        {
            Assert.Equal(result, dividend / divisor, Ratio.Comparer.INSTANCE);
            Assert.Equal(inverseResult, divisor / dividend, Ratio.Comparer.INSTANCE);
        }

        [Theory]
        [ClassData(typeof(IntegerDivisionTheoryData))]
        public void Integer_Division(Ratio dividend, int divisor, Ratio result, Ratio inverseResult)
        {
            Assert.Equal(result, dividend / divisor, Ratio.Comparer.INSTANCE);
            Assert.Equal(inverseResult, divisor / dividend, Ratio.Comparer.INSTANCE);
        }

        [Theory]
        [ClassData(typeof(SimplificationTheoryData))]
        public void Simplification(Ratio ratio, Ratio result)
            => Assert.Equal(ratio.Reduce(), result, Ratio.Comparer.INSTANCE);

        [Theory]
        [ClassData(typeof(ReciprocalTheoryData))]
        public void Reciprocal(Ratio ratio, Ratio result)
            => Assert.Equal(ratio.Reciprocal(), result, Ratio.Comparer.INSTANCE);

        [Theory]
        [ClassData(typeof(ComponentPreservationTheoryData))]
        public void Component_Preservation(Ratio ratio1, Ratio ratio2)
        {
            Assert.NotEqual(ratio1, ratio2, Ratio.Comparer.INSTANCE);
            Assert.Equal(ratio1.Value, ratio2.Value);
        }

        [Theory]
        [ClassData(typeof(NegationNormalizationTheoryData))]
        public void Negation_Normalization(Ratio ratio, Ratio negatedRatio)
            => Assert.Equal(-ratio, negatedRatio, Ratio.Comparer.INSTANCE);
    }
}