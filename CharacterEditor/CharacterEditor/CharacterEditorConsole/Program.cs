using CharacterEditorCore;

var war = new Warrior();
var rog = new Rogue();

Console.WriteLine($"War: Attack {war.AttackDamage}" +
    $" Health {war.Health} Mana {war.Mana} " +
    $"Mag attack {war.MagicalAttackDamage}" +
    $"Physical def {war.PhysicalDefence}");