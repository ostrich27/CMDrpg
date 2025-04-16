using RPG;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace RPG
{
    public class Program
    {

        static void Main(string[] args)
        {

            // Load player data
            RegisteredPlayer.CurrentPlayer = PlayerDataService.LoadPlayer();

            if (RegisteredPlayer.CurrentPlayer?.Name == null)
            {
                string? PlayerName;
                Console.Write("enter player name ");
                PlayerName = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(PlayerName))
                {
                    ConsoleTexts.PrintInvalidInput();
                    PlayerName = Console.ReadLine();
                }


                int Gold = 0;
                int PlayerExp = 0;
                int ExpToNextLvl = 500;
                int Lvl = 1;


                Console.WriteLine("enter player class");
                Console.WriteLine("1.Warrior");
                Console.WriteLine("2.Mage");
                Player.PlayerClass playerclass;
                playerclass = Console.ReadLine() switch
                {
                    "1" => Player.PlayerClass.Warrior,
                    "2" => Player.PlayerClass.Mage,
                    _ => throw new NotImplementedException(),
                };

                RegisteredPlayer.CurrentPlayer = new Player(
                    playerclass,   // PlayerClass
                    PlayerName,    // Name
                    100,           // CurrentHealth (starts full)
                    Gold,          // Gold
                    PlayerExp,     // EXP
                    ExpToNextLvl,  // EXPToNextLvl
                    Lvl            // LVL
                );

                Console.WriteLine("vaa vaa " + PlayerName + "s gaumarjos! " + playerclass + " kargi archevania");

 


            }
            else
            {
                ConsoleTexts.PrintWelcomeMessage();
            }

            ConsoleTexts.WhereToGo();
        }
    


        


    } 
}

