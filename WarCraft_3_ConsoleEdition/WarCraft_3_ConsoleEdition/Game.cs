using System;
using System.Runtime.ExceptionServices;
using WarCraft_3_ConsoleEdition;
using Range = WarCraft_3_ConsoleEdition.Range;

static public class Game
{
    static private int _time = 0;

    static public void StartGame(Unit firstUnit, Unit secondUnit)
	{
        try
        {
            firstUnit.AttackEvent += firstUnit.Attack(secondUnit);
            firstUnit.AttackEvent += firstUnit.ReportDamage(secondUnit);
            secondUnit.AttackEvent += secondUnit.AttackDamage(firstUnit);
            secondUnit.AttackEvent += secondUnit.ReportDamage(firstUnit);
        }
        catch
        {
            Console.WriteLine("The wrong type of fighter is selected!");
        }


        for (; firstUnit.Health > 0 && secondUnit.Health > 0; _time++)
        {
            if (firstUnit.TimeWithoutAttack == 0)
            {
                ChoosingMove(firstUnit, secondUnit, _time);
            }

            if (secondUnit.TimeWithoutAttack == 0)
            {
                ChoosingMove(secondUnit, firstUnit, _time);
            }

            if (firstUnit.TimeWithoutAttack > 0)
            {
                firstUnit.TimeWithoutAttack--;
            }

            if (secondUnit.TimeWithoutAttack > 0)
            {
                secondUnit.TimeWithoutAttack--;
            }
        }

        Console.WriteLine(firstUnit.Health > 0 ?
            $"{firstUnit.Name} win!" : $"{secondUnit.Name} win!");
	}

    static void ChoosingMove(Unit atUnit, Unit defUnit, int time)
    {

        switch (atUnit.GetType().Name.ToString())
        {
            case "GuardTower":
                if (time % ((GuardTower)atUnit).AttackSpeed == 0)
                {
                    atUnit.AttackEvent;
                }
                break;

            case "Military":
                if (time % ((Military)atUnit).AttackSpeed == 0)
                {
                    atUnit.AttackEvent;
                }
                break;

            case "Footman":
                if (time % ((Footman)atUnit).AttackSpeed == 0)
                {
                    atUnit.AttackEvent;
                }

                if (atUnit.Health < 35 && !((Footman)atUnit).IsBerserk)
                {
                    ((Footman)atUnit).HealthChangedEvent; 
                }

                if ((time % ((Footman) atUnit).AttackSpeed * 5) == 0)
                {
                    try
                    {
                        ((Footman)atUnit).Stun((Movable) defUnit);
                        Console.WriteLine($"{atUnit.Name} stunned " +
                            $"{defUnit.Name} for {((Footman)atUnit).StunTime} second");                                            
                    }
                    catch
                    { }   
                }
                break;

            case "Range":
                if (time % ((Range) atUnit).AttackSpeed == 0)
                {
                    atUnit.AttackEvent;
                }
                break;

            case "Archer":
                if (time % ((Archer) atUnit).AttackSpeed == 0 
                    && ((Archer)atUnit).ArrowCount != 0)
                {
                    atUnit.AttackEvent;
                    ((Archer)atUnit).ArrowCount--;
                }
                break;

            case "Mage":
                if (time % ((Mage)atUnit).AttackSpeed == 0)
                {
                    atUnit.AttackEvent;
                }

                if (time % (((Mage)atUnit).AttackSpeed * 3) == 0)
                {
                    Random rnd = new Random();
                    int value = rnd.Next(1, 4);

                    switch (value)
                    {
                        case 1:
                            ((Mage)atUnit).Fireball(defUnit);
                            Console.WriteLine($"{atUnit.Name} used fireball " +
                                $"and dealt {((Mage)atUnit).Damage * 2} " +
                                $"damage to {defUnit.Name}");
                            break;

                        case 2:
                            ((Mage)atUnit).Blizzard(defUnit);
                            Console.WriteLine($"{atUnit.Name} froze " +
                            $"{defUnit.Name} for 7 second");
                            break;

                        case 3:
                            Console.WriteLine($"{atUnit.Name} healed " +
                                $"{atUnit.Name} for {((Mage)atUnit).Heal(atUnit)} HP");
                            break;
                    }
                }
                break;

            case "Dragon":
                if (time % ((Dragon)atUnit).AttackSpeed == 0)
                {
                    atUnit.AttackEvent;
                }

                if (time % (((Dragon)atUnit).AttackSpeed * 2) == 0)
                {
                    ((Dragon)atUnit).FireBreath(defUnit);
                    Console.WriteLine($"{atUnit.Name} used firebreath and" +
                        $" dealt {((Dragon)atUnit).Damage * 3} " +
                        $"damage to {defUnit.Name}");
                }
                break;

            default:
                break;
        }

    }
}

