namespace CharacterEditorCore.Items
{
    public class Knife : Weapon
    {
        public Knife(string name, int strengthChange, int dexterityChange, 
            int constitutionChange, int intellisenceChange, int damage)
            : base(strengthChange, dexterityChange, 
                  constitutionChange, intellisenceChange, damage)
        {
            Name = name;
        }
    }
}