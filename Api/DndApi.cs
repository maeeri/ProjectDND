using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using APIHelpers;

namespace ProjectDndConsole
{
    public static class DndApi
    {
        const string url = "https://www.dnd5eapi.co/";

        public static async Task<MainOptions> GetMainOptionsAsync()
        {
            string urlParams = "api/";
            MainOptions response = await ApiHelper.RunAsync<MainOptions>(url, urlParams);
            
            return response;
        }


    }
}
