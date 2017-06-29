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
                var result = calculator.Calculate("1+,3");
            });
        }
    }
}
