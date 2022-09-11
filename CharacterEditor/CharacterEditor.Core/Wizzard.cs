namespace CharacterEditor.Core
{
    public class Wizzard : Character
    {
        public Wizzard()
        {
            minStrength = 10;
            maxStrength = 45;
            minDexterity = 20;
            maxDexterity = 70;
            minConstitution = 15;
            maxConstitution = 60;
            minIntelligence = 35;
            maxIntelligence = 250;

            StrengthChangedEvent += delegate
            {
                healthPoint = Strength + Constitution * 3;
                physicalDamage = Strength * 3;
            };

            DexterityChangedEvent += delegate
            {
                physicalDefense = Dexterity * 0.5 + Constitution;
            };

            ConstitutionChangedEvent += delegate
            {
                healthPoint = Strength + Constitution * 3;
                physicalDefense = Dexterity * 0.5 + Constitution;
            };

            IntelligenceChangedEvent += delegate
            {
                mageDamage = Intelligence * 5;
                manaPoint = Intelligence * 2;
            };

            Strength = minStrength;
            Dexterity = minDexterity;
            Constitution = minConstitution;
            Intelligence = minIntelligence;
        }
    }
}