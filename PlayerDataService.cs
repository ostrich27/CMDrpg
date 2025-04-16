using System;
using System.IO;
using System.Xml.Serialization;

namespace RPG
{
    public static class PlayerDataService
    {
        // Use the current folder + "PlayerData"
        private static string AppDataFolder => Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "PlayerData");

        private static string SaveFileName => Path.Combine(AppDataFolder, "PlayerData.xml");
        private static string BackupFileName => Path.Combine(AppDataFolder, "PlayerData_Backup.xml");

        static PlayerDataService()
        {
            // Ensure the PlayerData folder exists
            if (!Directory.Exists(AppDataFolder))
            {
                Directory.CreateDirectory(AppDataFolder);
            }
        }

        public static void SavePlayer(Player player)
        {
            if (player == null)
            {
                Console.WriteLine("Error: Cannot save null player");
                return;
            }

            try
            {
                // Create backup if existing save exists
                if (File.Exists(SaveFileName))
                {
                    File.Copy(SaveFileName, BackupFileName, overwrite: true);
                }

                // Serialize and save player data
                var serializer = new XmlSerializer(typeof(Player));
                using (var stream = new FileStream(SaveFileName, FileMode.Create))
                {
                    serializer.Serialize(stream, player);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving game:");
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                RestoreBackup();
            }
        }

        public static Player? LoadPlayer()
        {

            if (!File.Exists(SaveFileName))
            {
                Console.WriteLine("No save file found - starting new game");
                return null;
            }

            try
            {
                var serializer = new XmlSerializer(typeof(Player));
                using (var stream = new FileStream(SaveFileName, FileMode.Open))
                {
                    var player = (Player?)serializer.Deserialize(stream);

                    if (player?.Name == null)
                    {
                        Console.WriteLine("Save file corrupted - attempting backup");
                        return TryLoadBackup();
                    }

                    Console.WriteLine("Game loaded successfully!");
                    return player;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading save:");
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                return TryLoadBackup();
            }
        }

        private static Player? TryLoadBackup()
        {
            if (!File.Exists(BackupFileName))
            {
                Console.WriteLine("No backup save found - starting new game");
                return null;
            }

            try
            {
                var serializer = new XmlSerializer(typeof(Player));
                using (var stream = new FileStream(BackupFileName, FileMode.Open))
                {
                    var player = (Player?)serializer.Deserialize(stream);

                    if (player?.Name == null)
                    {
                        Console.WriteLine("Backup file also corrupted - starting new game");
                        return null;
                    }

                    Console.WriteLine("Successfully loaded from backup!");
                    return player;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading backup:");
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                return null;
            }
        }

        private static void RestoreBackup()
        {
            if (File.Exists(BackupFileName))
            {
                try
                {
                    File.Copy(BackupFileName, SaveFileName, overwrite: true);
                    Console.WriteLine("Restored from backup");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to restore backup:");
                    Console.WriteLine($"Message: {ex.Message}");
                    Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                }
            }
        }

        public static void DeleteAllSaveData()
        {
            try
            {
                if (File.Exists(SaveFileName))
                    File.Delete(SaveFileName);
                if (File.Exists(BackupFileName))
                    File.Delete(BackupFileName);
                Console.WriteLine("All save data deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting save data:");
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            }
        }
    }
}
