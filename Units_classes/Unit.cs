
public abstract class Unit
{
    private double _health;

    public delegate void Delegate_HealthChanged(double health, double real_loss, string Name);
    public Delegate_HealthChanged Event_HealthChanged { get; set; }

    public double Max_health; 
    public double Real_health 
    {
        get 
        { return _health; }
        set
        { 
            _health = value;
        }
    }

    public int Cost;
    public string Name;
    public int Level; // Уровень: 1 <= x <= 99
    public int Defence; // Защита: 0 <= x <= 100

    public Unit(string name = "Undefined")
    {
        Name = name;
        Defence = 0;
        Level = 1;
    }

    public void Taking_damage(double loss)
    {
        double real_loss = (loss - loss / 100 * Defence);
        Event_HealthChanged(Real_health, real_loss, Name);
        Real_health -= real_loss;
        /*Console.WriteLine($"{Name} получает урон, равный {real_loss}!" );*/
    }

    public abstract double Step();
}


