using System;

namespace VMath.Transpiler.Common.Exceptions
{
    public class UnexpectedCharException : Exception
    {
        public UnexpectedCharException(int lineNumber, int index)
            : this(String.Format("Unexpected character found at line {0}, index {1}", lineNumber, index))
        {
        }

        public UnexpectedCharException(string message)
            : base(message)
        {
        }

        public UnexpectedCharException(string message, Exception innerException)
            : base(message)
        {
        }
    }
}
