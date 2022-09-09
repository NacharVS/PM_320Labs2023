using System;


namespace Warcraft
{
    class Footman : Military
    {

        public Footman(int health, int cost, string name, int lvl, int speed,
                    int damage, int attackSpeed, int armor)
                    : base(health, cost, name, lvl, speed, damage, attackSpeed, armor)
        {

        }

        public string GetName()
        {
            return base.GetName();
        }

        public int GetAttackSpeed()
        {
            return base.GetAttackSpeed();
        }

        public bool GetIsDestroyed()
        {
            return base.GetIsDestroyed();
        }

        public void SetIsDestroyed()
        {
            base.SetIsDestroyed();
        }

        public override void Attack(Unit unit)
        {
            if (this.GetHealth() < 30)
            {
                Berserker();
            }
            int rand = rnd.Next(1, 11);
            if (rand == 1) this.Stun(unit);
            unit.SetHealth(unit.GetHealth() - this.GetDamage());
            Console.WriteLine(this.GetName() + $"({this.GetHealth()})" + " attacked " + unit.GetName() + $"({unit.GetHealth()})");
        }

        public void Berserker()
        {
            SetAttackSpeed(GetAttackSpeed() * 2);
        } //<30% health

        public void Stun(Unit unit) //??
        {
            Console.WriteLine(unit.GetName() + " is stunned");
        }
    }
}
