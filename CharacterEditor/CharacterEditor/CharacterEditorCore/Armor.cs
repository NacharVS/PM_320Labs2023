namespace CharacterEditorCore
{
    public class Armor : IItem
    {
        public string Name { get; set; }

        public Armor ()
        {
            Name = GetType().Name;
        }
    }
}