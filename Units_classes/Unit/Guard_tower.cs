






class Guard_tower : Unit
{
    public double Damage;
    public int Radius;
    public double Attack_speed;

    public Guard_tower()
    {
        Max_health = 200;
        Real_health = Max_health;
        Damage = 10;
        Defence = 40;
        Attack_speed = 0.5;
        Radius = 3;
        Name = "Guard_tower";
    }
    public double Attack()
    {
        double loss;
        loss = Damage * Attack_speed;
        Console.WriteLine($"Стражники из {Name} поливают противника градом стрел");
        return loss;
    }

    public override double Step()
    {
        return Attack();
    }
}



