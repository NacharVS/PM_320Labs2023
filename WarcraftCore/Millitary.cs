namespace WarcraftCore;

public abstract class Millitary : Moveable
{
    protected int damage;
    protected int attackSpeed;
    protected int armor;

    protected Millitary(int health, string name, int cost, int level, int moveSpeed, 
        int damage, int attackSpeed, int armor, ILogger logger) : base(health, name, cost, level, moveSpeed, logger)
    {
        this.damage = damage;
        this.attackSpeed = attackSpeed;
        this.armor = armor;
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

        logger.Log($"{GetName()} нанес урон {target.GetName()}");
        target.GetHit(damage);
    }

    public override void GetHit(int damage)
    {
        // Formula for calculating damage taking into account armor
        base.GetHit(Math.Min(damage, damage - armor / 2));
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