using System;


namespace Warcraft
{
    class Mage : Range
    {

        public Mage(int health, int cost, string name, int lvl, int speed,
                    int damage, int attackSpeed, int armor, int range, int mana)
                    : base(health, cost, name, lvl, speed, damage, attackSpeed, armor, range, mana)
        {

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

        public void Attack(Unit unit)
        {
            if (this.GetHealth() < 50) //< 50%
            {
                this.SetHealth(this.GetHealth() + 10);
            }

            unit.SetHealth(unit.GetHealth() - this.GetDamage());
            Console.WriteLine(this.GetName() + $"({this.GetHealth()})" + " attacked " + unit.GetName() + $"({unit.GetHealth()})");


            int rand = rnd.Next(1, 6);
            if (rand == 1) FireBall(unit);
            else Blizzard(unit);


        }

        public string GetName()
        {
            return base.GetName();
        }

        public void FireBall(Unit unit)
        {
            unit.SetHealth(unit.GetHealth() - 11);
            Console.WriteLine("FireBall!!!");
        }

        public void Blizzard(Unit unit)
        {
            GetAttackSpeed();
            Console.WriteLine("Blizzard!!!");
        } // AttackSpeed down 

        public void Heal()
        {
            this.SetHealth(this.GetHealth() + 12);
        }
    }
}
