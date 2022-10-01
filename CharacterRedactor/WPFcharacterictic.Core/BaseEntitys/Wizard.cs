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
            Name = "Wizard";
            MaxCountInventoryItem = 7;

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

            PhysicalAttack = Strength;
            Health = Strength + Constitution * 3;
            PhysicalDefense = Dexterity + Constitution;
            Mana = Intelligence * 2;
            MagicAttack = Intelligence * 5;

        }

        public override void IncreasedStrength()
        {
            if (AvailablePoints > 0 && MaxStrength > Strength)
            {
                Strength++;
                PhysicalAttack += 3;
                Health += 1;
                AvailablePoints--;
            }
            
        }
        public override void IncreasedDexterity()
        {
            if (AvailablePoints > 0 && MaxDexterity > Dexterity)
            {
                Dexterity++;
                PhysicalDefense += 0.5;
                AvailablePoints--;
            } 
        }

        public override void IncreasedConstitution()
        {
            if (AvailablePoints > 0 && MaxConstitution > Constitution)
            {
                Constitution++;
                Health += 3;
                PhysicalDefense += 1;
                AvailablePoints--;
            }
        }

        public override void IncreasedIntelligence()
        {
            if (AvailablePoints > 0 && MaxIntelligence > Intelligence)
            {
                Intelligence++;
                Mana += 2;
                MagicAttack += 5;
                AvailablePoints--;
            }
        }
    }
}
