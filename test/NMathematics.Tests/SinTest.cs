using System;
using System.Collections.Generic;
using System.Text;
using NMathematics.Functions;
using Xunit;

namespace NMathematics.Tests
{
    public class SinTest
    {
        [Theory]
        [InlineData(2, 0, 0.909297426825681695396019865911744842702254971447890268378)]
        [InlineData(3, 4, 3.85373803791937732161752894046373066706827494698903495676,
            -27.0168132580039344880975437549921522633638656897651847059)]
        [InlineData(0.00874924334173521, 0.85491010167399, 0.012145913997003, 0.962883935002471)]
        [InlineData(0.660058005554629, 0.385297442034491, 0.659241783433311, 0.3119551670684)]
        [InlineData(0.847115426253116, 0.185624624688935, 0.762321019995798, 0.123617948602888)]
        [InlineData(0.129600466289371, 0.00699716434208544, 0.129241133659322, 0.00693853999602824)]
        [InlineData(0.627208291379366, 0.16126704223513, 0.594534840017778, 0.131139643484128)]
        [InlineData(0.490903106746684, 0.856098306763963, 0.654988505918677, 0.850662361918773)]
        [InlineData(0.544720204800703, 0.247053286641395, 0.534073012311793, 0.213453842559054)]
        [InlineData(0.420020727636302, 0.0520677916016745, 0.408332260184603, 0.0475635690212572)]
        [InlineData(0.027902680462181, 0.581351604583371, 0.0327478635254705, 0.614416724400739)]
        [InlineData(0.0982684563371672, 0.0594530119837509, 0.0982838192080121, 0.0592010448317141)]
        public void ToConstantTest(double real, double imag, double expectedReal, double expectedImag = 0)
        {
            var expected = new Constant(expectedReal, expectedImag);

            var actual = new Sin(new Constant(real, imag)).ToConstant();

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void DeriveTest()
        {
            var expected = new Cos(new Constant(1)) * new Constant(0);

            var actual = new Sin(new Constant(1)).Derive();

            Assert.Equal(expected, actual);
        }
    }
}