using CharacterEditor.Core;
using CharacterEditor.Core.Classes;
using CharacterEditor.Core.Db;
using CharacterEditor.Core.Exceptions;
using MongoDB.Driver;

namespace CharacterEditor.MongoDB;

public class CharacterRepository : ICharacterRepository
{
    private IMongoCollection<CharacterDb> Characters { get; }

    public CharacterRepository(MongoConnection connection)
    {
        Characters =
            connection.Database?.GetCollection<CharacterDb>("Characters")!;
    }

    public IEnumerable<CharacterTuple> GetAllCharacterNamesByClass(
        string characterClass)
    {
        return Characters
            .Find(x =>
                x.ClassName != null && x.ClassName.Equals(characterClass))
            .ToEnumerable()
            .Select(x => new CharacterTuple { Id = x.Id, Name = x.Name });
    }

    public CharacterBase GetCharacter(string id)
    {
        var dbChar = Characters.Find(x => x.Id == id).FirstOrDefault() ??
                     throw new NotFoundException();
        CharacterBase character;
        switch (dbChar.ClassName)
        {
            case "Warrior":
                character = new Warrior(dbChar.Experience);
                break;
            case "Wizard":
                character = new Wizard(dbChar.Experience);
                break;
            case "Rogue":
                character = new Rogue(dbChar.Experience);
                break;
            default:
                throw new NotFoundException();
        }

        character.Id = dbChar.Id;
        character.Name = dbChar.Name;
        character.Strength = dbChar.Strength;
        character.Dexterity = dbChar.Dexterity;
        character.Constitution = dbChar.Constitution;
        character.Intelligence = dbChar.Intelligence;
        character.Inventory = dbChar.Inventory is not null
            ? dbChar.Inventory.ToArray()
            : Array.Empty<Item>();

        return character;
    }

    public void InsertCharacter(CharacterBase character)
    {
        Characters.InsertOne(new CharacterDb
        {
            Experience = character.Level.TotalExperience,
            Name = character.Name, Strength = character.Strength,
            Dexterity = character.Dexterity,
            Constitution = character.Constitution,
            Intelligence = character.Intelligence,
            ClassName = character.GetType().Name,
            Inventory = character.Inventory.Length == 0
                ? null
                : character.Inventory
        });
    }

    public void UpdateCharacter(string id, CharacterBase character)
    {
        Characters.ReplaceOne(x => x.Id == id, new CharacterDb
        {
            Experience = character.Level.TotalExperience,
            Id = id, Name = character.Name, Strength = character.Strength,
            Dexterity = character.Dexterity,
            Constitution = character.Constitution,
            Intelligence = character.Intelligence,
            ClassName = character.GetType().Name,
            Inventory = character.Inventory.Length == 0
                ? null
                : character.Inventory
        });
    }
}