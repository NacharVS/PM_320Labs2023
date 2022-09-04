using RTS.Core.BaseEntities;

namespace RTS.Core.Units;

public class Archer : Ranged
{
    public int ArrowCount { get; set; }
    
    public Archer(int health, int cost, string? name, int level, int speed, int damage, 
        int attackSpeed, int armor, int attackRange, int mana, int arrowCount) 
        : base(health, cost, name, level, speed, damage, attackSpeed, armor, attackRange, mana)
    {
        ArrowCount = arrowCount;
    }

    private protected new void Attack(Unit entity, int damage)
    {
        if (entity.IsDestroyed || IsDestroyed)
        {
            return;
        }
        
        Thread.Sleep(AttackSpeed);

        if (entity.IsDestroyed || IsDestroyed)
        {
            return;
        }

        if (ArrowCount > 0)
        {
            --ArrowCount;
            Console.WriteLine($"\"{Name}\" attacks \"{entity.Name}\" ");
            entity.GetDamage(damage);
        }
        else
        {
            Console.WriteLine("Нужно больше стрел, милорд!");
        }
    }
}