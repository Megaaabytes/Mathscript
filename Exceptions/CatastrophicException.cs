using System;
using System.Runtime.Serialization;

namespace Math_Script_Runtime_Environment.Exceptions
{
    public class CatastrophicException : Exception
    {
        public CatastrophicException() : base()
        {
        }

        public CatastrophicException(string message) : base(message)
        {
        }

        public CatastrophicException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CatastrophicException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
