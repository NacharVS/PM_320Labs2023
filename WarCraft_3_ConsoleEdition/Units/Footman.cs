namespace WarCraft_3_ConsoleEdition
{
    public class Footman : Military
    {
        public bool IsBerserk { }

        public void Berserker()
        {
            if (!IsBerserk)
            {
                Damage *= 2;
            }

            IsBerserk = true;
        }

        public void Stun(Movable movable)
        {
            movable.TimeWithoutAttack += 5;
        }

        public Footman(int damage, int attackSpeed, int armor, int speed, int health,
            int cost, string name, int level) : base(damage, attackSpeed, armor, speed, health, cost, name, level) { }
    }
}
