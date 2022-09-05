using System;

internal class Archer : Military
{
    public int arrowCount;
    public Archer(int healthPoint, int cost, string name, int level, int speed, int damage, int attackSpeed, int armor, int newArrowCount) :
        base(healthPoint, cost, name, level, speed, damage, attackSpeed, armor)
    {
        this.arrowCount = newArrowCount;
    }

    public override void Attack(Unit enemy)
    {
        if (arrowCount > 0)
        {
            enemy.healthPoint = enemy.healthPoint - damage;
            enemy.Alive();
        }
        else
        {
            enemy.healthPoint = enemy.healthPoint - 5;
            enemy.Alive();
        }
    }
}