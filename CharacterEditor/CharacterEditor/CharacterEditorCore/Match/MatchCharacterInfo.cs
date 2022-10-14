namespace CharacterEditorCore.Match
{
    public class MatchCharacterInfo
    {
        public string Id { get; set; } 
        public string Name { get; set; }
        public int Level { get; set; }

        public override string? ToString()
        {
            return $"{Name} - {Level} level";
        }
    }
}