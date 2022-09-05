using System.Xml.Linq;

public class Unit
{
    public int healthPoint;
    public int cost;
    public string name;
    public int level;
    public bool alive = true;

    public Unit(int newHealthPoint, int newCost, string newName, int newLevel)
    {
        this.healthPoint = newHealthPoint;
        this.cost = newCost;
        this.name = newName;
        this.level = newLevel;
    }

    public virtual int getAttackSpeed()
    {
        return 0;
    }

    public bool Alive()
    {
        if(healthPoint <= 0)
        {
            alive = false;
        }
        return alive;
    }
    public virtual void Attack(Unit enemy)
    {
        enemy.Alive();
        //Console.WriteLine(name);
    }
    public virtual void Move()
    {
        //Console.WriteLine(name);
    }
    public virtual void Mining()
    {
        //Console.WriteLine(name);
    }

    public virtual void Choping()
    {
        //Console.WriteLine(name);
    }
    public virtual void Berserker()
    {
        //Console.WriteLine(name);
    }
    public virtual void Stun()
    {
        //Console.WriteLine(name);
    }
    public virtual void FireBall(Unit enemy)
    {
        //Console.WriteLine(name);
    }

    public virtual void Blizzard(Unit character6)
    {
        //Console.WriteLine(name);
    }
    public virtual void Heal()
    {
        //Console.WriteLine(name);
    }

}