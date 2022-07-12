using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using ProjectDndConsole.Api;
using ProjectDndConsole.ApiClasses;
using ProjectDndConsole.MethodClasses;
using System.Threading;


namespace ProjectDndConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                try
                {
                    await MonsterMethods.PrintRandomMonster();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oops!" + e);
                }
            }
        }
    }
}
