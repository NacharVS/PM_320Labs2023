﻿using Units.BaseClasses;
using Units.BaseUnits;

namespace Warcraft
{
    public class ConsoleAction : Units.Action
    {
        public override void Attack(Unit unt, double damage) 
        {
            unt.health -= damage;

            if (unt.health <= 0)
            {
                unt.isDestroyed = true;
                unt.health = 0;
            }
        }
        public override void Move() { }
        public override void Mining() { }
        public override void Choping() { }
        public override void Berserker() { }
        public override void Stun() { }
        public override void FireBreath() { }
        public override void FireBall() { }
        public override void Blizzard() { }
        public override void Heal(Unit unt) { }
    }
}
