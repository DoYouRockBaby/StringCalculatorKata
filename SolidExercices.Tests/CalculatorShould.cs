using System;
using System.Collections.Generic;
using NFluent;
using NUnit.Framework;
using SolidExercices.Exception;
using SolidExercices.Operator;

namespace SolidExercices.Tests
{
    [TestFixture]
    public class CalculatorShould
    {
        private Calculator InstantiateCalculator()
        {
            var calculator = new Calculator();

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

            return calculator;
        }

        [Test]
        public void CalculateASimpleSum()
        {
            var calculator = InstantiateCalculator();
            var result = calculator.Calculate("1+2,3");
            Check.That(result).IsEqualTo(3.3m);
        }

        [Test]
        public void CalculateWithSpacesSum()
        {
            var calculator = InstantiateCalculator();
            var result = calculator.Calculate("1 +  2,3");
            Check.That(result).IsEqualTo(3.3m);
        }

        [Test]
        public void SumException()
        {
            var calculator = InstantiateCalculator();
            Assert.Throws<IncorrectExpressionException>(delegate
            {
                calculator.Calculate("1+");
            });
        }

        [Test]
        public void CalculateASimpleMinus()
        {
            var calculator = InstantiateCalculator();
            var result = calculator.Calculate("2,3-1");
            Check.That(result).IsEqualTo(1.3m);
        }

        [Test]
        public void CalculateASimpleProduct()
        {
            var calculator = InstantiateCalculator();
            var result = calculator.Calculate("2,3x2");
            Check.That(result).IsEqualTo(4.6m);
        }

        [Test]
        public void CalculateASimpleDivision()
        {
            var calculator = InstantiateCalculator();
            var result = calculator.Calculate("2,8/1,4");
            Check.That(result).IsEqualTo(2m);
        }

        [Test]
        public void CalculateComposedOperation()
        {
            var calculator = InstantiateCalculator();
            var result = calculator.Calculate("1+2,8-1,4");
            Check.That(result).IsEqualTo(2.4m);
        }

        [Test]
        public void CalculateComposedOperationWithPriorities()
        {
            var calculator = InstantiateCalculator();
            var result = calculator.Calculate("1+2,8/1,4");
            Check.That(result).IsEqualTo(3m);

            result = calculator.Calculate("2,8/1,4 + 1");
            Check.That(result).IsEqualTo(3m);

            result = calculator.Calculate("1x4+2,8/1,4+3");
            Check.That(result).IsEqualTo(9m);
        }

        [Test]
        public void DivisionException()
        {
            var calculator = InstantiateCalculator();
            Assert.Throws<DivideByZeroException>(delegate
            {
                calculator.Calculate("1/0");
            });
        }
    }
}
