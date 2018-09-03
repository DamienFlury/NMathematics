using System;
using System.Collections.Generic;
using System.Text;

namespace NMathematics.Operations
{
    public class Addition : Operation
    {
        public Addition(Expression left, Expression right) : base(left, right)
        {
        }

        public override Expression Derive() => new Addition(Left.Derive(), Right.Derive());
        public override Expression Substitute(IDictionary<char, double> definitions) => new Addition(Left.Substitute(definitions), Right.Substitute(definitions));
        public override Constant ToConstant() => Left.ToConstant() + Right.ToConstant();

        public override string ToString() => $"{Left} + {Right}";
    }
}
