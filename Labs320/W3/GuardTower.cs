public class GuardTower : Unit
{
    public int range;
    public int damage;
    public int attackSpeed;

    public GuardTower(int gtHp, int gtMaxHp, int gtCost, string gtName, int gtRange, int gtDamage, int gtAttackSpeed)
    {
        health = gtHp;
        maxHP = gtMaxHp;
        cost = gtCost;
        name = gtName;
        range = gtRange;
        damage = gtDamage;
        attackSpeed = gtAttackSpeed;
    }
    public void Attack(Unit unit)
    {
        if (isDestroyed == false)
        {
            if (unit.isDestroyed == false)
            {
                if (isStunned == false)
                {
                    unit.health -= damage * attackSpeed;

                    Console.WriteLine($"{name} attack was successfull! Damage given to {unit.name} - {damage * attackSpeed}");
                    
                    if (unit.health < 0)
                    {
                        unit.health = 0;
                    }

                    Console.WriteLine($"{unit.name} health - {unit.health}");
                }

                else
                {
                    Console.WriteLine($"{name} is stunned!");
                    isStunned = false;
                }

                if (unit.health <= 0)
                {
                    unit.isDestroyed = true;

                    Console.WriteLine($"{unit.name} was illuminated!");
                }
            }

            else
            {
                Console.WriteLine($"{unit.name} is illuminated. Illuminated persons can't be attacked");
            }
        }

        else
        {
            Console.WriteLine($"{name} is illuminated. Illuminated units can't attack");
        }
    }
}
