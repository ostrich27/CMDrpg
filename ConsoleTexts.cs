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

            Console.WriteLine("""
                Chose where to go:                 
                1.Town
                2.Battlefield
                3.Main menu
                4. Profile
                """);

            int choice = Choice.Get(1, 4);
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
            
        }

        public static void ChoseDificulty()
        {
            Console.WriteLine("""
                chose dificulty: 
                1.Easy
                2.Normal
                3.Hard
                """);

            int choice = Choice.Get(1, 3);
            switch (choice)
            {
                case 1:
                    NumberOfEnemy.numberOfEnemy = 5;
                    NumberOfEnemy.numberOfEnemyBoss = 0;
                    break;
                case 2:
                    NumberOfEnemy.numberOfEnemy = 3;
                    NumberOfEnemy.numberOfEnemyBoss = 1;
                    break;
                case 3:
                    NumberOfEnemy.numberOfEnemy = 1;
                    NumberOfEnemy.numberOfEnemyBoss = 2;
                    break;
            }

        }
        public static void PrintPlayerVS()
        {
            Console.WriteLine("player: " + RegisteredPlayer.CurrentPlayer?.Name + "HP:" + RegisteredPlayer.CurrentPlayer?.CurrentHealth);
            Console.WriteLine("VS");

        }



    }
    class NumberOfEnemy
    {
        public static int numberOfEnemy = 0;
        public static int numberOfEnemyBoss = 0;
    }
}