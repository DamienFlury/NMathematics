using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NMathematics.Operations;

namespace NMathematics
{
    public class Variable : Expression
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
    }
}
