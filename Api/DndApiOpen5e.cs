using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using APIHelpers;
using ProjectDndConsole.ApiClasses;

namespace ProjectDndConsole.Api
{
    //for contacting api
    public static class DndApiOpen5e
    {

        private const string url = "https://api.open5e.com/";

        //array of monsters
        public static async Task<Monster[]> GetMonsters()
        {
            string urlParams = "monsters/?limit=1086";
            MonsterList monsterList = await ApiHelper.RunAsync<MonsterList>(url, urlParams);
            Monster[] monstersArray = monsterList.results;

            return monstersArray;
        }

        //array of spells
        public static async Task<Spell[]> GetSpells()
        {
            string urlParams = "spells/?limit=321";

            Spells spellList = await ApiHelper.RunAsync<Spells>(url, urlParams);
            Spell[] spellArray = spellList.results;
            return spellArray;
        }

        //one spell
        public static async Task<Spell> GetOneSpell(string urlParams)
        {
            Spell spell = await ApiHelper.RunAsync<Spell>(url, urlParams);
            return spell;
        }
    }
}
