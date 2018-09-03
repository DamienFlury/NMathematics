using System;
using System.Collections.Generic;
using System.Text;

namespace NMathematics.Operations
{
    public class Multiplication : Operation
    {
        public override Expression Derive() => new Addition(new Multiplication(Left.Derive(), Right), new Multiplication(Left, Right.Derive()));
        public override Constant ToConstant() => Left.ToConstant() * Right.ToConstant();
        public override Expression Substitute(IDictionary<char, double> definitions) => new Multiplication(Left.Substitute(definitions), Right.Substitute(definitions));


        public override string ToString() => $"{Left} * {Right}";

        public Multiplication(Expression left, Expression right) : base(left, right)
        {
        }
    }
}

