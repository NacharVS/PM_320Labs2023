using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWarcraft
{
    public class Archer : Military
    {
        public int arrowCount = 0;

        public Archer(String name, int health, int cost, int level, double damage, int attackSpeed, int armor, int arrowCount, bool isDestroy)
        {
            this.name = name;
            this.health = health;
            this.cost = cost;
            this.level = level;
            this.isDestroy = isDestroy;
            this.damage = damage;
            this.attackSpeed = attackSpeed;
            this.armor = armor;
            this.arrowCount = arrowCount;   
        }

        public override void attack(Unit unit)
        {
            damage = (attackSpeed + level * 0.2);
            unit.health -= damage;
        }
    }
}
