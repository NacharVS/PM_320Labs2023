using System.Text.RegularExpressions;
using CharacterCreator.Core;
using CharacterCreator.Data.Interfaces;
using CharacterCreator.Data.Models;
using MongoDB.Driver;

namespace CharacterCreator.Data.Repositories;

public class CharacterRepository : IRepository<Character>
{
    private DbConnection<CharacterDbModel> _dbConnection;

    public CharacterRepository(DbConnection<CharacterDbModel> connection)
    {
        _dbConnection = connection;
    }

    public Character GetEntityById(string id)
    {
        try
        {
            var result = _dbConnection.Collection.Find(x => x.Id == id).FirstOrDefault();
            return CreateCharacterFromModel(result);
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public IEnumerable<Character> GetAllEntities()
    {
        try
        {
            var result = _dbConnection.Collection.Find(x => x.ClassName != null);
            var charactersList = new List<Character>();
            foreach (var characterDbModel in result.ToList())
            {
                charactersList.Add(CreateCharacterFromModel(characterDbModel));
            }

            return charactersList;
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public IEnumerable<Character> GetAllByClassName(string className)
    {
        try
        {
            var result = _dbConnection.Collection.Find(x => x.ClassName == className);
            result.ToList();
            var charactersList = new List<Character>();
            foreach (var characterDbModel in result.ToList())
            {
                charactersList.Add(CreateCharacterFromModel(characterDbModel));
            }

            return charactersList;
        }
        catch
        {
            throw;
        }
    }

    public void Save(Character character)
    {
        _dbConnection.Collection.InsertOne(new CharacterDbModel(character));
    }

    public void UpdateCharacter(Character character, string id)
    {
        _dbConnection.Collection.ReplaceOne(x => x.Id == id,
            new CharacterDbModel(id, character));
    }

    public void Update(Character character, string id)
    {
        if (character.Id is null)
        {
            Save(character);
        }
        else
        {
            UpdateCharacter(character, character.Id);
        }
    }


    public void Delete(string id)
    {
        _dbConnection.Collection.DeleteOne(x => x.Id == id);
    }


    private Character CreateCharacterFromModel(CharacterDbModel model)
    {
        Character? character = null;
        switch (model.ClassName)
        {
            case "Warrior":
                character = new Warrior(model.Experience);
                break;
            case "Wizard":
                character = new Wizard(model.Experience);
                break;
            case "Rogue":
                character = new Rogue(model.Experience);
                break;
        }

        character.Name = model.Name;
        character.Id = model.Id;
        character.Constitution = model.Constitution;
        character.Dexterity = model.Dexterity;
        character.Intelligence = model.Intelligence;
        character.Strength = model.Strength;
        character.SkillPoints = model.SkillPoints;
        
        foreach (Equipment item in model.Inventory)
        {
            character.AddItemToInventory(item);
        }

        foreach (Ability a in model.Abilities)
        {
            character.AddAbility(a);
        }

        return character;
    }
}