public class Military : Moveble
{
    public Random rnd = new Random();
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
        if (!enemy.useArmor())
        {
            enemy.healthPoint = enemy.healthPoint - damage;
            enemy.Alive();
        }
        enemy.Alive();
    }
    public override int getAttackSpeed()
    {
        return attackSpeed  ;
    }

    public override int getArmor()
    {
        return armor;
    }
    public override bool useArmor()
    {
        if ((rnd.Next(1, 5) == 1) && armor > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}