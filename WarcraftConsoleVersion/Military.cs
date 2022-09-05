public class Military : Moveble
{
    public int damage;
    public int attackSpeed;
    public int armor;

    public Military(int healthPoint, int cost, string name, int level, int speed, int newDamage, int newAttackSpeed, int newArmor) :
        base(healthPoint, cost, name, level, speed)
    {
        this.damage = newDamage;
        this.attackSpeed = newAttackSpeed;
        this.armor = newArmor;
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