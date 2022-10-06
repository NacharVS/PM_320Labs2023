namespace CharacterEditorCore
{
    public class Rifle : IItem
    {
        public string Name { get; set; }

        public Rifle() 
        {
            Name = GetType().Name;
        }
    }
}