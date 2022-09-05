using static System.Net.Mime.MediaTypeNames;

public class Moveble : Unit
{
    public int speed;

    public Moveble(int healthPoint, int cost, string name, int level, int newSpeed) :
        base(healthPoint, cost, name, level)
    {
        this.speed = newSpeed;
    }
    public override void Move()
    {
        Console.WriteLine(name + ".Move");
    }

    public override void Attack(Unit enemy)
    {
    }
}