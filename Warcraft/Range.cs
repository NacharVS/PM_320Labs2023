class Range : Military
{
    public Range(int health, int cost, string name, int speed, int damage,
                int attackSpeed, int armor, int range, int mana) : base(health,
                    cost, name, speed, damage, attackSpeed, armor)
    {
        this.range = range;
        this.mana = mana;
    }
    protected int range;
    protected int mana;
}