namespace Characters
{
    public class Character
    {
        protected int maxStrength;
        protected int maxDexterity;
        protected int maxConstitution;
        protected int maxInteligence;

        protected int strength;
        protected int dexterity;
        protected int constitution;
        protected int inteligence;

        public int Strength 
        {
            get { return strength; }
            set
            {
                strength = value;
            }
        }
        public int Dexterity
        {
            get { return dexterity; }
            set
            {
                dexterity = value;
            }
        }
        public int Constitution
        {
            get { return constitution; }
            set
            {
                constitution = value;
            }
        }
        public int Inteligence
        {
            get { return inteligence; }
            set
            {
                inteligence = value;
            }
        }

        public int HP { get; protected set; }
        public double MP { get; protected set; }
        public int Damage { get; protected set; }
        public double PhysDef { get; protected set; }
        public int MagDamage { get; protected set; }

        public void Save(string path)
        {
            using (var writer = new StreamWriter(path, true))
            {
                writer.WriteLine(this.GetType().Name.ToString());
                writer.WriteLine("Strength: " + this.Strength.ToString());
                writer.WriteLine("Dexterity: " + this.Dexterity.ToString());
                writer.WriteLine("Constitution: " + this.Constitution.ToString());
                writer.WriteLine("Inteligence: " + this.Inteligence.ToString());
                writer.WriteLine("HP: " + this.HP.ToString());
                writer.WriteLine("MP: " + this.MP.ToString());
                writer.WriteLine("Damage: " + this.Damage.ToString());
                writer.WriteLine("Physical defense: " + this.PhysDef.ToString());
                writer.WriteLine("Magical damage: " + this.MagDamage.ToString());
                writer.WriteLine();
            }
        }
    }
}