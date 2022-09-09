namespace WarcraftGameCore
{
    public class Archer : Range
    {
        private int _arrowCount;
        private double _arrowUpgradeDamage = 200;
        private int _bowUpgradeCount = 10;

        public Archer(Logger logger, string name) : 
        base(logger, 3, 200, 300, 2, 800, 20, name, 1800, 1000, 2, 2000)
        {
            _arrowCount = 20;
        }

        public override void Attack(Unit unit)
        {
            if (_arrowCount > 0)
            {
                base.Attack(unit);
                _arrowCount--;
            }
            else
            {
                Log("Not enough arrows!");
            }
        }

        public void UpgradeArrow()
        {
            if (CheckDied())
            {
                return;
            }

            SetDamage(GetDamage() + _arrowUpgradeDamage);
        }

        public void UpgradeBow()
        {
            if (this.CheckDied())
            {
                return;
            }

            _arrowCount += _bowUpgradeCount;
        }
    }
}