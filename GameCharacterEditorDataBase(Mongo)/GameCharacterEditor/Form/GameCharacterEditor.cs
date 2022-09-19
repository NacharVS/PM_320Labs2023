namespace GameCharacterEditor
{
    public partial class GameCharacterEditor : Form
    {
        private Character character;
        private string characterName;
        public GameCharacterEditor()
        {
            InitializeComponent();
        }
        private void GameCharacterEditor_Load(object sender, EventArgs e)
        {
            
        }

        private void Strength_Text_ValueChanged(object sender, EventArgs e)
        {
            character.Strength = (int)Strength_Text.Value;
            HP_Text.Value = character.HP;
            Attack_Text.Value = character.Attack;
        }

        private void Dexterity_Text_ValueChanged(object sender, EventArgs e)
        {
            character.Dexterity = (int)Dexterity_Text.Value;
            PDef_Text.Value = character.PDef;
            Attack_Text.Value = character.Attack;
        }

        private void Constitution_Text_ValueChanged(object sender, EventArgs e)
        {
            character.Constitution = (int)Constitution_Text.Value;
            HP_Text.Value = character.HP;
            PDef_Text.Value = character.PDef;
        }

        private void Intelligence_Text_ValueChanged(object sender, EventArgs e)
        {
            character.Intelligence = (int)Intelligence_Text.Value;
            MP_Text.Value = character.MP;
            MPAttack_Text.Value = character.MPAttack;
        }

        private void Rogue_Button_Click(object sender, EventArgs e)
        {
            characterName = "Rogue";
            Characteristics();
        }

        private void Warrior_Button_Click(object sender, EventArgs e)
        {
            characterName = "Warrior";
            Characteristics();
        }

        private void Wizard_Button_Click(object sender, EventArgs e)
        {
            characterName = "Wizard";
            Characteristics();
        }

        private void Characteristics()
        {
            switch (characterName)
            {
                case "Rogue":
                    character = new Rogue(characterName);
                    break;
                case "Warrior":
                    character = new Warrior(characterName);
                    break;
                case "Wizard":
                    character = new Wizard(characterName);
                    break;
            }

            Strength_Text.Minimum = character.Strength;
            Strength_Text.Maximum = character.maxStrength;
            Strength_Text.Value = Strength_Text.Minimum;

            Dexterity_Text.Minimum = character.Dexterity;
            Dexterity_Text.Maximum = character.maxDexterity;
            Dexterity_Text.Value = Dexterity_Text.Minimum;

            Constitution_Text.Minimum = character.Constitution;
            Constitution_Text.Maximum = character.maxConstitution;
            Constitution_Text.Value = Constitution_Text.Minimum;

            Intelligence_Text.Minimum = character.Intelligence;
            Intelligence_Text.Maximum = character.maxIntelligence;
            Intelligence_Text.Value = Intelligence_Text.Minimum;
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            Strength_Text.Minimum = 0;
            Strength_Text.Value = 0;

            Dexterity_Text.Minimum = 0;
            Dexterity_Text.Value = 0;

            Constitution_Text.Minimum = 0;
            Constitution_Text.Value = 0;

            Intelligence_Text.Minimum = 0;
            Intelligence_Text.Value = 0;

            HP_Text.Minimum = 0;
            HP_Text.Value = 0;

            MP_Text.Minimum = 0;
            MP_Text.Value = 0;

            PDef_Text.Minimum = 0;
            PDef_Text.Value = 0;

            Attack_Text.Minimum = 0;
            Attack_Text.Value = 0;

            MPAttack_Text.Minimum = 0;
            MPAttack_Text.Value = 0;
        }
    }
}