using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore
{
    [Serializable]
    public class Rogue : Character
    {
        public Rogue()
        {
            Strength = (int)Enums.RogueStats.minStrength;
            Dexterity = (int)Enums.RogueStats.minDexterity;
            Constitution = (int)Enums.RogueStats.minConstitution;
            Intelligence = (int)Enums.RogueStats.minIntelligence;
        }
        public override int Strength 
        { 
            get { return strength; } 
            set
            {
                if(value >= (int)Enums.RogueStats.minStrength &&
                    value <= (int)Enums.RogueStats.maxStrength)
                {
                    attack += (value - strength) * 2;
                    healthPoints += (value - strength);

                    strength = value;
                }
            }
        }

        public override int Dexterity
        {
            get { return dexterity; }
            set
            {
                if (value >=(int)Enums.RogueStats.minDexterity &&
                    value <= (int)Enums.RogueStats.maxDexterity)
                {
                    attack += (value - dexterity) * 4;
                    physicalDefense += (value - dexterity) * 1.5;

                    dexterity = value;
                }
            }
        }

        public override int Constitution
        {
            get { return constitution; }
            set
            {
                if (value >= (int)Enums.RogueStats.minConstitution &&
                    value <= (int)Enums.RogueStats.maxConstitution)
                {
                    healthPoints += (value - constitution) * 6;

                    constitution = value;
                }
            }
        }

        public override int Intelligence
        {
            get { return intelligence; }
            set
            {
                if (value >= (int)Enums.RogueStats.minIntelligence &&
                    value <= (int)Enums.RogueStats.maxIntelligence)
                {
                    manaPoints += (value - intelligence) * 1.5;
                    magicAttack += (value - intelligence) * 2;

                    intelligence = value;
                }
            }
        }
    }
}
