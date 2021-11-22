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

        public static VariableInformation SplitStringAndVariable(this string mess, int i)
        {
            string parsedString = null;

            if (mess.StartsWith("${"))
            {
                for (int id = 0; id < mess.Length - 1; id++)
                {
                    if (mess[id] == '$' || mess[id] == '{') continue;
                    if (mess[id] == '}') break;

                    parsedString += mess[id];
                }

                return ReadInstructions.ReadVariable(parsedString, i, ReadInstructions.variables.ToArray(), ReadInstructions.arrayVariables.ToArray());
            }
            else
            {
                return null;
            }
        }
    }
}
