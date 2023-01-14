using Warcraft.Console;
using Warcraft.Core;
using Warcraft.Core.BaseClasses;

var logger = new ConsoleLogger();

var footman = new Footman(logger, (int)Health.Standard, (int)Cost.Expensive,
    "Footman",
    (int)Level.Hero, (int)MoveSpeed.Slow, (int)AttackSpeed.Slow,
    (int)Damage.Standard);
var footman1 = new Footman(logger, (int)Health.Standard, (int)Cost.Expensive,
    "Footman1",
    (int)Level.Hero, (int)MoveSpeed.Slow, (int)AttackSpeed.Slow,
    (int)Damage.Standard);
var mage = new Mage(logger, (int)Health.Puny, (int)Cost.Expensive, "Mage",
    (int)Level.Hero, (int)MoveSpeed.Fast, (int)AttackSpeed.Standard,
    (int)Damage.Weakling, (int)AttackRange.Standard, (int)ManaCount.Wizard);
var mage1 = new Mage(logger, (int)Health.Puny, (int)Cost.Expensive, "Mage1",
    (int)Level.Hero, (int)MoveSpeed.Fast, (int)AttackSpeed.Standard,
    (int)Damage.Weakling, (int)AttackRange.Standard, (int)ManaCount.Wizard);
var archer = new Archer(logger, (int)Health.Puny, (int)Cost.Expensive, "Archer",
    (int)Level.Hero, (int)MoveSpeed.Fast, (int)AttackSpeed.Standard,
    (int)Damage.Weakling, (int)AttackRange.Standard, (int)ManaCount.Wizard, 5);
var archer1 = new Archer(logger, (int)Health.Puny, (int)Cost.Expensive,
    "Archer1",
    (int)Level.Hero, (int)MoveSpeed.Fast, (int)AttackSpeed.Standard,
    (int)Damage.Weakling, (int)AttackRange.Standard, (int)ManaCount.Wizard, 10);
var dragon = new Dragon(logger, (int)Health.Standard, (int)Cost.Expensive,
    "Dragon",
    (int)Level.Hero, (int)MoveSpeed.Slow, (int)AttackSpeed.Slow,
    (int)Damage.Powerful, (int)AttackRange.Close, (int)ManaCount.Standard);
var peasant = new Peasant(logger, (int)Health.Puny, (int)Cost.Cheap, "Peasant",
    (int)Level.Creep, (int)MoveSpeed.Slow);
var guardTower = new GuardTower(logger, (int)Health.Tank, (int)Cost.Standard,
    "Tower",
    (int)Level.Creep, (int)AttackRange.Standard, (int)AttackSpeed.Slow,
    (int)Damage.Standard);
var blacksmith = new Blacksmith(logger, (int)Health.Tank, (int)Cost.Standard,
    "Blacksmith",
    (int)Level.Creep,
    new List<Military>
        { footman, dragon, footman1, mage, mage1, archer1, archer });

var random = new Random();
var heroes = new List<Unit>
    // { mage1, mage, dragon, footman, footman1, peasant, guardTower, archer, archer1 };
{ mage, mage1 };

var tasks = new List<Task>();
foreach (var hero in heroes)
{
    var task = new Task(() =>
    {
        while (!hero.IsDestroyed)
        {
            if (heroes.Count(x => !x.IsDestroyed) == 1)
            {
                return;
            }

            Unit target;
            while ((target = heroes[random.Next(0, heroes.Count)]) != hero)
            {
                if (target.IsDestroyed || hero.IsDestroyed) continue;
                
                logger.LogInfo(hero, "------------Делает свой ход------------");
                switch (hero)
                {
                    case Military military:
                        military.RandomAttack(target);
                        break;
                    case GuardTower tower:
                        tower.Attack(target);
                        break;
                    case Peasant villager:
                        villager.RandomAction();
                        break;
                    case Blacksmith smith:
                        smith.RandomBuff();
                        break;
                }
                
                logger.LogInfo(hero, "------------Закончил свой ход------------");
                Thread.Sleep(hero is Military mil ? mil.AttackSpeed : 500);
            }
        }
    });
    tasks.Add(task);
    task.Start();
}

Task.WaitAll(tasks.ToArray());

var winner = heroes.FirstOrDefault(x => !x.IsDestroyed);
if (winner is not null)
{
    logger.LogInfo(winner, "ПОБЕДИТЕЛЬ!");
}
else
{
    logger.LogInfo(null, "Никто не победил");
}