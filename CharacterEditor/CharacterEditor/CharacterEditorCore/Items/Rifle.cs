namespace CharacterEditorCore.Items
{
    public class Rifle : Weapon
    {
        public Rifle(string name, int strengthChange, int dexterityChange,
            int constitutionChange, int intellisenceChange, int damage)
            : base(strengthChange, dexterityChange, 
                  constitutionChange, intellisenceChange, damage)
        {
            Name = name;
        }
    }
}