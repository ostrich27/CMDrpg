using System;
using RPG;

namespace RPG
{
    public class InventorySlot
    {
        public Item Item { get; private set; }
        public int Quantity { get; private set; }

        public InventorySlot(Item item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }
        public void AddQuantity(int amount)
        {
            Quantity += amount;
        }
        public void RemoveQuantity(int amount) 
        {
            Quantity -= amount; 
        }
    }
}