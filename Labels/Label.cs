namespace Math_Script_Runtime_Environment.Labels
{
    public struct label
    {
        public string name { get; }
        public int line { get; }

        public label(string name, int line)
        {
            this.name = name;
            this.line = line;
        }
    }
}
