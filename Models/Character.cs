using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDndConsole
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public int Charisma { get; set; }
        public int Constitution { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public int Strength { get; set; }
        public int Wisdom { get; set; }
        public string Alignment { get; set; }
        public string Background { get; set; }
        public string MagicSchool { get; set; }
        public List<string> Equipment { get; set; }
        public List<string> Features { get; set; }
        public List<string> Languages { get; set; }
        public List<string> MagicItems { get; set; }
        public List<string> Proficiencies { get; set; }
        public List<string> Spells { get; set; }

        public Skills[] SkillsArray { get; set; }

        public class Skills
        {
            public int Acrobatics { get; set; }
            public int AnimalHandling { get; set; }
            public int Arcana { get; set; }
            public int Athletics { get; set; }
            public int Deception { get; set; }
            public int History { get; set; }
            public int Insight { get; set; }
            public int Intimidation { get; set; }
            public int Investigation { get; set; }
            public int Medicine { get; set; }
            public int Nature { get; set; }
            public int Perception { get; set; }
            public int Performance { get; set; }
            public int Persuasion { get; set; }
            public int Religion { get; set; }
            public int SleightOfHand { get; set; }
            public int Stealth { get; set; }
            public int Survival { get; set; }
        }
    }
}
