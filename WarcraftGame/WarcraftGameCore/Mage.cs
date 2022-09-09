﻿namespace WarcraftGameCore
{
    public class Mage : Range
    {
        public Mage(Logger logger, string name) : 
            base(logger, 3, 200, 1000, 3, 800, 40, 
                 name, 1500, 500, 2, 2000) {}

        public void FireBall(Unit unit)
        {
            SuperAttack(900, 100, unit);
        }

        public void Blizzerd(Unit unit)
        {
            SuperAttack(1200, 150, unit);
        }

        private void SuperAttack(double damage, int mana, Unit unit)
        {
            if (GetMana() >= mana)
            {
                this.Attack(unit, damage);
                SetMana(GetMana() - mana);
            }
            else
            {
                Log("Not have mana!");
            }
        }

        public void Heal(Unit unit)
        {
            if (CheckDied() || unit.CheckDied())
            {
                return;
            }

            if (GetMana() >= 150)
            {
                if (unit.GetHealth() + 800 <= unit.GetMaxHp())
                {
                    unit.SetHealth(unit.GetHealth() + 800);
                }
                else
                {
                    unit.SetHealth(unit.GetMaxHp());
                }
                SetMana(GetMana() - 150);
            }
            else
            {
                Log("Not have mana!");
            }
        }
    }
}