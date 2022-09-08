using Warcraft.Core.BaseEntities;
using Warcraft.Core.EventArgs;

namespace Warcraft.Core.Units;

public class Footman : Military
{
    private readonly int _rageAbility;
    
    private void CheckRageBuff(Unit _, HitArgs args)
    {
        if (args.PreviousHealth > _rageAbility && args.CurrentHealth < _rageAbility)
            AttackSpeed /= 2;
        else
            AttackSpeed *= 2;
    }

    public void Stun()
    {
    }

    public override void Move()
    {
    }

    public Footman(int health, int cost, string? name, int level, int speed, int damage, int attackSpeed, int armor)
        : base(health, cost, name, level, speed, damage, attackSpeed, armor)
    {
        _rageAbility = (int) (MaxHealth * 0.3);

        OnHealthChanged += CheckRageBuff;
    }
}