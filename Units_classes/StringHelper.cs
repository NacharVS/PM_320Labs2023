public class StringHelper
{
    public void GetDamage(double health, double real_loss, string name)
    {
        int int_health = Convert.ToInt32(health);
        int int_real_loss = Convert.ToInt32(real_loss);
        Console.WriteLine($"{name} был получен урон, равный {int_real_loss} от его здоровья в {int_health}!");
    }

    public void Berserk(string Name, double hit)
    {
        int int_hit = Convert.ToInt32(hit);
        Console.WriteLine($"{Name} звереет на глазах, налетая на противника и нанося ему {int_hit} урона.");
    }
}