using System;
using System.Collections.Generic;
using System.Text;
using NMathematics.Functions;
using Xunit;

namespace NMathematics.Tests
{
    public class SinTest
    {
        [Fact]
        public void DeriveTest()
        {
            var expected = new Cos(new Constant(1)) * new Constant(0);

            var actual = new Sin(new Constant(1)).Derive();

            Assert.Equal(expected, actual);
        }
    }
}