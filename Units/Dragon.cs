using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units
{
    public class Dragon : Range
    {
        public Dragon(double health, double armor, int attackSpeed, double range, double mana, double damage)
            : base(health, armor, attackSpeed, range, mana, damage)
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
            Console.WriteLine("Dragon is moving");
        }
    }
}
