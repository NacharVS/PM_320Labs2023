using Warcraft.Core.BaseClasses;
using Warcraft.Core.Effects;
using Warcraft.Core.Spells;

namespace Warcraft.Core;

public class Mage : Ranged
{
    private const int HealCost = 6;
    private const int HealValue = 20;
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
        Spells = new Dictionary<string, Spell>
        {
            {
                "Fireball",
                new AttackingSpell
                {
                    Name = "Файрбол", Damage = FireballDamage,
                    ManaCost = FireballManaCost,
                    Message = "Пустил файрбол на {0}",
                    InflictedEffects = new[]
                    {
                        new Effect
                        {
                            Name = "Горение", Damage = 50, Duration = 3,
                            Message = "Подгорел на {0} урона"
                        }
                    }
                }
            },
            {
                "Blizzard",
                new AttackingSpell
                {
                    Name = "Буря",
                    ManaCost = BlizzardManaCost, Damage = BlizzardDamage,
                    Message = "Выпустил снежную бурю на {0}"
                }
            },
            {
                "Heal",
                new HealingSpell
                {
                    Name = "Лечение",
                    HealValue = HealValue,
                    ManaCost = HealCost,
                    Message = "Вылечил {0}"
                }
            }
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

        target.GetHealed(HealValue);
        Mana -= HealCost;
        Log($"Вылечил {target.Name}");
    }
}