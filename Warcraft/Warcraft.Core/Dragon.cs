using Warcraft.Core.BaseClasses;
using Warcraft.Core.Effects;
using Warcraft.Core.Spells;

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
        Spells = new Dictionary<string, Spell>
        {
            {
                "FireBreath", new AttackingSpell
                {
                    Damage = FireBreathDamage, ManaCost = FireBreathManaCost,
                    Name = "FireBreath",
                    InflictedEffects = new[]
                    {
                        new Effect
                        {
                            Name = "Горение", Damage = 50, Duration = 3,
                            Message = "Подгорел на {0} урона"
                        }
                    },
                    Message = $"Пустил огненное дыхание на {{0}}. Урон: {Damage}"
                }
            }
        };
    }
}