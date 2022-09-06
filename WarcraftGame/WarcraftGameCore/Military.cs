namespace WarcraftGameCore
{
    public abstract class Military : Moveble
    {
        protected double _damage;
        protected int _attackSpeed;
        protected double _armor;
        protected bool _isAttacking;

        protected Military(double damage, int attackSpeed, double armor, 
            double speed, string name, double health, int cost, int level)
            : base (speed, name, health, cost, level)
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
            if (!this.GetIsDestroyed())
            {
                AttackUnit(unit, damage);
                Thread.Sleep(_attackSpeed * 1000);
                return;
            }
            else
            {
                Console.WriteLine($"{unit.GetName} is destroyed!");
            }
        }

        private void AttackUnit(Unit unit, double damage)
        {
            if (!unit.GetIsDestroyed())
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
            else
            {
                Console.WriteLine($"{unit.GetName} is destroyed!");
            }
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