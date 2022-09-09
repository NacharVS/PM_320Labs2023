using System;

namespace ConsoleWarcraft
{
    public class Mage : Range
    {
        public Mage(String name, int health, int cost, int level, int mana, int range, double damage, int attackSpeed, int armor, bool isDestroy)
        {
            this.name = name;
            this.health = health;
            this.cost = cost;
            this.level = level;
            this.isDestroy = isDestroy;
            this.mana = mana;
            this.range = range;
            this.damage = damage;   
            this.attackSpeed = attackSpeed;
            this.armor = armor;
        }
        
        public virtual void move()
        {
            speed = speed + level * 0.3;
        }

        public virtual void attack(Unit unit)
        {
            damage = range + attackSpeed +  level * 0.2 ;
            mana += 5;

            damageUnit(unit);
        }


        public void fireBall(Unit unit)
        {
            if (mana >= 20)
            {
                damage = range + level * 0.9 ;
                mana -= 20;
                damageUnit(unit);
            }
        }

        public void blizzard(Unit unit)
        {
            if (mana >= 100)
            {
                damage = range + level * 5.0;
                mana -= 100;
                damageUnit(unit);
            }
        }

        public void heal()
        {
            if (mana >= 15)
            {
                health += 15 + level * 0.5;
            }
            
        }
        
        public override bool isDestroyed()
        {
            if (health < 0)
            {
                isDestroy = true;
                return isDestroy;
            }
            return isDestroy;
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