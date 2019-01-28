using System;
using System.Collections.Generic;
using System.Text;

namespace NMathematics.Operations
{
    public class Division : Expression, IEquatable<Division>
    {
        public Division(Expression left, Expression right)
        {
            Left = left;
            Right = right;
        }

        public Expression Left { get; }
        public Expression Right { get; }

        public override Expression Derive() => Left.Derive() * Right - Left * Right.Derive();

        public override Expression Substitute(IDictionary<char, double> definitions)
            => Left.Substitute(definitions) / Right.Substitute(definitions);

        public override Constant ToConstant() => Left.ToConstant() / Right.ToConstant();

        public bool Equals(Division other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Left, other.Left) && Equals(Right, other.Right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Division) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Left != null ? Left.GetHashCode() : 0) * 397) ^ (Right != null ? Right.GetHashCode() : 0);
            }
        }

        public static bool operator ==(Division left, Division right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Division left, Division right)
        {
            return !Equals(left, right);
        }
    }
}
