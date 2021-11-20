namespace Math_Script_Runtime_Environment.Functions
{
    public struct Function
    {
        public string name { get; }
        public int line { get; }

        public Function(string name, int line)
        {
            this.name = name;
            this.line = line;
        }
    }
}
