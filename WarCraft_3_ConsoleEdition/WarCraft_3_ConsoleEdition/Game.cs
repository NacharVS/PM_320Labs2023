using System;
using System.Runtime.ExceptionServices;
using WarCraft_3_ConsoleEdition;
using Range = WarCraft_3_ConsoleEdition.Range;

static public class Game
{
    static private int _time = 0;

    static public void StartGame(Unit firstUnit, Unit secondUnit)
	{
        EventsDistributing(firstUnit);
        EventsDistributing(secondUnit);

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
                    ((GuardTower)atUnit).Attack(defUnit);
                   
                }
                break;

            case "Military":
                if (time % ((Military)atUnit).AttackSpeed == 0)
                {
                     ((Military)atUnit).Attack(defUnit);
                    ((Military)atUnit).ReportDamage(defUnit);
                }
                break;

            case "Footman":
                if (time % ((Footman)atUnit).AttackSpeed == 0)
                {
                    ((Footman)atUnit).Attack(defUnit);
                }

                if (atUnit.Health < 35)
                {
                   ((Footman)atUnit).Berserker(); 
                }

                if ((time % ((Footman) atUnit).AttackSpeed * 5) == 0)
                {
                    try
                    {
                        ((Footman)atUnit).Stun((Movable) defUnit);                                          
                    }
                    catch
                    { }   
                }
                break;

            case "Range":
                if (time % ((Range) atUnit).AttackSpeed == 0)
                {
                    ((Range)atUnit).Attack(defUnit);
                }
                break;

            case "Archer":
                if (time % ((Archer) atUnit).AttackSpeed == 0 
                    && ((Archer)atUnit).ArrowCount != 0)
                {
                    ((Archer)atUnit).Attack(defUnit);
                    ((Archer)atUnit).ArrowCount--;
                }
                break;

            case "Mage":
                if (time % ((Mage)atUnit).AttackSpeed == 0)
                {
                    ((Mage)atUnit).Attack(defUnit);
                }

                if (time % (((Mage)atUnit).AttackSpeed * 3) == 0)
                {
                    Random rnd = new Random();
                    int value = rnd.Next(1, 4);

                    switch (value)
                    {
                        case 1:
                            ((Mage)atUnit).Fireball(defUnit);
                            break;

                        case 2:
                            ((Mage)atUnit).Blizzard(defUnit);
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
                    ((Dragon)atUnit).Attack(defUnit);
                }

                if (time % (((Dragon)atUnit).AttackSpeed * 2) == 0)
                {
                    ((Dragon)atUnit).FireBreath(defUnit);
                }
                break;

            default:
                break;
        }

    }

    static private void EventsDistributing(Unit unit)
    {
        switch (unit.GetType().Name.ToString())
        {
            case "GuardTower":
                ((GuardTower)unit).AttackEvent 
                    += ((GuardTower)unit).ReportDamage;
                break;

            case "Military":
                ((Military)unit).AttackEvent 
                    += ((Military)unit).ReportDamage;
                break;

            case "Footman":
                ((Footman)unit).AttackEvent 
                    += ((Footman)unit).ReportDamage;

                 ((Footman)unit).HealthChangedEvent 
                    += ((Footman)unit).BerserkReport;

                ((Footman)unit).StunEvent 
                    += ((Footman)unit).StunReport;
                break;

            case "Range":
               ((Range)unit).AttackEvent 
                    += ((Range)unit).ReportDamage;
                break;

            case "Archer":
                ((Archer)unit).AttackEvent 
                    += ((Archer)unit).ReportDamage;
                break;

            case "Mage":
               ((Mage)unit).AttackEvent 
                    += ((Mage)unit).ReportDamage;

                 ((Mage)unit).FireballEvent 
                    += ((Mage)unit).FireballReport;

                 ((Mage)unit).BlizzardEvent 
                    += ((Mage)unit).BlizzardReport;
                break;

            case "Dragon":
               ((Dragon)unit).AttackEvent 
                    += ((Dragon)unit).ReportDamage;

                ((Dragon)unit).FireBreathEvent 
                    += ((Dragon)unit).FireBreathReport;
                break;

            default:
                break;
        }
    }
}

