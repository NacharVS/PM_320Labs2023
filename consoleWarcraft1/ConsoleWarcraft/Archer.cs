using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWarcraft
{
    public class Archer : Military
    {
        public Archer(String name, int health, int cost, int level, bool isDestroy, double damage, int attackSpeed, int armor, int arrowCount)
        {
            this.name = name;
            this.health = health;
            this.cost = cost;
            this.level = level;
            this.isDestroy = isDestroy;
            this.damage = damage;
            this.attackSpeed = attackSpeed;
            this.armor = armor;
            
        }

        public override void attack(Unit unit)
        {
            damage = attackSpeed + level * 0.2;
            unit.health -= damage;
        }
    }
}
