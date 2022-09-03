
public abstract class Unit
{
    public double Max_health; 
    public double Real_health;
    public int Cost;
    public string Name;
    public int Level; // Уровень: 1 <= x <= 99
    public int Defence; // Защита: 0 <= x <= 100
    public bool Is_dead = false;

    public Unit(string name = "Undefined")
    {
        Name = name;
        Defence = 0;
        Level = 1;
    }

    public void Taking_damage(double loss)
    {
        double real_loss = (loss - loss / 100 * Defence);
        Real_health -= real_loss;
        Console.WriteLine($"{Name} получает урон, равный {real_loss}!" );

    }

    public abstract double Step();
}


