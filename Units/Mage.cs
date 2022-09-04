using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Units
{
    public class Mage : Range
    {
        public Mage(double health, double armor, int attackSpeed,
            double range, double mana, double damage, string name)
            : base(health, armor, attackSpeed, range, mana, damage, name)
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

        public void Blizzard(Unit unit)
        {
            if (GetMana() < 25)
            {
                throw new Exception("Not enough mana for blizzard!");
            }

            this.SetMana(GetMana() - 25);
            SetDamage(14);
            ((Military)unit).SetAttackSpeed(0);
            Attack(unit);
            SetDamage(GetMaxDamage());
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
