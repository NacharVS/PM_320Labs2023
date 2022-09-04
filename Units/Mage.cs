using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units
{
    public class Mage : Range
    {
        public Mage(double health, double armor, int attackSpeed, double range, double mana, double damage)
            : base(health, armor, attackSpeed, range, mana, damage)
        {
        }
        public void FireBall(Unit unit)
        {
            if (GetMana() < 35)
            {
                throw new Exception("Not enough mana for fireball!");
            }

            this.SetMana(GetMana() - 35);
            SetDamage(9);
            Attack(unit);
            SetDamage(GetMaxDamage());
        }
        public void Blizzard()
        {

        }
        public void Heal(Unit unit)
        {
            if(GetMana() < 20)
            {
                throw new Exception("Not enough mana for heal!");
            }

            this.SetMana(GetMana() - 20);
            unit.SetHealth(unit.GetHealth() + 15);
            if (unit.GetHealth() > unit.GetMaxHealth())
            {
                unit.SetHealth(GetMaxHealth());
            }
        }


        public override void Move()
        {
            Console.WriteLine("Mage is moving");
        }
    }
}
