﻿// Turushkin Sergey, 320P, "Warcraft"

namespace Units
{
    public class Dragon : Range
    {
        public Dragon(double health, double cost, string name, int lvl, double speed,
                      double damage, double attackSpeed, double armor, double range, double mana)
               : base(health, cost, name, lvl, speed, damage, attackSpeed, armor, range, mana) { }

        public override void Attack(Unit unt)
        {
            action.Attack(unt, damage);
        }

        public void FireBreath() 
        {
            action.FireBreath();
        }

        public override void Move() 
        {
            action.Move();
        }
    }
}
