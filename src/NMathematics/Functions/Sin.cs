using System;
using System.Collections.Generic;
using System.Text;
using NMathematics.Operations;

namespace NMathematics.Functions
{
    public class Sin : Expression, IEquatable<Sin>
    {
        public Sin(Expression innerExpression) => InnerExpression = innerExpression;

        public Expression InnerExpression { get; }
        public override Expression Derive() => new Cos(InnerExpression) * InnerExpression.Derive();

        public override Constant ToConstant()
        {
            var inner = InnerExpression.ToConstant();
            var a = inner.RealPart;
            var b = inner.ImagPart;

            return new Constant(Math.Sin(a) * Math.Cosh(b), Math.Cos(a) * Math.Sinh(b));
        }

        public override Expression Substitute(IDictionary<char, double> definitions) => new Sin(InnerExpression.Substitute(definitions));


        public static Multiplication operator *(Sin left, Expression right) => new Multiplication(left, right);
        public static Addition operator +(Sin first, Expression second) => new Addition(first, second);

        //public static Expression operator *(Expression left, Sin right) => right * left;

        public override string ToString() => $"Sin({InnerExpression})";

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
