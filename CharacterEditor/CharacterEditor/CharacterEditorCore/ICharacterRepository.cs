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
    }
}