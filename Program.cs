using System;
using System.Threading.Tasks;
using ProjectDndConsole.MethodClasses;


namespace ProjectDndConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            bool menu = true;

            while (menu)
            {
                menu = await CommonMethods.MainMenu();
            }
        }
    }
}
