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
        public double AttackChange { get; set; }
        public double MagicalAttackChange { get; set; }
        public double ManaChange { get; set; }
        public double HealthChange { get; set; }
        public double PhysicalDefChange { get; set; }

        public Ability(string? name, double attackChange, double magicalAttackChange,
            double manaChange, double healthChange, double physicalDefChange)
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
