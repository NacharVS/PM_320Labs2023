namespace CharacterEditor.Core;

public interface ICharacterRepository
{
    public IEnumerable<CharacterPair> GetAllCharacterNamesByClass(
        string characterClass);

    public CharacterBase GetCharacter(string id);
    public void InsertCharacter(CharacterBase character);
    public void UpdateCharacter(string id, CharacterBase character);
}