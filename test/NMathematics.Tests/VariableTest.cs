using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NMathematics.Tests
{
    public class VariableTest
    {
        [Fact]
        public void EqualityTest()
        {
            var left = new Variable('x');
            var right = new Variable('x');
            Assert.Equal(left, right);
        }

        [Fact]
        public void EqualityTestUsingOperator()
        {
            var left = new Variable('x');
            var right = new Variable('x');
            Assert.True(left == right);
        }

        [Fact]
        public void InequalityTest()
        {
            var left = new Variable('x');
            var right = new Variable('y');
            Assert.NotEqual(left, right);
        }

        [Fact]
        public void InequalityTestUsingOperator()
        {
            var left = new Variable('x');
            var right = new Variable('y');
            Assert.True(left != right);
        }
    }
}
