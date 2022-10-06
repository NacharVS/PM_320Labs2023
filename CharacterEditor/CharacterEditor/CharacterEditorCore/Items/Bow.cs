namespace CharacterEditorCore
{
    public class Bow : IItem
    {
        public string Name { get; set; }

        public Bow()
        {
            Name = GetType().Name;
        }
    }
}
