public class Footman : Military
{

    public Footman(int healthPoint, int cost, string name, int level, int speed, int damage, int attackSpeed, int armor) :
        base(healthPoint, cost, name, level, speed, damage, attackSpeed, armor)
    {
    }

    public override void Berserker()
    {
        Console.WriteLine(name + ".Berserker");
    }
    public override void Stun()
    {
        Console.WriteLine(name + ".Stun");
    }
    public override void Attack(Unit enemy)
    {
        enemy.healthPoint = enemy.healthPoint - damage;
        Console.WriteLine(name + ".Attack");
        enemy.Alive();
    }
}