using RTS.ConsoleGame;
using RTS.Core.BaseEntities;
using RTS.Core.Buffs;
using RTS.Core.Units;

var units = new List<Military>
{
    new Footman(300, 250, "Juggernaute", 2, 4, 70, 1200, 5),
    new Footman(500, 250, "Pudge", 5, 6, 250, 2500, 5),
    new Mage(150, 300, "Ogre magi", 3, 7, 140, 1000, 1, 100, 200),
    new Dragon(1000, 2000, "Dragon knight", 15, 300, 400, 4000, 50, 300, 600),
    new Mage(10, 100, "UltraKiller", 1, 10, 10000, 400, 5, 600, 600),
};

var blacksmith = new Blacksmith(units);

foreach (var unit in units)
{
    ThreadPool.QueueUserWorkItem(new UnitWrapper(unit, units).Run);
}

Random rnd = new Random();

while (units.FindAll(x => !x.IsDestroyed).Count > 1)
{
    var r = rnd.Next(0, 10);
    if (r == 2)
    {
        blacksmith.UpgradeArmory(5);
    }
    else if (r == 6)
    {
        blacksmith.UpgradeArrow(10);
    }
    else if (r == 4)
    {
        blacksmith.UpgradeWeapon(7);
    }
    
    Thread.Sleep(500);
}

Console.WriteLine($"{units.FirstOrDefault(x => !x.IsDestroyed)?.Name} is last standing warrior");