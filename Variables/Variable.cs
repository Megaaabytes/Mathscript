using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_Script_Runtime_Environment.Variables
{
    public struct Variable
    {
        public string name { get; }
        public VariableType type { get; }
        public string value { get; }

        public Variable(string name, VariableType type, string value)
        {
            this.name = name;
            this.type = type;
            this.value = value;
        }
    }

    public enum VariableType
    {
        Number,
        Char,
        String,
        Boolean,
    }
}
