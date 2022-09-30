using System.Text.RegularExpressions;
using CharacterCreator.Core;
using CharacterCreator.Data.Interfaces;
using CharacterCreator.Data.Models;
using MongoDB.Driver;

namespace CharacterCreator.Data.Repositories;

public class CharacterRepository : ICharacterRepository
{
    private DbConnection<CharacterDbModel> _dbConnection;

    public CharacterRepository(DbConnection<CharacterDbModel> connection)
    {
        _dbConnection = connection;
    }
    public Character GetCharacterById(string id)
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

    public IEnumerable<Character> GetAllCharacters()
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

    public void InsertCharacter(Character character)
    {
        _dbConnection.Collection.InsertOne(new CharacterDbModel(character));
    }

    public void UpdateCharacter(Character character, string id)
    {
        _dbConnection.Collection.ReplaceOne(x => x.Id == id, 
            new CharacterDbModel(id, character));
    }

    public void InsertOrUpdate(Character character)
    {
        if (character.Id is null)
        {
            InsertCharacter(character);
        }
        else
        {
            UpdateCharacter(character, character.Id);
        }
    }
    

    public void DeleteCharacter(string id)
    {
        _dbConnection.Collection.DeleteOne(x => x.Id == id);
    }


    private Character CreateCharacterFromModel(CharacterDbModel model)
    {
        Character? character = new();
        switch (model.ClassName)
        {
            case "Warrior":
                character = new Warrior();
                break;
            case "Wizard":
                character = new Wizard();
                break;
            case "Rogue":
                character = new Rogue();
                break;
            default:
                break;
        }

        character.Name = model.Name;
        character.Id = model.Id;
        character.Constitution = model.Constitution;
        character.Dexterity = model.Dexterity;
        character.Intelligence = model.Intelligence;
        character.Strength = model.Strength;
        character.SkillPoints = model.SkillPoints;
        character.Inventory = model.Inventory.ToArray();

        return character;
    }
}