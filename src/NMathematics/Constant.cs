using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using NMathematics.Operations;

namespace NMathematics
{
    public class Constant : Expression, IEquatable<Constant>
    {
        public Constant(double realPart, double imaginaryPart = 0)
        {
            RealPart = realPart;
            ImaginaryPart = imaginaryPart;
        }

        public double RealPart { get; }
        public double ImaginaryPart { get; }
        public static Constant operator *(Constant first, Constant second) => 
            new Constant(first.RealPart * second.RealPart - first.ImaginaryPart * second.ImaginaryPart, first.RealPart * second.ImaginaryPart + first.ImaginaryPart * second.RealPart);
        public static Constant operator +(Constant first, Constant second) => new Constant(first.RealPart + second.RealPart, first.ImaginaryPart + second.ImaginaryPart);
        public static Constant operator -(Constant first, Constant second) => new Constant(first.RealPart - second.RealPart, first.ImaginaryPart - second.ImaginaryPart);

        public static Constant operator /(Constant first, Constant second)
        {
            var denominator = first * second.Conjugate();
            var divisor = second.RealPart * second.RealPart + second.ImaginaryPart * second.ImaginaryPart;

            return new Constant(denominator.RealPart / divisor, denominator.ImaginaryPart / divisor);
        }


        //
        // (a + bi) / (c + di) = ((a + bi) * (c - di)) / (c^2 + d^2)
        //

        public override Expression Derive() => new Constant(0);
        public override Constant ToConstant() => this;
        public override Expression Substitute(IDictionary<char, double> definitions) => this;

        public Constant Conjugate() => new Constant(RealPart, -ImaginaryPart);

        public bool Equals(Constant other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return RealPart.Equals(other.RealPart) && ImaginaryPart.Equals(other.ImaginaryPart);
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
                return (RealPart.GetHashCode() * 397) ^ ImaginaryPart.GetHashCode();
            }
        }

        public static bool operator ==(Constant left, Constant right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Constant left, Constant right)
        {
            return !Equals(left, right);
        }
    }
}
