using System;
using System.Runtime.Serialization;

namespace Math_Script_Runtime_Environment.Parsing
{
    [Serializable]
    internal class ParameterException : Exception
    {
        public ParameterException()
        {
        }

        public ParameterException(string message) : base(message)
        {
        }

        public ParameterException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ParameterException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}