namespace WarCraft_3_ConsoleEdition
{
    class GuardTower : Unit
    {
        public int range;
        public int damage;
        public int attackSpeed;
        public void Attack(Unit unit)
        {
            try
            {
                unit.health -= (int)(this.damage -
                        this.damage * (double)((Military)unit).armor / 100);
            }

            catch { unit.health -= this.damage; }
        }

        public GuardTower(int range, int damage, int attackSpeed,
            int health, int cost, string name, int level) : base(health, cost, name, level)
        {
            this.range = range;
            this.damage = damage;
            this.attackSpeed = attackSpeed;
        }
    }
}
