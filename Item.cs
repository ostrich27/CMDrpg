using System;
using System.Security.Cryptography.X509Certificates;
using RPG;

namespace RPG
{
    public class Item
    {
        public string name;
        public bool isStackable;
        public int quantity;
        public int stackLimit;
        public Item (string name, bool isStackable = false, int quantity = 1, int stackLimit = 1)
        {
            this.name = name;
            this.isStackable = isStackable;
            this.quantity = quantity;
            this.stackLimit = stackLimit;
        }
    }
}