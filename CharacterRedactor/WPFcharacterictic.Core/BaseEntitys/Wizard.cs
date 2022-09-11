using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFcharacterictic.Core.BaseEntitys
{
    public class Wizard : Entity
    {
        public Wizard() 
        {
            Strength = 10;
            MinStrength = 10;
            MaxStrength = 45;
            Dexterity = 20;
            MinDexterity = 20;
            MaxDexterity = 70;
            Constitution = 15;
            MinConstitution = 15;
            MaxConstitution = 60;
            Intelligence = 35;
            MinIntelligence = 35;
            MaxIntelligence = 250;
        }

        public override void IncreasedStrength()
        {
            if (AvailablePoints > 0)
            {
                Strength++;
                PhysicalAttack += 3;
                Health += 1;
                AvailablePoints--;
            }
            
        }
        public override void IncreasedDexterity()
        {
            if (AvailablePoints > 0)
            {
                Dexterity++;
                PhysicalDefense += 0.5;
                AvailablePoints--;
            } 
        }

        public override void IncreasedConstitution()
        {
            if (AvailablePoints > 0)
            {
                Constitution++;
                Health += 3;
                PhysicalDefense += 1;
                AvailablePoints--;
            }
        }

        public override void IncreasedIntelligence()
        {
            if (AvailablePoints > 0)
            {
                Intelligence++;
                Mana += 2;
                MagicAttack += 5;
                AvailablePoints--;
            }
        }
    }
}
