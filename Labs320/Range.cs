class Range : Military
{
    protected int range;
    protected int mana;

    public Range(int health, int cost, string name, int speed, int damage,
        int attackSpeed, int armor, int mana) : base(health, cost, name, speed, damage, attackSpeed, armor)
    {
        this.range = range;
        this.mana = mana;
    }
}
