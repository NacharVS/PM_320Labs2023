namespace WarcraftCore;

public abstract class Millitary : Moveable
{
    protected int damage;
    protected int attackSpeed;
    protected int armor;
    protected ILogger logger;

    protected Millitary(int health, string name, int cost, int level, int moveSpeed, 
        int damage, int attackSpeed, int armor, ILogger logger) : base(health, name, cost, level, moveSpeed)
    {
        this.damage = damage;
        this.attackSpeed = attackSpeed;
        this.armor = armor;
        this.logger = logger;
    }

    public virtual void Attack(Unit target)
    {
        if (isDestroyed || target.IsDestroyed())
            return;

        if (isStunned)
        {
            logger.Log($"{GetName()} пропустит ход");
            isStunned = false;
            return;
        }
        target.GetHit(damage);
        logger.Log($"{GetName()} нанес {damage} урона {target.GetName()}");
    }

    public override void GetHit(int damage)
    {
        // Formula for calculating damage taking into account armor
        base.GetHit(damage - armor / 2);
    }


    public int GetAttackSpeed()
    {
        return attackSpeed;
    }

    public override void Move()
    {
        logger.Log("Move");
    }

    public void UpgradeWeapon(int upgradeValue)
    {
        damage += upgradeValue;
    }
    
    public void UpgradeArmor(int upgradeValue)
    {
        armor += upgradeValue;
    }
}