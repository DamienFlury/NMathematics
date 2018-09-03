using System;
using System.Collections.Generic;
using System.Text;
using NMathematics.Operations;

namespace NMathematics
{
    public abstract class Expression
    {
        public abstract Expression Derive();
        public abstract Expression Substitute(IDictionary<char, double> definitions);

        public static Expression operator *(Expression left, Expression right) => new Multiplication(left, right);
        public static Expression operator +(Expression left, Expression right) => new Addition(left, right);

        public static Expression operator -(Expression expression) => new Multiplication(expression, new Constant(-1));
        public static Expression operator -(Expression left, Expression right) => new Subtraction(left, right);
        public static Expression operator /(Expression left, Expression right) => new Division(left, right);
        public abstract Constant ToConstant();
    }
}
