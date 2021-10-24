using Math_Script_Runtime_Environment.Arrays;

namespace Math_Script_Runtime_Environment.Variables
{
    public class VariableInformation
    {
        public Variable var { get; }
        public bool isInArray { get; }
        public ArrayVariable array { get; }
        public string value { get; }
        public string name { get; }
        public int index { get; }

        public VariableInformation(Variable var, bool isInArray, ArrayVariable array, int index)
        {
            this.var = var;
            this.isInArray = isInArray;
            this.array = array;
            this.value = var.value;
            this.name = var.name;
            this.index = index;
        }
    }
}
