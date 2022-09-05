public class GuardTowers : Unit
{
    public int range;
    public int damage;
    public int attackSpeed;

    public GuardTowers(int healthPoint, int cost, string name, int level, int newRange, int newDamage, int newAttackSpeed) : 
        base(healthPoint, cost, name, level)
    {
        this.range = newRange;
        this.damage = newDamage;
        this.attackSpeed = newAttackSpeed;
    }
    public override void Attack(Unit enemy)
    {
        enemy.healthPoint = enemy.healthPoint - damage;
        enemy.Alive();
    }

    public override int getAttackSpeed()
    {
        return attackSpeed;
    }
}