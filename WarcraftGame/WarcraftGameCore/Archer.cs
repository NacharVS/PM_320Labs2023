namespace WarcraftGameCore
{
    public class Archer : Range
    {
        private int _arrowCount;

        public Archer(string name) : base (3, 200, 300, 2, 800, 20, name, 1800, 1000, 2)
        {
            _arrowCount = 20;
        }

        public override void Attack(Unit unit)
        {
            if (_arrowCount > 0)
            {
                base.Attack(unit);
            }
            else
            {
                Console.WriteLine("Not enough arrows!");
            }        
        }

        public void UpgradeArrow()
        {
            if (this.CheckDied())
            {
                return;
            }

            this._damage += 200;
        }

        public void UpgradeBow()
        {
            if (this.CheckDied())
            {
                return;
            }

            this._arrowCount += 10;
        }
    }
}