namespace CharacterEditorCore.Items
{
    public class Bow : Weapon
    {
        public Bow(string name, int strengthChange, int dexterityChange, 
            int constitutionChange, int intellisenceChange, int damage) 
            : base(strengthChange, dexterityChange, 
                  constitutionChange, intellisenceChange, damage)
        {
            Name = name;
        }
    }
}