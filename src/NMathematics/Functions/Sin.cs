using System;
using System.Collections.Generic;
using System.Text;
using NMathematics.Operations;

namespace NMathematics.Functions
{
    public struct Sin : IExpression, IEquatable<Sin>
    {
        public Sin(IExpression innerExpression) => InnerExpression = innerExpression;

        public IExpression InnerExpression { get; }
        public IExpression Derive() => new Cos(InnerExpression) .Multiply(InnerExpression.Derive());

        public Constant ToConstant()
        {
            var inner = InnerExpression.ToConstant();
            var a = inner.RealPart;
            var b = inner.ImagPart;

            return new Constant(Math.Sin(a) * Math.Cosh(b), Math.Cos(a) * Math.Sinh(b));
        }

        public IExpression Substitute(IDictionary<char, double> definitions) => new Sin(InnerExpression.Substitute(definitions));


        //public static Expression operator *(Expression left, Sin right) => right * left;

        public override string ToString() => $"Sin({InnerExpression})";

        public Multiplication Multiply(IExpression other) => new Multiplication(this, other);

        public Division Divide(IExpression other) => new Division(this, other);

        public Subtraction Subtract(IExpression other) => new Subtraction(this, other);

        public Addition Add(IExpression other) => new Addition(this, other);

        public bool Equals(Sin other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(InnerExpression, other.InnerExpression);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Sin) obj);
        }

        public override int GetHashCode()
        {
            return (InnerExpression != null ? InnerExpression.GetHashCode() : 0);
        }
    }
}
