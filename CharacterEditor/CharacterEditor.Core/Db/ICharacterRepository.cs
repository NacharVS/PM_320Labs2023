using CharacterEditor.Core.Misc;

namespace CharacterEditor.Core.Db;

public interface ICharacterRepository
{
    public IEnumerable<ShortCharacter> GetAllCharacterNamesByClass(
        string characterClass);

    public CharacterBase GetCharacter(string id);
    public void InsertCharacter(CharacterBase character);
    public void UpdateCharacter(string id, CharacterBase character);

    public void UpdateInventory(string id, IEnumerable<Item> inventory);
    public IEnumerable<ShortCharacter> GetMatchParticipants(int minLevel = 0, int maxLevel = 1000);
}