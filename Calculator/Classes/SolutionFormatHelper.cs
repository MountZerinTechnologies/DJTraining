using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Classes
{
    public class SolutionFormatHelper 
    {
        public string FinalResultMessage(string _operator, decimal firstNumber, decimal secondNumber, decimal solution, OperatorType type)
        {
            SquareRootChecker squareRoot = new SquareRootChecker();
            string finalResultMessage = "";
            if (squareRoot.SquareRootCheck(type) == SquareRootType.InUse)
            {
                finalResultMessage = $"{_operator} {firstNumber} = {solution}";
            }
            else
            {
                finalResultMessage = $"{firstNumber} {_operator} {secondNumber} = {solution}";
            }
            return finalResultMessage;
        }

    }
}
