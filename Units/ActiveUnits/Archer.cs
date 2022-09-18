using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Units.BaseUnits;

namespace Units.ActiveUnits
{
    public class Archer : BaseUnits.Range
    {
        public delegate void OnArrowsShortageDelegate();
        public event OnArrowsShortageDelegate OnArrowsShortageEvent;
        private int _arrowCount;

        public Archer(double health, double armor, int attackSpeed,
            double range, double mana, double damage, int arrowCount, string name)
            : base(health, armor, attackSpeed, range, mana, damage, name)
        {
            _arrowCount = arrowCount;
            OnArrowsShortageEvent += ArrowsToEnd;
        }

        public override void Move()
        {
            Console.WriteLine($"Archer {this.Name} is moving");
        }

        public override void Attack(Unit unit)
        {
            if (_arrowCount < 1)
            {
                OnArrowsShortageEvent.Invoke();
                return;
            }
            _arrowCount--;

            base.Attack(unit);
        }

        public void ArrowsToEnd()
        {
            Console.WriteLine($"{this.Name}'s arrows are all gone!");
        }
    }
}
