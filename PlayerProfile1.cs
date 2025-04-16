using System;
using RPG;

namespace RPG
{
    public class PlayerProfile1
    {
        public static void ShowPlayerProfile1()
        {
            Console.Clear();

            if (RegisteredPlayer.CurrentPlayer == null)
            {
                Console.WriteLine("No player data available.");
                return;
            }

            Console.WriteLine("_________________________________Player Profile_________________________________");
            Console.WriteLine(); Console.WriteLine(); Console.WriteLine();

            // Display base player stats
            Console.WriteLine("Base Player Stats:");
            Console.WriteLine($"Name: {RegisteredPlayer.CurrentPlayer.Name}");
            Console.WriteLine($"Class: {RegisteredPlayer.CurrentPlayer.playerClass}");
            Console.WriteLine($"Health: {RegisteredPlayer.CurrentPlayer.CurrentHealth}/{RegisteredPlayer.CurrentPlayer.MaxHealth}");
            Console.WriteLine($"Damage: {RegisteredPlayer.CurrentPlayer.Damage}");
            Console.WriteLine($"Level: {RegisteredPlayer.CurrentPlayer.LVL}");
            Console.WriteLine($"EXP: {RegisteredPlayer.CurrentPlayer.EXP}");
            Console.WriteLine($"EXP Till Next Level: {RegisteredPlayer.CurrentPlayer.EXPTillNextLvl}");
            Console.WriteLine($"Gold: {RegisteredPlayer.CurrentPlayer.Gold}");

            Console.WriteLine("____________________________________________________________");
            Console.WriteLine(); Console.WriteLine();

            // Display class-specific stats and description
            Console.WriteLine("Class Stats and Abilities:");
            switch (RegisteredPlayer.CurrentPlayer.playerClass)
            {
                case Player.PlayerClass.Warrior:
                    Console.WriteLine("Warrior: A strong melee fighter with high strength and durability.");
                    Console.WriteLine($"Strength: {RegisteredPlayer.CurrentPlayer.Strength} (Primary)");
                    Console.WriteLine($"Dexterity: {RegisteredPlayer.CurrentPlayer.Dexterity}");
                    Console.WriteLine($"Intellect: {RegisteredPlayer.CurrentPlayer.Intelect}");
                    Console.WriteLine("Abilities: Melee attacks, high defense.");
                    Console.WriteLine(Quests.questID);
                    break;

                case Player.PlayerClass.Mage:
                    Console.WriteLine("Mage: A spellcaster with high intellect and magical abilities.");
                    Console.WriteLine($"Strength: {RegisteredPlayer.CurrentPlayer.Strength}");
                    Console.WriteLine($"Dexterity: {RegisteredPlayer.CurrentPlayer.Dexterity}");
                    Console.WriteLine($"Intellect: {RegisteredPlayer.CurrentPlayer.Intelect} (Primary)");
                    Console.WriteLine("Abilities: Spells, ranged attacks, low defense.");
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            ConsoleTexts.WhereToGo();
        }
    }
}