using Editor.Core.Characters;
using Editor.Core.Characters.interfaces;

namespace Editor.Core.Abilities;

public class Ability : IHaveName
{
    public string? Name { get; set; }
    public int RequiredLevel { get; set; }
    public Action<Character>? AbilityImpact { get; set; }
    public bool IsApplied { get; set; }

    public Ability(string? name, int requiredLevel, Action<Character>? abilityAction)
    {
        Name = name;
        RequiredLevel = requiredLevel;
        AbilityImpact = abilityAction;
    }

    public Ability(string? name, int requiredLevel, bool isApplied=false)
    {
        Name = name;
        RequiredLevel = requiredLevel;
        AbilityImpact = null;
        IsApplied = isApplied;
    }

    public void Apply(Character character)
    {
        AbilityImpact?.Invoke(character);
        IsApplied = true;
    }
}