namespace CharacterEditorCore.Items
{
    public class Breastplate : Item
    {
        public Breastplate(string name, int strengthChange, int dexterityChange,
            int constitutionChange, int intellisenceChange)
            : base(strengthChange, dexterityChange,
                  constitutionChange, intellisenceChange)
        {
            Name = name;
        }
    }
}