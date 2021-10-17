using System;
using Math_Script_Runtime_Environment.Command_Line_Arguments;
using System.Windows.Forms;
using Math_Script_Runtime_Environment.InstructionsTools;
using Math_Script_Runtime_Environment.Parsing;
using System.IO;
using System.Runtime.InteropServices;

namespace Math_Script_Runtime_Environment
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (File.Exists(args[0]) == false)
                {
                    MessageBox.Show("The file specified does not exist!", "Mathscript file error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        string[] fileData = File.ReadAllLines(args[0]);
                        string[] arguments = CommandLineUtilites.GetCommandLineArguments(args);
                        int argLength = CommandLineUtilites.GetCommandLineArgumentsLength(args);
                        Instructions[] instructions = Parser.BeginParse(fileData);
                        ReadInstructions.InitalizeArguments(arguments, argLength);
                        ReadInstructions.BeginRead(instructions);
                    }
                    catch (NullReferenceException ex)
                    {
                        MessageBox.Show($"A null reference error occured! Error Message: {ex.Message}", "Mathscript NullReference error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch(ScriptException ex)
                    {
                        MessageBox.Show($"The script provided has script errors! Error Message: {ex.Message}", "Mathscript execution error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch(DataException ex)
                    {
                        MessageBox.Show($"Could not retrieve data from paramter! Error Message: {ex.Message}", "Mathscript data error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch(ParameterException ex)
                    {
                        MessageBox.Show($"A parameter provided is invalid! Error Message: {ex.Message}", "Mathscript parameter error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch(ParseException ex)
                    {
                        MessageBox.Show($"Could not read script file! Error Message: {ex.Message}", "Mathscript parse error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (ScriptEngineException ex)
                    {
                        MessageBox.Show($"An internal script engine error has occured! (This can be caused by a script) Error Message: {ex.Message}", "Mathscript execution error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"The script provided has unknown errors! Error Message: {ex.Message}", "Mathscript failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("The file specified does not exist!", "Mathscript file error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        [DllImport("Kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int cmdShow);

        internal static void HideConsole()
        {
            IntPtr hWnd = GetConsoleWindow();
            if(hWnd != IntPtr.Zero)
            {
                ShowWindow(hWnd, 0);
            }
        }

        internal static void ShowConsole()
        {
            IntPtr hWnd = GetConsoleWindow();
            if (hWnd != IntPtr.Zero)
            {
                ShowWindow(hWnd, 1);
            }
        }
    }
}
