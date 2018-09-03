using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NMathematics.Tests
{
    public class MultiplicationTest
    {
        [Theory]
        [InlineData(4, 0, 2, 0, 8, 0)]
        [InlineData(5, 2, 2, 3, 4, 19)]
        [InlineData(-3, -2, -4, 5, 22, -7)]
        public void ConstantTest(double firstReal, double firstImag, double secondReal, double secondImag,
            double expectedReal, double expectedImag)
        {
            var first = new Constant(firstReal, firstImag);
            var second = new Constant(secondReal, secondImag);

            var expected = new Constant(expectedReal, expectedImag);
            var actual = first * second;

            Assert.Equal(expected, actual);

        }
    }
}
