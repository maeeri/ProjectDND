using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDndConsole.ApiClasses
{

    public class MonsterList
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public Monster[] results { get; set; }
    }

    public class Monster
    {
        public string slug { get; set; }
        public string name { get; set; }
        public string size { get; set; }
        public string type { get; set; }
        public string subtype { get; set; }
        public string group { get; set; }
        public string alignment { get; set; }
        public int armor_class { get; set; }
        public string armor_desc { get; set; }
        public int hit_points { get; set; }
        public string hit_dice { get; set; }
        public Speed speed { get; set; }
        public int strength { get; set; }
        public int dexterity { get; set; }
        public int constitution { get; set; }
        public int intelligence { get; set; }
        public int wisdom { get; set; }
        public int charisma { get; set; }
        public int? strength_save { get; set; }
        public int? dexterity_save { get; set; }
        public int? constitution_save { get; set; }
        public int? intelligence_save { get; set; }
        public int? wisdom_save { get; set; }
        public int? charisma_save { get; set; }
        public int? perception { get; set; }
        public Skills skills { get; set; }
        public string damage_vulnerabilities { get; set; }
        public string damage_resistances { get; set; }
        public string damage_immunities { get; set; }
        public string condition_immunities { get; set; }
        public string senses { get; set; }
        public string languages { get; set; }
        public string challenge_rating { get; set; }
        public object actions { get; set; }
        public object reactions { get; set; }
        public string legendary_desc { get; set; }
        public object legendary_actions { get; set; }
        public object special_abilities { get; set; }
        public string[] spell_list { get; set; }
        public string img_main { get; set; }
        public string document__slug { get; set; }
        public string document__title { get; set; }
        public string document__license_url { get; set; }
    }

    public class Speed
    {
        public int walk { get; set; }
        public int swim { get; set; }
        public bool hover { get; set; }
        public int fly { get; set; }
        public int burrow { get; set; }
        public int climb { get; set; }
        public int lightwalking { get; set; }
        public string notes { get; set; }
    }

    public class Skills
    {
        public int athletics { get; set; }
        public int intimidation { get; set; }
        public int history { get; set; }
        public int perception { get; set; }
        public int deception { get; set; }
        public int performance { get; set; }
        public int persuasion { get; set; }
        public int stealth { get; set; }
        public int medicine { get; set; }
        public int religion { get; set; }
        public int insight { get; set; }
        public int arcana { get; set; }
        public int nature { get; set; }
        public int acrobatics { get; set; }
        public int survival { get; set; }
        public int investigation { get; set; }
    }

}
