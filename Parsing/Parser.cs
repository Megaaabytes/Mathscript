using Math_Script_Runtime_Environment.For_Loops;
using Math_Script_Runtime_Environment.InstructionsTools;
using System;
using System.Collections.Generic;

namespace Math_Script_Runtime_Environment.Parsing
{
    public class Parser
    {
        public static Instructions[] BeginParse(string[] lines)
        {
            List<Instructions> instructions = new List<Instructions>();
            foreach (string line in lines)
            {
                if (line.Contains("add"))
                {
                    ArgumentsAndOperation data = GetData(line);
                    instructions.Add(new Instructions(InstructionType.Addition, $"{data.arg1},{data.arg2}"));
                }
                else if (line.Contains("sub"))
                {
                    ArgumentsAndOperation data = GetData(line);
                    instructions.Add(new Instructions(InstructionType.Subtraction, $"{data.arg1},{data.arg2}"));
                }
                else if (line.Contains("pow"))
                {
                    ArgumentsAndOperation data = GetData(line);
                    instructions.Add(new Instructions(InstructionType.Power, $"{data.arg1},{data.arg2}"));
                }
                else if (line.Contains("mul"))
                {
                    ArgumentsAndOperation data = GetData(line);
                    instructions.Add(new Instructions(InstructionType.Multiplication, $"{data.arg1},{data.arg2}"));
                }
                else if (line.Contains("mod"))
                {
                    ArgumentsAndOperation data = GetData(line);
                    instructions.Add(new Instructions(InstructionType.Modulo, $"{data.arg1},{data.arg2}"));
                }
                else if (line.Contains("fac"))
                {
                    string data = GetOneArgData(line);
                    instructions.Add(new Instructions(InstructionType.Factorial, data));
                }
                else if (line.Contains("div"))
                {
                    ArgumentsAndOperation data = GetData(line);
                    instructions.Add(new Instructions(InstructionType.Division, $"{data.arg1},{data.arg2}"));
                }
                else if (line.Contains("per"))
                {
                    ArgumentsAndOperation data = GetData(line);
                    instructions.Add(new Instructions(InstructionType.Percent, $"{data.arg1},{data.arg2}"));
                }
                else if (line.Contains("blur"))
                {
                    string data = GetOneArgData(line);
                    instructions.Add(new Instructions(InstructionType.Blur, data));
                }
                else if (line.Contains("label("))
                {
                    string data = GetOneArgData(line);
                    instructions.Add(new Instructions(InstructionType.Label, data));
                }
                else if (line.Contains("toLabel"))
                {
                    string data = GetOneArgData(line);
                    instructions.Add(new Instructions(InstructionType.ToLabel, data));
                }
                else if (line.Contains("function("))
                {
                    string data = GetOneArgData(line);
                    instructions.Add(new Instructions(InstructionType.Function, data));
                }
                else if (line.Contains("endf("))
                {
                    string data = GetOneArgData(line);
                    instructions.Add(new Instructions(InstructionType.Endf, data));
                }
                else if (line.Contains("run("))
                {
                    string data = GetOneArgData(line);
                    instructions.Add(new Instructions(InstructionType.Run, data));
                }
                else if (line.Contains("infoAt("))
                {
                    string data = GetOneArgData(line);
                    instructions.Add(new Instructions(InstructionType.InfoAt, data));
                }
                else if (line.Contains("insert("))
                {
                    ArgumentsAndOperation data = GetData(line);
                    instructions.Add(new Instructions(InstructionType.Insert, $"{data.arg1},{data.arg2}"));
                }
                else if (line.Contains("remove("))
                {
                    ArgumentsAndOperation data = GetData(line);
                    instructions.Add(new Instructions(InstructionType.Remove, $"{data.arg1},{data.arg2}"));
                }
                else if (line.Contains("default"))
                {
                    Instructions instruct = new Instructions(InstructionType.Default, null);
                    instructions.Add(instruct);
                }
                else if (line.Contains("def"))
                {
                    TwoArgumentsAndOperation data = GetMoreData(line);
                    if (data.arg1 == "number")
                    {
                        Instructions instruct = new Instructions(InstructionType.VariableNumber, $"{data.arg2},{data.arg3}");
                        instruct.isVariable = true;
                        instructions.Add(instruct);
                    }
                    else if (data.arg1 == "string")
                    {
                        Instructions instruct = new Instructions(InstructionType.VariableString, $"{data.arg2},{data.arg3}");
                        instruct.isVariable = true;
                        instructions.Add(instruct);
                    }
                    else if (data.arg1 == "boolean")
                    {
                        Instructions instruct = new Instructions(InstructionType.VariableBoolean, $"{data.arg2},{data.arg3}");
                        instruct.isVariable = true;
                        instructions.Add(instruct);
                    }
                    else if (data.arg1 == "character")
                    {
                        Instructions instruct = new Instructions(InstructionType.VariableChar, $"{data.arg2},{data.arg3}");
                        instruct.isVariable = true;
                        instructions.Add(instruct);
                    }
                    else if (data.arg1 == "string#")
                    {
                        Instructions instruct = new Instructions(InstructionType.VariableStringArray, $"{data.arg2},{data.arg3}");
                        instruct.isVariable = true;
                        instructions.Add(instruct);
                    }
                    else if (data.arg1 == "boolean#")
                    {
                        Instructions instruct = new Instructions(InstructionType.VariableBooleanArray, $"{data.arg2},{data.arg3}");
                        instruct.isVariable = true;
                        instructions.Add(instruct);
                    }
                    else if (data.arg1 == "char#")
                    {
                        Instructions instruct = new Instructions(InstructionType.VariableCharArray, $"{data.arg2},{data.arg3}");
                        instruct.isVariable = true;
                        instructions.Add(instruct);
                    }
                    else if (data.arg1 == "number#")
                    {
                        Instructions instruct = new Instructions(InstructionType.VariableNumberArray, $"{data.arg2},{data.arg3}");
                        instruct.isVariable = true;
                        instructions.Add(instruct);
                    }
                    else
                    {
                        throw new Exception("Invaild data structure cannot be used inside variable declaration.");
                    }
                }
                else if (line.Contains("randomint"))
                {
                    ArgumentsAndOperation data = GetData(line);
                    Instructions instruct = new Instructions(InstructionType.RandomInt, $"{data.arg1},{data.arg2}");
                    instructions.Add(instruct);
                }
                else if (line.Contains("loop("))
                {
                    Instructions instruct = new Instructions(InstructionType.Loop, null);
                    instructions.Add(instruct);
                }
                else if (line.Contains("loopuntil("))
                {
                    string data = GetOneArgData(line);
                    Instructions instruct = new Instructions(InstructionType.LoopUntil, data);
                    instructions.Add(instruct);
                }
                else if (line.Contains("endif("))
                {
                    Instructions instruct = new Instructions(InstructionType.EndIf, null);
                    instructions.Add(instruct);
                }
                else if (line.Contains("endl("))
                {
                    Instructions instruct = new Instructions(InstructionType.Endl, null);
                    instructions.Add(instruct);
                }
                else if (line.Contains("endw("))
                {
                    Instructions instruct = new Instructions(InstructionType.Endw, null);
                    instructions.Add(instruct);
                }
                else if (line.Contains("endh("))
                {
                    Instructions instruct = new Instructions(InstructionType.Endh, null);
                    instructions.Add(instruct);
                }
                else if (line.Contains("switch("))
                {
                    string data = GetOneArgData(line);
                    Instructions instruct = new Instructions(InstructionType.Switch, data);
                    instructions.Add(instruct);
                }
                else if (line.Contains("case("))
                {
                    string data = GetOneArgData(line);
                    Instructions instruct = new Instructions(InstructionType.Case, data);
                    instructions.Add(instruct);
                }
                else if (line.Contains("cease"))
                {
                    Instructions instruct = new Instructions(InstructionType.Cease, null);
                    instructions.Add(instruct);
                }
                else if (line.Contains("whilst"))
                {
                    string data = GetOneArgData(line);
                    Instructions instruct = new Instructions(InstructionType.Whilst, data);
                    instructions.Add(instruct);
                }
                else if (line.Contains("elseif("))
                {
                    string data = GetOneArgData(line);
                    Instructions instruct = new Instructions(InstructionType.ElseIf, data);
                    instructions.Add(instruct);
                }
                else if (line.Contains("else("))
                {
                    string data = GetOneArgData(line);
                    Instructions instruct = new Instructions(InstructionType.Else, data);
                    instructions.Add(instruct);
                }
                else if (line.Contains("set("))
                {
                    ArgumentsAndOperation data = GetData(line);
                    Instructions instruct = new Instructions(InstructionType.Set, $"{data.arg1},{data.arg2}");
                    instructions.Add(instruct);
                }
                else if (line.Contains("out"))
                {
                    string data = GetOneArgData(line);
                    Instructions instruct = new Instructions(InstructionType.PrintOutInstruction, data);
                    instructions.Add(instruct);
                }
                else if (line.Contains("goto"))
                {
                    string data = GetOneArgData(line);
                    Instructions instruct = new Instructions(InstructionType.Goto, data);
                    instructions.Add(instruct);
                }
                else if (line.Contains("chkver("))
                {
                    string data = GetOneArgData(line);
                    Instructions instruct = new Instructions(InstructionType.CheckVersion, data);
                    instructions.Add(instruct);
                }
                else if (line.Contains("pause"))
                {
                    string data = GetOneArgData(line);
                    Instructions instruct = new Instructions(InstructionType.Pause, data);
                    instructions.Add(instruct);
                }
                else if (line.Contains("newline"))
                {
                    string data = GetOneArgData(line);
                    Instructions instruct = new Instructions(InstructionType.Outline, data);
                    instructions.Add(instruct);
                }
                else if (line.Contains("title"))
                {
                    string data = GetOneArgData(line);
                    Instructions instruct = new Instructions(InstructionType.Title, data);
                    instructions.Add(instruct);
                }
                else if (line.Contains("continue"))
                {
                    string data = GetOneArgData(line);
                    Instructions instruct = new Instructions(InstructionType.Continue, data);
                    instructions.Add(instruct);
                }
                else if (line.Contains("fileexists"))
                {
                    string data = GetOneArgData(line);
                    Instructions instruct = new Instructions(InstructionType.FileExists, data);
                    instructions.Add(instruct);
                }
                else if (line.Contains("info"))
                {
                    string data = GetOneArgData(line);
                    Instructions instruct = new Instructions(InstructionType.Info, data);
                    instructions.Add(instruct);
                }
                else if (line.Contains("sleep"))
                {
                    string data = GetOneArgData(line);
                    Instructions instruct = new Instructions(InstructionType.Sleep, data);
                    instructions.Add(instruct);
                }
                else if (line.Contains("enablevisualstyles"))
                {
                    string data = GetOneArgData(line);
                    Instructions instruct = new Instructions(InstructionType.EnableVisualStyles, data);
                    instructions.Add(instruct);
                }
                else if (line.Contains("try"))
                {
                    Instructions instruct = new Instructions(InstructionType.Attempt, null);
                    instructions.Add(instruct);
                }
                else if (line.Contains("finish"))
                {
                    Instructions instruct = new Instructions(InstructionType.Finish, null);
                    instructions.Add(instruct);
                }
                else if (line.Contains("increment"))
                {
                    string data = GetOneArgData(line);
                    Instructions instruct = new Instructions(InstructionType.Increment, data);
                    instructions.Add(instruct);
                }
                else if (line.Contains("decrement"))
                {
                    string data = GetOneArgData(line);
                    Instructions instruct = new Instructions(InstructionType.Decrement, data);
                    instructions.Add(instruct);
                }
                else if (line.Contains("next("))
                {
                    string data = GetOneArgData(line);
                    if (data != null) throw new ParseException($"next() does not take any parameters.");
                    Instructions instruct = new Instructions(InstructionType.Next, data);
                    instructions.Add(instruct);
                }
                else if (line.Contains("getCLArugments("))
                {
                    string data = GetOneArgData(line);
                    Instructions instruct = new Instructions(InstructionType.GetClArguments, data);
                    instructions.Add(instruct);
                }
                else if (line.Contains("getCLArugmentLength("))
                {
                    string data = GetOneArgData(line);
                    Instructions instruct = new Instructions(InstructionType.GetClArgumentsLength, data);
                    instructions.Add(instruct);
                }
                else if (line.Contains("length("))
                {
                    ArgumentsAndOperation data = GetData(line);
                    Instructions instruct = new Instructions(InstructionType.Length, $"{data.arg1},{data.arg2}");
                    instructions.Add(instruct);
                }
                else if (line.Contains("in("))
                {
                    ArgumentsAndOperation data = GetData(line);
                    Instructions instruct = new Instructions(InstructionType.In, $"{data.arg1},{data.arg2}");
                    instructions.Add(instruct);
                }
                else if (line.Contains("endr("))
                {
                    string data = GetOneArgData(line);
                    if (data != null) throw new ParseException($"endr does not take any parameters at {line}");
                    instructions.Add(new Instructions(InstructionType.Endr, data));
                }
                else if (line.Contains("if("))
                {
                    string data = GetOneArgData(line);
                    Instructions instruct = new Instructions(InstructionType.If, data);
                    instructions.Add(instruct);
                }
                else if (line.Contains("exit"))
                {
                    string data = GetOneArgData(line);
                    Instructions instruct = new Instructions(InstructionType.Exit, data);
                    instructions.Add(instruct);
                }
                else if (line.Contains("alert"))
                {
                    TwoArgumentsAndOperation data = GetMoreData(line);
                    Instructions instruct = new Instructions(InstructionType.Alert, $"{data.arg1},{data.arg2},{data.arg3}");
                    instructions.Add(instruct);
                }
                else if (line.Contains("except"))
                {
                    ArgumentsAndOperation data = GetData(line);
                    Instructions instruct = new Instructions(InstructionType.Except, $"{data.arg1},{data.arg2}");
                    instructions.Add(instruct);
                }
                else if (line.Contains("stop"))
                {
                    string data = GetOneArgData(line);
                    Instructions instruct = new Instructions(InstructionType.Stop, data);
                    instructions.Add(instruct);
                }
                else if (line.Contains("hide"))
                {
                    string data = GetOneArgData(line);
                    Instructions instruct = new Instructions(InstructionType.Hide, data);
                    instructions.Add(instruct);
                }
                else if (line.Contains("show"))
                {
                    string data = GetOneArgData(line);
                    Instructions instruct = new Instructions(InstructionType.Show, data);
                    instructions.Add(instruct);
                }
                else if (line.Contains("bfor("))
                {
                    ForData forLoop = ParseForLoopExpression(line);
                    Instructions instruct = new Instructions(InstructionType.Bfor, $"{forLoop.arrayVariableName},{forLoop.index},{forLoop.objectName}");
                    instructions.Add(instruct);
                }
                else if (line.Contains("for("))
                {
                    ForData forLoop = ParseForLoopExpression(line);
                    Instructions instruct = new Instructions(InstructionType.ForIn, $"{forLoop.arrayVariableName},{forLoop.index},{forLoop.objectName}");
                    instructions.Add(instruct);
                }
                else if (string.IsNullOrWhiteSpace(line) == true)
                {
                    continue;
                }
                else
                {
                    throw new ParseException($"Unknown command/operation at {line}");
                }
            }

            return instructions.ToArray();
        }

        private static ForData ParseForLoopExpression(string line)
        {
            bool beginGettingChars = false;
            bool success = false;
            bool switchCharToVariableIndex = false;
            bool switchCharToVariableName = false;

            string objectVariableName = null;
            string indexVariableName = null;
            string arrayVariableName = null;

            foreach (char ch in line)
            {
                if (ch == '(')
                {
                    if (beginGettingChars == true) throw new ParseException($"Character '(' is not allowed at {line}");
                    beginGettingChars = true;
                }
                else
                {
                    if (beginGettingChars == true)
                    {
                        if (ch == ')')
                        {
                            success = true;
                            break;
                        }
                        else if (ch == ':')
                        {
                            if (switchCharToVariableIndex == true) throw new ParseException($"Character ':' is not allowed twice at {line}");
                            switchCharToVariableIndex = true;
                        }
                        else if(ch == ',')
                        {
                            if (switchCharToVariableIndex == false) throw new ParseException($"Cannot parse array variable name until an index variable was parsed at {line}");
                            if (switchCharToVariableName == true) throw new ParseException($"Character ',' is not allowed twice at {line}");
                            switchCharToVariableName = true;
                        }
                        else if (ch == ' ') continue;
                        else
                        {
                            if (switchCharToVariableIndex == true)
                            {
                                if (switchCharToVariableName == true)
                                {
                                    arrayVariableName += ch;
                                }
                                else
                                {
                                    indexVariableName += ch;
                                }
                            }
                            else
                            {
                                objectVariableName += ch;
                            }
                        }
                    }
                }
            }

            if (success == false) throw new DataException($"Parsing the for loop at {line} failed because not enough data was given to the parser.");
            else
            {
                return new ForData(arrayVariableName, objectVariableName, indexVariableName);
            }
        }

        private static string GetOneArgData(string line)
        {
            bool beginGettingChars = false;
            bool success = false;
            string finalResult = null;

            foreach (char ch in line)
            {
                if (beginGettingChars == true)
                {
                    if (ch.ToString() == ")")
                    {
                        success = true;
                        break;
                    }
                    else
                    {
                        finalResult += ch.ToString();
                    }
                }
                else
                {
                    if (ch.ToString() == "(")
                    {
                        beginGettingChars = true;
                    }
                }
            }

            if (success == false)
            {
                throw new DataException($"Getting function data failed because not enough information was provided AT {line}");
            }
            return finalResult;
        }

        private static TwoArgumentsAndOperation GetMoreData(string line)
        {
            bool beginGettingChars = false;
            bool success = false;
            int getSecondArgument = 0;
            string finalResult = null;
            string argResult = null;
            string thirdResult = null;

            foreach (char ch in line)
            {
                if (beginGettingChars == true)
                {
                    if (ch.ToString() == ")")
                    {
                        success = true;
                        break;
                    }
                    else if (ch.ToString() == ",")
                    {
                        if (getSecondArgument == 0)
                        {
                            getSecondArgument = 1;
                        }
                        else if (getSecondArgument == 1)
                        {
                            getSecondArgument = 2;
                        }
                    }
                    else
                    {
                        if (getSecondArgument == 1)
                        {
                            argResult += ch.ToString();
                        }
                        else if(getSecondArgument == 2)
                        {
                            thirdResult += ch.ToString();
                        }
                        else
                        {
                            finalResult += ch.ToString();
                        }
                    }
                }
                else
                {
                    if (ch.ToString() == "(")
                    {
                        beginGettingChars = true;
                    }
                }
            }

            if (success == false || getSecondArgument < 2)
            {
                throw new DataException($"Getting function data failed because not enough information was provided. AT {line}");
            }
            return new TwoArgumentsAndOperation(finalResult, argResult, thirdResult);
        }

        private static ArgumentsAndOperation GetData(string line)
        {
            bool beginGettingChars = false;
            bool success = false;
            bool getSecondArgument = false;
            string finalResult = null;
            string argResult = null;

            foreach(char ch in line)
            {
                if(beginGettingChars == true)
                {
                    if(ch.ToString() == ")")
                    {
                        success = true;
                        break;
                    }
                    else if(ch.ToString() == ",")
                    {
                        getSecondArgument = true;
                    }
                    else
                    {
                        if (getSecondArgument == true)
                        {
                            argResult += ch.ToString();
                        }
                        else
                        {
                            finalResult += ch.ToString();
                        }
                    }
                }
                else
                {
                    if(ch.ToString() == "(")
                    {
                        beginGettingChars = true;
                    }
                }
            }

            if(success == false || getSecondArgument == false)
            {
                throw new DataException($"Getting function data failed because not enough information was provided. AT {line}");
            }
            return new ArgumentsAndOperation(finalResult, argResult);
        }
    }

    public struct TwoArgumentsAndOperation
    {
        public string arg1 { get; }
        public string arg2 { get; }
        public string arg3 { get; }

        public TwoArgumentsAndOperation(string arg1, string arg2, string arg3)
        {
            this.arg1 = arg1;
            this.arg2 = arg2;
            this.arg3 = arg3;
        }
    }

    public struct ArgumentsAndOperation
    {
        public string arg1 { get; }
        public string arg2 { get; }

        public ArgumentsAndOperation(string arg1, string arg2)
        {
            this.arg1 = arg1;
            this.arg2 = arg2;
        }
    }

    public struct Instructions
    {
        public InstructionType type { get; }
        public string data { get; }
        public bool isVariable { get; set; }

        public Instructions(InstructionType type, string data)
        {
            this.isVariable = false;
            this.type = type;
            this.data = data;
        }
    }

    public enum InstructionType
    {
        Multiplication,
        Subtraction,
        Addition,
        Division,
        Power,
        Modulo,
        Percent,
        Factorial,
        VariableChar,
        VariableNumber,
        VariableString,
        VariableBoolean,
        Pause,
        PrintOutInstruction,
        Outline,
        Title,
        Goto,
        Continue,
        FileExists,
        Sleep,
        Except,
        In,
        Stop,
        Hide,
        Show,
        Blur,
        Info,
        Exit,
        Alert,
        EnableVisualStyles,
        Attempt,
        Finish,
        VariableStringArray,
        VariableNumberArray,
        VariableCharArray,
        VariableBooleanArray,
        Set,
        RandomInt,
        Loop,
        LoopUntil,
        Endl,
        Cease,
        Whilst,
        Label,
        ToLabel,
        InfoAt, 
        Function,
        Endf,
        Insert,
        Run,
        Remove,
        Increment,
        Decrement,
        GetClArguments,
        GetClArgumentsLength,
        Length,
        If,
        EndIf,
        Else,
        ElseIf,
        Switch,
        Endw, // end of switch
        Case, // switch case
        Default, // the default case of a switch.
        Endh, // end of whilst
        Endr, // end of for
        ForIn,
        Next, // skip something inside for loop.
        CheckVersion,
        Bfor, // Similar to for block but rather than starting at index of 0, it starts at the end and goes down. Like a reverse for loop.
    }
}
