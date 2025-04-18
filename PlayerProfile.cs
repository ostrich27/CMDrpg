using System;
using RPG;
namespace RPG 
{
    public class PlayerProfile
    {
        public static void ShowPlayerProfile() 
        {
            Console.Clear();

            Console.WriteLine("_________________________________Player Profile_________________________________");
            Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine("");
            Console.WriteLine("Player Stats:");
            Console.WriteLine("Strength: " + RegisteredPlayer.CurrentPlayer.Strength);
            Console.WriteLine("Dexterity: " + RegisteredPlayer.CurrentPlayer?.Dexterity);
            Console.WriteLine("Intellect: " + RegisteredPlayer.CurrentPlayer?.Intelect);

            Console.WriteLine("____________________________________________________________"); Console.WriteLine(""); Console.WriteLine("");
            Console.WriteLine("Base Player Stats:");
            Console.WriteLine("Name: " + RegisteredPlayer.CurrentPlayer?.Name);
            Console.WriteLine("Class: " + RegisteredPlayer.CurrentPlayer?.playerClass);
            Console.WriteLine("Health: " + RegisteredPlayer.CurrentPlayer?.CurrentHealth);
            Console.WriteLine("Damage: " + RegisteredPlayer.CurrentPlayer?.Damage);
            Console.WriteLine("Level: " + RegisteredPlayer.CurrentPlayer?.LVL);
            Console.WriteLine("EXP: " + RegisteredPlayer.CurrentPlayer?.EXP);
            Console.WriteLine("EXP Till Next Level: " + RegisteredPlayer.CurrentPlayer?.EXPTillNextLvl);
            Console.WriteLine("Gold: " + RegisteredPlayer.CurrentPlayer?.Gold);
            ConsoleTexts.WhereToGo();
        }
             

    }
}
