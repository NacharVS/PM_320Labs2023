using System;
using WarCraft_3_ConsoleEdition;
using Range = WarCraft_3_ConsoleEdition.Range;

static public class Game
{
    static private int time = 0;

    static public void StartGame(Unit firstUnit, Unit secondUnit)
	{
        for (; firstUnit.health > 0 && secondUnit.health > 0; time++)
        {
            if (firstUnit.timeWithoutAttack == 0)
            {
                ChoosingMove(firstUnit, secondUnit, time);
            }

            if (secondUnit.timeWithoutAttack == 0)
            {
                ChoosingMove(secondUnit, firstUnit, time);
            }

            if (firstUnit.timeWithoutAttack > 0)
            {
                firstUnit.timeWithoutAttack--;
            }

            if (secondUnit.timeWithoutAttack > 0)
            {
                secondUnit.timeWithoutAttack--;
            }
        }

        Console.WriteLine(firstUnit.health > 0 ?
            $"{firstUnit.name} win!" : $"{secondUnit.name} win!");
	}

    static void ChoosingMove(Unit atUnit, Unit defUnit, int time)
    {
        switch (atUnit.GetType().Name.ToString())
        {
            case "GuardTower":
                if (time % ((GuardTower)atUnit).attackSpeed == 0)
                {
                    ((GuardTower)atUnit).Attack(defUnit);
                    ReportDamage(atUnit, (int)(((GuardTower)atUnit).damage -
                                   ((GuardTower)atUnit).damage * (double)((Military)defUnit).armor / 100), defUnit);
                }
                break;

            case "Military":
                if (time % ((Military)atUnit).attackSpeed == 0)
                {
                    ((Military)atUnit).Attack(defUnit);
                    ReportDamage(atUnit, ((Military)atUnit).damage, defUnit);
                }
                break;

            case "Footman":
                if (time % ((Footman)atUnit).attackSpeed == 0)
                {
                    ((Footman)atUnit).Attack(defUnit);
                    try
                    {
                        ReportDamage(atUnit, (int)(((Footman)atUnit).damage -
                                    ((Footman)atUnit).damage * (double)((Military)defUnit).armor / 100), defUnit);
                    }

                    catch{ ReportDamage(atUnit, ((Footman)atUnit).damage, defUnit); }
                }

                if (atUnit.health < 35 && !((Footman)atUnit).isBerserk)
                {
                    ((Footman)atUnit).Berserker();
                    Console.WriteLine($"{atUnit.name} used Berserker");
                }

                if ((time % ((Footman) atUnit).attackSpeed * 5) == 0)
                {
                    try
                    {
                        ((Footman)atUnit).Stun((Movable) defUnit);
                        Console.WriteLine($"{atUnit.name} stunned " +
                            $"{defUnit.name} for 5 second");                                            
                    }

                    catch{ }   
                }
                break;

            case "Range":
                if (time % ((Range) atUnit).attackSpeed == 0)
                {
                    ((Range)atUnit).Attack(defUnit);
                    ReportDamage(atUnit, ((Range)atUnit).damage, defUnit);
                }
                break;

            case "Archer":
                if (time % ((Archer) atUnit).attackSpeed == 0 
                    && ((Archer)atUnit).arrowCount != 0)
                {
                    ((Archer)atUnit).Attack(defUnit);
                    ((Archer)atUnit).arrowCount--;
                    ReportDamage(atUnit, ((Range)atUnit).damage, defUnit);
                }
                break;

            case "Mage":
                if (time % ((Mage)atUnit).attackSpeed == 0)
                {
                    ((Mage)atUnit).Attack(defUnit);

                    try
                    {
                        ReportDamage(atUnit, (int)(((Mage)atUnit).damage -
                            ((Mage)atUnit).damage * (double)((Military)defUnit).armor / 100), defUnit);
                    }

                    catch{ ReportDamage(atUnit, ((Mage)atUnit).damage, defUnit); }
                }

                if (time % (((Mage)atUnit).attackSpeed * 3) == 0)
                {
                    Random rnd = new Random();
                    int value = rnd.Next(1, 4);

                    switch (value)
                    {
                        case 1:
                            ((Mage)atUnit).Fireball(defUnit);
                            Console.WriteLine($"{atUnit.name} used fireball " +
                                $"and dealt {((Mage)atUnit).damage * 2} " +
                                $"damage to {defUnit.name}");
                            break;

                        case 2:
                            ((Mage)atUnit).Blizzard(defUnit);
                            Console.WriteLine($"{atUnit.name} froze " +
                            $"{defUnit.name} for 7 second");
                            break;

                        case 3:
                            Console.WriteLine($"{atUnit.name} healed " +
                                $"{atUnit.name} for {((Mage)atUnit).Heal(atUnit)} HP");
                            break;
                    }
                }
                break;

            case "Dragon":
                if (time % ((Dragon)atUnit).attackSpeed == 0)
                {
                    ((Dragon)atUnit).Attack(defUnit);

                    try
                    {
                        ReportDamage(atUnit, (int)(((Dragon)atUnit).damage -
                            ((Dragon)atUnit).damage * (double)((Military)defUnit).armor / 100), defUnit);
                    }

                    catch { ReportDamage(atUnit, ((Dragon)atUnit).damage, defUnit); }
                }

                if (time % (((Dragon)atUnit).attackSpeed * 2) == 0)
                {
                    ((Dragon)atUnit).FireBreath(defUnit);
                    Console.WriteLine($"{atUnit.name} used firebreath and" +
                        $" dealt {((Dragon)atUnit).damage * 3} " +
                        $"damage to {defUnit.name}");
                }
                break;

            default:
                break;
        }

    }

    private static void ReportDamage(Unit atUnit, int damage, Unit defUnit)
    {
        Console.WriteLine($"{atUnit.name} dealt {damage} damage to {defUnit.name}");
    }
}

