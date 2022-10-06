namespace CharacterEditorCore
{
    public class Knife : IItem
    {
        public string Name { get; set; }

        public Knife()
        {
            Name = GetType().Name;
        }
    }
}