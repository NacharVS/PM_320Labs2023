namespace WarcraftGameCore
{
    public class Mage : Range
    {
        public Mage(string name) : base(3, 200, 1000, 3, 800, 40, 
                                name, 1500, 500, 2, 2000) {}

        public void FireBall(Unit unit)
        {
            if (this._mana >= 100)
            {
                this.Attack(unit, 900);
                this._mana -= 100;
            }
            else
            {
                Console.WriteLine("Not have mana!");
            }
        }

        public void Blizzerd(Unit unit)
        {
            if (this._mana >= 150)
            {
                this.Attack(unit, 1200);
                this._mana -= 150;
            }
            else
            {
                Console.WriteLine("Not have mana!");
            }
        }

        public void Heal(Unit unit)
        {
            if (this.CheckDied() || unit.CheckDied())
            {
                return;
            }

            if (this._mana >= 150)
            {
                if (unit.GetHealth() + 800 <= unit.GetMaxHp())
                {
                    unit.SetHealth(unit.GetHealth() + 800);
                }
                else
                {
                    unit.SetHealth(unit.GetMaxHp());
                }
                this._mana -= 150;
            }
            else
            {
                Console.WriteLine("Not have mana!");
            }
        }
    }
}