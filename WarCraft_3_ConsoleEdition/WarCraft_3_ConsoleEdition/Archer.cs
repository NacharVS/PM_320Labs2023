﻿namespace WarCraft_3_ConsoleEdition
{
    class Archer : Range
    {
        public int arrowCount;
        public Archer(int range, int damage, int attackSpeed, int arrowCount,
            int armor, int speed, int health, int cost, string name, int level)
           : base(range, 0, damage, attackSpeed, armor, speed, health, cost, name, level)
        {
            this.arrowCount = arrowCount;
        }
    }
}
