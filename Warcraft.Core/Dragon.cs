namespace Warcraft.Core;

public class Dragon : Ranged
{
    private const int FireBreathManaCost = 100;
    private const int FireBreathDamage = 100;

    public Dragon(IEventLogger logger, int health, int cost, string name,
        int level, int speed,
        int attackSpeed, int damage, int attackRange, int mana) : base(logger,
        health,
        cost, name, level,
        speed, attackSpeed, damage, attackRange, mana)
    {
        Spells = new Dictionary<string, Action<Unit>>
            { { "FireBreath", FireBreath } };
    }

    private void FireBreath(Unit target)
    {
        if (Mana < FireBreathManaCost)
        {
            Log("Рррр! Нет маны!");
            return;
        }

        Attack(target, FireBreathDamage);
        Mana -= FireBreathManaCost;
        Log($"Задул огненным дыханием на {target.Name}");
    }
}