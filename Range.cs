namespace Warcraft
{
    class Range : Military
    {
        int range;
        int mana;

        public Range(int health, int cost, string name, int lvl, int speed, int damage,
                    int attackSpeed, int armor, int range, int mana)
                    : base(health, cost, name, lvl, speed, damage, attackSpeed, armor)
        {
            this.range = range;
            this.mana = mana;
        }

        public string GetName()
        {
            return base.GetName();
        }

        public override void Attack(Unit unit)
        {

        }
    }
}
