using RPG;
using System;
using System.Security.Cryptography.X509Certificates;

namespace RPG 
{
    public static class WheretoGoTown
    {
        public static void Town()
        {
            Console.Clear();
            Console.WriteLine("""
                Chose where to Go: 
                1. Shop
                2. Tavern
                3. Main menu
                """);
            int choice = Choice.Get(1, 3);
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
        }
        public static void Shop()
        {
            Console.Clear();

            Console.WriteLine($"Hello, {RegisteredPlayer.CurrentPlayer.Name},!");
            Console.WriteLine("""
                Welcome to the shop!
                1. Buy items
                2. Sell items
                3. Exit shop
                """);
            int choice = Choice.Get(1, 3);
            switch (choice)
            {
                case 1:
                    BuyItems();
                    break;
                case 2:
                    Console.WriteLine("You chose to sell items.");
                    // Add logic for selling items
                    break;
                case 3:
                    WheretoGoTown.Town();
                    break;
            }


        }
        public static void Tavern()
        {
            Console.Clear();

            Console.WriteLine($"""
                Hello, {RegisteredPlayer.CurrentPlayer.Name},! 
                Welcome to the tavern!
                1. Quests
                2. Eat
                3. Exit tavern
                """);
            int choice = Choice.Get(1, 3);
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
        }
        public static void BuyItems()
        {
            Inventory inventory = new Inventory();
            Item potion = new Item("Health Potion", true);
            Item sword = new Item("Sword", false);
            Console.WriteLine("""
                1. health potion - 10 gold
                2. sword - 50 gold
                """);
            int choice = Choice.Get(1, 2);
            switch (choice)
            {
                case 1:
                    if (RegisteredPlayer.CurrentPlayer.Gold >= 10)
                    {
                        RegisteredPlayer.CurrentPlayer.Gold -= 10;
                        Console.WriteLine("You bought a health potion.");
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough gold.");
                    }
                    break;
                case 2:
                    if (RegisteredPlayer.CurrentPlayer.Gold >= 50)
                    {
                        RegisteredPlayer.CurrentPlayer.Gold -= 50;
                        Console.WriteLine("You bought a sword.");
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough gold.");
                    }
                    break;
            }
            Console.WriteLine("Press any key to return to the shop menu.");
            Console.ReadKey();
            Shop();
        }




    }
    public static class Choice
    {
        public static int Get(int min, int max)
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