using RPG;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RPG
{
    public class BattleVSGoblin
    {
        public static int numberOfGoblins = 0;
        public static int numberOfGoblinBoss = 0;

        public static void Battle()
        {
            Console.Clear();

            ConsoleTexts.ChoseDificulty();

            List<Enemy> goblins = new List<Enemy>();
            List<Enemy> goblinBosses = new List<Enemy>();
            int enemyGoblinhealth = 50;
            int enemyGoblindamage = 5;
            float enemyGoblinDefense = 0.01f;

            // Create regular goblins
            for (int i = 0; i < numberOfGoblins; i++)
            {
                goblins.Add(new Enemy("Goblin " + (i + 1), enemyGoblinhealth, enemyGoblindamage, enemyGoblinDefense));
            }

            // Create boss goblins
            for (int j = 0; j < numberOfGoblinBoss; j++)
            {
                goblinBosses.Add(new Enemy("Goblin Boss " + (j + 1), enemyGoblinhealth * 3, enemyGoblindamage * 3, (enemyGoblinDefense + 0.2f) * 3));
            }

            Spell.Heal();
            Console.Clear();
            ConsoleTexts.PrintPlayerVS();

            // Display enemies
            if (goblins.Count > 0 || goblinBosses.Count > 0)
            {
                Console.WriteLine($"Enemies: {goblins.Count} goblins and {goblinBosses.Count} bosses");

                foreach (var goblin in goblins)
                {
                    Console.WriteLine($"{goblin.Name} HP: {goblin.Health}");
                }

                foreach (var boss in goblinBosses)
                {
                    Console.WriteLine($"{boss.Name} HP: {boss.Health}");
                }
            }

            while (RegisteredPlayer.CurrentPlayer?.CurrentHealth > 0 && (goblins.Count > 0 || goblinBosses.Count > 0))
            {
                // Player's turn
                Console.WriteLine("\nPlayer HP: " + RegisteredPlayer.CurrentPlayer.CurrentHealth);
                Console.Write("Choose action: 1.Attack  2.Heal ");

                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
                {
                    Console.WriteLine("invalid input!");
                    Console.Write("Choose action 1.Attack 2.Heal ");
                }

                if (choice == 1)
                {
                    // Player chooses target
                    Console.WriteLine("\nChoose which enemy to attack:");
                    int index = 1;

                    // List regular goblins
                    for (int i = 0; i < goblins.Count; i++)
                    {
                        Console.WriteLine($"{index++}. {goblins[i].Name} HP: {goblins[i].Health}");
                    }

                    // List bosses
                    for (int j = 0; j < goblinBosses.Count; j++)
                    {
                        Console.WriteLine($"{index++}. {goblinBosses[j].Name} HP: {goblinBosses[j].Health}");
                    }

                    int targetChoice;
                    int totalEnemies = goblins.Count + goblinBosses.Count;

                    if (totalEnemies == 1)
                    {
                        targetChoice = 1;
                    }
                    else
                    {
                        while (!int.TryParse(Console.ReadLine(), out targetChoice) || targetChoice < 1 || targetChoice > totalEnemies)
                        {
                            Console.WriteLine("invalid input!");
                            Console.Write("Choose which enemy to attack: ");
                        }
                    }

                    Console.Clear();

                    // Determine if target is regular goblin or boss
                    if (targetChoice <= goblins.Count)
                    {
                        // Attacking a regular goblin
                        Enemy target = goblins[targetChoice - 1];
                        int calculatedPlayerDamage = (int)(RegisteredPlayer.CurrentPlayer.Damage * (1 - target.Defense));
                        target.Health -= calculatedPlayerDamage;

                        Console.WriteLine($"\n{RegisteredPlayer.CurrentPlayer.Name} deals {calculatedPlayerDamage} damage to {target.Name}");
                        Console.WriteLine($"{target.Name} has {target.Health} HP remaining");

                        if (!target.IsAlive)
                        {
                            Console.WriteLine($"{target.Name} was defeated!");
                            goblins.Remove(target);
                            if (Quests.isQuestInProgress)
                            {
                                Quests.killCount++;
                                Console.WriteLine($"Quest progress: {Quests.killAmountRequired} / {Quests.killCount}");
                                if(Quests.killAmountRequired <= Quests.killCount)
                                {
                                    Quests.isQuestCompleted = true;
                                    Console.WriteLine("Quest completed! Go to tavern to claim reward!");
                                }
                            }
                        }
                    }
                    else
                    {
                        // Attacking a boss
                        int bossIndex = targetChoice - goblins.Count - 1;
                        Enemy target = goblinBosses[bossIndex];
                        int calculatedPlayerDamage = (int)(RegisteredPlayer.CurrentPlayer.Damage * (1 - target.Defense));
                        target.Health -= calculatedPlayerDamage;

                        Console.WriteLine($"\n{RegisteredPlayer.CurrentPlayer.Name} deals {calculatedPlayerDamage} damage to {target.Name}");
                        Console.WriteLine($"{target.Name} has {target.Health} HP remaining");

                        if (!target.IsAlive)
                        {
                            Console.WriteLine($"{target.Name} was defeated!");
                            goblinBosses.Remove(target);
                        }
                    }
                }
                else if (choice == 2)
                {
                    Console.Clear();

                    // Player heals
                    Spell.Heal();
                }

                // Check if all enemies are defeated
                if (goblins.Count == 0 && goblinBosses.Count == 0)
                {
                    Console.WriteLine("\nAll enemies defeated! You win!");
                    int totalExp = (500 * numberOfGoblins) + (1500 * numberOfGoblinBoss);
                    RegisteredPlayer.CurrentPlayer.EXP += totalExp;
                    Console.WriteLine($"You gained {totalExp} EXP!");

                    // Handle level ups
                    State.HandleLvlUP();
                    RegisteredPlayer.CurrentPlayer.CurrentHealth = RegisteredPlayer.CurrentPlayer.MaxHealth;

                    PlayerDataService.SavePlayer(RegisteredPlayer.CurrentPlayer);
                    ConsoleTexts.PrintExpTillNextLvl();
                    ConsoleTexts.PrintCurrentExp();
                    ConsoleTexts.WhereToGo();
                    return;
                }

                // Enemies' turn
                if (RegisteredPlayer.CurrentPlayer?.CurrentHealth > 0 && (goblins.Count > 0 || goblinBosses.Count > 0))
                {
                    Console.WriteLine("\nEnemies attack!");
                    int totalDamage = 0;

                    // Regular goblins attack
                    foreach (var goblin in goblins)
                    {
                        int calculatedDamage = (int)(goblin.Damage - (goblin.Damage * RegisteredPlayer.CurrentPlayer.Defense));
                        RegisteredPlayer.CurrentPlayer.CurrentHealth -= calculatedDamage;
                        totalDamage += calculatedDamage;
                        Console.WriteLine($"{goblin.Name} deals {calculatedDamage} damage");
                    }

                    // Bosses attack
                    foreach (var boss in goblinBosses)
                    {
                        int calculatedDamage = (int)(boss.Damage - (boss.Damage * RegisteredPlayer.CurrentPlayer.Defense));
                        RegisteredPlayer.CurrentPlayer.CurrentHealth -= calculatedDamage;
                        totalDamage += calculatedDamage;
                        Console.WriteLine($"{boss.Name} deals {calculatedDamage} damage");
                    }

                    Console.WriteLine($"Total damage taken: {totalDamage}");
                    Console.WriteLine($"Player HP: {RegisteredPlayer.CurrentPlayer.CurrentHealth}");

                    if (!RegisteredPlayer.CurrentPlayer.IsAlive)
                    {
                        Console.WriteLine("\n" + RegisteredPlayer.CurrentPlayer.Name + " was defeated!");
                        RegisteredPlayer.CurrentPlayer.EXP -= 500;

                        State.HandleLvlDown();

                        MainMenu.Mainmenu();
                    }
                }
            }
        }
    }
}