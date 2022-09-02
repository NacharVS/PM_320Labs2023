using Warcraft.Console;
using Warcraft.Core;

var logger = new ConsoleLogger();

var footman = new Footman(logger, (int)Health.Tank, (int)Cost.Expensive,
    "Footman",
    (int)Level.Hero, (int)MoveSpeed.Slow, (int)AttackSpeed.Slow,
    (int)Damage.Powerful);
var footman1 = new Footman(logger, (int)Health.Tank, (int)Cost.Expensive,
    "Footman1",
    (int)Level.Hero, (int)MoveSpeed.Slow, (int)AttackSpeed.Slow,
    (int)Damage.Powerful);
var mage = new Mage(logger, (int)Health.Puny, (int)Cost.Expensive, "Mage",
    (int)Level.Hero, (int)MoveSpeed.Fast, (int)AttackSpeed.Standard,
    (int)Damage.Weakling, (int)AttackRange.Standard, (int)ManaCount.Wizard);
var mage1 = new Mage(logger, (int)Health.Puny, (int)Cost.Expensive, "Mage1",
    (int)Level.Hero, (int)MoveSpeed.Fast, (int)AttackSpeed.Standard,
    (int)Damage.Weakling, (int)AttackRange.Standard, (int)ManaCount.Wizard);
var dragon = new Dragon(logger, (int)Health.Standard, (int)Cost.Expensive,
    "Dragon",
    (int)Level.Hero, (int)MoveSpeed.Slow, (int)AttackSpeed.Slow,
    (int)Damage.Powerful, (int)AttackRange.Close, (int)ManaCount.Standard);
var peasant = new Peasant(logger, (int)Health.Tank, (int)Cost.Cheap, "Peasant",
    (int)Level.Creep, (int)MoveSpeed.Slow);
var tower = new GuardTower(logger, (int)Health.Tank, (int)Cost.Standard,
    "Tower",
    (int)Level.Creep, (int)AttackRange.Standard, (int)AttackSpeed.Slow,
    (int)Damage.Standard);

var random = new Random();
var heroes = new List<Military> { mage1, mage, dragon, footman, footman1 };
while (heroes.Count != 1)
{
    var hero = heroes[random.Next(heroes.Count)];
    var target = heroes[random.Next(heroes.Count)];

    var action = random.Next(2);
    switch (action)
    {
        // spell
        case 0:
            var spell = hero.SpellNames[random.Next(hero.SpellNames.Length)];
            hero.CastSpell(spell, target);
            break;
        // default attack
        case 1:
            hero.Attack(target);
            break;
    }

    if (target.IsDestroyed)
        heroes.Remove(target);
}

logger.LogInfo(heroes[0], "ПОБЕДИТЕЛЬ!!!");