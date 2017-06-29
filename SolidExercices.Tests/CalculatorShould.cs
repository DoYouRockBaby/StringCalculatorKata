using System;
using NFluent;
using NUnit.Framework;
using SolidExercices.Exception;

namespace SolidExercices.Tests
{
    [TestFixture]
    public class CalculatorShould
    {
        [Test]
        public void CalculateASimpleSum()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("1+2,3");
            Check.That(result).IsEqualTo(3.3m);
        }

        [Test]
        public void CalculateWithSpacesSum()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("1 +  2,3");
            Check.That(result).IsEqualTo(3.3m);
        }

        [Test]
        public void SumException()
        {
            var calculator = new Calculator();
            Assert.Throws<IncorrectExpressionException>(delegate
            {
                calculator.Calculate("1+");
            });
        }

        [Test]
        public void CalculateASimpleMinus()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("2,3-1");
            Check.That(result).IsEqualTo(1.3m);
        }

        [Test]
        public void CalculateASimpleProduct()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("2,3x2");
            Check.That(result).IsEqualTo(4.6m);
        }

        [Test]
        public void CalculateASimpleDivision()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("2,8/1,4");
            Check.That(result).IsEqualTo(2m);
        }

        [Test]
        public void CalculateComposedOperation()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("1+2,8-1,4");
            Check.That(result).IsEqualTo(2.4m);
        }

        [Test]
        public void CalculateComposedOperationWithPriorities()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("1+2,8/1,4");
            Check.That(result).IsEqualTo(3m);
        }

        [Test]
        public void DivisionException()
        {
            var calculator = new Calculator();
            Assert.Throws<DivideByZeroException>(delegate
            {
                calculator.Calculate("1/0");
            });
        }
    }
}
