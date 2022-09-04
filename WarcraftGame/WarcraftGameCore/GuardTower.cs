namespace WarcraftGameCore
{
    public class GuardTower : Unit
    {
        private int _range;
        private double _damage;
        private int _attackSpeed;
        private bool _isAttacking;

        public void SetAttackedSpeed(int attackedSpeed)
        {
            _attackSpeed = attackedSpeed;
        }

        public int GetAttackedSpeed()
        {
            return _attackSpeed;
        }

        public GuardTower(string name) : base (name,5000,3000,4)
        {
            _damage = 300;
            _attackSpeed = 3;
        }

        public void Attack(Unit unit)
        {
            this.Attack(unit, _damage);
        }

        protected void Attack(Unit unit, double damage)
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
    }
}