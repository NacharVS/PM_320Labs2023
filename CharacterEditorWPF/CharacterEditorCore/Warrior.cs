using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore
{
    [Serializable]
    public class Warrior : Character
    {
        public Warrior()
        {
            Strength = (int)Enums.WarriorStats.minStrength;
            Dexterity = (int)Enums.WarriorStats.minDexterity;
            Constitution = (int)Enums.WarriorStats.minConstitution;
            Intelligence = (int)Enums.WarriorStats.minIntelligence;
        }

        public override int Strength
        {
            get { return strength; }
            set
            {
                if (value >= (int)Enums.WarriorStats.minStrength &&
                    value <= (int)Enums.WarriorStats.maxStrength)
                {
                    attack += (value - strength) * 5;
                    healthPoints += (value - strength) * 2;

                    strength = value;
                }
            }
        }

        public override int Dexterity
        {
            get { return dexterity; }
            set
            {
                if (value >= (int)Enums.WarriorStats.minDexterity &&
                    value <= (int)Enums.WarriorStats.maxDexterity)
                {
                    attack += (value - dexterity);
                    physicalDefense += (value - dexterity);

                    dexterity = value;
                }
            }
        }

        public override int Constitution
        {
            get { return constitution; }
            set
            {
                if (value >= (int)Enums.WarriorStats.minConstitution &&
                    value <= (int)Enums.WarriorStats.maxConstitution)
                {
                    healthPoints += (value - constitution) * 10;
                    physicalDefense += (value - constitution) * 2;

                    constitution = value;
                }
            }
        }

        public override int Intelligence
        {
            get { return intelligence; }
            set
            {
                if (value >= (int)Enums.WarriorStats.minIntelligence &&
                    value <= (int)Enums.WarriorStats.maxIntelligence)
                {
                    manaPoints += (value - intelligence);
                    magicAttack += (value - intelligence);

                    intelligence = value;
                }
            }
        }
    }
}
