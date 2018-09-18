using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace NMathematics.Operations
{
    public struct Subtraction : IExpression
    {
        public Subtraction(IExpression left, IExpression right)
        {
            Left = left;
            Right = right;
        }

        public IExpression Left { get; }
        public IExpression Right { get; }
        public IExpression Derive() => Left.Derive().Subtract(Right.Derive());

        public IExpression Substitute(IDictionary<char, double> definitions)
            => Left.Substitute(definitions).Subtract(Right.Substitute(definitions));

        public Constant ToConstant()
            => Left.ToConstant() - Right.ToConstant();

        public override string ToString() => $"{Left} - {Right}";

        public Multiplication Multiply(IExpression other) => new Multiplication(this, other);

        public Division Divide(IExpression other) => new Division(this, other);

        public Subtraction Subtract(IExpression other) => new Subtraction(this, other);

        public Addition Add(IExpression other) => new Addition(this, other);
    }
}
