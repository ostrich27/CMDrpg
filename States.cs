using System;
using RPG;
namespace RPG
{
    class State
    {

        public static void HandleLvlUP()
        {

            while (RegisteredPlayer.CurrentPlayer.EXP >= RegisteredPlayer.CurrentPlayer.EXPToNextLvl)
            {
                int excessExp = RegisteredPlayer.CurrentPlayer.EXP - RegisteredPlayer.CurrentPlayer.EXPToNextLvl;
                RegisteredPlayer.CurrentPlayer.LVL++;
                RegisteredPlayer.CurrentPlayer.MaxHealth += 10;
                RegisteredPlayer.CurrentPlayer.Damage += 5;
                //add stats
                if (RegisteredPlayer.CurrentPlayer.playerClass == Player.PlayerClass.Warrior)
                {
                    RegisteredPlayer.CurrentPlayer.Strength += 2;
                    RegisteredPlayer.CurrentPlayer.Intelect += 1;
                    RegisteredPlayer.CurrentPlayer.Dexterity += 1;
                }
                else if (RegisteredPlayer.CurrentPlayer.playerClass == Player.PlayerClass.Mage)
                {
                    RegisteredPlayer.CurrentPlayer.Intelect += 2;
                    RegisteredPlayer.CurrentPlayer.Strength += 1;
                    RegisteredPlayer.CurrentPlayer.Dexterity += 1;
                }
                else if (RegisteredPlayer.CurrentPlayer.playerClass == Player.PlayerClass.Gionus_Jah_Rak_AAl)
                {
                    RegisteredPlayer.CurrentPlayer.Strength += 2;
                    RegisteredPlayer.CurrentPlayer.Intelect += 1;
                    RegisteredPlayer.CurrentPlayer.Dexterity += 1;
                }
                else
                {
                    Console.WriteLine("Unknown player class.");

                    RegisteredPlayer.CurrentPlayer.EXP = excessExp; // Carry over remaining EXP
                    RegisteredPlayer.CurrentPlayer.EXPToNextLvl *= 2;
                    Console.WriteLine("LVL UP!");
                    Console.WriteLine($"Current LVL: {RegisteredPlayer.CurrentPlayer.LVL}");
                    Console.WriteLine($"New EXP: {RegisteredPlayer.CurrentPlayer.EXP}/{RegisteredPlayer.CurrentPlayer.EXPToNextLvl}");

                    if (excessExp > 0)
                    {
                        Console.WriteLine($"Carried over {excessExp} EXP to next level");
                    }
                }

            }
        }


        public static void HandleLvlDown()
        {

            if (RegisteredPlayer.CurrentPlayer.EXP < 0 && RegisteredPlayer.CurrentPlayer.LVL > 1)
            {
                if (RegisteredPlayer.CurrentPlayer.playerClass == Player.PlayerClass.Warrior)
                {
                    RegisteredPlayer.CurrentPlayer.LVL--;
                    RegisteredPlayer.CurrentPlayer.MaxHealth -= 10;
                    RegisteredPlayer.CurrentPlayer.Damage -= 5;
                    RegisteredPlayer.CurrentPlayer.LVL--;
                    RegisteredPlayer.CurrentPlayer.EXPToNextLvl /= 2;
                    RegisteredPlayer.CurrentPlayer.Strength -= 2;
                    RegisteredPlayer.CurrentPlayer.Intelect -= 1;
                    RegisteredPlayer.CurrentPlayer.Dexterity -= 1;
                }
                else if (RegisteredPlayer.CurrentPlayer.playerClass == Player.PlayerClass.Mage)
                {
                    RegisteredPlayer.CurrentPlayer.LVL--;
                    RegisteredPlayer.CurrentPlayer.MaxHealth -= 10;
                    RegisteredPlayer.CurrentPlayer.Damage -= 5;
                    RegisteredPlayer.CurrentPlayer.LVL--;
                    RegisteredPlayer.CurrentPlayer.EXPToNextLvl /= 2;
                    RegisteredPlayer.CurrentPlayer.Strength -= 2;
                    RegisteredPlayer.CurrentPlayer.Intelect -= 1;
                    RegisteredPlayer.CurrentPlayer.Dexterity -= 1;
                }
                else if (RegisteredPlayer.CurrentPlayer.playerClass == Player.PlayerClass.Gionus_Jah_Rak_AAl)
                {
                    RegisteredPlayer.CurrentPlayer.LVL--;
                    RegisteredPlayer.CurrentPlayer.MaxHealth -= 10;
                    RegisteredPlayer.CurrentPlayer.Damage -= 5;
                    RegisteredPlayer.CurrentPlayer.LVL--;
                    RegisteredPlayer.CurrentPlayer.EXPToNextLvl /= 2;
                    RegisteredPlayer.CurrentPlayer.Strength -= 2;
                    RegisteredPlayer.CurrentPlayer.Intelect -= 1;
                    RegisteredPlayer.CurrentPlayer.Dexterity -= 1;
                }
            }


                Console.WriteLine("LVL DOWN!");
                Console.WriteLine($"Current LVL: {RegisteredPlayer.CurrentPlayer.LVL}");
        }

    }

}