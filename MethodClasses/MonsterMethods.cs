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
    public static class MonsterMethods
    {
        public static async Task PrintMonsterStats(Monster monster)
        {
            Console.WriteLine($"\n\n Name: {monster.name}\n" +
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
                              $" Legendary description: {monster.legendary_desc}\n" +
                              $"\n Speed:\n" +
                              $"    Walking: {monster.speed.walk}\n" +
                              $"    Swimming: {monster.speed.swim}\n" +
                              $"    Hovering: {monster.speed.hover}\n" +
                              $"    Flying: {monster.speed.fly}\n" +
                              $"    Climbing: {monster.speed.climb}\n" +
                              $"    Burrowing: {monster.speed.burrow}\n" +
                              $"    Lightwalking: {monster.speed.lightwalking}\n");
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


            //Console.WriteLine("\n Special Abilities:\n");
            //foreach (var ability in monster.special_abilities)
            //{
            //    Console.WriteLine($"   Name: {ability.name}\n   Description: {ability.desc}\n\n");
            //}

            //Console.WriteLine("\n\n Actions:\n");
            //foreach (var action in monster.actions)
            //{
            //    Console.WriteLine($"    Name: {action.name}\n" +
            //                      $"    Description: {action.desc}\n" +
            //                      $"    Damage dice: {action.damage_dice}\n" +
            //                      $"    Attack bonus: {action.attack_bonus}\n\n");
            //}

            //Console.WriteLine("\n Legendary actions:\n");
            //foreach (var action in monster.legendary_actions)
            //{
            //    Console.WriteLine($"   Name: {action.name}\n   Description: {action.desc}\n\n");
            //}

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
        public static async Task PrintRandomMonster(string challengeRating)
        {
            while (true)
            {
                try
                {
                    Monster monster = new Monster();
                    var t = Task.Run(async () => { monster = await GetRandomMonster(challengeRating); });

                    for (int i = 0; i < 3; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(350);
                    }
                    
                    await PrintMonsterStats(monster);
                    CommonMethods.PressKey();
                    break;
                }
                catch (NullReferenceException e)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(" ");
                }
            }
        }

        public static async Task LoopPrintRandomMonster()
        {
            Console.WriteLine("Give a challenge rating:");
            string challengeRating = Console.ReadLine();
            while (true)
            {
                try
                {
                    await PrintRandomMonster(challengeRating);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oops!" + e);
                }

                break;
            }
        }
    }
}