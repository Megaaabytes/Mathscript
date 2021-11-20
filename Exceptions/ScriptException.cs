using System;
using System.Runtime.Serialization;

namespace Math_Script_Runtime_Environment.InstructionsTools
{
    [Serializable]
    internal class ScriptException : Exception
    {
        public ScriptException()
        {
        }

        public ScriptException(string message) : base(message)
        {
        }

        public ScriptException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ScriptException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}