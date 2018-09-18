using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NMathematics.Tests
{
    public class DivisionTest
    {
        [Fact]
        public void ToConstantTest()
        {
            var const1 = new Constant(8, 16);
            var const2 = new Constant(4, 3);

            var expected = new Constant(16/5.0, 8/5.0);
            var actual = const1 / const2;
            Assert.Equal(expected, actual);
        }
    }
}
