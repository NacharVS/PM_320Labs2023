using Labs320;
using Warcraft.Core.BaseEntities;
using Warcraft.Core.Units;

var warriors = new List<Military>
{
    new Footman(100, 250, "Garen", 2, 4, 70, 1200, 5),
    new Footman(500, 250, "Alistar", 5, 6, 250, 2500, 5),
    new Mage(150, 300, "Ezreal", 3, 7, 140, 1000, 1, 100, 200),
    new Dragon(1000, 2000, "Shivana", 15, 300, 400, 4000, 50, 300, 600),
};

foreach (var unit in warriors)
{
    ThreadPool.QueueUserWorkItem(new UnitWrapper(unit, warriors).Run);
}

while (warriors.FindAll(unit => !unit.IsDestroyed).Count > 1)
{
    Thread.Sleep(500);
}

Console.WriteLine($"{warriors.FirstOrDefault(military => !military.IsDestroyed)?.Name} is last standing warrior");
