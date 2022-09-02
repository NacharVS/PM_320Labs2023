namespace Warcraft.Core;

public class Mage : Ranged
{
    private const int HealCost = 6;
    private const int FireballDamage = 600;
    private const int FireballManaCost = 100;
    private const int BlizzardDamage = 400;
    private const int BlizzardManaCost = 50;

    public Mage(IEventLogger logger, int health, int cost, string name,
        int level, int speed,
        int attackSpeed, int damage, int attackRange, int mana) : base(logger,
        health,
        cost, name, level,
        speed, attackSpeed, damage, attackRange, mana)
    {
        Spells = new Dictionary<string, Action<Unit>>
        {
            { "Fireball", Fireball },
            { "Blizzard", Blizzard }, { "Heal", Heal }
        };
    }

    private void Fireball(Unit target)
    {
        if (Mana < FireballManaCost)
        {
            Log("У меня нет маны!");
            return;
        }

        Attack(target, FireballDamage);
        Mana -= FireballManaCost;
        Log($"Пустил файрбол на {target.Name}");
    }

    private void Blizzard(Unit target)
    {
        if (Mana < BlizzardManaCost)
        {
            Log("У меня нет маны!");
            return;
        }

        Attack(target, BlizzardDamage);
        Mana -= BlizzardManaCost;
        Log($"Выпустил снежную бурю на {target.Name}");
    }

    private void Heal(Unit target)
    {
        if (Mana < HealCost)
        {
            Log("У меня нет маны!");
            return;
        }

        target.GetHealed();
        Mana -= HealCost;
        Log($"Вылечил {target.Name}");
    }
}