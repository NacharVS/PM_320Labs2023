
class Military : Moveble
{
    public double Damage; // Урон: 0 < x <= 100
    public double Attack_speed; // Атака в секунду: 0 < x <= 2

    public Military()
    {
        Attack_speed = 1;
        Damage = 0;
    }

/*    public Military(double damage, double attack_speed, int defence, int speed) : base(speed)
    {
        Damage = damage;
        Attack_speed = attack_speed;
        Defence = defence;
    }*/

    public double Attack()
    {
        double loss;
        loss = Damage * Attack_speed;
        Console.WriteLine($"{Name} атакует врага");
        return loss;
    }
}



