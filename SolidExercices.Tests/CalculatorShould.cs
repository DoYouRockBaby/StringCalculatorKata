using NFluent;
using NUnit.Framework;
using SolidExercices.Exception;

namespace SolidExercices.Tests
{
    public class CalculatorShould
    {
        [Test]
        public void CalculateASum()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("1+2,3");
            Check.That(result).IsEqualTo(3.3);
        }

        [Test]
        public void CalculateWithSpacesSum()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("1 +  2,3");
            Check.That(result).IsEqualTo(3.3);
        }

        [Test]
        public void SumException()
        {
            var calculator = new Calculator();
            Assert.Throws<IncorrectExpressionException>(delegate
            {
                var result = calculator.Calculate("1+,3");
            });
        }
    }
}
