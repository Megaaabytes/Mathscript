using System;

namespace Math_Script_Runtime_Environment.Operators
{
    public class Operator
    {
        public string arg1 { get; }
        public string arg2 { get; }
        public string arg3 { get; private set; }
        public OperatorType type { get; }

        public Operator(string arg1, string arg2, OperatorType type)
        {
            this.arg1 = arg1;
            this.arg2 = arg2;
            this.type = type;
        }

        public void PrintOperator()
        {
            Console.WriteLine($"{arg1},{arg2},{arg3}:{type}");
        }

        public void SetArg3(string data)
        {
            if (arg3 == null)
            {
                arg3 = data;
            }
            else
            {
                throw new UnauthorizedAccessException("You cannot change arg3 once it has already been defined.");
            }
        }
    }

    public enum OperatorType
    {
        Plus,
        Minus,
        Multiply,
        Divide,
        Power,
        Lessthan,
        Greaterthan,
        Equals,
        Modulo,
        Not,
    }
}
