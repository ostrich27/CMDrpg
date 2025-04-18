using System;
using System.Security.Cryptography.X509Certificates;
using RPG;

namespace RPG
{
    public class Inventory
    {
        private List <InventorySlot> slots = new List<InventorySlot>();
        private int maxSlots;
        public Inventory(int maxSlots = 20)
        {
            this.maxSlots = maxSlots;
        }
        public void AddItem(Item item, int quantity) 
        {
            if (item.IsStackable) 
            {
                var existingslot = slots.Find(slot => slot.Item.Name == item.Name);
                if (existingslot != null) 
                {
                    existingslot.AddQuantity(quantity);
                    return;
                }                
            }
            if (slots.Count < maxSlots)
            {
                slots.Add(new InventorySlot(item, quantity));
            }
            else
            {
                Console.WriteLine("Inventory is full!");
            }
        }
        public void RemoveItem(Item item,string itemName, int quantity)
        {
            var slot = slots.Find(slot => slot.Item.Name == itemName);
            if (slot != null)
            {
                slot.RemoveQuantity(quantity);
                if (slot.Quantity <= 0)
                    slots.Remove(slot);
            }
            else 
            {
                Console.WriteLine("Item not found in inventory!"); 
            }
        }
        public void ShowInventory()
        {
            Console.WriteLine("Inventory:");
            foreach (var slot in slots)
            {
                Console.WriteLine($"{slot.Item.Name} - {slot.Quantity}");
            }
        }
    }
}
