using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidExercices.Operator
{
    class DivisionOperator : IOperator
    {
        private readonly char _symbol = '/';
        public char Symbol
        {
            get { return _symbol; }
        }

        public decimal Calculate(decimal operand1, decimal operand2)
        {
            if (operand2 == 0)
            {
                throw new DivideByZeroException();
            }

            return operand1 / operand2;
        }
    }
}
