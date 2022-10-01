using static System.Net.WebRequestMethods;

public class Military : Moveable
{
    public int damage;
    public int attackSpeed;
    public int armor;
    
    public void Attack(Unit unit)
    {
        if (isDestroyed == false)
        {
            if (unit.isDestroyed == false)
            {
                if (isStunned == false)
                {
                    unit.health -= damage * attackSpeed;

                    if (unit.health < 0)
                    {
                        unit.health = 0;
                    }
                    //Console.WriteLine($"{unit.name} health - {unit.health}");
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
