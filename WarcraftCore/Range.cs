namespace WarcraftCore;


/// <summary>
/// 
/// </summary>
public abstract class Range : Millitary
{
    protected int range;
    protected int mana;

    protected Range(int health, string name, int cost, int level, int moveSpeed, 
        int damage, int attackSpeed, int armor, int range, int mana, ILogger logger) : 
        base(health, name, cost, level, moveSpeed, damage, attackSpeed, armor, logger)
    {
        this.range = range;
        this.mana = mana;
    }
}