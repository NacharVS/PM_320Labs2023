namespace CharacterEditorCore
{
    public class Armor : IItem
    {
        public string Name { get; set; }

        public Armor (string name)
        {
            Name = name;
        }
    }
}