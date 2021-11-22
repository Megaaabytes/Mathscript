using Math_Script_Runtime_Environment.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_Script_Runtime_Environment.Operations
{
    public class FunctionList
    {
        public static List<FunctionCall> functions = new List<FunctionCall>();
    }

    public struct FunctionCall
    {
        public Function function { get; }
        public int lastLine { get; }

        public FunctionCall(Function function, int lastLine)
        {
            this.function = function;
            this.lastLine = lastLine;
        }
    }
}
