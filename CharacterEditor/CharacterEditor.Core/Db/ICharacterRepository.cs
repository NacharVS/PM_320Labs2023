using CharacterEditor.Core.Misc;

namespace CharacterEditor.Core.Db;

public interface ICharacterRepository
{
    public IEnumerable<CharacterTuple> GetAllCharacterNamesByClass(
        string characterClass);

    public CharacterBase GetCharacter(string id);
    public void InsertCharacter(CharacterBase character);
    public void UpdateCharacter(string id, CharacterBase character);

    public void UpdateInventory(string id, IEnumerable<Item> inventory);
}