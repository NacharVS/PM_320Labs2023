using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units
{
    public abstract class Range : Military
    {
        private double _range;
        private double _mana;
        public Range(double health, double armor, int attackSpeed, double range, double mana, double damage) 
            : base(health, armor, attackSpeed, damage)
        {
            _range = range;
            _mana = mana;
        }
        public double GetMana()
        {
            return _mana;
        }
        public void SetMana(double mana)
        {
            this._mana = mana;
        }
    }
}
