using System;

namespace Math_Script_Runtime_Environment.For_Loops
{
    public struct ForData
    {
        public string arrayVariableName { get; }
        public string objectName { get; }
        public string index { get; }

        public ForData(string arrayVariableName, string objectName, string index)
        {
            this.arrayVariableName = arrayVariableName;
            this.objectName = objectName;
            this.index = index;
        }
    }
}
