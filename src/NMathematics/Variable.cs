using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NMathematics.Operations;

namespace NMathematics
{
    public struct Variable : IExpression, IEquatable<Variable>
    {
        public Variable(char symbol)
        {
            Symbol = symbol;
        }
        public char Symbol { get; }

        public override string ToString() => Symbol.ToString();

        public IExpression Derive() => new Constant(1);

        public IExpression Substitute(IDictionary<char, double> definitions)
        {
            if (definitions.TryGetValue(Symbol, out var value)) return new Constant(value);

            return this;
        }

        public Multiplication Multiply(IExpression other) => new Multiplication(this, other);

        public Division Divide(IExpression other) => new Division(this, other);

        public Subtraction Subtract(IExpression other) => new Subtraction(this, other);

        public Addition Add(IExpression other) => new Addition(this, other);

        public Constant ToConstant() => throw new Exception();

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

        public static bool operator ==(Variable left, Variable right) => left.Equals(right);
        public static bool operator !=(Variable left, Variable right) => !(left == right);
    }
}
