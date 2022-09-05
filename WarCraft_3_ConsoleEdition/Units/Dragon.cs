namespace WarCraft_3_ConsoleEdition
{
    public class Dragon : Range
    {
        public void FireBreath(Unit unit)
        {
            if (this.mana >= 35)
            {
                unit.health -= this.damage * 3;
                mana -= 35;
            }

            else
            {
                ReportingLackOfMana();
            }
        }

        public Dragon(int range, int mana, int damage, int attackSpeed,
            int armor, int speed, int health, int cost, string name, int level)
           : base(range, mana, damage, attackSpeed, armor, speed, health, cost, name, level)
        {
        }
    }
}
