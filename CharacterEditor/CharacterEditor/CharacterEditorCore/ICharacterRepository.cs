namespace CharacterEditorCore
{
    public interface ICharacterRepository
    {
        public List<string> GetCharacterNames();

        public List<Match.MatchCharacterInfo> GetAllCharacters();

        public void InsertCharacter(Character character);

        public bool IsCharacterExist(string name);

        public Character GetCharacterByName(string name);

        public bool ReplaceByName(string name, Character character);

        public Character GetCharacterById(string id);

        public void UpdateInventory(string name, Character character);
        public void UpdateEquipment(string name, Character character);
    }
}