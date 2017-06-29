namespace SolidExercices.Operator
{
    public interface IOperator
    {
        char Symbol { get; }
        decimal Calculate(decimal operand1, decimal operand2);
    }
}
