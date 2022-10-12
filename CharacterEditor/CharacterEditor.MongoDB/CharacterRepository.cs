using CharacterEditor.Core;
using CharacterEditor.Core.Characteristics;
using CharacterEditor.Core.Classes;
using CharacterEditor.Core.Db;
using CharacterEditor.Core.Exceptions;
using CharacterEditor.Core.Misc;
using MongoDB.Driver;

namespace CharacterEditor.MongoDB;

public class CharacterRepository : RepositoryBase, ICharacterRepository
{
    private IMongoCollection<CharacterDb> Characters { get; }

    public CharacterRepository(MongoConnection connection)
    {
        Characters =
            connection.Database?.GetCollection<CharacterDb>("Characters")!;
    }

    public IEnumerable<CharacterInfo> GetAllCharacterNamesByClass(
        string characterClass)
    {
        return Characters
            .Find(x =>
                x.ClassName != null && x.ClassName.Equals(characterClass))
            .ToEnumerable()
            .Select(x => new CharacterInfo(x.Experience)
            {
                Id = x.Id, Name = x.Name ?? String.Empty,
                ClassName = x.ClassName ?? string.Empty
            });
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
            ? dbChar.Inventory
                .Select(x => ConvertItem(x))
                .ToArray()
            : Array.Empty<Item>();
        character.Abilities = dbChar.Abilities is not null
            ? dbChar.Abilities.Select(x => new Ability
            {
                Name = x.Name, AttackChange = x.AttackChange,
                HealthChange = x.HealthChange, ManaChange = x.ManaChange,
                MagicalAttackChange = x.MagicalAttackChange,
                PhysicalResistanceChange = x.PhysicalResistanceChange
            }).ToArray()
            : Array.Empty<Ability>();

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
                : character.Inventory.Select(x => ConvertItem(x)),
            Abilities = character.Abilities.Length == 0
                ? null
                : character.Abilities.Select(x => new AbilityDb
                {
                    Name = x.Name, AttackChange = x.AttackChange,
                    HealthChange = x.HealthChange, ManaChange = x.ManaChange,
                    MagicalAttackChange = x.MagicalAttackChange,
                    PhysicalResistanceChange = x.PhysicalResistanceChange
                })
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
                : character.Inventory.Select(x => ConvertItem(x)),
            Abilities = character.Abilities.Length == 0
                ? null
                : character.Abilities.Select(x => new AbilityDb
                {
                    Name = x.Name, AttackChange = x.AttackChange,
                    HealthChange = x.HealthChange, ManaChange = x.ManaChange,
                    MagicalAttackChange = x.MagicalAttackChange,
                    PhysicalResistanceChange = x.PhysicalResistanceChange
                })
        });
    }

    public void UpdateInventory(string id, IEnumerable<Item> inventory)
    {
        var filter = Builders<CharacterDb>.Filter.Eq(x => x.Id, id);
        var updateDefinition =
            Builders<CharacterDb>.Update.Set(x => x.Inventory, inventory.Select(
                x => ConvertItem(x)));
        Characters.UpdateOne(filter, updateDefinition);
    }

    public IEnumerable<CharacterInfo> GetMatchParticipants(int minLevel = 0,
        int maxLevel = 1000)
    {
        var filter = Builders<CharacterDb>.Filter.Gte(x => x.Experience,
                         LevelInfo.GetLevelXp(minLevel)) &
                     Builders<CharacterDb>.Filter.Lte(x => x.Experience,
                         LevelInfo.GetLevelXp(maxLevel));

        return Characters.Find(filter)
            .SortBy(x => x.Experience)
            .ToList()
            .Select(x => new CharacterInfo(x.Experience)
            {
                Id = x.Id, Name = String.Empty,
                ClassName = x.ClassName ?? string.Empty
            });
    }
}