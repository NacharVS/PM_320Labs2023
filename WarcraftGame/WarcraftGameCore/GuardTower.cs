namespace WarcraftGameCore
{
    public class GuardTower : Unit
    {
        private int _range;
        private double _damage;
        private int _attackSpeed;

        public GuardTower(Logger logger, string name) : 
            base(logger, name, 5000, 3000, 4, 5000)
        {
            _damage = 300;
            _attackSpeed = 3;
        }

        public void SetAttackedSpeed(int attackedSpeed)
        {
            _attackSpeed = attackedSpeed;
        }

        public int GetAttackedSpeed()
        {
            return _attackSpeed;
        }

        public void Attack(Unit unit)
        {
            this.Attack(unit, _damage);
        }

        protected virtual void Attack(Unit unit, double damage)
        {
            if (unit == this)
            {
                Log("You can`t attack yourself!!");
                return;
            }

            if (CheckDied() || unit.CheckDied())
            {
                return;
            }

            AttackUnit(unit, damage);
            Thread.Sleep(_attackSpeed);
            return;
        }

        private void AttackUnit(Unit unit, double damage)
        {
            if (unit is Military)
            {
                var militaryUnit = (Military)unit;

                if (militaryUnit.GetArmor() >= damage * 0.1)
                {
                    militaryUnit.SetArmor(militaryUnit.GetArmor() - damage * 0.1);
                    militaryUnit.SetHealth(militaryUnit.GetHealth() - damage * 0.2);
                    Log($"{GetName()} attacked {unit.GetName()}," +
                        $"Health: {militaryUnit.GetHealth()}, " +
                        $"Armor: {militaryUnit.GetArmor()}");
                    return;
                }
            }

            unit.SetHealth(unit.GetHealth() - damage);
            Log($"{GetName()} attacked {unit.GetName()}," +
                $"Health: {unit.GetHealth()}");
        }
    }
}