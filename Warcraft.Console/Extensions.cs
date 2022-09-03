using Warcraft.Core;

namespace Warcraft.Console;

public static class Extensions
{
    private static readonly Random Random = new();

    public static void RandomAttack(this Military hero, Unit target)
    {
        var action = Random.Next(2);
        switch (action)
        {
            // spell
            case 0:
                if (hero.SpellNames.Length != 0)
                {
                    var spell =
                        hero.SpellNames[Random.Next(hero.SpellNames.Length)];
                    hero.CastSpell(spell, target);
                }

                break;
            // default attack
            case 1:
                hero.Attack(target);
                break;
        }
    }

    public static void RandomBuff(this Blacksmith smith)
    {
        var action = Random.Next(3);
        switch (action)
        {
            case 0:
                smith.UpgradeWeapon();
                break;
            case 1:
                smith.UpgradeArmor();
                break;
            case 2:
                smith.UpgradeBow();
                break;
        }
    }

    public static void RandomAction(this Peasant peasant)
    {
        var action = Random.Next(2);
        switch (action)
        {
            case 0:
                peasant.Chop();
                break;
            case 1:
                peasant.Mine();
                break;
        }
    }
}