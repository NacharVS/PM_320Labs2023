namespace WarCraft_3_ConsoleEdition
{
    public class Military : Movable
    {
        public int Damage { get; set; }
        public int AttackSpeed { get; set; }
        public int Armor { get; set; }

        public Military(int damage, int attackSpeed, int armor,
            int speed, int health, int cost, string name, int level)
            : base(speed, health, cost, name, level)
        {
            this.Damage = damage;
            this.AttackSpeed = attackSpeed;
            this.Armor = armor;
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
