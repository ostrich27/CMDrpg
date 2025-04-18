using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using RPG;
namespace RPG
{
    class Quests
    {
        public static bool isQuestAvailable;
        public static bool isQuestInProgress;
        public static bool isQuestAcceptable;
        public static bool isQuestCompleted;
        public static bool isQuestAccepted;
        public static string questName;
        public static int questID = 1;
        public static int questEXP;
        public static int questGold;
        public static int requiredKillCount;
        public static int killCount;
        public static int killAmountRequired;

        public static void ChoseQuest()
        {
            Console.Clear();
            Console.WriteLine($"Hello, {RegisteredPlayer.CurrentPlayer.Name},!");
            Console.WriteLine("""
                Welcome to the quest menu!
                1. Kill Goblin
                2. Exit tavern
                """);
            int choice = Choice.Get(1, 2);
            switch (choice)
            {
                case 1:
                    KillGoblin();
                    break;
                case 2:
                    WheretoGoTown.Tavern();
                    break;
            }
        }
        public static void KillGoblin()
        {
            if (isQuestCompleted)
            {
                Console.WriteLine($"""
                    You have completed quest!
                    your reward: {questGold} gold and {questEXP} exp!
                    """);

                CompleteQuest();
                Console.WriteLine("press any key to return to Tavern");
                Console.ReadKey();
                WheretoGoTown.Tavern();
                return;
            }

            else if (isQuestInProgress)
            {
                Console.WriteLine("""
                    You are already on a quest!
                    press any key to return to Tavern
                    """);
                Console.ReadKey();

                WheretoGoTown.Tavern();
            }
            if (!isQuestInProgress && questID <= 1)
            {
                killAmountRequired = 1;
                questGold = 100;
                questEXP = 1000;
                questName = "Kill Goblin";
                Console.WriteLine($"{questName} Reward: {questGold} Gold, {questEXP} EXP");


                Console.WriteLine($"""
                    Kill {killAmountRequired} goblin
                    1. Accept Quest
                    2. Decline Quest
                    """);

                int choice = Choice.Get(1, 2);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Quest Acepted, Go kill goblin!");
                        isQuestAccepted = true;
                        isQuestAvailable = true;
                        isQuestInProgress = true;
                        killCount = 0;
                        Console.WriteLine("press any key to return to Tavern");
                        Console.ReadKey();
                        WheretoGoTown.Tavern();
                        break;
                    case 2:
                        Console.WriteLine("Quest Declined, try another time!");
                        isQuestAccepted = false;
                        isQuestAvailable = true;
                        isQuestCompleted = false;
                        WheretoGoTown.Tavern();
                        break;

                }
            }else
            {
                Console.WriteLine("""
                    Quest allready claimed!
                    press any key to return to Tavern
                    """);
                Console.ReadKey();
                WheretoGoTown.Tavern();
            }
        }


        public static void CompleteQuest()
        {
            RegisteredPlayer.CurrentPlayer.Gold += questGold;
            RegisteredPlayer.CurrentPlayer.EXP += questEXP;
            questID++;
            isQuestAccepted = false;
            isQuestAvailable = false;
            isQuestCompleted = false;
            isQuestInProgress = false;
        }
    }
}