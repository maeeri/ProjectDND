using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ProjectDndConsole.MethodClasses
{
    public static class CommonMethods
    {
        //validates int input
        public static int ValidateIntInput(string input)
        {
            int newInput;
            while (true)
            {
                if (int.TryParse(input, out newInput))
                    break;

                Console.WriteLine(" Please give a number:");
                input = Console.ReadLine();
            }
            return newInput;
        }

        //validates yes or no input
        public static bool ValidateYesOrNoInput(string input)
        {
            bool newInput;
            while (true)
            {
                if (input.Equals("yes", StringComparison.OrdinalIgnoreCase))
                    newInput = true;
                else if (input.Equals("no", StringComparison.OrdinalIgnoreCase))
                    newInput = false;
                else
                {
                    Console.WriteLine(" Did you write yes or no?");
                    input = Console.ReadLine();
                    continue;
                }
                break;
            }
            return newInput;
        }

        //to help with async operations
        public static void PressKey()
        {
            Console.WriteLine(" Press enter to continue");
            Console.ReadKey();
        }

        public static void AlertInvalidChoice(int maxNumber)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($" Did you choose a number between 1 and {maxNumber}?");
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public static async Task<bool> MainMenu()
        {
            Console.WriteLine(" What do you want to do?\n" +
                              " 1) Get stats from a random monster\n" +
                              " 2) Get a list of character abilities\n" +
                              " 3) exit");
            int input = ValidateIntInput(Console.ReadLine());

            switch (input)
            {
                case 1:
                    await MonsterMethods.LoopPrintRandomMonster();
                    return true;

                case 2:
                    await StatsMethods.PrintAbilitiesList();
                    return true;

                case 3:
                    return false;

                default:
                    AlertInvalidChoice(3);
                    return true;
            }
        }
    }
}