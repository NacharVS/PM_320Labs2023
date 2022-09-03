


class Spearman : Military
{
/*    public Footman(double damage, double attack_speed, int defence, int speed) : base(damage, attack_speed, defence, speed)
    {
        Max_health = 100;
    }*/

    public Spearman()
    {
        Max_health = 110;
        Real_health = Max_health;
        Damage = 10;
        Defence = 20;
        Attack_speed = 1.5;
        Name = "Spearman";
    }

    public double Berserker()
    {
        double hit = 0;
        if (Real_health <= Max_health * 0.3)
        {
            hit = Damage * 2;
        }
        Console.WriteLine($"{Name} звереет на глазах, налетая на противника и нанося ему {hit} урона.");
        return hit;
    }

    public override double Step()
    {
        double hit = Attack();
        if (Real_health <= Max_health * 0.3)
        {
            hit = Berserker();
        }

        return hit;
    }
}



