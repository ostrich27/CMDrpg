using System;

namespace RPG
{
    [Serializable]

    public enum ItemType
    {
        None,
        Weapon,
        Armor,
        Helmet,

    }

    public class Item
    {
        public ItemType itemType { get; set; }

        public string name { get; set; }
        public bool isStackable { get; set; }
        public bool isEquipable { get; set; }
        public bool isEquiped { get; set; } = false;
        public bool isEnchanted { get; set; }
        public int quantity { get; set; }
        public int stackLimit { get; set; } = 10;
        public int itemDamage { get; set; } = 0;
        public int itemStrength { get; set; } = 0;
        public int itemIntelect { get; set; } = 0;
        public int itemDexterity { get; set; } = 0;
        public int itemHealth { get; set; } = 0;
        public int itemEnchantNumber { get; set; } = 0;

        public Item()
        {
            name = "Unknown Item";
            isStackable = false;
            quantity = 1;
            stackLimit = 1;
        }

        public Item(string name,
            bool isStackable = false,
            bool isEquipable = false,
            bool isEquiped = false,
            bool isEnchanted = false,
            int quantity = 1,
            int stackLimit = 1,
            int itemDamage = 0,
            int itemHealth = 0,
            int itemStrength = 0,
            int itemDexterity = 0,
            int itemIntelect = 0,
            ItemType itemType = ItemType.None
            )
        {
            this.name = name;
            this.isStackable = isStackable;
            this.isEquipable = isEquipable;
            this.isEquiped = isEquiped;
            this.isEnchanted = isEnchanted;
            this.quantity = quantity;
            this.stackLimit = stackLimit;
            this.isEquiped = isEquiped;
            this.itemDamage = itemDamage;
            this.itemHealth = itemHealth;
            this.itemStrength = itemStrength;
            this.itemDexterity = itemDexterity;
            this.itemIntelect = itemIntelect;
            this.itemType = itemType;
        }

    }
}
