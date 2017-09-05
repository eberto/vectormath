using System;

namespace VMath.Transpiler.Common.Exceptions
{
    public class NotSupportedOperatorException : Exception
    {
        public NotSupportedOperatorException()
            : this("This operator is not supported.")
        {
        }

        public NotSupportedOperatorException(string message)
            : base(message)
        {
        }

        public NotSupportedOperatorException(string message, Exception innerException)
            : base(message)
        {
        }
    }
}
