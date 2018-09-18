using System;
using System.Collections.Generic;
using System.Text;

namespace NMathematics.Operations
{
    public struct Addition : IExpression
    {
        public Addition(IExpression left, IExpression right)
        {
            Left = left;
            Right = right;
        }

        public IExpression Left { get; }
        public IExpression Right { get; }

        public IExpression Derive() => new Addition(Left.Derive(), Right.Derive());
        public IExpression Substitute(IDictionary<char, double> definitions) => new Addition(Left.Substitute(definitions), Right.Substitute(definitions));
        public Multiplication Multiply(IExpression other) => new Multiplication(this, other);

        public Division Divide(IExpression other) => new Division(this, other);

        public Subtraction Subtract(IExpression other) => new Subtraction(this, other);

        public Addition Add(IExpression other) => new Addition(this, other);

        public Constant ToConstant() => Left.ToConstant() + Right.ToConstant();

        public override string ToString() => $"{Left} + {Right}";
    }
}
