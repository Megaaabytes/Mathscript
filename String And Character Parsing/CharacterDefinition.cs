using System;

namespace Math_Script_Runtime_Environment.String_And_Character_Parsing
{
    public struct CharacterDefinition
    {
        public char data { get; }

        public CharacterDefinition(char dataWithSpeechMark)
        {
            this.data = dataWithSpeechMark;
        }

        public static char Parse(string mess)
        {
            char res = '\0';
            bool gottenExit = false;
            bool gottenStart = false;

            foreach (char ch in mess)
            {
                if (ch.ToString() == "'")
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
                        if(res != '\0')
                        {
                            throw new ArgumentException($"Char type only supports 'char' types. Provided string. CAUSED BY {mess}");
                        }
                        res = ch;
                    }
                }
            }

            if (gottenExit == false)
            {
                throw new ArgumentException($@"Char was not enclosed properly with ' symbol. CAUSED BY {mess}");
            }
            return res;
        }
    }
}
