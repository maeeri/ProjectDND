using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using APIHelpers;
using ProjectDndConsole.ApiClasses;

namespace ProjectDndConsole.Api
{
    public static class DndApiOpen5e
    {
        private const string url = "https://api.open5e.com/";

        public static async Task<Monster[]> GetMonsters()
        {
            string urlParams = "monsters/?limit=1086";
            MonsterList monsterList = await ApiHelper.RunAsync<MonsterList>(url, urlParams);
            Monster[] monstersArray = monsterList.results;

            return monstersArray;
        }
    }
}
