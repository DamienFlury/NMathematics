using System;
using System.Collections.Generic;

namespace NMathematics
{
    public class Variable : Expression, IEquatable<Variable>
    {
        public Variable(char symbol)
        {
            Symbol = symbol;
        }
        public char Symbol { get; }

        public override string ToString() => Symbol.ToString();

        public override Expression Derive() => new Constant(1);

        public override Expression Substitute(IDictionary<char, double> definitions)
        {
            if (definitions.TryGetValue(Symbol, out var value)) return new Constant(value);

            return this;
        }

        public override Constant ToConstant() => throw new Exception();

        public bool Equals(Variable other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Symbol == other.Symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Variable) obj);
        }

        public override int GetHashCode()
        {
            return Symbol.GetHashCode();
        }

        public static bool operator ==(Variable left, Variable right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Variable left, Variable right)
        {
            return !Equals(left, right);
        }
    }
}
