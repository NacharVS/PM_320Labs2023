using Units.BaseClasses;
using Units.BaseUnits;

namespace Warcraft
{
    public class ConsoleAction : Units.Action
    {
        public override void Attack(Unit unt, double damage) 
        {
            unt.health -= damage;
            unt.IsDestroyed();
        }
        public override void Unit_OnDiedEvent(Unit unit) { Console.WriteLine($"{unit.name} is died"); }
        public override void Unit_HealthChangedEvent(Unit unit) { Console.WriteLine($"{unit.name} current health is {unit.health}"); }
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
