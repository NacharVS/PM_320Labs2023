namespace Editor.Core.Abilities;

public static class InitializedAbilities
{
    public static Dictionary<int, Ability> Abilities = new Dictionary<int, Ability>()
    {
        {0, new Ability("Upgrade Health", 3, x => x.HealthPoints += 15)},
        {1, new Ability("Upgrade Physical Defense", 3, x => x.PhysicalDefense += 10)},
        {2, new Ability("Stone skin", 3, x => x.PhysicalDefense += 25)},
        {3, new Ability("Iron fists", 3, x => x.PhysicalDamage += 25)},
        {4, new Ability("Genius brain", 3, x => x.MagicDamage += 18)},
        {5, new Ability("Holy arms", 3, x => x.MagicDamage += 35)},
        {6, new Ability("Double Upgrade Health", 3, x => x.HealthPoints += 35)},
        {7, new Ability("Double Upgrade Physical Defense", 3, x => x.PhysicalDefense += 35)},
        {8, new Ability("Daedra skin", 3, x => x.PhysicalDefense += 55)},
        {9, new Ability("Valkyrie bless", 3, x => x.MagicDamage += 55)}
    };
}