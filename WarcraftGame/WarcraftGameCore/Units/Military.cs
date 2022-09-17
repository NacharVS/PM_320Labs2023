namespace WarcraftGameCore
{
    public abstract class Military : Moveble
    {
        private double _damage;
        private int _attackSpeed;
        private double _armor;
        private double _armorUpgradeAmount = 500;
        private int _buffCount;
        public int BuffCount
        {
            get { return _buffCount; }
            set
            {
                if (value < 0)
                {
                    _buffCount = 0;
                }
                _buffCount = value;
            }
        }

        protected Military(Logger logger, double damage, int attackSpeed, double armor, 
            double speed, string name, double health, int cost, int level, double maxHp)
            : base (logger, speed, name, health, cost, level, maxHp)
        {
            _damage = damage;
            _attackSpeed = attackSpeed;
            _armor = armor;
        }

        public void SetDamage(double damage)
        {
            if (damage <= 0)
            {
                _damage = 0;
            }
            else
            {
                _damage = damage;
            }
        }

        public double GetDamage()
        {
            return _damage;
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
            if (CheckDied())
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

        private void AttackUnit(Unit unit, double attackDamage)
        {
            var damage = CheckBuff(attackDamage);

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

        private double CheckBuff(double damage)
        {
            if (_buffCount > 0)
            {
                _buffCount--;
                return damage * 0.6;
            }
            return damage;
        }

        public void UpgradeArmor()
        {
            if (CheckDied())
            {
                return;
            }

            this._armor += _armorUpgradeAmount;
        }
    }
}