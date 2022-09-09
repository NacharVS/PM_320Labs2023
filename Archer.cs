using System;
namespace Warcraft
{
    class Archer : Military
    {
        int ArrowCount;
        public Archer(int health, int cost, string name, int lvl, int speed,
                    int damage, int attackSpeed, int armor, int ArrowCount)
                    : base(health, cost, name, lvl, speed, damage, attackSpeed, armor)
        {
            this.ArrowCount = ArrowCount;
        }


    }
}
