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
                Item itemCopy = new Item(newItem.name, newItem.isStackable, addAmount, newItem.stackLimit);
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
        }

        [NonSerialized]
        public static Inventory SharedInventory = new Inventory();

        // These object instances should not be here; they’re not used inside methods or properties.
        // You might want to move them to somewhere like a Game class initializer or main method.
         //Item potion = new Item("Health Potion", true, 1, 5);
        // Item sword = new Item("Sword", false, 1, 1);
    }
}
