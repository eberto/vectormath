using System;

namespace VMath.Transpiler.Common.Exceptions
{
    public class PopulateEmptyTokenException : Exception
    {
        public PopulateEmptyTokenException()
            : this("Token is empty. You must set SourceLine, StartIndex and CharCount properly in order to populate content.")
        {
        }

        public PopulateEmptyTokenException(string message)
            : base(message)
        {            
        }

        public PopulateEmptyTokenException(string message, Exception innerException)
            : base(message)
        {
        }
    }
}
