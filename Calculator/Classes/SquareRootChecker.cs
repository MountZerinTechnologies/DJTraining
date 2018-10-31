using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Classes
{
    public class SquareRootChecker
    {
        public SquareRootType SquareRoot { get; set; }


        public SquareRootType SquareRootCheck(OperatorType type)
        {
            SquareRootType squareRootCheck = SquareRoot;
            if (type == OperatorType.SquareRoot)
            {
                squareRootCheck = SquareRootType.InUse;
            }
            else
            {
                squareRootCheck = SquareRootType.NotInUse;
            }
            return squareRootCheck;
        }
    }
    public enum SquareRootType
    {
        InUse,
        NotInUse
    }
}
