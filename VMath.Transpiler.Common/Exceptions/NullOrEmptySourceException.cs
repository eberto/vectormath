using System;

namespace VMath.Transpiler.Common.Exceptions
{
    public class NullOrEmptySourceException : Exception
    {
        public NullOrEmptySourceException()
            : this("The source to transpile is empty.")
        {
        }

        public NullOrEmptySourceException(string message)
            : base(message)
        {
        }

        public NullOrEmptySourceException(string message, Exception innerException)
            : base(message)
        {
        }
    }
}
