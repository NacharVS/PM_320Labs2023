﻿namespace WarcraftGameCore
{
    public class Dragon : Range
    {
        public Dragon(Logger logger, string name) : 
        base(logger, 3, 300, 1000, 4, 600, 15, name, 2200, 1300, 3, 2500) { }

        public void FireBreuth(Unit unit)
        {
            if (GetMana() >= 200)
            {
                this.Attack(unit, 1800);
                SetMana(GetMana() - 200);
            }
            else
            {
                Log("Not have mana!");
            }
        }
    }
}