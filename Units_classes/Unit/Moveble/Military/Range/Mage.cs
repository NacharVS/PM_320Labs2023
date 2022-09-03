




class Mage : Range
{
/*    public Mage(double damage, double attack_speed, int defence, int speed, int radius, int mana) : base(damage, attack_speed, defence, speed, radius, mana)
    {
        Mana = 200;
    }*/

    public Mage()
    {
        Mana = 200;
        Max_health = 100;
        Real_health = Max_health;
        Damage = 20;
        Defence = 5;
        Attack_speed = 0.9;
        Name = "Mage";
    }

    public double Fireball()
    {
        double hit = 0;
        if (Mana >= 20)
        {
            hit = Damage * 3;
        }
        Console.WriteLine($"{Name} отправляет огненный шар во врага.");
        return hit;
    }

    public void Heal()
    {
        if (Mana >= 30 && Real_health > 0)
        {
            Real_health += Max_health * 0.4;
        }
        Console.WriteLine($"{Name} колдует исцеление, восстанавливая себе {Max_health * 0.4}");
    }

    public override double Step()
    {
        Random rnd = new Random();
        int cube = rnd.Next(0, 3);
        double hit = 0;
        switch (cube)
        {
            case 0:
                hit = Attack();
                break;
            case 1:
                hit = Fireball();
                break;
            case 2:
                Heal();
                break;
        }
        return hit;
    }
}



