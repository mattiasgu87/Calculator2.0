using System;
using Xunit;
using Calculator2;

namespace Calculator2Testing
{
    public class CalculatorShould
    {
        [Theory]
        [InlineData(4, 6, 10)]
        [InlineData(15, -15, 0)]
        [InlineData(-15, -15, -30)]
        [InlineData(10.3, 10.7, 21)]
        [InlineData(Double.MaxValue, Double.MaxValue, Double.PositiveInfinity)]
        public void DoAddition(double x, double y, double expected)
        {
            double sut = Calculator.UseAddition(x, y);

            Assert.Equal(expected, sut);
        }

        [Fact]
        public void DoArrayAddition()
        {
            double[] testArray = { 1, 2, 3, 4, 5 };
            double expectedSum = 1 + 2 + 3 + 4 + 5;

            double result = Calculator.UseAdditionOnArray(testArray);

            Assert.Equal(expectedSum, result, 0);
        }

        [Theory]
        [InlineData(10, 5, 5)]
        [InlineData(-10, -5, -5)]
        [InlineData(10.7, 10.3, 0.4)] //rounded 
        [InlineData(Double.MaxValue, Double.MaxValue, 0)]
        [InlineData(10, 0, 10)]
        public void DoSubtraction(double x, double y, double expected)
        {
            double sut = Calculator.UseSubtraction(x, y);

            Assert.Equal(expected, sut, 4);
        }

        [Fact]
        public void DoArraySubtraction()
        {
            double[] testArray = { 1, 2, 3, 4, 5 };
            double expectedSum = 1 - 2 - 3 - 4 - 5;

            double result = Calculator.UseSubtractionOnArray(testArray);

            Assert.Equal(expectedSum, result, 0);
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(0, 10, 0)]
        [InlineData(10, -10, -100)]
        [InlineData(-10, -10, 100)]
        [InlineData(10.5, 10.3, 108.15)]
        [InlineData(Double.MaxValue, Double.MaxValue, Double.PositiveInfinity)]
        public void DoMultiplication(double x, double y, double expected)
        {
            double sut = Calculator.UseMultiplication(x, y);

            Assert.Equal(expected, sut);
        }

        [Theory]
        [InlineData(10, 1, true, 10)]
        [InlineData(10, -10, true, -1)]
        [InlineData(-1000, -100, true, 10)]
        [InlineData(10.333, 1.111, true, 9.3006)]
        [InlineData(0, 10, true, 0)]
        [InlineData(10, 0, false, double.NaN)] //divide by zero
        public void DoDivision(double x, double y, bool divisable, double expected)
        {
            double sutExpected;
            bool sutIsDivisable = Calculator.UseDivision(x, y, out sutExpected);

            Assert.Equal(sutIsDivisable, divisable);
            Assert.Equal(sutExpected, expected, 4);
        }
    }
}
