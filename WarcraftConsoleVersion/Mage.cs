internal class Mage : RangeMan
{
    public Mage(int healthPoint, int cost, string name, int level, int speed, int damage, int attackSpeed, int armor, int range, int mana) : 
        base(healthPoint, cost, name, level, speed, damage, attackSpeed, armor, range, mana)
    {
    }

    public override void FireBall(Unit enemy)
    {
        Console.WriteLine(name + ".Fireball");
    }

    public override void Blizzard(Unit enemy)
    {
        Console.WriteLine(name + ".Blizzard");
    }

    public override void Heal()
    {
        Console.WriteLine(name + ".Heal");
    }
    public override void Attack(Unit enemy)
    {
        enemy.healthPoint = enemy.healthPoint - damage;
        enemy.Alive();
    }
}