using System;

namespace Math_Script_Runtime_Environment.String_And_Character_Parsing
{
    public struct StringDefinition
    {
        public string data { get; }

        public StringDefinition(string data)
        {
            this.data = data;
        }

        public static string Parse(string mess)
        {
            string res = null;
            bool gottenExit = false;
            bool gottenStart = false;

            foreach (char ch in mess)
            {
                if (ch == '"')
                {
                    if (gottenStart == false)
                    {
                        gottenStart = true;
                    }
                    else
                    {
                        gottenExit = true;
                        break;
                    }
                }
                else
                {
                    if (gottenStart == true)
                    {
                        res += ch;
                    }
                }
            }

            if (gottenExit == false)
            {
                throw new ArgumentException($@"String was not enclosed properly with "" symbol. CAUSED BY {mess}");
            }
            return res;
        }
    }
}
