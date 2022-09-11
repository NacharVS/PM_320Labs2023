using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFcharacterictic.Core.BaseEntitys
{
    public class Warrior : Entity
    {
        public Warrior() 
        {
            Strength = 30;
            MinStrength = 30;
            MaxStrength = 250;
            Dexterity = 15;
            MinDexterity = 15;
            MaxDexterity = 70;
            Constitution = 20;
            MinConstitution = 20;
            MaxConstitution = 100;
            Intelligence = 10;
            MinIntelligence = 10;
            MaxIntelligence = 50;
        }

        public override void IncreasedStrength()
        {
            if (AvailablePoints > 0) 
            {
                Strength++;
                PhysicalAttack += 5;
                Health += 2;
                AvailablePoints--;
            }
        }
        public override void IncreasedDexterity()
        {
            if (AvailablePoints > 0)
            {
                Dexterity++;
                PhysicalAttack += 1;
                PhysicalDefense += 1;
                AvailablePoints--;
            }
        }

        public override void IncreasedConstitution()
        {
            if (AvailablePoints > 0)
            {
                Constitution++;
                Health += 10;
                PhysicalDefense += 2;
                AvailablePoints--;
            }
        }

        public override void IncreasedIntelligence()
        {
            if (AvailablePoints > 0)
            {
                Intelligence++;
                Mana += 1;
                MagicAttack += 1;
                AvailablePoints--;
            }
        }
    }
}
