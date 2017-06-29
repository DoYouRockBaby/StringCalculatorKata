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

            calculator.Operators.Add(prioritaryOperators);
            calculator.Operators.Add(simpleOperators);

            var calculatorTrainer = new CalculatorTrainer();
            calculatorTrainer.Run(calculator);
            System.Console.ReadKey();
        }
    }
}
