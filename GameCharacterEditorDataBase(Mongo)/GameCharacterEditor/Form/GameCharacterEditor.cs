using MongoDB.Bson.Serialization;
using System.Data.Common;

namespace GameCharacterEditor
{
    public partial class GameCharacterEditor : Form
    {
        private Character character;
        private string characterName;
        private string equipmentName;
        public GameCharacterEditor()
        {
            InitializeComponent();
            BsonClassMap.RegisterClassMap<Character>();
            BsonClassMap.RegisterClassMap<Warrior>();
            BsonClassMap.RegisterClassMap<Rogue>();
            BsonClassMap.RegisterClassMap<Wizard>();
            ListUpdate();
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
            characterName = Rogue_Button.Text;
            Characteristics();
        }

        private void Warrior_Button_Click(object sender, EventArgs e)
        {
            characterName = Warrior_Button.Text;
            Characteristics();
        }

        private void Wizard_Button_Click(object sender, EventArgs e)
        {
            characterName = Wizard_Button.Text;
            Characteristics();
        }

        private void Characteristics()
        {
            switch (characterName)
            {
                case "Rogue":
                    character = new Rogue();
                    Type_Lable.Text = character.Type;
                    Name_Text.Text = "";
                    break;
                case "Warrior":
                    character = new Warrior();
                    Type_Lable.Text = character.Type;
                    Name_Text.Text = "";
                    break;
                case "Wizard":
                    character = new Wizard();
                    Type_Lable.Text = character.Type;
                    Name_Text.Text = "";
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
            SavedCharactersBox.Items.Add(character.Name);
            DataBase.AddToDataBase(character);

            Name_Text.Text = "";

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

        private void Name_Text_TextChanged(object sender, EventArgs e)
        {
            character.Name = Name_Text.Text;
        }

        private void SavedCharactersBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            character = DataBase.FindByName(SavedCharactersBox.Text);
            Type_Lable.Text = character.Type;
            Name_Text.Text = character.Name;
            Strength_Text.Value = character.Strength;
            Dexterity_Text.Value = character.Dexterity;
            Constitution_Text.Value = character.Constitution;
            Intelligence_Text.Value = character.Intelligence;
        }

        private void ListUpdate()
        {
            var collection = DataBase.ImportData();

            foreach (var c in collection)
            {
                SavedCharactersBox.Items.Add(c.Name);
            }
        }

        private void Bow_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            equipmentName = Bow_CheckBox.Text;
            character.AddToEquipment(new Equipment("Bow", 10));
        }

        private void Mace_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            equipmentName = Mace_CheckBox.Text;
            character.AddToEquipment(new Equipment("Mace", 10));
        }

        private void Dagger_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            equipmentName = Dagger_CheckBox.Text;
            character.AddToEquipment(new Equipment("Dagger", 10));
        }
    }
}