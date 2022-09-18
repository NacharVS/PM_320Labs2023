using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Units.BaseUnits;

namespace Units.ActiveUnits
{
    public class Dragon : BaseUnits.Range
    {
        public Dragon(double health, double armor, int attackSpeed,
            double range, double mana, double damage, string name)
            : base(health, armor, attackSpeed, range, mana, damage, name)
        {
        }

        public void FireBreath(Unit unit)
        {
            this.SetMana(GetMana() - 25);
            SetDamage(40);
            Attack(unit);
            SetDamage(GetMaxDamage());
        }

        public override void Move()
        {
            Console.WriteLine($"Dragon {this.Name} is moving");
        }

        public override void Attack(Unit unit)
        {
            Random random = new Random();

            if(random.Next(5) == 1)
            {
                FireBreath(unit);
                return;
            }

            base.Attack(unit);
        }
    }
}
