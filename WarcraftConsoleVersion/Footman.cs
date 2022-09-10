public class Footman : Military
{
    public int maxHealtPoint;
    public Footman(int healthPoint, int cost, string name, int level, int speed, int damage, int attackSpeed, int armor) :
        base(healthPoint, cost, name, level, speed, damage, attackSpeed, armor)
    {
        this.maxHealtPoint = healthPoint;
    }

    public void Berserker(Unit enemy)
    {
        enemy.healthPoint = enemy.healthPoint - (damage * 2);
        Console.WriteLine(name + ".Berserker");
    }
    public override bool Stun()
    {
        if ((rnd.Next(1, 5) == 1))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public override void Attack(Unit enemy)
    {
        if (healthPoint > (maxHealtPoint * 0.3))
        {
            enemy.healthPoint = enemy.healthPoint - damage;
            enemy.Alive();
        }
        else
        {
            Berserker(enemy);
        }
    }
}