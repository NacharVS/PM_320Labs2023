﻿public class Footman : Military
{
    private double _stunChance;
    private bool _berserkerModeActive;

    public Footman(string name, double health, int cost, int lvl,
    double maxHp, double speed, double damage, double attackSpeed,
                                    double armor, double stunChance)
        : base(name, health, cost, lvl, maxHp, speed, damage, attackSpeed, armor) 
    {
        _stunChance = stunChance;
        HealthChangedEvent += Berserker;
    }

    public void Berserker()
    {
        if (!_berserkerModeActive && GetHealth() < GetMaxHealth() * 0.3)
        {
            SetDamage(GetDamage() * 2);
            SetAttackSpeed(GetAttackSpeed() - 0.1);
            _stunChance += 0.1;
            _berserkerModeActive = true;
            
            Console.WriteLine("Berserker mode activated!");
        }
        else if(_berserkerModeActive && GetHealth() > GetMaxHealth() * 0.3)
        {
            SetDamage(GetDamage() / 2);
            SetAttackSpeed(GetAttackSpeed() + 0.1);
            _stunChance -= 0.1;
            _berserkerModeActive = false;

            Console.WriteLine("Berserker mode deactivated!");
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
}