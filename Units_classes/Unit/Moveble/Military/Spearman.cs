


class Spearman : Military
{
    private bool berserk;
/*    public Footman(double damage, double attack_speed, int defence, int speed) : base(damage, attack_speed, defence, speed)
    {
        Max_health = 100;
    }*/
    public delegate void Delegate_Berserk(string Name, double hit);
    public Delegate_Berserk Event_Berserk { get; set; }

    public Spearman()
    {
        Max_health = 110;
        Real_health = Max_health;
        Damage = 10;
        Defence = 20;
        Attack_speed = 1.5;
        berserk = false;
        Name = "Spearman";
    }

    public double Berserker()
    {
        double hit = Damage * 2;
        Console.WriteLine($"{Name} звереет на глазах, налетая на противника и нанося ему {hit} урона.");
        /*Event_Berserk(Name, hit);*/
        return hit;
    }

    public override double Step()
    {
        double hit;
        if (berserk == true)
        {
            hit = Attack();
        }
        else if (Real_health <= Max_health * 0.3)
        {
            hit = Berserker();
            berserk = true;
        }
        else
        {
            hit = Attack();
        }

        return hit;
    }
}



