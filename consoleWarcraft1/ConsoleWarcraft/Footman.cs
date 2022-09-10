using System;

namespace ConsoleWarcraft
{
    public class Footman : Military
    {
        
        public Footman(String name, int health, int cost, int level, int attackSpeed, int speed, int armor, bool isDestroy)
        {
            this.name = name;
            this.health = health;
            this.cost = cost;
            this.level = level;
            this.isDestroy = isDestroy;
            this.attackSpeed = attackSpeed;
            this.speed = speed;
            this.armor = armor;
        }

        public override void attack(Unit unit)
        {
            damage =  attackSpeed + level * 0.2;
            damageUnit(unit);
        }

        public void berserker()
        {
            Console.WriteLine("Footman is berserker");
        }

        public void stun(Unit unit)
        {
            damage = damage + attackSpeed +  level * 0.2 ;
            damageUnit(unit);
        }

        public virtual void move()
        {
            speed = speed + level * 0.1;
        }

        private void damageUnit(Unit unit)
        {
            if (unit is Military military)
            {
                // military.Health -= damage;

                TakeDamage(military, damage, true);

            }
            else
            {
                // unit.Health -= damage;
                TakeDamage(unit, damage, true);
            }
        }
    }
}