namespace WarcraftCore;

public class Footman : Millitary
{
    Random rand = new();
    public Footman(int health, string name, int cost, int level, int moveSpeed, int damage, 
        int attackSpeed, int armor, ILogger logger) : 
        base(health, name, cost, level, moveSpeed, damage, attackSpeed, armor, logger)
    {
    }

    public override void GetHit(int damage)
    {
        base.GetHit(damage);
        
        if (health <= maxHealth / 3)
            Berserker();
    }

    public override void Attack(Unit target)
    {
        Stun(target);
        base.Attack(target);
    }

    public void Berserker()
    {
        if (isDestroyed)
            return;
        attackSpeed *= 2;
        logger.Log($"{GetName()} включил режим берсерка");
    }

    public void Stun(Unit target)
    {
        // Stun have 25% chance of triggering
        int stunChance = rand.Next(1, 5);

        if (stunChance == 1)
        {
            target.GetStunned();
            logger.Log($"{GetName()} застанил {target.GetName()}");
        }
    }
}