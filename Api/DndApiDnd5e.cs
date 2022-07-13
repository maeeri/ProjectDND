using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using APIHelpers;

namespace ProjectDndConsole
{
    public static class DndApiDnd5e
    {
        const string url = "https://www.dnd5eapi.co/";

        public static async Task<MainOptions> GetMainOptionsAsync()
        {
            string urlParams = "api/";
            MainOptions response = await ApiHelper.RunAsync<MainOptions>(url, urlParams);
            
            return response;
        }

        public static async Task<Ability[]> GetAbilities()
        {
            string urlParams = "ability-scores/";
            Ability[] response = await ApiHelper.RunAsync<Ability[]>(url, urlParams);
            return response;
        }

        public static async Task<CharStats> GetCharStats(string input)
        {
            string urlParams = "ability-scores/" + input;
            CharStats response = await ApiHelper.RunAsync<CharStats>(url, urlParams);

            return response;
        }
    }
}
