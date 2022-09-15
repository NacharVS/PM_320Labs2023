using Warcraft.Core.BaseClasses;
using Warcraft.Core.Effects;

namespace Warcraft.Core.Spells;

public abstract class Spell
{
    public string Name { get; set; }
    public int ManaCost { get; set; }
    public Effect[] InflictedEffects { get; set; } = Array.Empty<Effect>();
    public string Message { get; set; }

    public abstract void Cast(Unit target);
}