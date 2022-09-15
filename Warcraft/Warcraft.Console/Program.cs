using Warcraft.Console;
using Warcraft.Core;
using Warcraft.Core.BaseClasses;

var logger = new FileLogger();

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
var peasant = new Peasant(logger, (int)Health.Tank, (int)Cost.Cheap, "Peasant",
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
    { mage1, mage, dragon, footman, footman1, peasant, guardTower, blacksmith, archer, archer1 };
    // { mage, mage1 };
while (heroes.Count != 1)
{
    var unit = heroes[random.Next(heroes.Count)];
    var target = heroes[random.Next(heroes.Count)];

    switch (unit)
    {
        case Military hero:
            hero.RandomAttack(target);
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

    if (target.IsDestroyed)
        heroes.Remove(target);
}

logger.LogInfo(heroes[0], "ПОБЕДИТЕЛЬ!!!");