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
            Name = "Warrior";
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

            PhysicalAttack = Strength * 5 + Dexterity;
            Health = Strength * 2 + Constitution * 10;
            PhysicalDefense = Dexterity + Constitution * 2;
            Mana = Intelligence;
            MagicAttack = Intelligence;
        }

        public override void IncreasedStrength()
        {
            if (AvailablePoints > 0 && MaxStrength > Strength) 
            {
                Strength++;
                PhysicalAttack += 5;
                Health += 2;
                AvailablePoints--;
            }
        }
        public override void IncreasedDexterity()
        {
            if (AvailablePoints > 0 && MaxDexterity > Dexterity)
            {
                Dexterity++;
                PhysicalAttack += 1;
                PhysicalDefense += 1;
                AvailablePoints--;
            }
        }

        public override void IncreasedConstitution()
        {
            if (AvailablePoints > 0 && MaxConstitution > Constitution)
            {
                Constitution++;
                Health += 10;
                PhysicalDefense += 2;
                AvailablePoints--;
            }
        }

        public override void IncreasedIntelligence()
        {
            if (AvailablePoints > 0 && MaxIntelligence > Intelligence)
            {
                Intelligence++;
                Mana += 1;
                MagicAttack += 1;
                AvailablePoints--;
            }
        }
    }
}
