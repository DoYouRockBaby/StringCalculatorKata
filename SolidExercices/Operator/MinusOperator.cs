using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidExercices.Operator
{
    class MinusOperator : IOperator
    {
        private readonly char _symbol = '-';
        public char Symbol
        {
            get { return _symbol; }
        }

        public decimal Calculate(decimal operand1, decimal operand2)
        {
            return operand1 - operand2;
        }
    }
}
