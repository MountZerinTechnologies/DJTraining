﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Classes
{
    public class CalculatorObject
    {
        public decimal OperandOne { get; set; }
        public decimal OperandTwo { get; set; }
        public OperatorType Operator { get; set; }
        
        public decimal PerformCalculation()
        {
            decimal solution = 0;
            if (this.Operator == OperatorType.Plus)
            {
                solution = OperandOne + OperandTwo;
            }
            else if (this.Operator == OperatorType.Minus)
            {
                solution = OperandOne - OperandTwo;
            }
            else if (this.Operator == OperatorType.Times)
            {
                solution = OperandOne * OperandTwo;
            }
            else if (this.Operator == OperatorType.DividedBy)
            {
                solution = OperandOne / OperandTwo;
            }
            else if (this.Operator == OperatorType.SquareRoot)
            {
                solution = (decimal)Math.Sqrt((double)OperandOne);
            }
            else if (this.Operator == OperatorType.Exponent)
            {
                //solution = (decimal)Math.Pow((double)OperandOne, (double)OperandTwo);
                solution = OperandOne;
                for (int i = 1; i < OperandTwo; i++)
                {
                    Func<decimal, decimal, decimal> square = (x, y) => x * y;
                    solution = square(OperandOne, solution);
                }
            }
            else
            {
                throw new Exception("Invalid operator: " + this.Operator.ToString());
            }
            return solution;
        }

    }
    public enum OperatorType
    {
        Plus, 
        Minus,
        Times,
        DividedBy,
        SquareRoot,
        Exponent
    }


}
