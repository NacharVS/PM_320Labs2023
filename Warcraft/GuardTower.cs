namespace Warcraft
{
    class GuardTower : Unit
    {
        int range;
        int dmg;
        int attackSpeed;

        public GuardTower(int health, int cost, string name, int lvl, int range,
            int dmg, int attackSpeed) : base(health, cost, name, lvl)
        {
            this.range = range;
            this.dmg = dmg;
            this.attackSpeed = attackSpeed;
        }

        public string GetName()
        {
            return base.GetName();
        }

        public int GetDmg()
        {
            return dmg;
        }

        public void SetDmg(int dmg)
        {
            this.dmg = dmg;
        }

        public bool GetIsDestroyed()
        {
            return base.GetIsDestroyed();
        }

        public void SetIsDestroyed()
        {
            base.SetIsDestroyed();
        }

        public void Attack(Unit unit)
        {
            unit.SetHealth(unit.GetHealth() - this.GetDmg());
        }
    }
}
