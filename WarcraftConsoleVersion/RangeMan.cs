public class RangeMan : Military
{
    public int range;
    public int mana;

    public RangeMan(int healthPoint, int cost, string name, int level, int speed, int damage, int attackSpeed, int armor, int newRange, int newMana) :
        base(healthPoint, cost, name, level, speed, damage, attackSpeed, armor)
    {
        this.range = newRange;
        this.mana = newMana;
    }


}