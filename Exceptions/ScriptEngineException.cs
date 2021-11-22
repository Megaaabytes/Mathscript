using System;
using System.Runtime.Serialization;

namespace Math_Script_Runtime_Environment.InstructionsTools
{
    [Serializable]
    internal class ScriptEngineException : Exception
    {
        public ScriptEngineException()
        {
        }

        public ScriptEngineException(string message) : base(message)
        {
        }

        public ScriptEngineException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ScriptEngineException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}