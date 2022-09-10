using RTS.Core.BaseEntities;

namespace RTS.Core.EventArgs;

public class SpellArgs : System.EventArgs
{
    public Unit Target { get; set; }
    public int SpellCost { get; set; }
    public int SpellDamage { get; set; }

    public SpellArgs(Unit target, int spellCost, int spellDamage)
    {
        Target = target;
        SpellCost = spellCost;
        SpellDamage = spellDamage;
    }
}