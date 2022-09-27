namespace CharacterEditorCore
{
    public class Rifle : IItem
    {
        public string Name { get; set; }

        public Rifle(string name) 
        {
            Name = name;
        }
    }
}