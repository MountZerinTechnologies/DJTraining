using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Classes;

namespace Calculator
{
    public class Program 
    {
        public static void Main(string[] args)
        {
            //CalculatorObject myCalculator = new CalculatorObject();
            //Console.WriteLine("Welcome to Calculator: \ntype \"x\" to exit at anytime." +
            //                  "\n -Accepted parameters (+ - * / (s for square root))");
            //while (true)
            //{
            //    SolutionFormatHelper solutionFormatHelper = new SolutionFormatHelper();
            //    UserInput input = new UserInput();
            //    OperatorType operatorInput = new OperatorType();
            //    SquareRootChecker squareRootChecker = new SquareRootChecker();

            //    SquareRootType squareRootType = squareRootChecker.SquareRoot;
            //    decimal firstNumberInput = input.GetNumber("first", operatorInput);
            //    operatorInput = input.AskForOperator();
            //    myCalculator.Operator = operatorInput;

            //    squareRootType = squareRootChecker.SquareRootCheck(operatorInput);
            //    squareRootChecker.SquareRoot = squareRootType;

            //    decimal secondNumberInput = input.GetNumber("second", operatorInput);
            //    myCalculator.OperandOne = firstNumberInput;
            //    myCalculator.OperandTwo = secondNumberInput;

            //    decimal solution = myCalculator.PerformCalculation();

            //    Console.WriteLine();

            //    string finalResultMessage = solutionFormatHelper.FinalResultMessage(myCalculator.Operator
            //                                .DisplayOperator(), firstNumberInput, secondNumberInput, solution, myCalculator.Operator);

            //    Console.WriteLine(finalResultMessage);

            //    Console.Read();
            //}


            CalculatorObject myCalculator = new CalculatorObject();
            Console.WriteLine("Welcome to Calculator: \ntype \"x\" to exit at anytime." +
                              "\n -Accepted parameters (+ - * / (s for square root))");
            while (true)
            {
                UserInput input = new UserInput();
                OperatorType operatorInput = new OperatorType();
                SquareRootChecker squareRootChecker = new SquareRootChecker();

                SquareRootType squareRootType = squareRootChecker.SquareRoot;
                string numberInput = UserInput.GetEquation();
                operatorInput = input.ParseOperator(numberInput);
                input.ParseOperandsFromEquation(numberInput);
                myCalculator.Operator = operatorInput;
                
                myCalculator.OperandOne = input.FirstNumber;
                myCalculator.OperandTwo = input.SecondNumber;

                decimal solution = myCalculator.PerformCalculation();



                SolutionFormatHelper resultMessageStructure = new SolutionFormatHelper();
                string finalResultMessage = resultMessageStructure.FinalResultMessage(myCalculator.Operator
                                            .DisplayOperator(), input.FirstNumber, input.SecondNumber, solution, myCalculator.Operator);

                Console.WriteLine(finalResultMessage);
            }
        }
    }
}
