using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Classes
{
    public static class OperatorTypeExtensions
    {
        public static string DisplayOperator(this OperatorType type)
        {
            switch (type)
            {
                case OperatorType.Plus:
                    return "+";
                case OperatorType.Minus:
                    return "-";
                case OperatorType.Times:
                    return "*";
                case OperatorType.DividedBy:
                    return "/";
                case OperatorType.SquareRoot:
                    return "The Square Root of ";
                default:
                    throw new Exception("Unrecognized type: " + type.ToString());
            }
        }

        public static OperatorType ConvertOperator(this char type)
        {
            switch (type)
            {
                case '+':
                    return OperatorType.Plus;
                case '-':
                    return OperatorType.Minus;
                case '*':
                    return OperatorType.Times;
                case '/':
                    return OperatorType.DividedBy;
                case 's':
                    return OperatorType.SquareRoot;
                case 'S':
                    return OperatorType.SquareRoot;
                default:
                    throw new Exception("Unrecognized type: " + type.ToString());
            }
        }
    }
}
