
class Archer : Range
{
    public int Arrows_count;

    public Archer()
    {
        Arrows_count = 50;
        Max_health = 90;
        Real_health = Max_health;
        Damage = 15;
        Attack_speed = 2;
        Defence = 5;
        Name = "Archer";
    }

    public override double Step()
    {
        double hit = 0;
        if (Arrows_count > 0)
        {
            hit = Attack();
            Arrows_count--;
        }
        return hit;
    }
}




