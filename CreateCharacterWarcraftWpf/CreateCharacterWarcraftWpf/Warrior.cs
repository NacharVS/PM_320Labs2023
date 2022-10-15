using System.Collections.Generic;

namespace CreateCharacterWarcraftWpf
{
    internal class Warrior : Character
    {
        public Warrior(string name, int healthPoint, int manaPoint, int attack, double protDet, int skillPoint, int strength,
            int strengthMax, int dexterity, int dexterityMax, int constitution, int constitutionMax,
            int intelligence, int intelligenceMax, int experience, int level, List<string> activeAbility, List<string> inventory)
            : base(name, healthPoint, manaPoint, attack, protDet, skillPoint, strength, strengthMax,
                  dexterity, dexterityMax, constitution, constitutionMax,
                  intelligence, intelligenceMax, experience, level, activeAbility, inventory)
        {
        }
    }
}