using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Classes
{
    public class UserInput 
    {
        public decimal FirstNumber { get; set; }

        public decimal SecondNumber { get; set; }

        public static string GetEquation()
        {
            Console.WriteLine();
            string equation =  Console.ReadLine();
            return equation;
        }

        public OperatorType ParseOperator(string operatorInput)
        {
            OperatorType convertType = new OperatorType();
            string[] test = { "+", "-", "*", "/", "^", "s" };
            foreach (string x in test)
            {
                if (operatorInput.Contains(x))
                {
                    char.TryParse(x, out char _operator);
                    convertType = OperatorTypeExtensions.ConvertOperator(_operator);
                    return convertType;
                }
            }
            return convertType;
        }

        public void ParseOperandsFromEquation(string equation)
        {
            //validate input
            char[] testOperators = { '+', '-', '*', '/', '^', 's', '=', 'x' };
            equation = equation.ToLower().Replace(" ", "");
            string squareRootPlacement = "s";
            
            
            string[] numberValues = equation.Split(testOperators);
            //foreach (string x in numberValues)
            //{
            //    ParseDecimalFromInput(x);
            //}

            //Protection for if user inputs s before initial number or after, 
            // as well as not attempting to parse and assign SecondNumber if SquareRoot function is used
            if (ParseOperator(equation) != OperatorType.SquareRoot)
            {
                FirstNumber = ParseDecimalFromInput(numberValues[0]);
                SecondNumber = ParseDecimalFromInput(numberValues[1]);
            }
            else if (ParseOperator(equation) == OperatorType.SquareRoot)
            {
                if (equation.IndexOf(squareRootPlacement) == 0)
                {
                    FirstNumber = ParseDecimalFromInput(numberValues[1]);
                }
                else
                { 
                    FirstNumber = ParseDecimalFromInput(numberValues[0]);
                }
            }
            //string equals = "=";
            //string numberString = "";
            //foreach (string x in testOperators)
            //{
            //    if (!String.IsNullOrWhiteSpace(equation))
            //    {
            //        int charLocation = equation.IndexOf(x, StringComparison.OrdinalIgnoreCase);

            //        if (charLocation >= 0)
            //        {
            //            ParseDecimalFromInput(equation, charLocation);
            //        }
            //        int charLocationTwo = equation.IndexOf(x, StringComparison.OrdinalIgnoreCase);
            //        if (charLocationTwo > 0)
            //        {
            //            string numberString = equation.Substring(charLocation + 1, charLocationTwo);

            //            if (decimal.TryParse(numberString, out decimal number))
            //            {
            //                SecondNumber = number;
            //                break;
            //            }
            //        }
            //        else if (/*charLocation == 0 &&*/ equation.ToLower().Contains("s"))
            //        {
            //            Console.WriteLine("squareRoot");
            //        }
            //        else
            //        {
            //            Console.WriteLine("Sorry, your equation was unreadable - Try writing in the following format: (1) + (1) = | s(4)");
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("Write an equation: ");
            //    }
            //}
        }

        private decimal ParseDecimalFromInput(string numberString)
        {
            if (decimal.TryParse(numberString, out decimal number))
            {
                return number;
            }
            throw new Exception("Bad input " + numberString);
        }

        public decimal GetNumber(string whichNumber, OperatorType type)
        {
            SquareRootChecker squareRootCheck = new SquareRootChecker();
            decimal returnValue = 0;
            while (true)
            {
                if (squareRootCheck.SquareRootCheck(type) == SquareRootType.NotInUse)
                { 
                    Console.WriteLine("\nEnter a " + whichNumber + " number for your equation: ");

                    string inputString = Console.ReadLine();
                    CheckForExit(inputString);


                    if (decimal.TryParse(inputString, out returnValue))
                    {
                        return returnValue;
                    }
                    else
                    {
                        Console.WriteLine("Please enter valid integer");
                        continue;
                    }
                }
                return returnValue;
            }
        }

        protected char operatorChar { get; set; }

        protected ConsoleKeyInfo whichKey;
        
        public OperatorType AskForOperator()
        {
            while (true)
            {
                OperatorType _operator = new OperatorType();
                CheckForExit(whichKey.KeyChar);
                if (operatorChar == '+')
                {
                    _operator = OperatorType.Plus;
                }
                else if (operatorChar == '-')
                {
                    _operator = OperatorType.Minus;
                }
                else if (operatorChar == '*')
                {
                    _operator = OperatorType.Times;
                }
                else if (whichKey.Key == ConsoleKey.Divide)
                {
                    _operator = OperatorType.DividedBy;
                }
                else if (whichKey.KeyChar == 's' || whichKey.KeyChar == 'S')
                {
                    _operator = OperatorType.SquareRoot;
                }
                else
                {
                    Console.WriteLine("Please enter valid operator (+ - * / (s)");
                    continue;
                }
                return _operator;
            }
        }

        //public OperatorType AskForOperator()
        //{
        //    while (true)
        //    {
        //        OperatorType _operator = new OperatorType();
        //        Console.WriteLine("\nEnter an operator: (+ - * / (s for square root))");
        //        whichKey = Console.ReadKey();
        //        CheckForExit(whichKey.KeyChar);
        //        if (whichKey.Key == ConsoleKey.Add || whichKey.Key == ConsoleKey.OemPlus)
        //        {
        //            _operator = OperatorType.Plus;
        //        }
        //        else if (whichKey.Key == ConsoleKey.Subtract || whichKey.Key == ConsoleKey.OemMinus)
        //        {
        //            _operator = OperatorType.Minus;
        //        }
        //        else if (whichKey.Key == ConsoleKey.Multiply)
        //        {
        //            _operator = OperatorType.Times;
        //        }
        //        else if (whichKey.Key == ConsoleKey.Divide)
        //        {
        //            _operator = OperatorType.DividedBy;
        //        }
        //        else if (whichKey.KeyChar == 's' || whichKey.KeyChar == 'S')
        //        {
        //            _operator = OperatorType.SquareRoot;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Please enter valid operator (+ - * / (s)");
        //            continue;
        //        }
        //        return _operator;
        //    }
        //}

        public static void CheckForExit(char inputChar)
        {
            if (inputChar == 'x' || inputChar == 'X')
            {
                Environment.Exit(0);
            }
        }

        public static void CheckForExit(string inputText)
        {
            if (inputText.ToLower() == "x")
            {
                Environment.Exit(0);
            }
        }
    }
}
