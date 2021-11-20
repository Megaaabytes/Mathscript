using System;
using System.Runtime.Serialization;

namespace Math_Script_Runtime_Environment.InstructionsTools
{
    [Serializable]
    internal class ScriptMathException : Exception
    {
        public ScriptMathException()
        {
        }

        public ScriptMathException(string message) : base(message)
        {
        }

        public ScriptMathException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ScriptMathException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}