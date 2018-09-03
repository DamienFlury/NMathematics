using System;
using System.Collections.Generic;
using System.Text;

namespace NMathematics.Operations
{
    public class Division : Operation
    {
        public Division(Expression left, Expression right) : base(left, right)
        {
        }

        public override Expression Derive() => Left.Derive() * Right - Left * Right.Derive();

        public override Expression Substitute(IDictionary<char, double> definitions)
            => Left.Substitute(definitions) / Right.Substitute(definitions);

        public override Constant ToConstant() => Left.ToConstant() / Right.ToConstant();
    }
}
