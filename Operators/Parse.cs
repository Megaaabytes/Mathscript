using System;
using Math_Script_Runtime_Environment.Parsing;
using Math_Script_Runtime_Environment.InstructionsTools;
using Math_Script_Runtime_Environment.Variables;
using Math_Script_Runtime_Environment.String_And_Character_Parsing;

namespace Math_Script_Runtime_Environment.Operators
{
    public class Parse
    {
        public static Operator ParseOperationsFromLine(string line, int i)
        {
            bool gottenOperation = false;
            bool gottenEqualSign = false;
            OperatorType gottenType = new OperatorType();
            string arg1 = null;
            string arg2 = null;
            string arg3 = null;

            foreach (char token in line)
            {
                if (token == '=')
                {
                    if (gottenEqualSign == true)
                    {
                        throw new Exception($"There can only be 1 equal sign in your operation.");
                    }
                    gottenEqualSign = true;
                }
                else if (token == '^')
                {
                    if (gottenOperation == true)
                    {
                        throw new Exception($"There can only be 1 operator in your operation.");
                    }
                    gottenType = OperatorType.Power;
                    gottenOperation = true;
                }
                else if (token == '/')
                {
                    if (gottenOperation == true)
                    {
                        throw new Exception($"There can only be 1 operator in your operation.");
                    }
                    gottenType = OperatorType.Divide;
                    gottenOperation = true;
                }
                else if (token == '%')
                {
                    if (gottenOperation == true)
                    {
                        throw new Exception($"There can only be 1 operator in your operation.");
                    }
                    gottenType = OperatorType.Modulo;
                    gottenOperation = true;
                }
                else if (token == '*')
                {
                    if (gottenOperation == true)
                    {
                        throw new Exception($"There can only be 1 operator in your operation.");
                    }
                    gottenType = OperatorType.Multiply;
                    gottenOperation = true;
                }
                else if (token == '>')
                {
                    if (gottenOperation == true)
                    {
                        throw new Exception($"There can only be 1 operator in your operation.");
                    }
                    gottenType = OperatorType.Greaterthan;
                    gottenOperation = true;
                }
                else if (token == '<')
                {
                    if (gottenOperation == true)
                    {
                        throw new Exception($"There can only be 1 operator in your operation.");
                    }
                    gottenType = OperatorType.Lessthan;
                    gottenOperation = true;
                }
                else if (token == '!')
                {
                    if (gottenOperation == true)
                    {
                        throw new Exception($"There can only be 1 operator in your operation.");
                    }
                    gottenType = OperatorType.Not;
                    gottenOperation = true;
                }
                else if (token == '+')
                {
                    if (gottenOperation == true)
                    {
                        throw new Exception($"There can only be 1 operator in your operation.");
                    }
                    gottenType = OperatorType.Plus;
                    gottenOperation = true;
                }
                else if (token == '-')
                {
                    if (gottenOperation == true)
                    {
                        throw new Exception($"There can only be 1 operator in your operation.");
                    }
                    gottenType = OperatorType.Minus;
                    gottenOperation = true;
                }
                else
                {
                    if (gottenEqualSign == true)
                    {
                        arg3 += token.ToString();
                    }
                    else
                    {
                        if (gottenOperation == true)
                        {
                            arg2 += token.ToString();
                        }
                        else
                        {
                            arg1 += token.ToString();
                        }
                    }
                }
            }

            // Check wether an argument is a variable.
            OperatorVariableType varType = OperatorVariableType.Default;
            if (arg1.Contains("${"))
            {
                if (arg1.Replace("${", "").Replace("}", "").ParseValue(i).var.type == VariableType.Boolean)
                {
                    varType = OperatorVariableType.Boolean;
                    if (arg2.Contains("${"))
                    {
                        arg2 = arg2.Replace("${", "").Replace("}", "").ParseValue(i).value;
                    }
                    if (arg3.Contains("${"))
                    {
                        arg3 = arg3.Replace("${", "").Replace("}", "").ParseValue(i).value;
                    }

                    Operator newOperation = new Operator(arg1, arg2, gottenType, varType);
                    newOperation.SetArg3(arg3);
                    return newOperation;
                }
                else if (arg1.Replace("${", "").Replace("}", "").ParseValue(i).var.type == VariableType.Char)
                {
                    varType = OperatorVariableType.Character;
                    if (arg2.Contains("${"))
                    {
                        arg2 = arg2.Replace("${", "").Replace("}", "").ParseValue(i).value;
                    }
                    if (arg3.Contains("${"))
                    {
                        arg3 = arg3.Replace("${", "").Replace("}", "").ParseValue(i).value;
                    }

                    Operator newOperation = new Operator(arg1, arg2, gottenType, varType);
                    newOperation.SetArg3(arg3);
                    return newOperation;
                }
                else if (arg1.Replace("${", "").Replace("}", "").ParseValue(i).var.type == VariableType.Number)
                {
                    varType = OperatorVariableType.Number;
                    if (arg2.Contains("${"))
                    {
                        arg2 = arg2.Replace("${", "").Replace("}", "").ParseValue(i).value;
                    }
                    if (arg3.Contains("${"))
                    {
                        arg3 = arg3.Replace("${", "").Replace("}", "").ParseValue(i).value;
                    }

                    Operator newOperation = new Operator(arg1, arg2, gottenType, varType);
                    newOperation.SetArg3(arg3);
                    return newOperation;
                }
                else if (arg1.Replace("${", "").Replace("}", "").ParseValue(i).var.type == VariableType.String)
                {
                    varType = OperatorVariableType.String;
                    if (arg2.Contains("${"))
                    {
                        arg2 = arg2.Replace("${", "").Replace("}", "").ParseValue(i).value;
                    }
                    if (arg3.Contains("${"))
                    {
                        arg3 = arg3.Replace("${", "").Replace("}", "").ParseValue(i).value;
                    }

                    Operator newOperation = new Operator(arg1, arg2, gottenType, varType);
                    newOperation.SetArg3(arg3);
                    return newOperation;
                }
                else
                {
                    Operator newOperation = new Operator(arg1, arg2, gottenType, OperatorVariableType.Number);
                    newOperation.SetArg3(arg3);
                    return newOperation;
                }
            }

            // Check wether is argument is string
            if (arg1.Contains('"'.ToString()))
            {
                string data = StringDefinition.Parse(arg1);
                arg1 = data;

                if (arg2 == "null" || arg2 == "?")
                {
                    arg2 = "?";
                }
                else
                {
                    string data2 = StringDefinition.Parse(arg2);
                    arg2 = data2;
                }

                if(arg3 == "true" || arg3 == "false")
                {
                    arg3 = "false";

                    Operator newOperation3 = new Operator(arg1, arg2, gottenType, OperatorVariableType.String);
                    newOperation3.SetArg3(arg3);
                    return newOperation3;
                }

                if (arg3 == "null" || arg3 == "?")
                {
                    arg3 = "?";
                }
                else
                {
                    string data3 = StringDefinition.Parse(arg3);
                    arg3 = data3;
                }

                Operator newOperation2 = new Operator(arg1, arg2, gottenType, OperatorVariableType.String);
                newOperation2.SetArg3(arg3);
                return newOperation2;
            }

            Operator newOperation1 = new Operator(arg1, arg2, gottenType, OperatorVariableType.Number);
            newOperation1.SetArg3(arg3);
            return newOperation1;
        }
    }
}
