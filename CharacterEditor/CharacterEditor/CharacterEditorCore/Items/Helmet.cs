namespace CharacterEditorCore
{
    public class Helmet : Item
    {
        public Helmet(string name, int strengthChange, int dexterityChange, 
            int constitutionChange, int intellisenceChange) 
            : base(strengthChange, dexterityChange, 
                  constitutionChange, intellisenceChange)
        {
            Name = name;
        }
    }
}