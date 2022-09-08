namespace WarcraftGameCore
{
    public abstract class Military : Moveble
    {
        protected double _damage;
        protected int _attackSpeed;
        protected double _armor;

        protected Military(double damage, int attackSpeed, double armor, 
            double speed, string name, double health, int cost, int level, double maxHp)
            : base (speed, name, health, cost, level, maxHp)
        {
            _damage = damage;
            _attackSpeed = attackSpeed;
            _armor = armor;
        }

        public void SetAttackedSpeed(int attackedSpeed)
        {
            _attackSpeed = attackedSpeed;
        }

        public int GetAttackedSpeed()
        {
            return _attackSpeed;
        }

        public double GetArmor()
        {
            return _armor;
        }

        public void SetArmor(double armor)
        {
            if (this.CheckDied())
            {
                return;
            }

            if (armor < 0)
            {
                _armor = 0;
                return;
            }
            _armor = armor;
        }

        public virtual void Attack(Unit unit)
        {
            this.Attack(unit, _damage);
        }

        protected virtual void Attack(Unit unit, double damage)
        {
            if (unit == this)
            {
                Console.WriteLine("You can`t attack yourself!!");
                return;
            }

            if (this.CheckDied() || unit.CheckDied())
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
                    Console.WriteLine($"{this._name} attacked " +
                        $"{unit.GetName()},Health: {militaryUnit.GetHealth()}, " +
                        $"Armor: {militaryUnit.GetArmor()}");
                    return;
                }
            }

            unit.SetHealth(unit.GetHealth() - damage);
            Console.WriteLine($"{this._name} attacked {unit.GetName()}," +
                $"Health: {unit.GetHealth()}");
        }     

        public void UpgradeArmor()
        {
            if (this.CheckDied())
            {
                return;
            }

            this._armor += 500;
        }
    }
}