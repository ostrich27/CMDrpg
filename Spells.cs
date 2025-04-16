using System;
using RPG;

namespace RPG
{
      class Spell
    { 
        
                     public static int BaseHealAmmount = 15;
                      public static int HealAmmount = (int)(BaseHealAmmount + (RegisteredPlayer.CurrentPlayer.Intelect * 0.5f));


        public static void Heal()
        {
            if (RegisteredPlayer.CurrentPlayer.CurrentHealth <= RegisteredPlayer.CurrentPlayer.MaxHealth - HealAmmount)
            {
                RegisteredPlayer.CurrentPlayer.CurrentHealth += HealAmmount;
                Console.WriteLine($"You healed for {HealAmmount} HP");
            }
            else
            {
                RegisteredPlayer.CurrentPlayer.CurrentHealth = RegisteredPlayer.CurrentPlayer.MaxHealth;
                Console.WriteLine($"You healed for " + (RegisteredPlayer.CurrentPlayer.MaxHealth - RegisteredPlayer.CurrentPlayer.CurrentHealth) +  "HP");
            }


        }



    } 
}