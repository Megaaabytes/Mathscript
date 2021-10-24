using System;
using Math_Script_Runtime_Environment.Command_Line_Arguments;
using System.Windows.Forms;
using Math_Script_Runtime_Environment.InstructionsTools;
using Math_Script_Runtime_Environment.Parsing;
using System.IO;
using System.Runtime.InteropServices;
using Math_Script_Runtime_Environment.Update_Checker;
using System.Threading;
using System.Diagnostics;

namespace Math_Script_Runtime_Environment
{
    class Program
    {
        private static bool failedToCheckForUpdates = false;
        public static string errorMessage = "The code that executed that raised this error did not specify any details.";
        private static bool updatesAvaliable = false;
        public static bool tooManyRequests = false;

        static void Main(string[] args)
        {
            // Thread for checking for updates. Thread was used to boost performance.
            Thread checkForUpdates = new Thread(new ThreadStart(checker));
            
            // Update checking is automatically disabled for now.
            
            try
            {
                if (File.Exists(args[0]) == false)
                {
                    MessageBox.Show("The file specified does not exist!", "Mathscript file error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    updatesAvaliable = false;
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
                    catch(NotImplementedException ex)
                    {
                        MessageBox.Show($"{ex.Message} Sorry for the inconvience.", "Mathscript Not implemented feature", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        updatesAvaliable = false;
                    }
                    catch (ArgumentNullException ex)
                    {
                        MessageBox.Show($"An argument was null. Error Message: {ex.Message}", "Mathscript Arugment Null error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        updatesAvaliable = false;
                    }
                    catch (NullReferenceException ex)
                    {
                        MessageBox.Show($"A null reference error occured! Error Message: {ex.Message}", "Mathscript NullReference error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        updatesAvaliable = false;
                    }
                    catch(ScriptMathException ex)
                    {
                        MessageBox.Show($"The script provided has mathematical errors. Error Message: {ex.Message}", "Mathscript Math error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        updatesAvaliable = false;
                    }
                    catch(ScriptException ex)
                    {
                        MessageBox.Show($"The script provided has script errors! Error Message: {ex.Message}", "Mathscript execution error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        updatesAvaliable = false;
                    }
                    catch(DataException ex)
                    {
                        MessageBox.Show($"Could not retrieve data from paramter! Error Message: {ex.Message}", "Mathscript data error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        updatesAvaliable = false;
                    }
                    catch(ParameterException ex)
                    {
                        MessageBox.Show($"A parameter provided is invalid! Error Message: {ex.Message}", "Mathscript parameter error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        updatesAvaliable = false;
                    }
                    catch(ParseException ex)
                    {
                        MessageBox.Show($"Could not read script file! Error Message: {ex.Message}", "Mathscript parse error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        updatesAvaliable = false;
                    }
                    catch (ScriptEngineException ex)
                    {
                        MessageBox.Show($"An internal script engine error has occured! (This can be caused by a script) Error Message: {ex.Message}", "Mathscript execution error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        updatesAvaliable = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"The script provided has unknown errors! Error Message: {ex.Message}", "Mathscript failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        updatesAvaliable = false;
                    }
                }
            }
            catch
            {
                MessageBox.Show("The file specified does not exist!", "Mathscript file error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if(failedToCheckForUpdates == true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nMathscript could not automatically check for updates. Are you connected to the internet?");
                Console.WriteLine($"Error Details: {errorMessage}\n");
                Console.ResetColor();
                Console.ReadKey();
            }
            else
            {
                if(updatesAvaliable == true)
                {
                    DialogResult question = MessageBox.Show("A new version of Mathscript (Version 1.0.2) is avaliable. Would you like to go to the download page now?", "Software Updates", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (question == DialogResult.Yes)
                    {
                        Process.Start("https://github.com/Megaaabytes/Mathscript/releases");
                    }
                }
            }
        }

        private static void checker()
        {
            try
            {
                updatesAvaliable = CheckForUpdates.GetCurrentVersion();
            }
            catch(Exception ex)
            {
                if(tooManyRequests == true)
                {
                    failedToCheckForUpdates = true;
                }
                else
                {
                    failedToCheckForUpdates = true;
                    errorMessage = ex.Message;
                }
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
