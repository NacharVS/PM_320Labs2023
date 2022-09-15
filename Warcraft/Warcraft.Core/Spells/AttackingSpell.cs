using Warcraft.Core.BaseClasses;

namespace Warcraft.Core.Spells;

public class AttackingSpell : Spell
{
    public int Damage { get; set; }
    
    public override void Cast(Unit target)
    {
        target.Hit(Damage);
        foreach (var effect in InflictedEffects)
        {
            target.AddEffect(effect);
        }
    }
}