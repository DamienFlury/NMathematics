using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using NMathematics.Operations;

namespace NMathematics
{
    public class Constant : Expression, IEquatable<Constant>
    {
        public Constant(double realPart, double imagPart = 0)
        {
            RealPart = realPart;
            ImagPart = imagPart;
        }

        public double RealPart { get; }
        public double ImagPart { get; }
        public static Constant operator *(Constant first, Constant second) => 
            new Constant(first.RealPart * second.RealPart - first.ImagPart * second.ImagPart, first.RealPart * second.ImagPart + first.ImagPart * second.RealPart);
        public static Constant operator +(Constant first, Constant second) => new Constant(first.RealPart + second.RealPart, first.ImagPart + second.ImagPart);
        public static Constant operator -(Constant first, Constant second) => new Constant(first.RealPart - second.RealPart, first.ImagPart - second.ImagPart);

        public static Constant operator /(Constant first, Constant second)
        {
            var denominator = first * second.Conjugate();
            var divisor = second.RealPart * second.RealPart + second.ImagPart * second.ImagPart;

            return new Constant(denominator.RealPart / divisor, denominator.ImagPart / divisor);
        }


        //
        // (a + bi) / (c + di) = ((a + bi) * (c - di)) / (c^2 + d^2)
        //

        public override Expression Derive() => new Constant(0);
        public override Constant ToConstant() => this;
        public override Expression Substitute(IDictionary<char, double> definitions) => this;

        public Constant Conjugate() => new Constant(RealPart, -ImagPart);

        public override string ToString()
        {
            if (ImagPart == 0) return RealPart.ToString(CultureInfo.InvariantCulture);
            if (RealPart == 0) return $"{ImagPart}i";
            return $"({RealPart} + {ImagPart}i)";
        }

        public bool Equals(Constant other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            const double tolerance = 0.000000000000001;
            return Math.Abs(RealPart - other.RealPart) < tolerance && Math.Abs(ImagPart - other.ImagPart) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Constant) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (RealPart.GetHashCode() * 397) ^ ImagPart.GetHashCode();
            }
        }
    }
}
