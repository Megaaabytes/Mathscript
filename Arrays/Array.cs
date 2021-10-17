using System.Collections.Generic;
using Math_Script_Runtime_Environment.Variables;
using Math_Script_Runtime_Environment.InstructionsTools;

namespace Math_Script_Runtime_Environment.Arrays
{
    public class ArrayVariable
    {
        private Dictionary<int, Variable> arrayContents = new Dictionary<int, Variable>();
        public VariableType type { get; }
        public string name { get; }
        public int length { get; private set; }
        public int maxLength { get; }

        public ArrayVariable(int maxLength, VariableType type, string name)
        {
            this.type = type;
            this.name = name;
            this.length = 0;
            this.maxLength = maxLength;
        }

        public void Add(Variable var, int i)
        {
            if(length == maxLength)
            {
                if(ReadInstructions.tryBlockActive == true)
                {
                    return;
                }
                else
                {
                    throw new ScriptEngineException($"addindex({var.value}) (ARRAY INDEX IS FULL) AT {i}");
                }
            }
            arrayContents.Add(length, var);
            length++;
        }

        public void Remove(int index)
        {
            arrayContents.Remove(index);
        }

        public void Empty()
        {
            arrayContents.Clear();
            length = 0;
        }

        public string GetValue(int index)
        {
            return arrayContents[index].value;
        }

        public Variable GetVariable(int index)
        {
            return arrayContents[index];
        }

        public string GetValue(string name, int index)
        {
            for (int i = 0; i < length; i++)
            {
                Variable var = arrayContents[i];
                if (var.name == name)
                {
                    return var.value;
                }
                else
                {
                    continue;
                }
            }
            throw new ScriptEngineException($"Variable {name} does not exist AT {index}");
        }

        public Variable Filter(string name, int index)
        {
            for (int i = 0; i < length; i++)
            {
                Variable var = arrayContents[i];
                if(var.name == name)
                {
                    return var;
                }
                else
                {
                    continue;
                }
            }
            throw new ScriptEngineException($"Variable {name} does not exist AT {index}");
        }
    }
}
