using System;

namespace RPG
{
    [Serializable]
    public class Item
    {
        public string name { get; set; }
        public bool isStackable { get; set; }
        public int quantity { get; set; }
        public int stackLimit { get; set; } = 10;

        public Item()
        {
            name = "Unknown Item";
            isStackable = false;
            quantity = 1;
            stackLimit = 1;
        }

        public Item(string name, bool isStackable = false, int quantity = 1, int stackLimit = 1)
        {
            this.name = name;
            this.isStackable = isStackable;
            this.quantity = quantity;
            this.stackLimit = stackLimit;
        }
    }
}
