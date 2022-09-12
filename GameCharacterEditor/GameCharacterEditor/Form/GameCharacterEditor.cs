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
            switch (characterName)
            {
                case "Rogue":
                    HP_Text.Value += (Strength_Text.Value - character.minStrength) * 1;
                    Attack_Text.Value += ((Strength_Text.Value - character.minStrength) * 2);
                    break;
                case "Warrior":
                    HP_Text.Value += (Strength_Text.Value - character.minStrength) * 2;
                    Attack_Text.Value += (Strength_Text.Value - character.minStrength) * 5;
                    break;
                case "Wizard":
                    HP_Text.Value += (Strength_Text.Value - character.minStrength) * 1;
                    Attack_Text.Value += ((Strength_Text.Value - character.minStrength) * 2);
                    break;
            }

            /*HP_Text.Text = character.HP.ToString();
            Attack_Text.Text = character.Attack.ToString();*/
        }

        private void Dexterity_Text_ValueChanged(object sender, EventArgs e)
        {
            switch (characterName)
            {
                case "Rogue":
                    PDef_Text.Value += (Dexterity_Text.Value - character.minDexterity) * (int)1.5;
                    Attack_Text.Value += (Dexterity_Text.Value - character.minDexterity) * 4;
                    break;
                case "Warrior":
                    PDef_Text.Value += (Dexterity_Text.Value - character.minDexterity) * 1;
                    Attack_Text.Value += (Dexterity_Text.Value - character.minDexterity) * 1;
                    break;
                case "Wizard":
                    PDef_Text.Value += (Dexterity_Text.Value - character.minDexterity) * (int)0.5;
                    break;
            }

            /*PDef_Text.Text = character.PDef.ToString();
            Attack_Text.Text = character.Attack.ToString();*/
        }

        private void Constitution_Text_ValueChanged(object sender, EventArgs e)
        {
            switch (characterName)
            {
                case "Rogue":
                    HP_Text.Value += (Constitution_Text.Value - character.minConstitution) * 6;
                    break;
                case "Warrior":
                    HP_Text.Value += (Constitution_Text.Value - character.minConstitution) * 10;
                    PDef_Text.Value += (Constitution_Text.Value - character.minConstitution) * 2;
                    break;
                case "Wizard":
                    HP_Text.Value += (Constitution_Text.Value - character.minConstitution) * 3;
                    PDef_Text.Value += (Constitution_Text.Value - character.minConstitution) * 1;
                    break;
            }

            /*HP_Text.Text = character.HP.ToString();
            PDef_Text.Text = character.PDef.ToString();*/
        }

        private void Intelligence_Text_ValueChanged(object sender, EventArgs e)
        {
            switch (characterName)
            {
                case "Rogue":
                    /*MP_Text.Value += (MP_Text.Value - character.minIntelligence) * (int)1.5;
                    MPAttack_Text.Value += (MPAttack_Text.Value - character.minIntelligence) * 2;*/
                    break;
                case "Warrior":
                    /*MP_Text.Value += (MP_Text.Value - character.minIntelligence) * 1;
                    MPAttack_Text.Value += (MPAttack_Text.Value - character.minIntelligence) * 1;*/
                    break;
                case "Wizard":
                    /*MP_Text.Value += (MP_Text.Value - character.minIntelligence) * 2;
                    MPAttack_Text.Value += (MPAttack_Text.Value - character.minIntelligence) * 5;*/
                    break;
            }

            /*MP_Text.Text = character.MP.ToString();
            MPAttack_Text.Text = character.MPAttack.ToString();*/
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