using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectDndConsole.Api;
using ProjectDndConsole.ApiClasses;

namespace ProjectDndConsole.MethodClasses
{
    public class MonsterMethods
    {
        public static void PrintMonsterStats(Monster monster)
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
                              $" Damage:\n" +
                              $"    Vulnerabilities: {monster.damage_vulnerabilities}\n" +
                              $"    Resistances: {monster.damage_resistances}\n" +
                              $"    Immunities: {monster.damage_immunities}\n" +
                              $"    Condition immunities: {monster.condition_immunities}\n" +
                              $" Senses: {monster.senses}\n" +
                              $" Languages: {monster.languages}\n" +
                              $" Challenge rating: {monster.challenge_rating}\n" +
                              $" Reactions: {monster.reactions}\n" +
                              $" Legendary description: {monster.legendary_desc}\n" +
                              $" Legendary actions: {monster.legendary_actions}\n" +
                              $" Speed:\n" +
                              $"    Walking: {monster.speed.walk}\n" +
                              $"    Swimming: {monster.speed.swim}\n" +
                              $"    Hovering: {monster.speed.hover}\n" +
                              $"    Flying: {monster.speed.fly}\n" +
                              $"    Climbing: {monster.speed.climb}\n" +
                              $"    Burrowing: {monster.speed.burrow}\n");
            Console.WriteLine($" Skills:\n" +
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

            //Console.WriteLine("\n\n Actions:");

            //foreach (var action in monster.actions)
            //{
            //    Console.WriteLine($"\t -- Name: {action.name}" +
            //                      $"\t -- Description: {action.desc}" +
            //                      $"\t -- Attack bonus: {action.attack_bonus}" +
            //                      $"\t -- Damage dice: {action.damage_dice}" +
            //                      $"\t -- Damage bonus: {action.damage_bonus}");
            //    Console.WriteLine("\n\n");
            //}

            //Console.WriteLine("\n\n Abilities:\n");
            //foreach (var ability in monster.special_abilities)
            //{
            //    Console.WriteLine($"\t -- Name: {ability.name}" +
            //                      $"\t -- Description: {ability.desc}");
            //}

            Console.WriteLine("\n\n Spells: \n");
            foreach (var spell in monster.spell_list)
            {
                Console.WriteLine("   " + spell);
            }
        }

        public static async Task<List<Monster>> GetAllMonsters()
        {
            var monstersArray = await DndApiOpen5e.GetMonsters();
            var response = monstersArray.ToList();
            return response;
        }

        public static async Task<List<Monster>> ReturnMonstersByRating(string challengeRating)
        {
            var monsterList = await GetAllMonsters();
            var monstersByRating = monsterList.Where(monster => monster.challenge_rating == challengeRating).ToList();
            return monstersByRating;
        }

        public static async Task<Monster> GetRandomMonster(string challengeRating)
        {
            List<Monster> monstersByRating = await ReturnMonstersByRating(challengeRating);
            Random rand = new Random();
            int index = rand.Next(monstersByRating.Count);
            Monster response = monstersByRating[index];
            return response;
        }
    }
}