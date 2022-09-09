using System;

namespace ConsoleWarcraft
{
    public class GuardTower : Unit
    {
        public int range = 0;
        public double damage = 0;
        public int attackSpeed = 5;

        public GuardTower(String name, int health, int cost, int level, int range, double damage, int attackSpeed, bool isDestroy)
        {
            this.name = name;
            this.health = health;
            this.cost = cost;
            this.level = level;
            this.isDestroy = isDestroy;
            this.damage = damage;
            this.range = range;
            this.attackSpeed = attackSpeed;
        }

        public void attack(Unit unit)
        {
            damage = damage + range + attackSpeed + level * 0.2;
            damageUnit(unit);
        }

        private void damageUnit(Unit unit)
        {
            if (unit is Military military)
            {
                military.Health = military.health + military.armor - damage;
            }
            else
            {
                unit.Health -= damage;
            }
        }
    }
}