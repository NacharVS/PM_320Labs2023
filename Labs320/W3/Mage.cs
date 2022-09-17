public class Mage : Range
{
    public Mage(int mHP, int mMaxHP, int mCost, string mName, int mRange, int mMana, int mDamage, int mAttackSpeed, int mArmor)
    {
        health = mHP;
        maxHP = mMaxHP;
        cost = mCost;
        name = mName;
        lvl = 1;
        range = mRange;
        mana = mMana;
        damage = mDamage;
        attackSpeed = mAttackSpeed;
        armor = mArmor;
        speed = 6;
    }
    public void FireBall(Unit unit)
    {
        if (isDestroyed == false)
        {
            if (mana >= 10)
            {
                if (unit.health > 0)
                {
                    unit.health -= 25;

                    Console.WriteLine($"{name} uses fireball! Damage given to {unit.name}: 15");

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

        else
        {
            Console.WriteLine($"{name} is illuminated. Illuminated persons can't use spells");
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
                    unit.health -= 20;

                    Console.WriteLine($"{name} uses blizzard! Damage given to {unit.name}: 20");

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
    public void Heal(Unit unit)
    {
        if (isDestroyed == false)
        {
            if (mana >= 10)
            {
                if (unit.health > 0)
                {
                    unit.health += 10;

                    Console.WriteLine($"{name} heals {unit.name} by 10 HP");

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
                    Console.WriteLine($"{unit.name} is illuminated. Illuminated persons can't be healed");
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
