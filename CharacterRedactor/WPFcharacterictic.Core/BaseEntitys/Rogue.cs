using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFcharacterictic.Core.BaseEntitys
{
     public class Rogue : Entity
     {
        public Rogue() 
        {
            Strength = 15;
            MinStrength = 15;
            MaxStrength = 55;
            Dexterity = 30;
            MinDexterity = 30;
            MaxDexterity = 250;
            Constitution = 20;
            MinConstitution = 20;
            MaxConstitution = 80;
            Intelligence = 15;
            MinIntelligence = 15;
            MaxIntelligence = 70;
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
