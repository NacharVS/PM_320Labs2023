public class Footman : Military
{
    public Footman footman;
    public bool isBerserker = false;
    public delegate void HealthChangedDelegate(int health, int maxHealth);
    public Footman(int fHP, int fMaxHP, int fCost, string fName, int fDamage, int fAttackSpeed, int fArmor)
    {
        health = fHP;
        maxHP = fMaxHP;
        cost = fCost;
        name = fName;
        lvl = 1;
        damage = fDamage;
        attackSpeed = fAttackSpeed;
        armor = fArmor;
        speed = 4;
}

    public void Berserker()
    {
        if (!isDestroyed)
        {

            if (isBerserker == false)
            {
                if (health < (maxHP % 100 * 40))
                {
                    damage += 5;
                    speed += 5;
                    isBerserker = true;

                    Console.WriteLine($"{name} became a berserker!");
                }

                else
                {
                    Console.WriteLine($"{name} health is too much to became berserker");
                }

            }
            else
            {
                Console.WriteLine($"{name} is berserker already!");
            }
        }

        else
        {
            Console.WriteLine($"{name} is illuminated. He can't to become berserker");
        }
    }

    public void Stun(Unit unit)
    {
        unit.isStunned = true;
        Console.WriteLine($"{unit.name} was stunned by {name}");
    }
}
