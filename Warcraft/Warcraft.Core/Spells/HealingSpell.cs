using Warcraft.Core.BaseClasses;

namespace Warcraft.Core.Spells;

public class HealingSpell : Spell
{
    public int HealValue { get; set; }
    public override void Cast(Unit target)
    {
        target.GetHealed(HealValue);
    }
}