
class Moveble : Unit
{
    public int Speed; // Скорость приближения. 1 ход при 2-ой скорости - 2 шага.

    public Moveble()
    {
        Name = "Moveble";
        Speed = 1;
    }

    public override double Step()
    {
        return 1;
    }
}



