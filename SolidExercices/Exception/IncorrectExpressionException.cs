using System.Runtime.Serialization;

namespace SolidExercices.Exception
{
    public class IncorrectExpressionException : System.Exception
    {
        public IncorrectExpressionException()
        {
        }

        public IncorrectExpressionException(string message) : base(message)
        {
        }

        public IncorrectExpressionException(string message, System.Exception inner) : base(message, inner)
        {
        }

        protected IncorrectExpressionException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
