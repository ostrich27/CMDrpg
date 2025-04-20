using RPG;

[Serializable]
public class Player
{
    public enum PlayerClass
    {
        Warrior,
        Mage,
        GionusJahRakAAl,
    }

    public PlayerClass playerClass; // This is the field that will be serialized

    public void HandlePlayerClass()
    {
        switch (playerClass)
        {
            case PlayerClass.Warrior:
                Strength = 5;
                Dexterity = 3;
                Intelect = 2;
                int WarriorBaseHealth = 150;
                int WarriorBaseDamage = 10;
                float WarriorBaseDefense = 0.02f;
                Defense = WarriorBaseDefense + (Dexterity / 100);

                MaxHealth = (int)(WarriorBaseHealth + (Strength * 0.5f));
                Damage = (int)(WarriorBaseDamage + (Strength * 0.2));
                break;
            case PlayerClass.Mage:
                Strength = 2;
                Dexterity = 3;
                Intelect = 7;
                int MageBaseHealth = 100;
                int MageBaseDamage = 10;
                float MageBaseDefense = 0.01f + (Dexterity / 100);
                MaxHealth = (int)(MageBaseHealth + (Strength * 0.5f));
                Damage = (int)(MageBaseDamage + (Intelect * 0.5));
                break;
            case PlayerClass.GionusJahRakAAl:
                Strength = 10;
                Dexterity = 10;
                Intelect = 10;
                int GionusBaseHealth = 130;
                int GionusBaseDamage = 16;
                float GionusBaseDefense = 0.5f + (Dexterity / 100);
                MaxHealth = (int)(GionusBaseHealth + (Strength * 0.5f));
                Damage = (int)(GionusBaseDamage + (Dexterity * 0.5));
                break;

        }
    }

    // Basic stats
    public string Name { get; set; }
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }
    public int Damage { get; set; }
    public float Defense { get; set; }
    // Player stats
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Intelect { get; set; }

    // Resource types
    public int Gold { get; set; }
    public int EXP { get; set; }
    public int EXPToNextLvl { get; set; }
    public int EXPTillNextLvl => EXPToNextLvl - EXP;
    public int LVL { get; set; }

    public bool IsAlive => RegisteredPlayer.CurrentPlayer.CurrentHealth > 0;
    public Inventory Inventory { get; set; } = new Inventory();


    // Parameterless constructor required for XML serialization
    public Player( )
    {
        // Initialize with default values
        playerClass = PlayerClass.Warrior;
        Name = "New Player";
        MaxHealth = 100;
        CurrentHealth = 100;
        Damage = 10;
        Strength = 5;
        Dexterity = 3;
        Intelect = 2;
        Gold = 0;
        EXP = 0;
        EXPToNextLvl = 500;
        LVL = 1;
        Inventory = new Inventory();
    }

    public Player(PlayerClass playerClass, string name, int gold, int playerExp, int expToNextLvl, int lvl)
    {
        this.playerClass = playerClass;
        Name = name;
        Gold = gold;
        EXP = playerExp;
        EXPToNextLvl = expToNextLvl;
        LVL = lvl;
        Inventory = new Inventory();
        // Set base stats based on class
        HandlePlayerClass();

        // Ensure CurrentHealth does not exceed MaxHealth
        CurrentHealth = MaxHealth;
    }
}