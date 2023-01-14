using Warcraft.Core.BaseClasses;
using Warcraft.Core.Spells;

namespace Warcraft.Core;

public class Footman : Military
{
    private const int BerserkBoundary = 200;
    private bool _berserkActive;

    public Footman(IEventLogger logger, int health, int cost, string name,
        int level, int speed, int attackSpeed, int damage)
        : base(logger, health, cost, name, level, speed, attackSpeed, damage)
    {
        AfterHpChange += CheckBerserkMode;
        Spells = new Dictionary<string, Spell> { { "Stun", new AttackingSpell { Damage = 10, ManaCost = 0, Name = "Стан", Message = $"Застанил {0}. Урон: {Damage}"} } };
    }

    // Berserk passive
    private void CheckBerserkMode(object? sender, EventArgs args)
    {
        if (!_berserkActive && Health <= BerserkBoundary)
        {
            Damage *= 2;
            _berserkActive = true;
            Log("Получил способность берсерка");
        }
        else if (_berserkActive && Health > BerserkBoundary)
        {
            Damage /= 2;
            _berserkActive = false;
            Log("Больше не берсерк");
        }
    }

    public void Stun(Unit target)
    {
        if (target != this && target is Movable movableTarget)
        {
            movableTarget.Slow(100);
            Log($"Застанил {target.Name}");
        }
    }

    public void UpgradeWeapon(int value)
    {
        Damage += value;
    }
}