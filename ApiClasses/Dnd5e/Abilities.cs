namespace ProjectDndConsole
{
    public class Abilities
    {
        public int count { get; set; }
        public Ability[] results { get; set; }
    }

    public class Ability
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }
}