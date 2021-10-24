using Math_Script_Runtime_Environment.InstructionsTools;
using Math_Script_Runtime_Environment.Variables;

namespace Math_Script_Runtime_Environment.Parsing
{
    public static class ConvertVariableNameToValue
    {
        public static VariableInformation ParseValue(this string mess, int i)
        {
            return ReadInstructions.ReadVariable(mess.Replace("${", "").Replace("}", ""), i, ReadInstructions.variables.ToArray(), ReadInstructions.arrayVariables.ToArray());
        }
    }
}
