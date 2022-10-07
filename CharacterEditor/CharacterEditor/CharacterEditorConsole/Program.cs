using CharacterEditorCore;
using CharacterEditorMongoDb;

var war = new Warrior();
var rog = new Rogue();

Console.WriteLine($"War: Attack {war.AttackDamage}" +
    $" Health {war.Health} Mana {war.Mana} " +
    $"Mag attack {war.MagicalAttackDamage}");


var repos = new CharacterRepository("mongodb://localhost", "CharacterEditor");
var rifle = new Rifle("Ak");
var armor = new Armor("Armor");

rog.Inventory = new Inventory(new List<Item> { rifle, armor });

repos.InsertCharacter(rog);

var charac = repos.GetCharacterByName(rog.Name);

foreach (Item item in charac.Inventory.Items)
{
    Console.WriteLine($"{item.Name} {item.GetType().Name}");
}

