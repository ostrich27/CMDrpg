using System;
using System.Security.Cryptography.X509Certificates;

namespace RPG
{
    public static class ConsoleTexts
    {
        public static void PrintWelcomeMessage()
        {
            string playerName = RegisteredPlayer.CurrentPlayer.Name;
            Console.WriteLine($"Welcome, {playerName}!");
        }
        public static void PrintInvalidInput()
        {
            Console.WriteLine("Invalid input! Please try again.");
        }
        public static void PrintCurrentExp()
        {
            Console.WriteLine("Current EXP: " + RegisteredPlayer.CurrentPlayer.EXP);
        }
        public static void PrintExpTillNextLvl()
        {
            Console.WriteLine("EXP remaining to next LVL: " + RegisteredPlayer.CurrentPlayer.EXPTillNextLvl);
        }
        public static void WhereToGo() {

            Console.WriteLine("Chose where to go: ");
            Console.WriteLine("1.Town");
            Console.WriteLine("2.Battlefield");
            Console.WriteLine("3.Main menu");
            Console.WriteLine("4. Profile");
            int choice = GetChoice(1, 4);
            switch (choice)
            {
                case 1:
                    Town.Enter();
                    break;
                case 2:
                    BattleVSGoblin.Battle();
                    break;
                case 3:
                    MainMenu.Mainmenu();
                    break;    
                case 4:
                    PlayerProfile1.ShowPlayerProfile1();
                    break;

            }
            static int GetChoice(int min, int max)
            {
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) && choice < min || choice > max)
                {
                    Console.WriteLine("invalid choice. try again");
                }
                return choice;
            }
            
        }

        public static void ChoseDificulty()
        {
            Console.WriteLine("chose dificulty: ");
            Console.WriteLine("1.Easy");
            Console.WriteLine("2.Normal");
            Console.WriteLine("3.Hard");
            int choice = GetChoice(1, 3);
            switch (choice)
            {
                case 1:
                    BattleVSGoblin.numberOfGoblins = 1;
                    BattleVSGoblin.numberOfGoblinBoss = 0;
                    break;
                case 2:
                    BattleVSGoblin.numberOfGoblins = 3;
                    BattleVSGoblin.numberOfGoblinBoss = 1;
                    break;
                case 3:
                    BattleVSGoblin.numberOfGoblins = 1;
                    BattleVSGoblin.numberOfGoblinBoss = 2;
                    break;
            }
            static int GetChoice(int min, int max)
            {
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) && choice < min || choice > max)
                {
                    Console.WriteLine("invalid choice. try again");
                }
                return choice;
            }

        }
        public static void PrintPlayerVS()
        {
            Console.WriteLine("player: " + RegisteredPlayer.CurrentPlayer?.Name + "HP:" + RegisteredPlayer.CurrentPlayer?.CurrentHealth);
            Console.WriteLine("VS");

        }



}
}