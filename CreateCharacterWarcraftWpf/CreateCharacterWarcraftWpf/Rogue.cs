namespace CreateCharacterWarcraftWpf
{
    internal class Rogue : Character
    {
        public Rogue(string name, int healthPoint, int manaPoint, int attack, double protDet, int skillPoint, int strength, 
            int strengthMax, int dexterity, int dexterityMax, int constitution, int constitutionMax, int intelligence, int intelligenceMax) 
            : base(name, healthPoint, manaPoint, attack, protDet, skillPoint, strength, strengthMax, dexterity, dexterityMax, 
                  constitution, constitutionMax, intelligence, intelligenceMax)
        {
        }
    }
}