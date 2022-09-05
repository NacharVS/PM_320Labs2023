public class Mage : Range
{
    private double _fireBallManaCost = 5;
    private double _fireBallDamage = 10;
    private double _blizzardManaCost = 7;
    private double _blizzardDamage = 12;
    private double _healManaCost = 10;
    private double _heal = 100; 
    public Mage(string name, double health, int cost, int lvl,
    double maxHp, double speed, double damage, double attackSpeed,
                        double armor, double range, double mana)
        : base(name, health, cost, lvl, maxHp, speed, damage, attackSpeed, 
                                                        armor, range, mana)
    {
    }
    public void FireBall(Unit attackedUnit)
    {
        if(GetManaRes() < _fireBallManaCost)
        {
            Console.WriteLine("Not have a mana!");
            return;
        }
        else if(GetState())
        {
            Console.WriteLine("Dead!");
            return;
        }
        Console.WriteLine($"{attackedUnit} was hit fireball!");
        Attack(attackedUnit, _fireBallDamage);
        SetMana(_fireBallManaCost);
    }

    public void Blizzard(Unit attackedUnit)
    {
        if (GetManaRes() < _blizzardManaCost)
        {
            Console.WriteLine("Not have a mana!");
            return;
        }
        if (GetState())
        {
            Console.WriteLine("Dead!");
            return;
        }
        Console.WriteLine($"{attackedUnit} caught in a blizzard!");
        Attack(attackedUnit, _blizzardDamage);
        SetMana(_fireBallManaCost);
    }

    public void Heal(Unit selectedUnit)
    {
        if (GetManaRes() < _healManaCost)
        {
            Console.WriteLine("Not have a mana!");
            return;            
        }
        else if (GetState())
        {
            Console.WriteLine("Dead!");
            return;
        }
        
        Console.WriteLine($"{selectedUnit} healed!");
        if (selectedUnit.GetHealth() + _heal > selectedUnit.GetMaxHealth())
        {
            selectedUnit.SetHealth(selectedUnit.GetMaxHealth());
        }
        else
        {
            selectedUnit.SetHealth(selectedUnit.GetHealth() + _heal);
        }
        SetMana(_healManaCost);
    }
}
