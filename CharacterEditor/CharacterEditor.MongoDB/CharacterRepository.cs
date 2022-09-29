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
        switch (dbChar.ClassName)
        {
            case "Warrior":
                return new Warrior(dbChar.Experience)
                {
                    Name = dbChar.Name, Constitution = dbChar.Constitution,
                    Dexterity = dbChar.Dexterity,
                    Intelligence = dbChar.Intelligence, Id = dbChar.Id,
                    Strength = dbChar.Strength,
                    Inventory = dbChar.Inventory is not null
                        ? dbChar.Inventory.ToArray()
                        : Array.Empty<Item>()
                };
            case "Wizard":
                return new Wizard(dbChar.Experience)
                {
                    Name = dbChar.Name, Constitution = dbChar.Constitution,
                    Dexterity = dbChar.Dexterity,
                    Intelligence = dbChar.Intelligence, Id = dbChar.Id,
                    Strength = dbChar.Strength,
                    Inventory = dbChar.Inventory is not null
                        ? dbChar.Inventory.ToArray()
                        : Array.Empty<Item>()
                };
            case "Rogue":
                return new Rogue(dbChar.Experience)
                {
                    Name = dbChar.Name, Constitution = dbChar.Constitution,
                    Dexterity = dbChar.Dexterity,
                    Intelligence = dbChar.Intelligence, Id = dbChar.Id,
                    Strength = dbChar.Strength,
                    Inventory = dbChar.Inventory is not null
                        ? dbChar.Inventory.ToArray()
                        : Array.Empty<Item>()
                };
            default:
                throw new NotFoundException();
        }
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
            Inventory = character.Inventory.Length == 0 ? null : character.Inventory
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
            Inventory = character.Inventory.Length == 0 ? null : character.Inventory
        });
    }
}