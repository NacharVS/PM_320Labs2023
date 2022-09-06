namespace WarCraft_3_ConsoleEdition
{
    public class GuardTower : Unit
    {
        public int Range { get; set; }
        public int Damage { get; set; }
        public int AttackSpeed { get; set; }

        public GuardTower(int range, int damage, int attackSpeed,
            int health, int cost, string name, int level) : base(health, cost, name, level)
        {
            this.Range = range;
            this.Damage = damage;
            this.AttackSpeed = attackSpeed;
        }

        public void Attack(Unit unit)
        {
            try
            {
                unit.Health -= (int)(this.Damage -
                        this.Damage * (double)((Military)unit).Armor / 100);
            }

            catch { unit.Health -= this.Damage; }
        }
    }
}
