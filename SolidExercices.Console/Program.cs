using System.Collections.Generic;
using SolidExercices.Operator;

namespace SolidExercices.Console
{
    public class Program
    {
        public static void Main()
        {
            //instantiate calculator
            Calculator calculator = new Calculator();

            //instantiate add and minus
            List<IOperator> simpleOperators = new List<IOperator>();
            simpleOperators.Add(new AddOperator());
            simpleOperators.Add(new MinusOperator());

            //instantiate product and division (they have proprity)
            List<IOperator> prioritaryOperators = new List<IOperator>();
            prioritaryOperators.Add(new ProductOperator());
            prioritaryOperators.Add(new DivisionOperator());

            //add the operations to the calculator
            calculator.Operators.Add(prioritaryOperators);
            calculator.Operators.Add(simpleOperators);

            //predefine the operations
            string[] operations = {"1+2,3", "2 x 3,6", "6-1-3,8", "6,6/3", "6/0", "not an operation", "a+1", "12", ""};

            //Run the operations
            CalculatorTrainer.Run(calculator, operations);
            System.Console.ReadKey();
        }
    }
}
