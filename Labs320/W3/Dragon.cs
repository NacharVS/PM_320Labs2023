public class Dragon : Range
{
    public Dragon(int dHP, int dMaxHP, int dCost, string dName, int dRange, int dMana, int dDamage, int dAttackSpeed, int dArmor)
    {
        health = dHP;
        maxHP = dMaxHP;
        cost = dCost;
        name = dName;
        lvl = 1;
        range = dRange;
        mana = dMana;
        damage = dDamage;
        attackSpeed = dAttackSpeed;
        armor = dArmor;
        speed = 10;
    }
    public void FireBreath(Unit unit)
    {
        if (mana >= 10)
        {
            if (unit.health > 0)
            {
                unit.health -= 20;

                Console.WriteLine($"Dragon uses fire breath! Damage given to {unit.name}: 20");

                if (unit.health < 0)
                {
                    unit.isDestroyed = true;
                    unit.health = 0;
                }

                Console.WriteLine($"{unit.name} health - {unit.health}");

                mana -= 10;
            }

            else
            {
                Console.WriteLine($"{unit.name} is illuminated. Illuminated persons can't be attacked");
            }
        }

        else
        {
            Console.WriteLine($"Not enough mana!");
        }
    }

    public void Blizzard(Unit unit)
    {
        if (isDestroyed == false)
        {
            if (mana >= 10)
            {
                if (unit.health > 0)
                {
                    unit.health -= 25;

                    Console.WriteLine($"Dragon uses blizzard! Damage given to {unit.name}: 25");

                    if (unit.health < 0)
                    {
                        unit.isDestroyed = true;
                        unit.health = 0;
                    }

                    Console.WriteLine($"{unit.name} health - {unit.health}");

                    mana -= 15;
                }

                else
                {
                    Console.WriteLine($"{unit.name} is illuminated. Illuminated persons can't be attacked");
                }
            }

            else
            {
                Console.WriteLine($"Not enough mana!");
            }
        } 
        
        else
        {
            Console.WriteLine($"{name} is illuminated. Illuminated persons can't use spells");
        }
    }
}
