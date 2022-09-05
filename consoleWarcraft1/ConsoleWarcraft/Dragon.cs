using System;

namespace ConsoleWarcraft
{
    public class Dragon : Range
    {
        public Dragon(String name, int health, int cost, int level, bool isDestroy, int mana, int range, double damage, int attackSpeed, int armor)
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

        public override void attack(Unit unit)
        {
            damage = attackSpeed + level * 0.2;
            unit.health -= damage;
        }

        public void fireBreath(Unit unit)
        {
            if (mana >= 35)
            {
                damage = range + level * 0.9 ;
                mana -= 35;


                if (unit is Military milUnit)
                {
                    milUnit.health = milUnit.health + milUnit.armor - damage;
                }else
                {
                    unit.health = health - damage;
                }
            }

           
  
        }
    }
}