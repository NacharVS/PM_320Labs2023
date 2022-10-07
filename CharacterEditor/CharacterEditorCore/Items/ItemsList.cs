using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore.Items
{
    public static class ItemsList
    {
        public static List<Item> ItemList = new()
        {
            new()
            {
                Name = "Simple Helmet",
                HPChange = 1,
                ManaChange = 1,
                PdefChange = 20,
                AttackChange = 1,
                MagicalAttackChange = 0,
                MinimumLevel = 1,
                ItemType = ItemType.Helmet,
                StrengthChange = 2,
                DexterityChange = 0,
                ConstitutionChange = 1,
                IntelligenceChange = 0
            },
            new()
            {
                Name = "Iron Helmet",
                HPChange = 3,
                ManaChange = 2,
                PdefChange = 50,
                AttackChange = 1,
                MagicalAttackChange = 0,
                MinimumLevel = 3,
                ItemType = ItemType.Helmet,
                StrengthChange = 4,
                DexterityChange = 0,
                ConstitutionChange = 2,
                IntelligenceChange = 0
            },

            new()
            {
                Name = "Diamond Helmet",
                HPChange = 5,
                ManaChange = 4,
                PdefChange = 100,
                AttackChange = 2,
                MagicalAttackChange = 0,
                MinimumLevel = 6,
                ItemType = ItemType.Helmet,
                StrengthChange = 10,
                DexterityChange = 1,
                ConstitutionChange = 5,
                IntelligenceChange = 0
            },

            new()
            {
                Name = "Simple Body Armor",
                HPChange = 1,
                ManaChange = 1,
                PdefChange = 40,
                AttackChange = 1,
                MagicalAttackChange = 0,
                MinimumLevel = 1,
                ItemType = ItemType.Armor,
                StrengthChange = 1,
                DexterityChange = 1,
                ConstitutionChange = 1,
                IntelligenceChange = 0
            },
            new()
            {
                Name = "Iron Body Armor",
                HPChange = 2,
                ManaChange = 2,
                PdefChange = 80,
                AttackChange = 2,
                MagicalAttackChange = 0,
                MinimumLevel = 3,
                ItemType = ItemType.Armor,
                StrengthChange = 5,
                DexterityChange = 3,
                ConstitutionChange = 2,
                IntelligenceChange = 0
             },

            new()
            {
                Name = "Diamond Body Armor",
                HPChange = 5,
                ManaChange = 4,
                PdefChange = 120,
                AttackChange = 4,
                MagicalAttackChange = 1,
                MinimumLevel = 7,
                ItemType = ItemType.Armor,
                StrengthChange = 20,
                DexterityChange = 5,
                ConstitutionChange = 3,
                IntelligenceChange = 1
            },

            new()
            {
                Name = "Simple Pistol",
                HPChange = 0,
                ManaChange = 0,
                PdefChange = 0,
                AttackChange = 30,
                MagicalAttackChange = 0,
                MinimumLevel = 1,
                ItemType = ItemType.Weapon,
                StrengthChange = 0,
                DexterityChange = 0,
                ConstitutionChange = 3,
                IntelligenceChange = 1
            },

            new()
            {
                Name = "Magic wand",
                HPChange = 0,
                ManaChange = 0,
                PdefChange = 0,
                AttackChange = 60,
                MagicalAttackChange = 0,
                MinimumLevel = 3,
                ItemType = ItemType.Weapon,
                StrengthChange = 1,
                DexterityChange = 3,
                ConstitutionChange = 0,
                IntelligenceChange = 4
            },

            new()
            {
                Name = "Dagon",
                HPChange = 0,
                ManaChange = 0,
                PdefChange = 0,
                AttackChange = 150,
                MagicalAttackChange = 0,
                MinimumLevel = 7,
                ItemType = ItemType.Weapon,
                StrengthChange = 5,
                DexterityChange = 5,
                ConstitutionChange = 5,
                IntelligenceChange = 5
            }
        };
    }
}
