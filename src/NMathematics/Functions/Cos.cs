using System;
using System.Collections.Generic;
using System.Text;
using NMathematics.Operations;

namespace NMathematics.Functions
{
    public class Cos : Expression, IEquatable<Cos>
    {

        public Cos(Expression innerExpression) => InnerExpression = innerExpression;

        public Expression InnerExpression { get; }

        public override Expression Derive() => new Constant(-1) * new Sin(InnerExpression) * InnerExpression.Derive();

        public override Constant ToConstant()
        {
            var inner = InnerExpression.ToConstant();
            var a = inner.RealPart;
            var b = inner.ImaginaryPart;

            return new Constant(Math.Cos(a) * Math.Cosh(b), -Math.Sin(a) * Math.Sinh(b));
        }

        public override Expression Substitute(IDictionary<char, double> definitions) => new Cos(InnerExpression.Substitute(definitions));


        //public static Expression operator *(Expression left, Cos right) => right * left;

        public override string ToString() => $"Cos({InnerExpression})";

        public bool Equals(Cos other)
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
            return Equals((Cos) obj);
        }

        public override int GetHashCode()
        {
            return (InnerExpression != null ? InnerExpression.GetHashCode() : 0);
        }

        public static bool operator ==(Cos left, Cos right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Cos left, Cos right)
        {
            return !Equals(left, right);
        }
    }
}
