using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace RPG
{
    [Serializable]
    public class Inventory
    {
        public int maxSlots { get; set; } = 10;
        public List<Item> items = new List<Item>();

        public Inventory()
        {
            maxSlots = 10;
            items = new List<Item>();
        }

        public void AddItem(Item newItem)
        {
            if (newItem.isStackable)
            {
                foreach (Item item in items)
                {
                    if (item.name == newItem.name && item.isStackable && item.quantity < item.stackLimit)
                    {
                        int spaceLeft = item.stackLimit - item.quantity;
                        int amountToAdd = Math.Min(spaceLeft, newItem.quantity);
                        item.quantity += amountToAdd;
                        newItem.quantity -= amountToAdd;
                        if (newItem.quantity == 0)
                            return;
                    }
                }
            }
            while (newItem.quantity > 0)
            {
                if (items.Count >= maxSlots)
                {
                    Console.WriteLine("inventory is full! could not add all items");
                    return;
                }
                int addAmount = newItem.isStackable ? Math.Min(newItem.stackLimit, newItem.quantity) : 1;

                Item itemCopy = new Item(
                    newItem.name,
                    newItem.isStackable,
                    newItem.isEquipable,
                    newItem.isEquiped,
                    newItem.isEnchanted,
                    addAmount,
                    newItem.stackLimit,
                    newItem.itemDamage,
                    newItem.itemHealth,
                    newItem.itemStrength,
                    newItem.itemDexterity,
                    newItem.itemIntelect,
                    newItem.itemType);
                items.Add(itemCopy);
                newItem.quantity -= addAmount;
            }
        }



        public void ShowItems()
        {
            Console.WriteLine("Inventory:");
            foreach (Item item in items)
            {
                Console.WriteLine("- " + item.name + " - " + item.quantity);
            }
            Console.WriteLine($"Inventory slots: {items.Count} / {maxSlots}");
            Console.WriteLine("""
                    do you want to equip items?
                    1. yes
                    2. no
                    """);
            int choice = Choice.Get(1, 2);
            switch (choice)
            {
                case 1:
                    EquipItems();
                    break;
                case 2:
                    ConsoleTexts.WhereToGo();
                    break;
            }

        }




        public void EquipItems()
        {
            foreach (Item item in items)
            {
                if (item.isEquipable && !item.isEquiped)
                {
                    Console.WriteLine($"""
                Equip {item.name} ({item.itemType})?
                1. Yes
                2. No
                """);
                    int choice = Choice.Get(1, 2);
                    switch (choice)
                    {
                        case 1:
                            EquipItem(item);
                            break;
                        case 2:
                            break;
                    }
                }
            }
        }

        private void EquipItem(Item item)
        {
            Player player = RegisteredPlayer.CurrentPlayer;

            switch (item.itemType)
            {
                case ItemType.Weapon:

                    if (player.EquippedWeapon != null)
                        UnequipItem(player.EquippedWeapon);
                    player.EquippedWeapon = item;
                    break;

                case ItemType.Armor:
                    if (player.EquippedArmor != null)
                        UnequipItem(player.EquippedArmor);
                    player.EquippedArmor = item;
                    break;

                case ItemType.Helmet:
                    if (player.EquippedHelmet != null)
                        UnequipItem(player.EquippedHelmet);
                    player.EquippedHelmet = item;
                    break;

                default:
                    Console.WriteLine("Item type not supported for equipping yet.");
                    return;
            }

            ApplyItemBonuses(item);
            item.isEquiped = true;
        }

        private void UnequipItem(Item item)
        {
            Player player = RegisteredPlayer.CurrentPlayer;
            player.Damage -= item.itemDamage;
            player.MaxHealth -= item.itemHealth;
            player.Strength -= item.itemStrength;
            player.Dexterity -= item.itemDexterity;
            player.Intelect -= item.itemIntelect;
            item.isEquiped = false;
        }

        private void ApplyItemBonuses(Item item)
        {
            Player player = RegisteredPlayer.CurrentPlayer;
            player.Damage += item.itemDamage;
            player.MaxHealth += item.itemHealth;
            player.Strength += item.itemStrength;
            player.Dexterity += item.itemDexterity;
            player.Intelect += item.itemIntelect;
        }


    }
}
