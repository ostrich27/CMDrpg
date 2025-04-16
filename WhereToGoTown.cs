using RPG;
using System;

namespace RPG 
{
    public static class WheretoGoTown
    {
        public static void Town()
        {
            Console.Clear();
            Console.WriteLine("Chose where to Go: ");
            Console.WriteLine("1. Shop");
            Console.WriteLine("2. Tavern");
            Console.WriteLine("3. Main menu");
            int choice = GetChoice(1, 3);
            switch (choice)
            {
                case 1:
                    Shop();
                    break;
                case 2:
                    Tavern();
                    break;
                case 3:
                    MainMenu.Mainmenu();
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
        public static void Shop()
        {
            Console.Clear();

            Console.WriteLine($"Hello, {RegisteredPlayer.CurrentPlayer.Name},!");
            Console.WriteLine("Welcome to the shop!");
            Console.WriteLine("1. Buy items");
            Console.WriteLine("2. Sell items");
            Console.WriteLine("3. Exit shop");
            int choice = GetChoice(1, 3);
            switch (choice)
            {
                case 1:
                    Console.WriteLine("You chose to buy items.");
                    // Add logic for buying items
                    break;
                case 2:
                    Console.WriteLine("You chose to sell items.");
                    // Add logic for selling items
                    break;
                case 3:
                    WheretoGoTown.Town();
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
        public static void Tavern()
        {
            Console.Clear();

            Console.WriteLine($"Hello, {RegisteredPlayer.CurrentPlayer.Name},!");
            Console.WriteLine("Welcome to the tavern!");
            Console.WriteLine("1. Quests");
            Console.WriteLine("2. Eat");
            Console.WriteLine("3. Exit tavern");
            int choice = GetChoice(1, 3);
            switch (choice)
            {
                case 1:
                    Quests.ChoseQuest();
                    break;
                case 2:
                    Console.WriteLine("You chose to eat.");
                    // Add logic for eating
                    break;
                case 3:
                    WheretoGoTown.Town();
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
    }

}