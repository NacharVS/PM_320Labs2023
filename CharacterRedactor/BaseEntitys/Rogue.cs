using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFcharacterictic.Core.BaseArmor;

namespace WPFcharacterictic.Core.BaseEntitys
{
     public class Rogue : Entity
     {
        public Rogue() 
        {
            Name = "Rogue";
            MaxCountInventoryItem = 5;

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

            Health = Strength + Constitution * 6;
            Mana = Intelligence * 1.5;
            PhysicalAttack = Strength * 2 + Dexterity * 4;
            MagicAttack = Intelligence * 15;
            PhysicalDefense = Dexterity * 1.5;
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

        public override bool ArmorCompatibilityCheck(Armor armor)
        {
            try
            {
                if (armor.WhoCan is "Rogue" || armor.WhoCan is "Entity")
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex) 
            {
                
            }
            return false;
        }
    }
}
