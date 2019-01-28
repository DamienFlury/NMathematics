using System;
using System.Collections.Generic;
using System.Text;

namespace NMathematics.Operations
{
    public class Addition : Expression, IEquatable<Addition>
    {
        public Addition(Expression left, Expression right)
        {
            Left = left;
            Right = right;
        }

        public Expression Left { get; }
        public Expression Right { get; }

        public override Expression Derive() => new Addition(Left.Derive(), Right.Derive());
        public override Expression Substitute(IDictionary<char, double> definitions) => new Addition(Left.Substitute(definitions), Right.Substitute(definitions));

        public override Constant ToConstant() => Left.ToConstant() + Right.ToConstant();

        public override string ToString() => $"{Left} + {Right}";

        public bool Equals(Addition other)
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
            return Equals((Addition) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Left != null ? Left.GetHashCode() : 0) * 397) ^ (Right != null ? Right.GetHashCode() : 0);
            }
        }

        public static bool operator ==(Addition left, Addition right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Addition left, Addition right)
        {
            return !Equals(left, right);
        }
    }
}
