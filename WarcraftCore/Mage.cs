namespace WarcraftCore;

public class Mage : Range
{
    private const int HEAL_MANA_COST = 6;
    
    private const int FIREBALL_DAMAGE_MULTIPLIER = 4;
    private const int FIREBALL_MANA_COST = 15;
    
    private const int BLIZZARD_DAMAGE_MULTIPLIER = 2;
    private const int BLIZZARD_MANA_COST = 10;

    private Random rand = new Random();
    
    public Mage(int health, string name, int cost, int level, 
        int moveSpeed, int damage, int attackSpeed, int armor, int range, int mana, ILogger logger) : 
        base(health, name, cost, level, moveSpeed, damage, attackSpeed, armor, range, mana, logger)
    {
    }

    public override void Attack(Unit target)
    {
        // 1 - FireBall
        // 2 - Blizzard
        // 3 - Base attack
        // 4 - Heal
        
        int attackType = rand.Next(1, 5);
        
        int healPoint = rand.Next(10, 20);
        
        switch (attackType)
        {
            case 1:
                FireBall(target);
                break;
            case 2:
                Blizzard(target);
                break;
            case 3:
                base.Attack(target);
                break;
            case 4:
                Heal(healPoint);
                break;
        }
    }

    public void FireBall(Unit target)
    {
        if (isDestroyed || target.IsDestroyed())
            return;

        logger.Log($"{GetName()} кинул фаербол в {target.GetName()} в {FIREBALL_DAMAGE_MULTIPLIER * damage} урона");
        target.GetHit(FIREBALL_DAMAGE_MULTIPLIER * damage);
        mana -= FIREBALL_MANA_COST;
    }

    public void Blizzard(Unit target)
    {
        if (isDestroyed || target.IsDestroyed())
            return;

        logger.Log($"{GetName()} кинул молнию в {target.GetName()} в {BLIZZARD_DAMAGE_MULTIPLIER * damage} урона");
        target.GetHit(BLIZZARD_DAMAGE_MULTIPLIER * damage);
        mana -= BLIZZARD_MANA_COST;
    }
    
    public void Heal(int healPoint)
    {
        if (mana >= HEAL_MANA_COST && !isDestroyed)
        {
            logger.Log($"{GetName()} вылечил себя на {healPoint} единиц");
            GetHeal(healPoint);
            mana -= HEAL_MANA_COST * healPoint;
        }
    }
}