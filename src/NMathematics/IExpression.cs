using System;
using System.Collections.Generic;
using System.Text;
using NMathematics.Operations;

namespace NMathematics
{
    public interface IExpression
    {
        IExpression Derive();
        IExpression Substitute(IDictionary<char, double> definitions);
        Multiplication Multiply(IExpression other);
        Division Divide(IExpression other);
        Subtraction Subtract(IExpression other);
        Addition Add(IExpression other);
        Constant ToConstant();
    }
}
