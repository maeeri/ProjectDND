using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using ProjectDndConsole.Api;
using ProjectDndConsole.ApiClasses;
using ProjectDndConsole.MethodClasses;


namespace ProjectDndConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Give a challenge rating: ");
                string challengerating = Console.ReadLine();
                Monster monster = await MonsterMethods.GetRandomMonster(challengerating);
                Console.WriteLine("Press any key");
                Console.ReadKey();
                MonsterMethods.PrintMonsterStats(monster);
            }
        }
    }
}
