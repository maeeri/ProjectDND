using System;
using System.Threading.Tasks;
using ProjectDndConsole.ApiClasses;

namespace ProjectDndConsole.MethodClasses
{
    public static class StatsMethods
    {
        public static async Task PrintAbilitiesList()
        {
            Ability[] abilityArray = await DndApiDnd5e.GetAbilities();

            foreach (var ability in abilityArray)
            {
                Console.WriteLine($" {ability.index}\n" +
                                  $" {ability.name}\n" +
                                  $" {ability.url}\n\n");
            }
        }
    }
}