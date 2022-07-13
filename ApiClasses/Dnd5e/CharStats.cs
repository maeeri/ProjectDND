namespace ProjectDndConsole
{
    public class CharStats
    {
        public string index { get; set; }
        public string name { get; set; }
        public string full_name { get; set; }
        public string[] desc { get; set; }
        public Skill[] skills { get; set; }
        public string url { get; set; }
    }

    public class Skill
    {
        public string name { get; set; }
        public string index { get; set; }
        public string url { get; set; }
    }
}