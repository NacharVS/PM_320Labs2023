namespace WarCraft_3_ConsoleEdition
{
    public class Military : Movable
    {
        public int damage;
        public int attackSpeed;
        public int armor;
        public void Attack(Unit unit)
        {
            try
            {
                unit.health -= (int)(this.damage -
                        this.damage * (double)((Military)unit).armor / 100);
            }

            catch { unit.health -= this.damage; }
        }


        public Military(int damage, int attackSpeed, int armor,
            int speed, int health, int cost, string name, int level)
            : base(speed, health, cost, name, level)
        {
            this.damage = damage;
            this.attackSpeed = attackSpeed;
            this.armor = armor;
        }
    }
}
