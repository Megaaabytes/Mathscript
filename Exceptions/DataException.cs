using System;
using System.Runtime.Serialization;

namespace Math_Script_Runtime_Environment.Parsing
{
    [Serializable]
    internal class DataException : Exception
    {
        public DataException()
        {
        }

        public DataException(string message) : base(message)
        {
        }

        public DataException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}