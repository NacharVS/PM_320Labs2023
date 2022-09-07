using Warcraft.Core.BaseEntities;

namespace Warcraft.Core.EventArgs;

public class SpellArgs
{
    public Unit Target { get; set; }
    public int SpellDamage { get; set; }
    public int SpellCost{ get; set; }

    public SpellArgs(Unit target, int spellDamage, int spellCost)
    {
        Target = target;
        SpellDamage = spellDamage;
        SpellCost = spellCost;
    }
}