namespace CharacterEditorCore
{
    public class Helmet : IItem
    {
        public string Name { get; set; }

        public Helmet(string name) 
        {
            Name = name;
        }
    }
}