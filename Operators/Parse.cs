using System;

namespace Math_Script_Runtime_Environment.Operators
{
    public class Parse
    {
        public static Operator ParseOperationsFromLine(string line)
        {
            bool gottenOperation = false;
            bool gottenEqualSign = false;
            OperatorType gottenType = new OperatorType();

            string arg1 = null;
            string arg2 = null;
            string arg3 = null;

            foreach(char token in line)
            {
                if(token == '=')
                {
                    if(gottenEqualSign == true)
                    {
                        throw new Exception($"There can only be 1 equal sign in your operation.");
                    }
                    gottenEqualSign = true;
                }
                else if(token == '^')
                {
                    if(gottenOperation == true)
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
                    if(gottenEqualSign == true)
                    {
                        arg3 += token.ToString();
                    }
                    else
                    {
                        if(gottenOperation == true)
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

            if(string.IsNullOrWhiteSpace(arg1) || string.IsNullOrWhiteSpace(arg2) || string.IsNullOrWhiteSpace(arg3))
            {
                return null;
            }
            else
            {
                Operator newOperation = new Operator(arg1, arg2, gottenType);
                newOperation.SetArg3(arg3);
                return newOperation;
            }
        }
    }
}
