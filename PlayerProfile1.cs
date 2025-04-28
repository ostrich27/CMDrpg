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
            Console.WriteLine("\n \n \n");

            // Display base player stats
            Console.WriteLine($"""
                Base Player Stats: 
                Name: {RegisteredPlayer.CurrentPlayer.Name} 
                Class: {RegisteredPlayer.CurrentPlayer.playerClass} 
                Health: {RegisteredPlayer.CurrentPlayer.CurrentHealth}/{RegisteredPlayer.CurrentPlayer.MaxHealth} 
                Damage: {RegisteredPlayer.CurrentPlayer.Damage}
                Level: {RegisteredPlayer.CurrentPlayer.LVL}
                EXP: {RegisteredPlayer.CurrentPlayer.EXP}
                EXP Till Next Level: {RegisteredPlayer.CurrentPlayer.EXPTillNextLvl}
                Gold: {RegisteredPlayer.CurrentPlayer.Gold}
                """);

            Console.WriteLine("____________________________________________________________");
            Console.WriteLine(); Console.WriteLine();

            // Display class-specific stats and description
            Console.WriteLine("Class Stats and Abilities:");
            switch (RegisteredPlayer.CurrentPlayer.playerClass)
            {
                case Player.PlayerClass.Warrior:
                    Console.WriteLine($"""
                        Warrior: A strong melee fighter with high strength and durability
                        Strength: {RegisteredPlayer.CurrentPlayer.Strength} (Primary)
                        Dexterity: {RegisteredPlayer.CurrentPlayer.Dexterity}
                        Intellect: {RegisteredPlayer.CurrentPlayer.Intelect}
                        Abilities: Melee attacks, high defense.
                        """);
                    break;

                case Player.PlayerClass.Mage:
                    Console.WriteLine($"""
                        Mage: A spellcaster with high intellect and magical abilities.
                        Strength: {RegisteredPlayer.CurrentPlayer.Strength}
                        Dexterity: {RegisteredPlayer.CurrentPlayer.Dexterity}
                        Intellect: {RegisteredPlayer.CurrentPlayer.Intelect} (Primary)
                        Abilities: Spells, ranged attacks, low defense.
                        """);
                    break;
                case Player.PlayerClass.GionusJahRakAAl:
                    Console.WriteLine($"""
                        Gionus_Jah_Rak_AAl: A powerful being with balanced stats.
                        Strength: {RegisteredPlayer.CurrentPlayer.Strength}
                        Dexterity: {RegisteredPlayer.CurrentPlayer.Dexterity}
                        Intellect: {RegisteredPlayer.CurrentPlayer.Intelect}
                        Abilities: Versatile in combat, high damage output.
                        """);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            Console.WriteLine("""
                Save Player data?
                1. Yes
                2. No
                """);
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                PlayerDataService.SavePlayer(RegisteredPlayer.CurrentPlayer);
                Console.WriteLine("Player data saved successfully.");
            }
            else if (choice == "2")
            {
                Console.WriteLine("Player data not saved.");
            }
            else
            {
                Console.WriteLine("Invalid choice. Player data not saved.");
            }




            Console.WriteLine("""
                Open Inventory?
                1. yes
                2. no
                """);
            string choice2 = Console.ReadLine();
            if (choice2 == "1")
            {
                RegisteredPlayer.CurrentPlayer.Inventory.ShowItems();
            }
            else if (choice2 == "2")
            {
                Console.WriteLine("Backpack not opened.");
            }
            else
            {
                Console.WriteLine("Invalid choice. Backpack not opened.");
            }
            ConsoleTexts.WhereToGo();
        }
    }
}