using System;
using System.Security.Cryptography.X509Certificates;
using RPG;

namespace RPG
{
    public class Item
    {
        public String Name { get; set; }
        public bool IsStackable { get; set; }
        public Item (string name, bool isStackable)
        {
            Name = name;
            IsStackable = isStackable;
        }
    }
}