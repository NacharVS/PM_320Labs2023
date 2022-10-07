namespace CharacterEditorCore.Items
{
    public abstract class Weapon : Item
    {
        public int Damage { get; private set; }

        protected Weapon(int strengthChange, int dexterityChange,
            int constitutionChange, int intellisenceChange, int damage)
            : base(strengthChange, dexterityChange,
                  constitutionChange, intellisenceChange)
        {
            Damage = damage;
        }    
    }
}