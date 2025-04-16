using System;

namespace RPG
{
    public class Enemy
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public float Defense { get; set; }
        public bool IsAlive => Health > 0;

        public Enemy(string name, int health, int damage, float defense)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Defense = defense;
        }


    }

}