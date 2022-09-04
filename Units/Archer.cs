using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Units
{
    public class Archer : Range
    {
        private int _arrowCount;

        public Archer(double health, double armor, int attackSpeed,
            double range, double mana, double damage, int arrowCount, string name) 
            : base(health, armor, attackSpeed, range, mana, damage, name)
        {
            _arrowCount = arrowCount;
        }

        public override void Move()
        {
            Console.WriteLine("Archer is moving");
        }

        public override void Attack(Unit unit)
        {
            if(_arrowCount < 1)
            {
                throw new Exception($"No arrows left for archer!");
            }
            _arrowCount--;

            base.Attack(unit);
        }
    }
}
