namespace Warcraft.Core;

public class Archer : Ranged
{
    public int ArrowCount { get; protected set; }

    public Archer(IEventLogger logger, int health, int cost, string name,
        int level, int speed, int attackSpeed, int damage, int attackRange,
        int mana, int arrowCount) : base(logger, health, cost, name, level, speed, attackSpeed,
        damage, attackRange, mana)
    {
        ArrowCount = arrowCount;
    }

    public void UpgradeBow(int value)
    {
        ArrowCount += value;
    }

    public override void Attack(Unit target)
    {
        if (ArrowCount <= 0)
        {
            Log("У меня нет стрел для атаки");
            return;
        }

        ArrowCount--;
        base.Attack(target);
    }
}