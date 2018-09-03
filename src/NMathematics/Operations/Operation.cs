using System;
using System.Collections.Generic;
using System.Text;

namespace NMathematics.Operations
{
    public abstract class Operation : Expression, IEquatable<Operation>
    {
        protected Operation(Expression left, Expression right)
        {
            Left = left;
            Right = right;
        }
        public Expression Left { get; }
        public Expression Right { get; }

        public bool Equals(Operation other)
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
            return Equals((Operation) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Left != null ? Left.GetHashCode() : 0) * 397) ^ (Right != null ? Right.GetHashCode() : 0);
            }
        }
    }
}
