using CharacterCreator.Core;

namespace CharacterCreator.Data.Interfaces;

public interface ICharacterRepository
{
    public Character GetCharacterById(string id);
    public IEnumerable<Character> GetAllCharacters();
    public IEnumerable<Character> GetAllByClassName(string className);
    public void InsertCharacter(Character character);
    public void UpdateCharacter(Character character, string id);
    public void InsertOrUpdate(Character character);
    public void DeleteCharacter(string id);
}