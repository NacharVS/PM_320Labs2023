namespace CharacterEditor.Core
{
    public class Warrior : Character
    {
        public Warrior()
        {
            minStrength = 30;
            maxStrength = 250;
            minDexterity = 15;
            maxDexterity = 70;
            minConstitution = 20;
            maxConstitution = 100;
            minIntelligence = 10;
            maxIntelligence = 50;

            StrengthChangedEvent += delegate
            {
                healthPoint = Strength * 2 + Constitution * 10;
                physicalDamage = Strength * 5 + Dexterity;
            };

            DexterityChangedEvent += delegate
            {
                physicalDefense = Dexterity + Constitution * 2;
                physicalDamage = Strength * 5 + Dexterity;
            };

            ConstitutionChangedEvent += delegate
            {
                healthPoint = Strength * 2 + Constitution * 10;
                physicalDefense = Dexterity + Constitution * 2;
            };

            IntelligenceChangedEvent += delegate
            {
                mageDamage = Intelligence;
                manaPoint = Intelligence;
            };

            Strength = minStrength;
            Dexterity = minDexterity;
            Constitution = minConstitution;
            Intelligence = minIntelligence;
        }
    }
}