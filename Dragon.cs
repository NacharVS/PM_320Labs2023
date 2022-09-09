using System;


namespace Warcraft
{
    class Dragon : Range
    {

        public Dragon(int health, int cost, string name, int lvl, int speed,
            int damage, int attackSpeed, int armor, int range, int mana)
            : base(health, cost, name, lvl, speed, damage, attackSpeed, armor, range, mana)
        {

        }

        public override void Attack(Unit unit)
        {
            unit.SetHealth(unit.GetHealth() - this.GetDamage());

            int rand = rnd.Next(1, 9);
            if (rand == 1) FireBreath(unit);
            Console.WriteLine(this.GetName() + $"({this.GetHealth()})" + " attacked " + unit.GetName() + $"({unit.GetHealth()})");
        }

        public string GetName()
        {
            return base.GetName();
        }

        public bool GetIsDestroyed()
        {
            return base.GetIsDestroyed();
        }

        public void SetIsDestroyed()
        {
            base.SetIsDestroyed();
        }

        public void FireBreath(Unit unit)
        {
            unit.SetHealth(unit.GetHealth() - 9);
            Console.WriteLine("FireBreath!!!");
        }
    }
}
