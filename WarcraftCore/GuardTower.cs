namespace WarcraftCore;

public class GuardTower : Unit
{
    protected int range;
    protected int damage;
    protected int attackSpeed;
    protected ILogger logger;

    public GuardTower(int health, string name, int cost, 
        int level, int range, int damage, int attackSpeed, ILogger logger) : 
        base(health, name, cost, level)
    {
        this.range = range;
        this.damage = damage;
        this.attackSpeed = attackSpeed;
        this.logger = logger;
    }

    public void Attack(Unit target)
    {
        if (isDestroyed || target.IsDestroyed())
            return;
        
        target.GetHit(damage);
        logger.Log($"{GetName()} нанес {target.GetName()} {damage} урона");
    }
    
    public int GetAttackSpeed()
    {
        return attackSpeed;
    }
}