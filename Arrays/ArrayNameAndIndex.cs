namespace Math_Script_Runtime_Environment.Arrays
{
    public struct ArrayNameAndIndex
    {
        public string name { get; }
        public int index { get; }

        public ArrayNameAndIndex(string name, int index)
        {
            this.name = name;
            this.index = index; 
        }
    }
}
