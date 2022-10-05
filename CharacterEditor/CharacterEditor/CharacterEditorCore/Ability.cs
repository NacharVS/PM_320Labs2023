namespace CharacterEditorCore
{
    public class Ability
    {
        public string Name { get; set; }
        public int StrengthChangeValue { get; set; }
        public int DexterityChangeValue { get; set; }
        public int ConstitutionChangeValue { get; set; }
        public int IntellisenseChangeValue { get; set; }

        public Ability(string name, 
            int strengthChangeValue,
            int dexterityChangeValue, 
            int constitutionChangeValue,
            int intellisenseChangeValue)
        {
            Name = name;
            StrengthChangeValue = strengthChangeValue;
            DexterityChangeValue = dexterityChangeValue;
            ConstitutionChangeValue = constitutionChangeValue;
            IntellisenseChangeValue = intellisenseChangeValue;
        }
    }
}