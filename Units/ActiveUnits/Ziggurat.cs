using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Units.BaseUnits;

namespace Units.ActiveUnits
{
    public class Ziggurat : Unit
    {
        double healBoost = 10;

        public delegate void OnHealAbilityDelegate();
        public event OnHealAbilityDelegate OnHealEvent;

        public Ziggurat(double health, string name) : base(name, health)
        {
            OnHealEvent += () => Console.WriteLine("All units were healed!");
        }

        public void MagicHeal(List<BaseUnits.Unit> units)
        {
            foreach(var unit in units)
            {
                double oldHP = unit.GetHealth();
                double newHP = oldHP + healBoost;

                if (newHP > GetMaxHealth())
                {
                    unit.SetHealth(GetMaxHealth());
                }
                else
                {
                    unit.SetHealth(newHP);
                }
            }
            OnHealEvent();
        }
    }
}
