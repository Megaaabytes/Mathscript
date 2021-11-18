using System.Collections.Generic;

namespace Math_Script_Runtime_Environment.Command_Line_Arguments
{
    public class CommandLineUtilites
    {
        public static int GetCommandLineArgumentsLength(string[] args)
        {
            List<string> finalArgs = new List<string>();
            try
            {
                for (int i = 1; i < args.Length; i++)
                {
                    finalArgs.Add(args[i]);
                }
            }
            catch
            {
                return 0;
            }
            return finalArgs.Count;
        }

        public static string[] GetCommandLineArguments(string[] args)
        {
            List<string> finalArgs = new List<string>();
            try
            {
                for (int i = 1; i < args.Length; i++)
                {
                    finalArgs.Add(args[i]);
                }
            }
            catch
            {
                return null;
            }
            return finalArgs.ToArray();
        }
    }
}
