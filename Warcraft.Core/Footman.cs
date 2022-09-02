namespace Warcraft.Core;

public class Footman : Military
{
    private const int BerserkBoundary = 200;
    private bool BerserkActive;

    public Footman(IEventLogger logger, int health, int cost, string name,
        int level, int speed, int attackSpeed, int damage)
        : base(logger, health, cost, name, level, speed, attackSpeed, damage)
    {
        OnHpChange += CheckBerserkMode;
        Spells = new Dictionary<string, Action<Unit>> { { "Stun", Stun } };
    }

    // Berserk passive
    private void CheckBerserkMode(object? sender, EventArgs args)
    {
        if (!BerserkActive && MaxHealth - Health < BerserkBoundary)
        {
            Damage *= 2;
            BerserkActive = true;
            Log("Получил способность берсерка");
        }
        else if (BerserkActive && Health > BerserkBoundary)
        {
            Damage /= 2;
            BerserkActive = false;
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
}