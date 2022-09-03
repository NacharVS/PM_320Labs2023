





class Dragon : Range
{
    /*public Dragon(double damage, double attack_speed, int defence, int speed, int radius, int mana) : base(damage, attack_speed, defence, speed, radius, mana)
    { }*/

    public Dragon ()
    {
        Max_health = 100;
        Real_health = Max_health;
        Mana = 300;
        Damage = 30;
        Defence = 50;
        Attack_speed = 0.5;
        Radius = 3;
        Name = "Dragon";
    }

    public double Firebreath()
    {
        double hit = 0;
        if (Mana >= 30)
        {
            hit = Damage * 2;
        }
        Console.WriteLine($"{Name} угрожает сжечь все дотла своим дыханием...");
        return hit;
    }

    public override double Step()
    {
        Random rnd = new Random();
        int cube = rnd.Next(0, 2);
        double hit = 0;
        switch (cube)
        {
            case 0:
                hit = Attack();
                break;
            case 1:
                hit = Firebreath();
                break;
        }
        return hit;
    }
}



