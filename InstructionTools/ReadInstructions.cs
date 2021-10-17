using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Math_Script_Runtime_Environment.Parsing;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using Math_Script_Runtime_Environment.Variables;
using Math_Script_Runtime_Environment.Arrays;
using System.Security.Cryptography;
using System.Text;
using Math_Script_Runtime_Environment.Crypto;
using Math_Script_Runtime_Environment.Labels;
using Math_Script_Runtime_Environment.Operators;
using Math_Script_Runtime_Environment.Functions;

namespace Math_Script_Runtime_Environment.InstructionsTools
{
    public class ReadInstructions
    {
        public static bool tryBlockActive = false;
        public static bool loopBlockActive = false;
        public static bool startReading = false;
        public static bool runningFunction = false;
        public static int loopUntil = -1;
        public static int loopLine = 0;
        public static int loopedUntil = 0;
        public static int lastUsedLineBeforeFunction = 0;
        public static string[] clArgs { get; private set; }
        public static int clLength { get; private set; }
        public static bool ifStatementReadBlockActive = false;
        public static bool ifStatmentActive = false;
        public static bool switchActive = false;
        public static string switchVariableData = null;
        public static bool breakSwitch = false;
        public static bool breakNextSwitch = false;
        public static bool whilstActive = false;
        public static string whilstConditionValue = null;
        public static int whilstLine = 0;
        public static Operator whilstOperator = null;

        public static void InitalizeArguments(string[] args, int argLength)
        {
            clArgs = args;
            clLength = argLength;
        }

        public static void BeginRead(Instructions[] instructions)
        {
            List<Variable> variables = new List<Variable>();
            List<ArrayVariable> arrayVariables = new List<ArrayVariable>();
            List<label> labels = new List<label>();
            List<Function> functions = new List<Function>();

            int index = 0;
            for (int i = 0; i < instructions.Length; i++)
            {
                Instructions instruction = instructions[i];
                if (instruction.type == InstructionType.Addition)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    string[] args = instruction.data.Split(',');
                    long arg1 = 0;
                    long arg2 = 0;
                    bool switchArg = false;

                    foreach (string arg in args)
                    {
                        try
                        {
                            if (switchArg == true)
                            {
                                arg2 = long.Parse(arg);
                            }
                            else
                            {
                                arg1 = long.Parse(arg);
                                switchArg = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error was found at {arg}. Error details: {ex.Message}");
                            break;
                        }
                    }
                    long finalAnswer = arg1 + arg2;
                    Console.WriteLine($"{index}: [Addition]: Answer => {finalAnswer}");
                    index++;
                }
                else if (instruction.type == InstructionType.Division)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    string[] args = instruction.data.Split(',');
                    long arg1 = 0;
                    long arg2 = 0;
                    bool switchArg = false;

                    foreach (string arg in args)
                    {
                        try
                        {
                            if (switchArg == true)
                            {
                                arg2 = long.Parse(arg);
                            }
                            else
                            {
                                arg1 = long.Parse(arg);
                                switchArg = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error was found at {arg}. Error details: {ex.Message}");
                            break;
                        }
                    }
                    long finalAnswer = arg1 / arg2;
                    Console.WriteLine($"{index}: [Division]: Answer => {finalAnswer}");
                    index++;
                }
                else if (instruction.type == InstructionType.Multiplication)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    string[] args = instruction.data.Split(',');
                    long arg1 = 0;
                    long arg2 = 0;
                    bool switchArg = false;

                    foreach (string arg in args)
                    {
                        try
                        {
                            if (switchArg == true)
                            {
                                arg2 = long.Parse(arg);
                            }
                            else
                            {
                                arg1 = long.Parse(arg);
                                switchArg = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error was found at {arg}. Error details: {ex.Message}");
                            break;
                        }
                    }
                    long finalAnswer = arg1 * arg2;
                    Console.WriteLine($"{index}: [Multiplication]: Answer => {finalAnswer}");
                    index++;
                }
                else if (instruction.type == InstructionType.Factorial)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    string[] args = instruction.data.Split(',');
                    long arg1 = 0;

                    foreach (string arg in args)
                    {
                        try
                        {
                            arg1 = long.Parse(arg);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error was found at {arg}. Error details: {ex.Message}");
                            break;
                        }
                    }
                    long finalAnswer = Factorial(arg1);
                    Console.WriteLine($"{index}: [Factorial]: Answer => {finalAnswer}");
                    index++;
                }
                else if (instruction.type == InstructionType.Modulo)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    string[] args = instruction.data.Split(',');
                    long arg1 = 0;
                    long arg2 = 0;
                    bool switchArg = false;

                    foreach (string arg in args)
                    {
                        try
                        {
                            if (switchArg == true)
                            {
                                arg2 = long.Parse(arg);
                            }
                            else
                            {
                                arg1 = long.Parse(arg);
                                switchArg = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error was found at {arg}. Error details: {ex.Message}");
                            break;
                        }
                    }
                    long finalAnswer = arg1 % arg2;
                    Console.WriteLine($"{index}: [Modulo]: Answer => {finalAnswer}");
                    index++;
                }
                else if (instruction.type == InstructionType.Power)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    string[] args = instruction.data.Split(',');
                    long arg1 = 0;
                    long arg2 = 0;
                    bool switchArg = false;

                    foreach (string arg in args)
                    {
                        try
                        {
                            if (switchArg == true)
                            {
                                arg2 = long.Parse(arg);
                            }
                            else
                            {
                                arg1 = long.Parse(arg);
                                switchArg = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error was found at {arg}. Error details: {ex.Message}");
                            break;
                        }
                    }
                    double finalAnswer = Math.Pow(double.Parse(arg1.ToString()), double.Parse(arg2.ToString()));
                    Console.WriteLine($"{index}: [Power]: Answer => {finalAnswer}");
                    index++;
                }
                else if (instruction.type == InstructionType.Subtraction)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    string[] args = instruction.data.Split(',');
                    long arg1 = 0;
                    long arg2 = 0;
                    bool switchArg = false;

                    foreach (string arg in args)
                    {
                        try
                        {
                            if (switchArg == true)
                            {
                                arg2 = long.Parse(arg);
                            }
                            else
                            {
                                arg1 = long.Parse(arg);
                                switchArg = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error was found at {arg}. Error details: {ex.Message}");
                            break;
                        }
                    }
                    long finalAnswer = arg1 - arg2;
                    Console.WriteLine($"{index}: [Subtraction]: Answer => {finalAnswer}");
                    index++;
                }
                else if (instruction.type == InstructionType.Percent)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    string[] args = instruction.data.Split(',');
                    long arg1 = 0;
                    long arg2 = 0;
                    bool switchArg = false;

                    foreach (string arg in args)
                    {
                        try
                        {
                            if (switchArg == true)
                            {
                                arg2 = long.Parse(arg);
                            }
                            else
                            {
                                arg1 = long.Parse(arg);
                                switchArg = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error was found at {arg}. Error details: {ex.Message}");
                            break;
                        }
                    }
                    double finalAnswer = arg1 / arg2 * 100;
                    Console.WriteLine($"{index}: [Percent]: Answer => {finalAnswer}%");
                    index++;
                }
                else if (instruction.type == InstructionType.VariableNumber)
                {
                    if (ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    string[] args = instruction.data.Split(',');
                    if (args[0].Length == 0)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"def(number, ?, ?) (EXPECTED INT) AT {i}");
                        }
                    }
                    if (args[1].Length == 0)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"def(number, {args[0]}, ?) (EXPECTED INT) AT {i}");
                        }
                    }
                    else
                    {
                        try
                        {
                            Variable newDefinition = new Variable(args[1].Replace(" ", ""), VariableType.Number, int.Parse(args[0].Replace(" ", "")).ToString());
                            variables.Add(newDefinition);
                        }
                        catch
                        {
                            if (tryBlockActive == true)
                            {
                                continue;
                            }
                            else
                            {
                                throw new ScriptException($"def(number, <NUMBER>, {args[1]}) (EXPECTED INT) AT {i}");
                            }
                        }
                    }
                }
                else if (instruction.type == InstructionType.VariableChar)
                {
                    if (ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    string[] args = instruction.data.Split(',');
                    if (args[0].Length == 0)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"def(character, ?, ?) (EXPECTED CHAR) AT {i}");
                        }
                    }
                    if (args[1].Length == 0)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"def(character, {args[0]}, ?) (EXPECTED CHAR) AT {i}");
                        }
                    }
                    else
                    {
                        try
                        {
                            Variable newDefinition = new Variable(args[1].Replace(" ", ""), VariableType.Char, char.Parse(args[0].Replace(" ", "")).ToString());
                            variables.Add(newDefinition);
                        }
                        catch
                        {
                            if (tryBlockActive == true)
                            {
                                continue;
                            }
                            else
                            {
                                throw new ScriptException($"def(character, <CHARACTER>, {args[1]}) (EXPECTED CHAR) AT {i}");
                            }
                        }
                    }
                }
                else if (instruction.type == InstructionType.VariableBoolean)
                {
                    if (ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    string[] args = instruction.data.Split(',');
                    if (args[0].Length == 0)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"def(boolean, ?, ?) (EXPECTED BOOLEAN) AT {i}");
                        }
                    }
                    if (args[1].Length == 0)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"def(boolean, {args[0]}, ?) (EXPECTED STRING) AT {i}");
                        }
                    }
                    else
                    {
                        try
                        {
                            Variable newDefinition = new Variable(args[1].Replace(" ", ""), VariableType.Boolean, bool.Parse(args[0].Replace(" ", "")).ToString());
                            variables.Add(newDefinition);
                        }
                        catch
                        {
                            if (tryBlockActive == true)
                            {
                                continue;
                            }
                            else
                            {
                                throw new ScriptException($"def(boolean, <BOOLEAN>, {args[1]}) (BOOLEAN EXPECTED) AT {i}");
                            }
                        }
                    }
                }
                else if (instruction.type == InstructionType.VariableString)
                {
                    if (ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    string[] args = instruction.data.Split(',');
                    if (args[0].Length == 0)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"def(string, ?, ?) (EXPECTED STRING) AT {i}");
                        }
                    }
                    if (args[1].Length == 0)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"def(string, {args[0]}, ?) (EXPECTED STRING) AT {i}");
                        }
                    }
                    else
                    {
                        Variable newDefinition = new Variable(args[1].Replace(" ", ""), VariableType.String, args[0].Replace(" ", ""));
                        variables.Add(newDefinition);
                    }
                }
                else if (instruction.type == InstructionType.VariableNumberArray)
                {
                    if (ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    string[] args = instruction.data.Split(',');
                    if (args[0].Length == 0)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"def(number#, ?, ?) (EXPECTED INT) AT {i}");
                        }
                    }
                    if (args[1].Length == 0)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"def(number#, ?, ?) (EXPECTED STRING) AT {i}");
                        }
                    }
                    else
                    {
                        ArrayVariable newDefiniton = new ArrayVariable(int.Parse(args[0]), VariableType.Number, args[1]);
                        arrayVariables.Add(newDefiniton);
                    }
                }
                else if (instruction.type == InstructionType.VariableStringArray)
                {
                    if (ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    string[] args = instruction.data.Split(',');
                    if (args[0].Length == 0)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"def(number#, ?, ?) (EXPECTED INT) AT {i}");
                        }
                    }
                    if (args[1].Length == 0)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"def(number#, ?, ?) (EXPECTED STRING) AT {i}");
                        }
                    }
                    else
                    {
                        ArrayVariable newDefiniton = new ArrayVariable(int.Parse(args[0]), VariableType.String, args[1]);
                        arrayVariables.Add(newDefiniton);
                    }
                }
                else if (instruction.type == InstructionType.Pause)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                }
                else if (instruction.type == InstructionType.Attempt)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    tryBlockActive = true;
                }
                else if (instruction.type == InstructionType.Finish)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    if (tryBlockActive == false)
                    {
                        throw new ScriptException($"finish() (EXPECTED ACTIVE TRY BLOCK) AT {i}");
                    }
                    else
                    {
                        tryBlockActive = false;
                    }
                }
                else if (instruction.type == InstructionType.Info)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    bool success = false;
                    foreach (Variable var in variables)
                    {
                        if (var.name == instruction.data)
                        {
                            Console.Write(var.value);
                            success = true;
                            break;
                        }
                    }
                    if (success == false)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"info({instruction.data}) (EXPECTED VARIABLE DECLARATION) AT {i}");
                        }
                    }
                }
                else if (instruction.type == InstructionType.PrintOutInstruction)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }
                    else
                    {
                        Console.Write(instruction.data);
                    }
                }
                else if (instruction.type == InstructionType.Outline)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    Console.Write("\n");
                }
                else if (instruction.type == InstructionType.InfoAt)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    if (instruction.data.Length == 0)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"infoAt(?,?) (EXPECTED VARIABLE#INDEX) AT {i}");
                        }
                    }
                    try
                    {
                        if (instruction.data.Contains("${"))
                        {
                            string variableIndex = instruction.data.Replace("${", "").Replace("}", "");
                            ArrayVariableAndIndex cleanedIndex = GetIndexVariable(variableIndex);
                            string variableData = ReadVariableInformation(cleanedIndex.index, i, variables.ToArray(), arrayVariables.ToArray());
                            string finalVariable = $"{cleanedIndex.arrayName}#{variableData}";
                            string data = ReadVariableInformation(finalVariable, i, variables.ToArray(), arrayVariables.ToArray());
                            Console.Write(data);
                        }
                        else
                        {
                            string data = ReadVariableInformation(instruction.data, i, variables.ToArray(), arrayVariables.ToArray());
                            Console.Write(data);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            if (ex.Message.Contains("The array does not contain any index that matches"))
                            {
                                throw new ScriptException($"infoAt({instruction.data}) (EXPECTED VALID INDEX) AT {i}");
                            }
                            else
                            {
                                throw new ScriptException($"infoAt({instruction.data}) (EXPECTED VARIABLE DECLARATION) AT {i}");
                            }
                        }
                    }
                }
                else if (instruction.type == InstructionType.ToLabel)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    bool success = false;
                    foreach (label label in labels)
                    {
                        if (label.name == instruction.data)
                        {
                            i = label.line;
                            success = true;
                            break;
                        }
                    }
                    if (success == false)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"toLabel(?) (EXPECTED LABEL DECLARATON) AT {i}");
                        }
                    }
                }
                else if (instruction.type == InstructionType.Label)
                {
                    if (ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    bool success = true;
                    foreach (label existinglabel in labels)
                    {
                        if (existinglabel.name == instruction.data)
                        {
                            success = false;
                            break;
                        }
                    }
                    if (success == false)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"label(?) (VARIABLE ALREADY DEFINED) AT {i}");
                        }
                    }
                    else
                    {
                        label label = new label(instruction.data, i);
                        labels.Add(label);
                    }
                }
                else if (instruction.type == InstructionType.Loop)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    if (loopBlockActive == true)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"loop() (ACTIVE LOOP ALREADY ACTIVE) AT {i}");
                        }
                    }
                    else
                    {
                        loopBlockActive = true;
                        loopUntil = -1;
                        loopLine = i;
                    }
                }
                else if (instruction.type == InstructionType.Endl)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    if (loopBlockActive == true)
                    {
                        if (loopLine != -1)
                        {
                            if (loopUntil == loopedUntil)
                            {
                                loopBlockActive = false;
                                loopedUntil = 0;
                                loopLine = 0;
                                loopUntil = -1;
                            }
                            else
                            {
                                loopedUntil++;
                                i = loopLine;
                            }
                        }
                        else
                        {
                            i = loopLine;
                        }
                    }
                    else
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"endl() (EXPECTED ACTIVE LOOP BEFORE EXECUTION) AT {i}");
                        }
                    }
                }
                else if (instruction.type == InstructionType.Cease)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        if (startReading == false)
                        {
                            continue;
                        }
                    }

                    if (loopBlockActive == true)
                    {
                        loopBlockActive = true;
                        loopLine = 0;
                        loopUntil = 0;
                    }
                    else
                    {
                        if (switchActive == true)
                        {
                            ifStatementReadBlockActive = true;
                            breakNextSwitch = true;
                            breakSwitch = true;
                        }
                        else
                        {
                            if (tryBlockActive == true)
                            {
                                continue;
                            }
                            else
                            {
                                throw new ScriptException($"cease() (EXPECTED ACTIVE LOOP OR SWITCH BEFORE EXECUTION) AT {i}");
                            }
                        }
                    }
                }
                else if (instruction.type == InstructionType.LoopUntil)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    if (loopBlockActive == true)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"loopuntil() (AN ACTIVE LOOP IS ALREADY ACTIVE)");
                        }
                    }
                    else
                    {
                        try
                        {
                            if (instruction.data.Contains("${"))
                            {
                                string variable = instruction.data.Replace("${", "").Replace("}", "");
                                string getData = ReadVariableInformation(variable, i, variables.ToArray(), arrayVariables.ToArray());
                                loopBlockActive = true;
                                loopUntil = int.Parse(getData);
                                loopLine = i;
                            }
                            else
                            {
                                loopBlockActive = true;
                                loopUntil = int.Parse(instruction.data);
                                loopLine = i;
                            }
                        }
                        catch
                        {
                            if (tryBlockActive == true)
                            {
                                continue;
                            }
                            else
                            {
                                throw new ScriptException($"loopuntil(?) (EXPECTED INT) AT {i}");
                            }
                        }
                    }
                }
                else if (instruction.type == InstructionType.RandomInt)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    string[] args = instruction.data.Split(',');
                    if (args[0].Length == 0)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"randomint(?,?) (EXPECTED VARIABLE) AT {i}");
                        }
                    }
                    if (args[1].Length == 0)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"randomint({args[0]},?) (EXPECTED VALUE) AT {i}");
                        }
                    }

                    bool success = false;
                    foreach (Variable var in variables)
                    {
                        if (var.name == args[0])
                        {
                            try
                            {
                                Random random = new Random();
                                int value = random.Next(0, int.Parse(args[1]));
                                success = true;
                                variables.Remove(var);
                                Variable newDeclaration = new Variable(var.name, var.type, value.ToString());
                                variables.Add(newDeclaration);
                                break;
                            }
                            catch
                            {
                                if (tryBlockActive == true)
                                {
                                    continue;
                                }
                                else
                                {
                                    throw new ScriptException($"randomint({args[0]},?) (EXPECTED INT) AT {i}");
                                }
                            }
                        }
                    }
                    if (success == false)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"randomint({args[0]}, ?) (EXPECTED VARIABLE DELCARATION) AT {i}");
                        }
                    }
                }
                else if (instruction.type == InstructionType.Set)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    string[] args = instruction.data.Split(',');
                    if (args[0].Length == 0)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"set(?,?) (EXPECTED VARIABLE) AT {i}");
                        }
                    }
                    if (args[1].Length == 0)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"set({args[0]},?) (EXPECTED VALUE) AT {i}");
                        }
                    }

                    bool success = false;
                    foreach (Variable var in variables)
                    {
                        if (var.name == args[0])
                        {
                            success = true;
                            variables.Remove(var);
                            Variable newDeclaration = new Variable(var.name, var.type, args[1]);
                            variables.Add(newDeclaration);
                            break;
                        }
                    }
                    if (success == false)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"set({args[0]}, ?) (EXPECTED VARIABLE DELCARATION) AT {i}");
                        }
                    }
                }
                else if (instruction.type == InstructionType.Exit)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    if (instruction.data.Length > 0)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ParameterException($"exit({instruction.data}) DOES NOT TAKE PARAMETERS AT {i}");
                        }
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
                else if (instruction.type == InstructionType.Alert)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    string[] args = instruction.data.Split(',');
                    if (args[0] == "notice")
                    {
                        string message = args[1];
                        string title = args[2];
                        bool success = false;
                        bool success2 = false;
                        bool variablesDetected = false;

                        if (args[1].Contains("${"))
                        {
                            variablesDetected = true;
                            foreach (Variable var in variables)
                            {
                                if (var.name == args[1].Replace("${", "").Replace("}", ""))
                                {
                                    success = true;
                                    message = var.value;
                                    variablesDetected = false;
                                    break;
                                }
                            }
                        }
                        if (args[2].Contains("${"))
                        {
                            variablesDetected = true;
                            foreach (Variable var in variables)
                            {
                                if (var.name == args[2].Replace("${", "").Replace("}", ""))
                                {
                                    success2 = true;
                                    title = var.value;
                                    variablesDetected = false;
                                    break;
                                }
                            }
                        }

                        if (success == false || success2 == false)
                        {
                            if (variablesDetected == true)
                            {
                                if (tryBlockActive == true)
                                {
                                    continue;
                                }
                                else
                                {
                                    throw new ScriptException($"alert({args[0]}, {args[1]}, {args[2]}) (EXPECTED VARIABLE DECLARATION) AT {i}");
                                }
                            }
                        }

                        MessageBox.Show($"{message}", $"{title}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (args[0] == "error")
                    {
                        string message = args[1];
                        string title = args[2];
                        bool success = false;
                        bool success2 = false;
                        bool variablesDetected = false;

                        if (args[1].Contains("${"))
                        {
                            variablesDetected = true;
                            foreach (Variable var in variables)
                            {
                                if (var.name == args[1].Replace("${", "").Replace("}", ""))
                                {
                                    success = true;
                                    message = var.value;
                                    variablesDetected = false;
                                    break;
                                }
                            }
                        }
                        if (args[2].Contains("${"))
                        {
                            variablesDetected = true;
                            foreach (Variable var in variables)
                            {
                                if (var.name == args[2].Replace("${", "").Replace("}", ""))
                                {
                                    success2 = true;
                                    title = var.value;
                                    variablesDetected = false;
                                    break;
                                }
                            }
                        }

                        if (success == false || success2 == false)
                        {
                            if (variablesDetected == true)
                            {
                                if (tryBlockActive == true)
                                {
                                    continue;
                                }
                                else
                                {
                                    throw new ScriptException($"alert({args[0]}, {args[1]}, {args[2]}) (EXPECTED VARIABLE DECLARATION) AT {i}");
                                }
                            }
                        }

                        MessageBox.Show($"{message}", $"{title}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (args[0] == "warning")
                    {
                        string message = args[1];
                        string title = args[2];
                        bool success = false;
                        bool success2 = false;
                        bool variablesDetected = false;

                        if (args[1].Contains("${"))
                        {
                            variablesDetected = true;
                            foreach (Variable var in variables)
                            {
                                if (var.name == args[1].Replace("${", "").Replace("}", ""))
                                {
                                    success = true;
                                    message = var.value;
                                    variablesDetected = false;
                                    break;
                                }
                            }
                        }
                        if (args[2].Contains("${"))
                        {
                            variablesDetected = true;
                            foreach (Variable var in variables)
                            {
                                if (var.name == args[2].Replace("${", "").Replace("}", ""))
                                {
                                    success2 = true;
                                    title = var.value;
                                    variablesDetected = false;
                                    break;
                                }
                            }
                        }

                        if (success == false || success2 == false)
                        {
                            if (variablesDetected == true)
                            {
                                if (tryBlockActive == true)
                                {
                                    continue;
                                }
                                else
                                {
                                    throw new ScriptException($"alert({args[0]}, {args[1]}, {args[2]}) (EXPECTED VARIABLE DECLARATION) AT {i}");
                                }
                            }
                        }

                        MessageBox.Show($"{message}", $"{title}", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (args[0] == "question")
                    {
                        string message = args[1];
                        string title = args[2];
                        bool success = false;
                        bool success2 = false;
                        bool variablesDetected = false;

                        if (args[1].Contains("${"))
                        {
                            variablesDetected = true;
                            foreach (Variable var in variables)
                            {
                                if (var.name == args[1].Replace("${", "").Replace("}", ""))
                                {
                                    success = true;
                                    message = var.value;
                                    variablesDetected = false;
                                    break;
                                }
                            }
                        }
                        if (args[2].Contains("${"))
                        {
                            variablesDetected = true;
                            foreach (Variable var in variables)
                            {
                                if (var.name == args[2].Replace("${", "").Replace("}", ""))
                                {
                                    success2 = true;
                                    title = var.value;
                                    variablesDetected = false;
                                    break;
                                }
                            }
                        }

                        if (success == false || success2 == false)
                        {
                            if (variablesDetected == true)
                            {
                                if (tryBlockActive == true)
                                {
                                    continue;
                                }
                                else
                                {
                                    throw new ScriptException($"alert({args[0]}, {args[1]}, {args[2]}) (EXPECTED VARIABLE DECLARATION) AT {i}");
                                }
                            }
                        }

                        MessageBox.Show($"{message}", $"{title}", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else if (args[0] == "none")
                    {
                        string message = args[1];
                        string title = args[2];
                        bool success = false;
                        bool success2 = false;
                        bool variablesDetected = false;

                        if (args[1].Contains("${"))
                        {
                            variablesDetected = true;
                            foreach (Variable var in variables)
                            {
                                if (var.name == args[1].Replace("${", "").Replace("}", ""))
                                {
                                    success = true;
                                    message = var.value;
                                    variablesDetected = false;
                                    break;
                                }
                            }
                        }
                        if (args[2].Contains("${"))
                        {
                            variablesDetected = true;
                            foreach (Variable var in variables)
                            {
                                if (var.name == args[2].Replace("${", "").Replace("}", ""))
                                {
                                    success2 = true;
                                    title = var.value;
                                    variablesDetected = false;
                                    break;
                                }
                            }
                        }

                        if (success == false || success2 == false)
                        {
                            if (variablesDetected == true)
                            {
                                if (tryBlockActive == true)
                                {
                                    continue;
                                }
                                else
                                {
                                    throw new ScriptException($"alert({args[0]}, {args[1]}, {args[2]}) (EXPECTED VARIABLE DECLARATION) AT {i}");
                                }
                            }
                        }

                        MessageBox.Show($"{message}", $"{title}", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    else
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"alert(?, {args[1]}, {args[2]}) (EXPECTED VAILD WIN32 ICON NAME) AT {i}");
                        }
                    }
                }
                else if (instruction.type == InstructionType.Hide)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    Program.HideConsole();
                }
                else if (instruction.type == InstructionType.Show)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    Program.ShowConsole();
                }
                else if (instruction.type == InstructionType.Blur)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    if (instruction.data.Length == 0)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"blur(?) (EXPECTED VARIABLE) AT {i}");
                        }
                    }
                    bool success = false;
                    foreach (Variable var in variables)
                    {
                        if (var.name == instruction.data)
                        {
                            variables.Remove(var);
                            success = true;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (success == false)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"blur({instruction.data}) (EXPECTED VARIABLE DECLARATION) AT {i}");
                        }
                    }
                }
                else if (instruction.type == InstructionType.Stop)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    if (instruction.data.Length == 0)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"stop(NULL) (EXPECTED INT) AT {i}");
                        }
                    }
                    else
                    {
                        try
                        {
                            Environment.Exit(int.Parse(instruction.data));
                        }
                        catch
                        {
                            if (tryBlockActive == true)
                            {
                                continue;
                            }
                            else
                            {
                                throw new ScriptException($"stop({instruction.data}) (EXPECTED INT) AT {i}");
                            }
                        }
                    }
                }
                else if (instruction.type == InstructionType.In)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    string[] args = instruction.data.Split(',');
                    if (args[0].Length == 0)
                    {
                        throw new ScriptException($"in(?,?) (EXPECTED FORMAT) AT {i}");
                    }
                    if (args[1].Length == 0)
                    {
                        throw new ScriptException($"in({args[0]},?) (EXPECTED VARIABLE) AT {i}");
                    }

                    bool success = false;
                    Variable variable = new Variable();
                    foreach (Variable var in variables)
                    {
                        if (var.name == args[1])
                        {
                            success = true;
                            variable = var;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (success == false)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"in({args[0]},?) (EXPECTED VARIABLE DECLARATION)");
                        }
                    }
                    if (args[0] == "%str")
                    {
                        try
                        {
                            string input = Console.ReadLine();
                            variables.Remove(variable);
                            Variable var = new Variable(variable.name, variable.type, input);
                            variables.Add(var);
                        }
                        catch
                        {
                            if (tryBlockActive == true)
                            {
                                continue;
                            }
                            else
                            {
                                throw new ParameterException($"in({instruction.data}) (EXPECTED STRING) AT {i}");
                            }
                        }
                    }
                    else if (args[0] == "%int")
                    {
                        try
                        {
                            int input = int.Parse(Console.ReadLine());
                            variables.Remove(variable);
                            Variable var = new Variable(variable.name, variable.type, input.ToString());
                            variables.Add(var);
                        }
                        catch
                        {
                            if (tryBlockActive == true)
                            {
                                continue;
                            }
                            else
                            {
                                throw new ParameterException($"in({instruction.data}) (EXPECTED INT) AT {i}");
                            }
                        }
                    }
                    else if (args[0] == "%bool")
                    {
                        try
                        {
                            bool input = bool.Parse(Console.ReadLine());
                            variables.Remove(variable);
                            Variable var = new Variable(variable.name, variable.type, input.ToString());
                            variables.Add(var);
                        }
                        catch
                        {
                            if (tryBlockActive == true)
                            {
                                continue;
                            }
                            else
                            {
                                throw new ParameterException($"in({instruction.data}) (EXPECTED BOOLEAN) AT {i}");
                            }
                        }
                    }
                    else if (args[0] == "%char")
                    {
                        try
                        {
                            char input = char.Parse(Console.ReadLine());
                            variables.Remove(variable);
                            Variable var = new Variable(variable.name, variable.type, input.ToString());
                            variables.Add(var);
                        }
                        catch
                        {
                            if (tryBlockActive == true)
                            {
                                continue;
                            }
                            else
                            {
                                throw new ParameterException($"in({instruction.data}) (EXPECTED CHAR) AT {i}");
                            }
                        }
                    }
                }
                else if (instruction.type == InstructionType.Except)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    string[] args = instruction.data.Split(',');
                    if (args[0] == "STANDARD_EXCEPTION")
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new Exception($"{args[1]} AT {i}");
                        }
                    }
                    else if (args[0] == "SCRIPT_EXCEPTION")
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"{args[1]} AT {i}");
                        }
                    }
                    else if (args[0] == "MEM_EXHAUSTED_EXCEPTION")
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new OutOfMemoryException($"{args[1]} AT {i}");
                        }
                    }
                    else if (args[0] == "OVERFLOW_EXCEPTION")
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new OverflowException($"{args[1]} AT {i}");
                        }
                    }
                    else if (args[0] == "ARG_EXCEPTION")
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ArgumentException($"{args[1]} AT {i}");
                        }
                    }
                    else if (args[0] == "ARG_NULL_EXCEPTION")
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ArgumentNullException($"{args[1]} AT {i}");
                        }
                    }
                    else if (args[0] == "NULLREF_EXCEPTION")
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new NullReferenceException($"{args[1]} AT {i}");
                        }
                    }
                }
                else if (instruction.type == InstructionType.Title)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    Console.Title = instruction.data;
                }
                else if (instruction.type == InstructionType.Goto)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    i = int.Parse(instruction.data);
                }
                else if (instruction.type == InstructionType.Continue)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    continue;
                }
                else if (instruction.type == InstructionType.Sleep)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    int timeOut = int.Parse(instruction.data);
                    System.Threading.Thread.Sleep(timeOut);
                }
                else if (instruction.type == InstructionType.EnableVisualStyles)
                {
                    if (ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    Application.EnableVisualStyles();
                }
                else if (instruction.type == InstructionType.getpermissions)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    Process proc = new Process();
                    proc.StartInfo.FileName = Assembly.GetExecutingAssembly().Location;
                    proc.StartInfo.UseShellExecute = true;
                    proc.StartInfo.Verb = "runas";
                    proc.StartInfo.UseShellExecute = true;
                    try
                    {
                        proc.Start();
                    }
                    catch
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptEngineException($"getpermissions() (EXPECTED BOOLEAN TRUE) AT {i}");
                        }
                    }
                }
                else if (instruction.type == InstructionType.FileExists)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    if (File.Exists(instruction.data) == true)
                    {
                        Console.Write(true);
                    }
                    else
                    {
                        Console.Write(false);
                    }
                }
                else if (instruction.type == InstructionType.Function)
                {
                    if (ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    if (instruction.data == "main")
                    {
                        if (startReading == true)
                        {
                            if (tryBlockActive == true)
                            {
                                continue;
                            }
                            else
                            {
                                throw new ScriptException($"function(main) (RESERVED FUNCTION NAME ALREADY HAS BEEN DECLARED) AT {i}");
                            }
                        }
                        else
                        {
                            startReading = true;
                        }
                    }
                    else
                    {
                        bool success = true;
                        foreach (Function function in functions)
                        {
                            if (function.name == instruction.data)
                            {
                                success = false;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        if (success == false)
                        {
                            if (tryBlockActive == true)
                            {
                                continue;
                            }
                            else
                            {
                                throw new ScriptException($"function({instruction.data}) (FUNCTION ALREADY DECLARED) AT {i}");
                            }
                        }
                        else
                        {
                            Function function = new Function(instruction.data, i);
                            functions.Add(function);
                        }
                    }
                }
                else if (instruction.type == InstructionType.Endf)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    if (runningFunction != true)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"endf() (EXPECTED ACTIVE FUNCTION) AT {i}");
                        }
                    }
                    runningFunction = false;
                    i = lastUsedLineBeforeFunction;
                }
                else if (instruction.type == InstructionType.Run)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    bool success = false;
                    Function functionToExecute = new Function();
                    foreach (Function function in functions)
                    {
                        if (function.name == instruction.data)
                        {
                            success = true;
                            functionToExecute = function;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (success == false)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"run({instruction.data}) (EXPECTED FUNCTION DECLARATION) AT {i}");
                        }
                    }
                    else
                    {
                        runningFunction = true;
                        lastUsedLineBeforeFunction = i;
                        i = functionToExecute.line;
                    }
                }
                else if (instruction.type == InstructionType.Insert)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    string[] args = instruction.data.Split(',');
                    if (args[0].Length == 0)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"insert(?,?) (EXPECTED VARIABLE ARRAY) AT {i}");
                        }
                    }
                    if (args[1].Length == 0)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"insert({args[0]},?) (EXPECTED STRING) AT {i}");
                        }
                    }
                    ArrayVariable variable = null;
                    bool success = false;

                    foreach (ArrayVariable var in arrayVariables)
                    {
                        if (var.name == args[0])
                        {
                            success = true;
                            variable = var;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (success == false)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"insert(?,{args[1]}) (EXPECTED VARIABLE ARRAY DECLARATION) AT {i}");
                        }
                    }
                    if (variable.type == VariableType.String)
                    {
                        variable.Add(new Variable(null, VariableType.String, args[1]), i);
                    }
                    else if (variable.type == VariableType.Number)
                    {
                        variable.Add(new Variable(null, VariableType.Number, args[1]), i);
                    }
                    else if (variable.type == VariableType.Char)
                    {
                        variable.Add(new Variable(null, VariableType.Char, args[1]), i);
                    }
                    else if (variable.type == VariableType.Boolean)
                    {
                        variable.Add(new Variable(null, VariableType.Boolean, args[1]), i);
                    }
                }
                else if (instruction.type == InstructionType.Remove)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    string[] args = instruction.data.Split(',');
                    if (args[0].Length == 0)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"remove(?,?) (EXPECTED VARIABLE) AT {i}");
                        }
                    }
                    if (args[1].Length == 0)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"remove({args[0]},?) (EXPECTED INDEX)");
                        }
                    }
                    ArrayVariable variable = null;
                    bool success = false;
                    foreach (ArrayVariable var in arrayVariables)
                    {
                        if (var.name == args[0])
                        {
                            variable = var;
                            success = true;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (success == false)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"remove(?,{args[1]} (EXPECTED VARIABLE DECLARATION) AT {i}");
                        }
                    }
                    try
                    {
                        variable.Remove(int.Parse(args[1]));
                    }
                    catch
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"remove({args[0]},?) (EXPECTED INDEX WITHIN ARRAY) AT {i}");
                        }
                    }
                }
                else if (instruction.type == InstructionType.Increment)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    if (instruction.data.Length == 0)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"increment(?) (EXPECTED VARIABLE) AT {i}");
                        }
                    }

                    VariableInformation vardata = ReadVariable(instruction.data, i, variables.ToArray(), arrayVariables.ToArray());
                    if (vardata.isInArray == true)
                    {
                        if (vardata.var.type == VariableType.Number)
                        {
                            arrayVariables.Remove(vardata.array);
                            int newValue = int.Parse(vardata.value) + 1;
                            Variable varObject = new Variable(vardata.name, vardata.var.type, newValue.ToString());
                            vardata.array.Remove(vardata.index);
                            vardata.array.Add(varObject, i);
                            arrayVariables.Add(vardata.array);
                        }
                        else
                        {
                            if (tryBlockActive == true)
                            {
                                continue;
                            }
                            else
                            {
                                throw new ScriptException($"increment(?) (EXPECTED NUMBER VARIABLE) AT {i}");
                            }
                        }
                    }
                    else
                    {
                        if (vardata.var.type == VariableType.Number)
                        {
                            variables.Remove(vardata.var);
                            int newValue = int.Parse(vardata.value) + 1;
                            Variable newVariable = new Variable(vardata.name, vardata.var.type, newValue.ToString());
                            variables.Add(newVariable);
                        }
                        else
                        {
                            if (tryBlockActive == true)
                            {
                                continue;
                            }
                            else
                            {
                                throw new ScriptException($"increment(?) (EXPECTED NUMBER VARIABLE) AT {i}");
                            }
                        }
                    }
                }
                else if (instruction.type == InstructionType.Decrement)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    if (instruction.data.Length == 0)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"increment(?) (EXPECTED VARIABLE) AT {i}");
                        }
                    }

                    VariableInformation vardata = ReadVariable(instruction.data, i, variables.ToArray(), arrayVariables.ToArray());
                    if (vardata.isInArray == true)
                    {
                        if (vardata.var.type == VariableType.Number)
                        {
                            arrayVariables.Remove(vardata.array);
                            int newValue = int.Parse(vardata.value) - 1;
                            Variable varObject = new Variable(vardata.name, vardata.var.type, newValue.ToString());
                            vardata.array.Remove(vardata.index);
                            vardata.array.Add(varObject, i);
                            arrayVariables.Add(vardata.array);
                        }
                        else
                        {
                            if (tryBlockActive == true)
                            {
                                continue;
                            }
                            else
                            {
                                throw new ScriptException($"increment(?) (EXPECTED NUMBER VARIABLE) AT {i}");
                            }
                        }
                    }
                    else
                    {
                        if (vardata.var.type == VariableType.Number)
                        {
                            variables.Remove(vardata.var);
                            int newValue = int.Parse(vardata.value) - 1;
                            Variable newVariable = new Variable(vardata.name, vardata.var.type, newValue.ToString());
                            variables.Add(newVariable);
                        }
                        else
                        {
                            if (tryBlockActive == true)
                            {
                                continue;
                            }
                            else
                            {
                                throw new ScriptException($"increment(?) (EXPECTED NUMBER VARIABLE) AT {i}");
                            }
                        }
                    }
                }
                else if (instruction.type == InstructionType.GetClArguments)
                {
                    if (ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    ArrayVariable var = null;
                    bool success = false;

                    foreach (ArrayVariable array in arrayVariables)
                    {
                        if (array.name == instruction.data)
                        {
                            var = array;
                            success = true;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    if (success == false)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"getCLArugments(?) (EXPECTED VARIABLE ARRAY DECLARATION) AT {i}");
                        }
                    }

                    if (var.type == VariableType.String)
                    {
                        arrayVariables.Remove(var);
                        foreach (string arg in clArgs)
                        {
                            var.Empty();
                            var.Add(new Variable(null, VariableType.String, arg), i);
                        }
                        arrayVariables.Add(var);
                    }
                    else
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"getCLArugments(?) (EXPECTED STRING ARRAY) AT {i}");
                        }
                    }
                }
                else if (instruction.type == InstructionType.GetClArgumentsLength)
                {
                    if (ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    if (instruction.data.Length == 0)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"getCLArugments(?) (EXPECTED VARIABLE) AT {i}");
                        }
                    }
                    Variable variable = new Variable();
                    bool success = false;

                    foreach (Variable var in variables)
                    {
                        if (var.name == instruction.data)
                        {
                            success = true;
                            variable = var;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (success == false)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"getCLArugmentLength(?) (EXPECTED VARIABLE DECLARATION) AT {i}");
                        }
                    }
                    if (variable.type == VariableType.Number)
                    {
                        variables.Remove(variable);
                        Variable newVariable = new Variable(variable.name, VariableType.Number, clLength.ToString());
                        variables.Add(newVariable);
                    }
                    else
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"getCLArugmentLength(?) (EXPECTED INT VARIABLE) AT {i}");
                        }
                    }
                }
                else if (instruction.type == InstructionType.Length)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    string[] args = instruction.data.Split(',');
                    if (args[0].Length == 0)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"length(?) (EXPECTED VARIABLE ARRAY)");
                        }
                    }
                    if (args[1].Length == 0)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"length(?) (EXPECTED VARIABLE) {i}");
                        }
                    }
                    ArrayVariable variable = null;
                    bool success = false;

                    foreach (ArrayVariable var in arrayVariables)
                    {
                        if (var.name == args[0])
                        {
                            success = true;
                            variable = var;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (success == false)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"length(?) (EXPECTED VARIABLE ARRAY DECLARATION) AT {i}");
                        }
                    }

                    bool success1 = false;
                    foreach (Variable var in variables)
                    {
                        if (var.name == args[1])
                        {
                            success1 = true;
                            variables.Remove(var);
                            Variable newVariable = new Variable(var.name, VariableType.Number, variable.length.ToString());
                            variables.Add(newVariable);
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (success1 == false)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"length(?) (EXPECTED VARIABLE DECLARATION) AT {i}");
                        }
                    }
                }
                else if (instruction.type == InstructionType.If)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    ifStatmentActive = true;
                    Operator opt = Parse.ParseOperationsFromLine(instruction.data);
                    if (opt.type == OperatorType.Divide)
                    {
                        long ans = long.Parse(opt.arg1) / long.Parse(opt.arg2);
                        if (ans != long.Parse(opt.arg3))
                        {
                            ifStatementReadBlockActive = true;
                        }
                    }
                    else if (opt.type == OperatorType.Greaterthan)
                    {
                        long arg1Long = long.Parse(opt.arg1);
                        long arg2Long = long.Parse(opt.arg2);
                        bool ans = bool.Parse(opt.arg3);

                        if (arg1Long > arg2Long)
                        {
                            if (ans == false)
                            {
                                ifStatementReadBlockActive = true;
                            }
                        }
                    }
                    else if (opt.type == OperatorType.Lessthan)
                    {
                        long arg1Long = long.Parse(opt.arg1);
                        long arg2Long = long.Parse(opt.arg2);
                        bool ans = bool.Parse(opt.arg3);

                        if (arg1Long < arg2Long)
                        {
                            if (ans == false)
                            {
                                ifStatementReadBlockActive = true;
                            }
                        }
                    }
                    else if (opt.type == OperatorType.Minus)
                    {
                        long ans = long.Parse(opt.arg1) - long.Parse(opt.arg2);
                        if (ans != long.Parse(opt.arg3))
                        {
                            ifStatementReadBlockActive = true;
                        }
                    }
                    else if (opt.type == OperatorType.Modulo)
                    {
                        long ans = long.Parse(opt.arg1) % long.Parse(opt.arg2);
                        if (ans != long.Parse(opt.arg3))
                        {
                            ifStatementReadBlockActive = true;
                        }
                    }
                    else if (opt.type == OperatorType.Multiply)
                    {
                        long ans = long.Parse(opt.arg1) * long.Parse(opt.arg2);
                        if (ans != long.Parse(opt.arg3))
                        {
                            ifStatementReadBlockActive = true;
                        }
                    }
                    else if (opt.type == OperatorType.Not)
                    {
                        throw new NotImplementedException();
                    }
                    else if (opt.type == OperatorType.Plus)
                    {
                        long ans = long.Parse(opt.arg1) + long.Parse(opt.arg2);
                        if (ans != long.Parse(opt.arg3))
                        {
                            ifStatementReadBlockActive = true;
                        }
                    }
                    else if (opt.type == OperatorType.Power)
                    {
                        long ans = (long)Math.Pow(long.Parse(opt.arg1), long.Parse(opt.arg2));
                        if (ans != long.Parse(opt.arg3))
                        {
                            ifStatementReadBlockActive = true;
                        }
                    }
                }
                else if (instruction.type == InstructionType.EndIf)
                {
                    if (startReading == false)
                    {
                        continue;
                    }

                    if (ifStatmentActive == true)
                    {
                        ifStatementReadBlockActive = false;
                        ifStatmentActive = false;
                    }
                    else
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"endif() (EXPECTED ACTIVE IF BLOCK)");
                        }
                    }
                }
                else if (instruction.type == InstructionType.Else)
                {
                    if (startReading == false)
                    {
                        continue;
                    }

                    if (ifStatmentActive == true)
                    {
                        if (ifStatementReadBlockActive == true)
                        {
                            ifStatementReadBlockActive = false;
                        }
                        else
                        {
                            ifStatementReadBlockActive = true;
                        }
                    }
                    else
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"endif() (EXPECTED ACTIVE IF BLOCK) AT {i}");
                        }
                    }
                }
                else if (instruction.type == InstructionType.ElseIf)
                {
                    if (startReading == false)
                    {
                        continue;
                    }

                    if (ifStatmentActive == false)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"elseif() (EXPECTED ALREADY ACTIVE IF STATEMENT BEFORE ELSEIF) AT {i}");
                        }
                    }
                    Operator opt = Parse.ParseOperationsFromLine(instruction.data);
                    if (opt.type == OperatorType.Divide)
                    {
                        long ans = long.Parse(opt.arg1) / long.Parse(opt.arg2);
                        if (ans == long.Parse(opt.arg3))
                        {
                            ifStatementReadBlockActive = false;
                        }
                    }
                    else if (opt.type == OperatorType.Greaterthan)
                    {
                        long arg1Long = long.Parse(opt.arg1);
                        long arg2Long = long.Parse(opt.arg2);
                        bool ans = bool.Parse(opt.arg3);

                        if (arg1Long > arg2Long)
                        {
                            if (ans == true)
                            {
                                ifStatementReadBlockActive = false;
                            }
                        }
                    }
                    else if (opt.type == OperatorType.Lessthan)
                    {
                        long arg1Long = long.Parse(opt.arg1);
                        long arg2Long = long.Parse(opt.arg2);
                        bool ans = bool.Parse(opt.arg3);

                        if (arg1Long < arg2Long)
                        {
                            if (ans == true)
                            {
                                ifStatementReadBlockActive = false;
                            }
                        }
                    }
                    else if (opt.type == OperatorType.Minus)
                    {
                        long ans = long.Parse(opt.arg1) - long.Parse(opt.arg2);
                        if (ans == long.Parse(opt.arg3))
                        {
                            ifStatementReadBlockActive = false;
                        }
                    }
                    else if (opt.type == OperatorType.Modulo)
                    {
                        long ans = long.Parse(opt.arg1) % long.Parse(opt.arg2);
                        if (ans == long.Parse(opt.arg3))
                        {
                            ifStatementReadBlockActive = false;
                        }
                    }
                    else if (opt.type == OperatorType.Multiply)
                    {
                        long ans = long.Parse(opt.arg1) * long.Parse(opt.arg2);
                        if (ans == long.Parse(opt.arg3))
                        {
                            ifStatementReadBlockActive = false;
                        }
                    }
                    else if (opt.type == OperatorType.Not)
                    {
                        throw new NotImplementedException();
                    }
                    else if (opt.type == OperatorType.Plus)
                    {
                        long ans = long.Parse(opt.arg1) + long.Parse(opt.arg2);
                        if (ans == long.Parse(opt.arg3))
                        {
                            ifStatementReadBlockActive = false;
                        }
                    }
                    else if (opt.type == OperatorType.Power)
                    {
                        long ans = (long)Math.Pow(long.Parse(opt.arg1), long.Parse(opt.arg2));
                        if (ans == long.Parse(opt.arg3))
                        {
                            ifStatementReadBlockActive = false;
                        }
                    }
                }
                else if (instruction.type == InstructionType.Switch)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    if (string.IsNullOrWhiteSpace(instruction.data))
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"switch(?) (EXPECTED VARIABLE) AT {i}");
                        }
                    }

                    if (switchActive == true)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"switch({instruction.data}) (A SWITCH IS ALREADY ACTIVE) AT {i}");
                        }
                    }

                    try
                    {
                        switchVariableData = ReadVariableInformation(instruction.data, i, variables.ToArray(), arrayVariables.ToArray());
                    }
                    catch (Exception ex)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"switch(?) ({ex.Message})");
                        }
                    }

                    switchActive = true;
                }
                else if (instruction.type == InstructionType.Case)
                {
                    if (startReading == false || breakSwitch == true)
                    {
                        continue;
                    }

                    if (breakNextSwitch == true)
                    {
                        breakNextSwitch = false;
                        breakSwitch = true;
                    }

                    if (switchActive == true)
                    {
                        if (ifStatementReadBlockActive == true)
                        {
                            ifStatementReadBlockActive = false;
                        }
                    }
                    else
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"case(?) (CASE CANNOT BE CALLED OUTSIDE OF ACTIVE SWITCH BLOCK) AT {i}");
                        }
                    }

                    if (string.IsNullOrWhiteSpace(instruction.data))
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"case(?) (EXPECTED DATA) AT {i}");
                        }
                    }

                    if (switchActive == true)
                    {
                        if (instruction.data != switchVariableData)
                        {
                            ifStatementReadBlockActive = true;
                        }
                        else
                        {
                            breakNextSwitch = true;
                        }
                    }
                    else
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"case(?) (EXPECTED ACTIVE SWITCH BLOCK) AT {i}");
                        }
                    }
                }
                else if (instruction.type == InstructionType.Default)
                {
                    if (startReading == false || breakSwitch == true)
                    {
                        continue;
                    }

                    if (breakNextSwitch == true)
                    {
                        breakNextSwitch = false;
                        breakSwitch = true;
                        ifStatementReadBlockActive = true;
                        continue;
                    }

                    if (switchActive == true)
                    {
                        if (breakNextSwitch == true || breakSwitch == true)
                        {
                            ifStatementReadBlockActive = true;
                            breakSwitch = true;
                            breakNextSwitch = false;
                            continue;
                        }
                        else
                        {
                            if (ifStatementReadBlockActive == true)
                            {
                                ifStatementReadBlockActive = false;
                            }
                        }
                    }
                    else
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"default() (DEFAULT CANNOT BE CALLED OUTSIDE OF ACTIVE SWITCH BLOCK) AT {i}");
                        }
                    }
                }
                else if (instruction.type == InstructionType.Endw)
                {
                    if (startReading == false)
                    {
                        continue;
                    }

                    if (switchActive == true)
                    {
                        if (breakSwitch == true)
                        {
                            breakNextSwitch = false;
                            ifStatementReadBlockActive = false;
                            breakSwitch = false;
                            switchActive = false;
                            switchVariableData = null;
                        }
                    }
                    else
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"endw() (EXPECTED ACTIVE SWITCH BLOCK) AT {i}");
                        }
                    }
                }
                else if (instruction.type == InstructionType.Whilst)
                {
                    if (startReading == false || ifStatementReadBlockActive == true)
                    {
                        continue;
                    }

                    if (whilstActive == true)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"whilst(?) (A WHILST LOOP IS ALREADY ACTIVE) AT {i}");
                        }
                    }

                    if (instruction.data.Length == 0)
                    {
                        if (tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"whilst(?) (EXPECTED OPERATION) AT {i}");
                        }
                    }

                    Operator opt = Parse.ParseOperationsFromLine(instruction.data);
                    if (opt.type == OperatorType.Divide)
                    {
                        long ans = long.Parse(opt.arg1) / long.Parse(opt.arg2);
                        if(ans != long.Parse(opt.arg3))
                        {
                            ifStatementReadBlockActive = true;
                        } 
                    }

                    whilstOperator = opt;
                    whilstConditionValue = opt.arg3;
                    whilstActive = true;
                    whilstLine = i;
                }
                else if(instruction.type == InstructionType.Endh)
                {
                    if (startReading == false)
                    {
                        continue;
                    }

                    if(whilstActive == false)
                    {
                        if(tryBlockActive == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ScriptException($"endh() (EXPECTED ACTIVE WHILST LOOP BEFORE EXECUTION) AT {i}");
                        }
                    }

                    if(ifStatementReadBlockActive == true)
                    {
                        whilstActive = false;
                        whilstConditionValue = null;
                        whilstLine = 0;
                        ifStatementReadBlockActive = false;
                    }
                    else
                    {
                        if(whilstOperator.type == OperatorType.Divide)
                        {
                            long ans = long.Parse(whilstOperator.arg1) / long.Parse(whilstOperator.arg2);
                            if(ans == long.Parse(whilstOperator.arg3))
                            {
                                i = whilstLine;
                            }
                            else
                            {
                                whilstActive = false;
                                whilstConditionValue = null;
                                whilstLine = 0;
                                whilstOperator = null;
                                ifStatementReadBlockActive = false;
                            }
                        }
                    }
                }
            }
            if(startReading == false)
            {
                throw new ScriptEngineException($@"No ""main"" function was declared.");
            }
        }

        private static ArrayVariableAndIndex GetIndexVariable(string input)
        {
            bool startGettingCharacters = false;
            string index = null;
            string arrayName = null;

            foreach(char ch in input)
            {
                if(ch.ToString() == "#")
                {
                    startGettingCharacters = true;
                }
                else
                {
                    if(startGettingCharacters == true)
                    {
                        index += ch.ToString();
                    }
                    else
                    {
                        arrayName += ch.ToString();
                    }
                }
            }
            return new ArrayVariableAndIndex(arrayName, index);
        }

        private static string ReadVariableInformation(string variableName, int index, Variable[] variables, ArrayVariable[] arrayVariables)
        {
            if (variableName.Contains("#"))
            {
                ArrayVariable array = new ArrayVariable(0, VariableType.Boolean, null);
                int arrayIndex = 0;
                bool success = false;

                foreach (ArrayVariable var in arrayVariables)
                {
                    ArrayNameAndIndex splitName = GetVariableAndIndex(variableName, index);
                    if (splitName.name == var.name)
                    {
                        success = true;
                        arrayIndex = splitName.index;
                        array = var;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (success == false)
                {
                    if(ReadInstructions.tryBlockActive == true)
                    {
                        return null;
                    }
                    else
                    {
                        throw new ScriptException($"No Variable Array was found with that name AT {index}");
                    }
                }
                else
                {
                    try
                    {
                        return array.GetValue(arrayIndex);
                    }
                    catch
                    {
                        if(ReadInstructions.tryBlockActive == true)
                        {
                            return null;
                        }
                        else
                        {
                            throw new ScriptException($"The array does not contain any index that matches {arrayIndex} AT {index}");
                        }
                    }
                }
            }
            else
            {
                foreach (Variable var in variables)
                {
                    if (var.name == variableName)
                    {
                        return var.value;
                    }
                    else
                    {
                        continue;
                    }
                }
                if(ReadInstructions.tryBlockActive == true)
                {
                    return null;
                }
                else
                {
                    throw new ScriptException($"Variable {variableName} does not exist AT {index}");
                }
            }
        }

        private static VariableInformation ReadVariable(string variableName, int index, Variable[] variables, ArrayVariable[] arrayVariables)
        {
            if (variableName.Contains("#"))
            {
                ArrayVariable array = new ArrayVariable(0, VariableType.Boolean, null);
                int arrayIndex = 0;
                bool success = false;

                foreach (ArrayVariable var in arrayVariables)
                {
                    ArrayNameAndIndex splitName = GetVariableAndIndex(variableName, index);
                    if (splitName.name == var.name)
                    {
                        success = true;
                        arrayIndex = splitName.index;
                        array = var;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (success == false)
                {
                    if (ReadInstructions.tryBlockActive == true)
                    {
                        return null;
                    }
                    else
                    {
                        throw new ScriptException($"No Variable Array was found with that name AT {index}");
                    }
                }
                else
                {
                    try
                    {
                        return new VariableInformation(array.GetVariable(arrayIndex), true, array, arrayIndex);
                    }
                    catch
                    {
                        if (ReadInstructions.tryBlockActive == true)
                        {
                            return null;
                        }
                        else
                        {
                            throw new ScriptException($"The array does not contain any index that matches {arrayIndex} AT {index}");
                        }
                    }
                }
            }
            else
            {
                foreach (Variable var in variables)
                {
                    if (var.name == variableName)
                    {
                        return new VariableInformation(var, false, null, 0);
                    }
                    else
                    {
                        continue;
                    }
                }
                if (ReadInstructions.tryBlockActive == true)
                {
                    return null;
                }
                else
                {
                    throw new ScriptException($"Variable {variableName} does not exist AT {index}");
                }
            }
        }

        private static ArrayNameAndIndex GetVariableAndIndex(string concatednatedVariableType, int index)
        {
            bool switchVariable = false;
            string nameResult = null;
            string indexResult = null;

            foreach(char ch in concatednatedVariableType)
            {
                if(ch.ToString() == "#")
                {
                    switchVariable = true;
                }
                else
                {
                    if (switchVariable == true)
                    {
                        indexResult += ch.ToString(); 
                    }
                    else
                    {
                        nameResult += ch.ToString();
                    }
                }
            }

            try
            {
                return new ArrayNameAndIndex(nameResult, int.Parse(indexResult));
            }
            catch
            {
                if(ReadInstructions.tryBlockActive == true)
                {
                    return new ArrayNameAndIndex();
                }
                else
                {
                    throw new ScriptException($"{concatednatedVariableType} (EXPECTED INT) AT {index}");
                }
            }
        }

        private static long Factorial(long input)
        {
            int factorial = 1;
            for (int i = 1; i <= input; i++)
            {
                factorial = factorial * i;
            }
            return factorial;
        }
    }

    public struct ArrayVariableAndIndex
    {
        public string arrayName { get; }
        public string index { get; }

        public ArrayVariableAndIndex(string arrayName, string index)
        {
            this.arrayName = arrayName;
            this.index = index;
        }
    }
}
