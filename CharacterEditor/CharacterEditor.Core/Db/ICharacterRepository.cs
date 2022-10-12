using CharacterEditor.Core.Misc;

namespace CharacterEditor.Core.Db;

public interface ICharacterRepository
{
    public IEnumerable<CharacterInfo> GetAllCharacterNamesByClass(
        string characterClass);

    public IEnumerable<CharacterInfo> GetAllCharacters();

    public Character GetCharacter(string id);
    public void InsertCharacter(Character character);
    public void UpdateCharacter(string id, Character character);

    public void UpdateInventory(string id, IEnumerable<Item> inventory);
    public IEnumerable<CharacterInfo> GetMatchParticipants(int minLevel = 0, int maxLevel = 1000);
}