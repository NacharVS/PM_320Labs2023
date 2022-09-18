using WarCraftCloneCore;

var logger = new ConsoleLogger();
{
    Footman footman = new Footman(logger,"Footman - 1",200.0,10,1,200.0,35.0,50.0,0.1,4,0.1);
    Mage mage = new Mage(logger,"Mage - 1", 100.0, 10, 1,100,50.0, 7,0.3,2,3.0,100);
    Dragon dragon = new Dragon(logger,"Dragon - 1", 350.0,10,1,350.0,30.0,50,0.1,8,3.0,100);
    
    var random = new Random();
    var units = new List<Military> { footman, mage, dragon };

    //--Check units attack--
     while (units.Count != 1)
     {
         var attackUnit = units[random.Next(units.Count)];
         var attackedUnit = units[random.Next(units.Count)];
     
         attackUnit.Attack(attackedUnit);
     
         if (attackedUnit.GetState())
             units.Remove(attackedUnit);
     }
     Console.WriteLine($"{units[0]} win! \n\n");
}

//--Check using spells--
 {
     Mage mage2 = new Mage(logger,"Mage - 2", 100.0, 10, 1, 100, 50.0, 7, 0.3, 2, 3.0, 300);
     Dragon dragon2 = new Dragon(logger,"Dragon - 2", 300.0, 10, 1, 300.0, 30.0, 15, 0.1, 8, 3.0, 100);
     Blacksmith blacksmith = new Blacksmith(logger,"Blacksmith", 200.0, 10,1,200.0,25.0);
     Archer archer = new Archer(logger,"Archer - 1", 100.0, 10, 1, 100, 50.0, 7, 0.3, 2, 3.0, 100);
     Archer archer2 = new Archer(logger,"Archer - 2", 100.0, 10, 1, 100, 50.0, 9, 0.3, 3, 3.0, 100);

     var units = new List<Unit> { mage2, dragon2, blacksmith, archer, archer2};

     dragon2.FireBreath(mage2);
     mage2.FireBall(dragon2);
     mage2.Blizzard(dragon2);
     mage2.Heal(dragon2);
     archer.Attack(dragon2);
     blacksmith.UpgradeArmor(units);
     blacksmith.UpgradeArrow(units);
     blacksmith.UpgradeBow(units);
 }

//--Check mage heal debuff
{
    Mage mage3= new Mage(logger, "Mage - 3", 100.0, 10, 1, 100, 50.0, 7, 0.3, 2, 3.0, 500);
    Dragon dragon3 = new Dragon(logger, "Dragon - 3", 500.0, 10, 1, 500.0, 30.0, 15, 0.1, 8, 3.0, 100);
    var units = new List<Unit> { mage3, dragon3 };
    mage3.Attack(dragon3);
    mage3.AntiHealDebuff(units);
    mage3.Heal(dragon3);
    mage3.Attack(dragon3);
    mage3.Heal(dragon3);
    mage3.Attack(dragon3);
    mage3.Attack(dragon3);
    mage3.Heal(dragon3);
}