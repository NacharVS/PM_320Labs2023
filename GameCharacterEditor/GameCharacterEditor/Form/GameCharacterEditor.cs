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
            HP_Text.Text = character.HP.ToString();
            Attack_Text.Text = character.Attack.ToString();
        }

        private void Dexterity_Text_ValueChanged(object sender, EventArgs e)
        {
            PDef_Text.Text = character.PDef.ToString();
            Attack_Text.Text = character.Attack.ToString();
        }

        private void Constitution_Text_ValueChanged(object sender, EventArgs e)
        {
            HP_Text.Text = character.HP.ToString();
            PDef_Text.Text = character.PDef.ToString();
        }

        private void Intelligence_Text_ValueChanged(object sender, EventArgs e)
        {
            MP_Text.Text = character.MP.ToString();
            MPAttack_Text.Text = character.MPAttack.ToString();
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

        private void CharacterSelection()
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
        }

        private void Characteristics()
        {
            CharacterSelection();

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
    }
}