






class Peasant : Moveble
{ 
    public Peasant()
    {
        Max_health = 50;
        Real_health = Max_health;
        Name = "Peasant";
    }

    public void Mining()
    {
        Random dig = new Random();
        int value = dig.Next(1, 5);
        Console.WriteLine($"{Name} накопал {value} булыжника");
    }

    public void Choping()
    {
        Random dig = new Random();
        int value = dig.Next(1, 3);
        Console.WriteLine($"{Name} нарубил {value} бревен");
        /*        return value;*/
    }

    public override double Step()
    {
        Random rnd = new Random();
        int cube = rnd.Next(0, 2);
        if (cube == 1)
        {
            Mining();
        }
        else if (cube == 2)
        {
            Choping();
        }
        return 0;
    }
}



