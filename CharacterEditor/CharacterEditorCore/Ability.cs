using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore
{
    public class Ability
    {
        public string? Name { get; set; }
        public int AttackChange { get; set; }
        public int MagicalAttackChange { get; set; }
        public double ManaChange { get; set; }
        public int HealthChange { get; set; }
        public double PhysicalDefChange { get; set; }

        public Ability(string? name, int attackChange, int magicalAttackChange,
            double manaChange, int healthChange, double physicalDefChange)
        {
            Name = name;
            AttackChange = attackChange;
            MagicalAttackChange = magicalAttackChange;
            ManaChange = manaChange;
            HealthChange = healthChange;
            PhysicalDefChange = physicalDefChange;
        }
    }
}
