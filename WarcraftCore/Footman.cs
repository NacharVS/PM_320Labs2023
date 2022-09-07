namespace WarcraftCore;

public class Footman : Millitary
{
    Random rand = new();

    protected bool isBerserkerModeActive;
    public Footman(int health, string name, int cost, int level, int moveSpeed, int damage, 
        int attackSpeed, int armor, ILogger logger) : 
        base(health, name, cost, level, moveSpeed, damage, attackSpeed, armor, logger)
    {
        HealthChangedEvent += Berserker;
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
        
        if (!isBerserkerModeActive && health <= maxHealth / 3)
        {
            isBerserkerModeActive = true;
            attackSpeed *= 2;
            damage *= 2;
            
            logger.Log($"{GetName()} включил режим берсерка");

        }
        else if (isBerserkerModeActive && health > maxHealth / 3)
        {
            isBerserkerModeActive = false;
            attackSpeed /= 2;
            damage /= 2;

            logger.Log($"У {GetName()} закончился режим берсерка");
        }

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