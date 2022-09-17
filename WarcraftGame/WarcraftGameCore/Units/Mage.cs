namespace WarcraftGameCore
{
    public class Mage : Range
    {
        private double _fireBallDamage = 900;
        private int _fireBallMana = 100;
        private double _blizzerdDamage = 1200;
        private int _blizzerdMana = 150;
        private int _healMana = 150;
        private double _healAmount = 800;
        private int _buffPeriod = 3;

        public Mage(Logger logger, string name) : 
            base(logger, 3, 200, 1000, 3, 800, 40, 
                 name, 1500, 500, 2, 2000) {}

        public void FireBall(Unit unit)
        {
            SuperAttack(_fireBallDamage, _fireBallMana, unit);
        }

        public void Blizzerd(Unit unit)
        {
            SuperAttack(_blizzerdDamage, _blizzerdMana, unit);
        }

        private void SuperAttack(double damage, int mana, Unit unit)
        {
            if (GetMana() >= mana)
            {
                this.Attack(unit, damage);
                SetMana(GetMana() - mana);
            }
            else
            {
                Log("Not have mana!");
            }
        }

        public void Heal(Unit unit)
        {
            if (CheckDied() || unit.CheckDied())
            {
                return;
            }

            if (GetMana() >= _healMana)
            {
                if (unit.GetHealth() + _healAmount <= unit.GetMaxHp())
                {
                    unit.SetHealth(unit.GetHealth() + _healAmount);
                }
                else
                {
                    unit.SetHealth(unit.GetMaxHp());
                }
                SetMana(GetMana() - _healMana);
            }
            else
            {
                Log("Not have mana!");
            }
        }

        public void Buff(List<Military> units)
        {
            foreach (Military unit in units)
            {
                unit.BuffCount = _buffPeriod;
            }
        }
    }
}