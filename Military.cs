namespace Warcraft
{
    class Military : Moveble
    {
        int damage;
        int attackSpeed;
        int armor;

        public Military(int health, int cost, string name, int lvl, int speed,
            int damage, int attackSpeed, int armor) : base(health, cost, name, lvl, speed)
        {
            this.damage = damage;
            this.attackSpeed = attackSpeed;
            this.armor = armor;
        }

        public string GetName()
        {
            return base.GetName();
        }

        public int GetDamage()
        {
            return damage;
        }

        public void SetDamage(int damage)
        {
            this.damage = damage;
        }

        public int GetAttackSpeed()
        {
            return damage;
        }

        public void SetAttackSpeed(int attackSpeed)
        {
            this.attackSpeed = attackSpeed;
        }

        public bool GetIsDestroyed()
        {
            return base.GetIsDestroyed();
        }

        public void SetIsDestroyed()
        {
            base.SetIsDestroyed();
        }

        virtual public void Attack(Unit unit)
        {
            unit.SetHealth(unit.GetHealth() - this.GetDamage());
        }

    }
}
