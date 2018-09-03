using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace NMathematics.Operations
{
    public class Subtraction : Operation
    {
        public override Expression Derive() => Left.Derive() - Right.Derive();

        public override Expression Substitute(IDictionary<char, double> definitions)
            => Left.Substitute(definitions) - Right.Substitute(definitions);

        public override Constant ToConstant()
            => Left.ToConstant() - Right.ToConstant();

        public override string ToString() => $"{Left} - {Right}";

        public Subtraction(Expression left, Expression right) : base(left, right)
        {
        }
    }
}
