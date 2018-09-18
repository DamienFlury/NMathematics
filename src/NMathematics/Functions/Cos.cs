using System;
using System.Collections.Generic;
using System.Text;
using NMathematics.Operations;

namespace NMathematics.Functions
{
    public struct Cos : IExpression, IEquatable<Cos>
    {

        public Cos(IExpression innerExpression) => InnerExpression = innerExpression;

        public IExpression InnerExpression { get; }

<<<<<<< HEAD
        public override Expression Derive() => -new Sin(InnerExpression) * InnerExpression.Derive();
=======
        public IExpression Derive() => new Constant(-1).Multiply(new Sin(InnerExpression)).Multiply(InnerExpression.Derive());
>>>>>>> develop

        public Constant ToConstant()
        {
            var inner = InnerExpression.ToConstant();
            var a = inner.RealPart;
            var b = inner.ImagPart;

            return new Constant(Math.Cos(a) * Math.Cosh(b), -Math.Sin(a) * Math.Sinh(b));
        }

        public IExpression Substitute(IDictionary<char, double> definitions) => new Cos(InnerExpression.Substitute(definitions));


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
            return Equals((Cos)obj);
        }

        public override int GetHashCode()
        {
            return (InnerExpression != null ? InnerExpression.GetHashCode() : 0);
        }

        public Multiplication Multiply(IExpression other) => new Multiplication(this, other);

        public Division Divide(IExpression other) => new Division(this, other);

        public Subtraction Subtract(IExpression other) => new Subtraction(this, other);

        public Addition Add(IExpression other) => new Addition(this, other);
    }
}
