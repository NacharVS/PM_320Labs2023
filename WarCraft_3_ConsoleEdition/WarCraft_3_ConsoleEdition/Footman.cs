namespace WarCraft_3_ConsoleEdition
{
    class Footman : Military
    {
        public bool isBerserk;

        public void Berserker()
        {
            if (!isBerserk)
            {
                damage *= 2;
            }

            isBerserk = true;
        }

        public void Stun(Movable movable)
        {
            movable.timeWithoutAttack += 5;
        }

        public Footman(int damage, int attackSpeed, int armor, int speed, int health,
            int cost, string name, int level) : base(damage, attackSpeed, armor, speed, health, cost, name, level) { }
    }
}
