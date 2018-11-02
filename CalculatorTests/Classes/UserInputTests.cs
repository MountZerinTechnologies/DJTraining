using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Classes.Tests
{
    [TestClass()]
    public class UserInputTests
    {
        private UserInput userInputTarget;

        [TestMethod()]
        [DataRow("12 + 2", 12, 2)]
        [DataRow("12 + 2 ", 12, 2)]
        [DataRow("12 + 2 =", 12, 2)]
        [DataRow("12 + 2 = ", 12, 2)]
        [DataRow("12 + 2 = 13", 12, 2)]
        [DataRow("12 + 2 = 13 ", 12, 2)]
        [DataRow("2 + 12 ", 2, 12)]
        [DataRow("2 + 12 =", 2, 12)]
        [DataRow("2 + 12 = ", 2, 12)]
        [DataRow("2 + 12 = 13", 2, 12)]
        [DataRow("2 + 12 = 13 ", 2, 12)]
        [DataRow("2.3 + 12.7", 2.3, 12.7)]
        //[DataRow("2.3 f 12.7", 2.3, 12.7)]
        public void ParseOperandsFromEquationTest(string equation, object expectedOperandOne, object expectedOperandTwo)
        {
            userInputTarget = new UserInput();
           

            userInputTarget.ParseOperandsFromEquation(equation);
            decimal actualOperandOne = userInputTarget.FirstNumber;
            decimal actualOperandTwo = userInputTarget.SecondNumber;

            Assert.AreEqual(Convert.ToDecimal(expectedOperandOne), actualOperandOne, "first operand was not parsed correctly");
            Assert.AreEqual(Convert.ToDecimal(expectedOperandTwo), actualOperandTwo, "second operand was not parsed correctly");
        }

        [DataRow("2.3 f 12.7", 2.3, 12.7)]
        [DataRow("s32", 32)]
        [DataRow("32s", 32)]
        [DataRow("32 s", 32)]
        [DataRow("32 s ", 32)]
        public void ParseOperandsFromEquationTestThrowsError(string equation)
        {
            userInputTarget = new UserInput();


            

            Assert.ThrowsException<Exception>
                (
                    () => userInputTarget.ParseOperandsFromEquation(equation),
                    "I should halve had an error"
                );
        }

        [DataRow("s 32", OperatorType.SquareRoot)]
        [DataRow("32 ^ 32", OperatorType.SquareRoot)]
        [DataRow("32 + 32", OperatorType.SquareRoot)]
        [DataRow("32 - 32", OperatorType.SquareRoot)]
        [DataRow("2 / 32", OperatorType.SquareRoot)]
        [DataRow("2 * 32", OperatorType.SquareRoot)]
        [DataRow(" s 32", OperatorType.SquareRoot)]
        [DataRow(" s32", OperatorType.SquareRoot)]
        [DataRow("s32", OperatorType.SquareRoot)]
        [DataRow("s32 ", OperatorType.SquareRoot)]
        public void ParseOperatorTest(string equation, object expectedOperator)
        {
            userInputTarget = new UserInput();
            

            userInputTarget.ParseOperator(equation);
            OperatorType actualOperatorType = OperatorType.SquareRoot;


            Assert.AreEqual(Convert.ToDecimal(expectedOperator), actualOperatorType, "operator was not parsed correctly");
            //Assert.AreEqual(Convert.ToDecimal(expectedOperandTwo), actualOperandTwo, "second operand was not parsed correctly");
        }
    }
}