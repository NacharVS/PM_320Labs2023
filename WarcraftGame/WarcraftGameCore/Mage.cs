namespace WarcraftGameCore
{
    public class Mage : Range
    {
        private double _maxHp;

        public Mage(string name) : base(3, 200, 1000, 3, 800, 40, name, 1500, 500, 2) 
        {
            _maxHp = 3000;
        }

        public void FireBall(Unit unit)
        {
            if (this._mana >= 100)
            {
                this.Attack(unit, 2000);
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
                this.Attack(unit, 3000);
                this._mana -= 150;
            }
            else
            {
                Console.WriteLine("Not have mana!");
            }
        }

        public void Heal()
        {
            if (this.CheckDied())
            {
                return;
            }

            if (this._mana >= 150)
            {
                if (this._health + 800 <= _maxHp)
                {
                    this._health += 800;
                }
                else
                {
                    this._health = _maxHp;
                }
                _mana -= 150;
            }
            else
            {
                Console.WriteLine("Not have mana!");
            }
        }
    }
}