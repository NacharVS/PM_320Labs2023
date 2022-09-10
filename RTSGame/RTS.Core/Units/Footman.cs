using RTS.Core.BaseEntities;
using RTS.Core.EventArgs;
using RTS.Core.Logger;

namespace RTS.Core.Units;

public class Footman : Military
{
    private readonly int _berserkAbilityHealthBoundary;
    
    public Footman(int health, int cost, string? name, int level, int speed, int damage, int attackSpeed, int armor, ILogger logger) 
        : base(health, cost, name, level, speed, damage, attackSpeed, armor, logger)
    {
        _berserkAbilityHealthBoundary = (int)(health * 0.3);
        
        OnGetDamage += CheckBerserkBuff;
    }

    private void CheckBerserkBuff(Unit _, HitArgs args)
    {
        if (args.PreviousHealth > _berserkAbilityHealthBoundary
            && args.CurrentHealth < _berserkAbilityHealthBoundary)
        {
            AttackSpeed /= 2;
        }
        else if (args.PreviousHealth < _berserkAbilityHealthBoundary
                 && args.CurrentHealth > _berserkAbilityHealthBoundary)
        {
            AttackSpeed *= 2;
        }
    }

    public void Stun(Unit entity)
    {
        
    }
}