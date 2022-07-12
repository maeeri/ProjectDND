using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using APIHelpers;
using ProjectDndConsole.Api;
using ProjectDndConsole.ApiClasses;

namespace ProjectDndConsole.MethodClasses
{
    public class MonsterMethods
    {
        public static async Task PrintMonsterStats(Monster monster)
        {
            Console.WriteLine($" Name: {monster.name}\n" +
                              $" Size: {monster.size}\n" +
                              $" Type and subtype: {monster.type}, {monster.subtype}\n" +
                              $" Group:  {monster.group}\n" +
                              $" Alignment: {monster.alignment}\n" +
                              $" Armor class: {monster.armor_class}\n" +
                              $" Armor description: {monster.armor_desc}\n" +
                              $" HP: {monster.hit_points}\n" +
                              $" Hit Dice: {monster.hit_dice}\n" +
                              $" Strength: {monster.strength}\n" +
                              $" Dexterity: {monster.dexterity}\n" +
                              $" Constitution: {monster.constitution}\n" +
                              $" Intelligence: {monster.intelligence}\n" +
                              $" Wisdom: {monster.wisdom}\n" +
                              $" Charisma: {monster.charisma}\n" +
                              $" Strength save: {monster.strength_save}\n" +
                              $" Dexterity save: {monster.dexterity_save}\n" +
                              $" Constitution save: {monster.constitution_save}\n" +
                              $" Intelligence save: {monster.intelligence_save}\n" +
                              $" Wisdom save: {monster.wisdom_save}\n" +
                              $" Charisma save: {monster.charisma_save}\n" +
                              $" Perception: {monster.perception}\n" +
                              $"\n Damage:\n" +
                              $"    Vulnerabilities: {monster.damage_vulnerabilities}\n" +
                              $"    Resistances: {monster.damage_resistances}\n" +
                              $"    Immunities: {monster.damage_immunities}\n" +
                              $"    Condition immunities: {monster.condition_immunities}\n" +
                              $" Senses: {monster.senses}\n" +
                              $" Languages: {monster.languages}\n" +
                              $" Challenge rating: {monster.challenge_rating}\n" +
                              $" Reactions: {monster.reactions}\n" +
                              $" Actions: {monster.actions}\n" +
                              $" Legendary description: {monster.legendary_desc}\n" +
                              $" Legendary actions: {monster.legendary_actions}\n" +
                              $" Special Abilities: {monster.special_abilities}\n" +
                              $"\n Speed:\n" +
                              $"    Walking: {monster.speed.walk}\n" +
                              $"    Swimming: {monster.speed.swim}\n" +
                              $"    Hovering: {monster.speed.hover}\n" +
                              $"    Flying: {monster.speed.fly}\n" +
                              $"    Climbing: {monster.speed.climb}\n" +
                              $"    Burrowing: {monster.speed.burrow}\n");
            Console.WriteLine($"\n Skills:\n" +
                              $"    Athletics: {monster.skills.athletics}\n" +
                              $"    Intimidation: {monster.skills.intimidation}\n" +
                              $"    History: {monster.skills.history}\n" +
                              $"    Perception: {monster.skills.perception}\n" +
                              $"    Deception: {monster.skills.deception}\n" +
                              $"    Performance: {monster.skills.performance}\n" +
                              $"    Persuasion: {monster.skills.persuasion}\n" +
                              $"    Stealth: {monster.skills.stealth}\n" +
                              $"    Medicine: {monster.skills.medicine}\n" +
                              $"    Religion: {monster.skills.religion}\n" +
                              $"    Insight: {monster.skills.insight}\n" +
                              $"    Arcana: {monster.skills.arcana}\n" +
                              $"    Nature: {monster.skills.nature}\n" +
                              $"    Acrobatics: {monster.skills.acrobatics}\n" +
                              $"    Survival: {monster.skills.survival}\n" +
                              $"    Investigation: {monster.skills.investigation}\n");

            Console.WriteLine("\n\n Spells: \n");
            foreach (var spell in monster.spell_list)
            {
                var urlArray = spell.Split("/");
                var newArray = new string[] { urlArray[3], urlArray[4] };
                var urlParams = string.Join("/", newArray);

                Spell sp = await DndApiOpen5e.GetOneSpell(urlParams);
                Console.WriteLine(sp.name);
            }
        }

        //places all monsters to list, returns list
        public static async Task<List<Monster>> GetAllMonsters()
        {
            var monstersArray = await DndApiOpen5e.GetMonsters();
            var response = monstersArray.ToList();
            return response;
        }

        //finds monsters with specific challenge rating
        public static async Task<List<Monster>> ReturnMonstersByRating(string challengeRating)
        {
            var monsterList = await GetAllMonsters();
            var monstersByRating = monsterList.Where(monster => monster.challenge_rating == challengeRating).ToList();
            return monstersByRating;
        }

        //gets one random monster within a set of monsters with specific challenge rating
        public static async Task<Monster> GetRandomMonster(string challengeRating)
        {
            List<Monster> monstersByRating = await ReturnMonstersByRating(challengeRating);
            Random rand = new Random();
            int index = rand.Next(monstersByRating.Count);
            Monster response = monstersByRating[index];
            return response;
        }

        //asks for challenge rating, calls for methods to find random monster and to print its info
        public static async Task PrintRandomMonster()
        {
            Console.WriteLine("Give a challenge rating:");
            string challengerating = Console.ReadLine();
            Stopwatch clicker = new Stopwatch();
            clicker.Start();
            //Monster monster = await MonsterMethods.GetRandomMonster(challengerating);
            Monster monster = new Monster();
            var t = Task.Run(async () =>
            {
                monster = await MonsterMethods.GetRandomMonster(challengerating);
            });

            for (int i = 0; i < 10; i++)
            {
                Console.Write("~");
                Thread.Sleep(350);
            }

            clicker.Stop();
            await MonsterMethods.PrintMonsterStats(monster);

            Console.WriteLine("\n" + clicker.Elapsed + "\nPress any key");
            Console.ReadKey();
        }
    }
}