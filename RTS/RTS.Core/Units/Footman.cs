using RTS.Core;

public class Footman : Military
{
    private int _meaningOfUsingBerserker;
    public Footman(int health, int cost, string? name, int level, int speed, int damage, int attackSpeed, int armor) 
        : base(health, cost, name, level, speed, damage, attackSpeed, armor)
    {
        _meaningOfUsingBerserker = (int)(Health * 0.3);
    }

    public void Berserker()
    {
        if (Health < _meaningOfUsingBerserker) AttackSpeed /= 2;
    }

    public void Stun(Unit entity)
    {
        
    }
}