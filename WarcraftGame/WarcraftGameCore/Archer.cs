namespace WarcraftGameCore
{
    public class Archer : Range
    {
        private int _arrowCount;

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

            SetDamage(GetDamage() + 200);
        }

        public void UpgradeBow()
        {
            if (this.CheckDied())
            {
                return;
            }

            _arrowCount += 10;
        }
    }
}