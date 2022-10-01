using System;

public abstract class Unit
{
    public int health;
    public int maxHP;
    public int cost;
    public string name;
    public int lvl;
    public bool isDestroyed = false;
    public bool isStunned = false;

    public delegate void HealthChangedDelegate(Unit unit);
    public event HealthChangedDelegate HealthChangedEvent;
    public void HealthOnChange(Unit unit)
    {
        Console.WriteLine($"{unit.name} health - {unit.health}. Max HP - {unit.maxHP} ");
    }
}
