namespace WarcraftCore;

public class Archer : Range
{
    protected int arrowsCount;
    public Archer(int health, string name, int cost, int level, int moveSpeed, int damage, int attackSpeed, 
        int armor, int range, int mana, ILogger logger, int arrowsCount) : 
        base(health, name, cost, level, moveSpeed, damage, attackSpeed, armor, range, mana, logger)
    {
        this.arrowsCount = arrowsCount;
    }

    public override void Attack(Unit target)
    {
        if (arrowsCount > 0)
        {
            base.Attack(target);
            --arrowsCount;
        }
        else
        {
            logger.Log($"{GetName()} не хватает стрел для атаки");
        }
    }

    public void UpgradeBow(int upgradeValue)
    {
        arrowsCount += upgradeValue;
    }
}