using RTS.Core.BaseEntities;
using RTS.Core.Logger;

namespace RTS.Core.Units;

public class Archer : Ranged
{
    public int ArrowCount { get; set; }
    
    public Archer(int health, int cost, string? name, int level, int speed, int damage, 
        int attackSpeed, int armor, int attackRange, int mana, int arrowCount, ILogger logger) 
        : base(health, cost, name, level, speed, damage, attackSpeed, armor, attackRange, mana, logger)
    {
        ArrowCount = arrowCount;
    }

    private protected new void Attack(Unit entity, int damage)
    {
        if (entity.IsDestroyed || IsDestroyed)
        {
            return;
        }
        
        Thread.Sleep(AttackSpeed);

        if (entity.IsDestroyed || IsDestroyed)
        {
            return;
        }

        if (ArrowCount > 0)
        {
            --ArrowCount;
            Logger.Log(LogMessageType.Info, $"\"{Name}\" attacks \"{entity.Name}\" ");
            entity.GetDamage(damage);
        }
        else
        {
            Logger.Log(LogMessageType.Info, "Нужно больше стрел, милорд!");
        }
    }
}