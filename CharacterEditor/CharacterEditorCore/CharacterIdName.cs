
namespace CharacterEditorCore
{
    public class CharacterIdName
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public int Level { get; set; }
        public string? ClassName { get; set; }

        public CharacterIdName(int exp)
        {
            Level = new Level(exp).CurrentLevel;
        }
    }
}
