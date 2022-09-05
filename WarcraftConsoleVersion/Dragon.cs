public class Dragon : RangeMan
{

    public Dragon(int healthPoint, int cost, string name, int level, int speed, int damage, int attackSpeed, int armor, int range, int mana) : 
        base(healthPoint, cost, name, level, speed, damage, attackSpeed, armor, range, mana)
    {
    }

    public void fireBreath(Unit enemy)
    {
        enemy.healthPoint = enemy.healthPoint - damage;
        enemy.Alive();
    }
}