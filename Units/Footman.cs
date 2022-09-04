using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units
{
    public class Footman : Military
    {
        public Footman(double health, double armor, int attackSpeed, double damage ) 
            : base(health, armor, attackSpeed, damage)
        {
        }
        public void Berserker()
        {
            this.SetAttackSpeed(GetAttackSpeed() * 2);
            this.SetDamage(GetDamage() * 1.2);
        }
        public void Stun(Military unit)
        {
            unit.SetAttackSpeed(0);
        }

        public override void Move()
        {
            Console.WriteLine("Footman is moving");
        }
        public override void Attack(Unit unit)
        {
            if(GetHealth() / GetMaxHealth() < 1/3)
            {
                Berserker();
            }
            if(GetRandom() == 1)
            {
                Stun((Military)unit);
            }
            else
            {
                SetAttackSpeed(GetMaxAttackSpeed());
                SetDamage(GetMaxDamage());
            }
            base.Attack(unit);
        }

    }
}
