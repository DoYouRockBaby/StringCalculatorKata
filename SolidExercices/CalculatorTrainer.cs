using System;

namespace SolidExercices
{
    public class CalculatorTrainer
    {
        public static void Run(Calculator calculator, string[] operations)
        {
            foreach (var operation in operations)
            {
                try
                {
                    var result = calculator.Calculate(operation);
                    Console.WriteLine(operation + " = " + result);
                }
                catch (System.Exception e)
                {
                    Console.WriteLine("ERROR: " + e.Message);
                }
            }
        }
    }
}
