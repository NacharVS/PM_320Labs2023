public class Footman : Military
{
    private double _stunChance;

    public Footman(string name, double health, int cost, int lvl,
    double maxHp, double speed, double damage, double attackSpeed,
                                    double armor, double stunChance)
        : base(name, health, cost, lvl, maxHp, speed, damage, attackSpeed, armor) 
    {
        _stunChance = stunChance;
    }

    public void Berserker()
    {
        if (GetHealth() < GetMaxHealth() * 0.3)
        {
            SetDamage(GetDamage() * 2);
            SetAttackSpeed(GetAttackSpeed() - 0.1);
            _stunChance += _stunChance + 0.1;
            Console.WriteLine("Berserker mode active!");
        }
    }

    public void Stun(Unit attackedUnit)
    {
        var random = new Random();
        
        if(random.NextDouble() >= _stunChance)
        {
            Console.WriteLine($"{attackedUnit} get stunned!");
        }
    }

    public override void Attack(Unit attackedUnit)
    {
        Berserker();
        base.Attack(attackedUnit);
    }
}