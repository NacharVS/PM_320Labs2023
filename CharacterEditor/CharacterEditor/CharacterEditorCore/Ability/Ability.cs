namespace CharacterEditorCore
{
    public class Ability
    {
        public string Name { get; set; }
        public double AttackChangeValue { get; set; }
        public double HealthChangeValue { get; set; }
        public double PhysicalDefenceChangeValue { get; set; }
        public double ManaChangeValue { get; set; }
        public double MagicalAttackChangeValue { get; set; }

        public Ability(string name, 
            double attackChangeValue, 
            double healthChangeValue, 
            double physicalDefenceChangeValue, 
            double manaChangeValue, 
            double magicalAttackChangeValue)
        {
            Name = name;
            AttackChangeValue = attackChangeValue;
            HealthChangeValue = healthChangeValue;
            PhysicalDefenceChangeValue = physicalDefenceChangeValue;
            ManaChangeValue = manaChangeValue;
            MagicalAttackChangeValue = magicalAttackChangeValue;
        }
    }
}