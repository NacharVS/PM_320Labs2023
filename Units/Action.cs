using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Units.BaseClasses;

namespace Units
{
    abstract public class Action
    {
        public abstract void Attack(Unit unt, double damage);
        public abstract void Unit_HealthChangedEvent(Unit unit);
        public abstract void Unit_OnDiedEvent(Unit unit);
        public abstract void Move();
        public abstract void Mining();
        public abstract void Choping();
        public abstract void Berserker();
        public abstract void Stun();
        public abstract void FireBreath();
        public abstract void FireBall();
        public abstract void Blizzard();
        public abstract void Heal(Unit unt);
    }
}
