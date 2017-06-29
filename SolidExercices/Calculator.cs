using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SolidExercices.Exception;
using SolidExercices.Operation;

namespace SolidExercices
{
    public class Calculator
    {
        //First list is used to determine priorities, second contains operators
        private List<List<IOperator>> _operators;

        public Calculator()
        {
            _operators = new List<List<IOperator>>();
            List<IOperator> simpleOperators = new List<IOperator>();
            simpleOperators.Add(new AddOperator());
            _operators.Add(simpleOperators);
        }
        public decimal Calculate(string operation)
        {
            //If we have a simple number, we return it
            decimal result;
            if (decimal.TryParse(operation, out result))
            {
                return result;
            }

            //We execute operation for each operator type
            foreach(var operatorGroup in _operators)
            {
                char[] symbols = new char[operatorGroup.Count];

                //We build symbol list to do the split
                for (var i = 0; i < operatorGroup.Count; i++)
                {
                    symbols[i] = operatorGroup[i].Symbol;
                }

                //Find the first symbol, the one of the first operation in the string
                char? usedSymbol = GetFirstCharMatching(symbols, operation);
                if (usedSymbol == null)
                {
                    continue;
                }

                //Split the both members
                var splitted = operation.Split(symbols, 2);
                if (splitted.Length >= 2)
                {
                    //use recursion to calculate the both members value
                    decimal operand1 = Calculate(splitted[0]);
                    decimal operand2 = Calculate(splitted[1]);

                    IOperator _operator = operatorGroup.Find(x => x.Symbol == usedSymbol);
                    return _operator.Calculate(operand1, operand2);
                }
            }

            throw new IncorrectExpressionException();
        }

        //Return the first char present in a string, null if not found
        private char? GetFirstCharMatching(char[] chars, string str)
        {
            foreach (char c in str)
            {
                if (chars.Contains(c))
                {
                    return c;
                }
            }

            return null;
        }
    }
}