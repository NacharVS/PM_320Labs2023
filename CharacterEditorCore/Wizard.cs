using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore
{
    [Serializable]
    public class Wizard : Character
    {
        public Wizard()
        {
            Strength = (int)Enums.WizardsStats.minStrength;
            Dexterity = (int)Enums.WizardsStats.minDexterity;
            Constitution = (int)Enums.WizardsStats.minConstitution;
            Intelligence = (int)Enums.WizardsStats.minIntelligence;
        }

        public override int Strength
        {
            get { return strength; }
            set
            {
                if (value >= (int)Enums.WizardsStats.minStrength &&
                    value <= (int)Enums.WizardsStats.maxStrength)
                {
                    attack += (value - strength) * 3;
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
                if (value >= (int)Enums.WizardsStats.minDexterity &&
                    value <= (int)Enums.WizardsStats.maxDexterity)
                {
                    physicalDefense += (value - dexterity) * 0.5;

                    dexterity = value;
                }
            }
        }

        public override int Constitution
        {
            get { return constitution; }
            set
            {
                if (value >= (int)Enums.WizardsStats.minConstitution &&
                    value <= (int)Enums.WizardsStats.maxConstitution)
                {
                    healthPoints += (value - constitution) * 3;
                    physicalDefense += (value - constitution);

                    constitution = value;
                }
            }
        }

        public override int Intelligence
        {
            get { return intelligence; }
            set
            {
                if (value >= (int)Enums.WizardsStats.minIntelligence &&
                    value <= (int)Enums.WizardsStats.maxIntelligence)
                {
                    manaPoints += (value - intelligence) * 2;
                    magicAttack += (value - intelligence) * 5;

                    intelligence = value;
                }
            }
        }
    }
}
