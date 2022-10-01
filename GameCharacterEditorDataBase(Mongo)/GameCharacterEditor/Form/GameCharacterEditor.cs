using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System.Data.Common;

namespace GameCharacterEditor
{
    public partial class GameCharacterEditor : Form
    {
        private Character character;
        private string characterType;
        private string equipmentName;
        private Skill skill;
        private string skillName;
        private int xp;

        public GameCharacterEditor()
        {
            InitializeComponent();
            BsonClassMap.RegisterClassMap<Character>();
            BsonClassMap.RegisterClassMap<Equipment>();
            BsonClassMap.RegisterClassMap<Bow>();
            BsonClassMap.RegisterClassMap<Dagger>();
            BsonClassMap.RegisterClassMap<Mace>();
            BsonClassMap.RegisterClassMap<Warrior>();
            BsonClassMap.RegisterClassMap<Rogue>();
            BsonClassMap.RegisterClassMap<Wizard>();
            ListUpdate();
        }

        private void Strength_Text_ValueChanged(object sender, EventArgs e)
        {
            if (int.Parse(Points_Text.Text) > 0)
            {
                try
                {
                    Point();
                    character.Strength = (int)Strength_Text.Value;
                    HP_Text.Value = character.HP;
                    Attack_Text.Value = character.Attack;
                }
                catch(Exception ex)
                {
                    Strength_Text.Value = character.Strength;
                }
            }
            else
            {
                Strength_Text.Maximum = character.Strength;
                BlockingFields();
            }
        }

        private void Dexterity_Text_ValueChanged(object sender, EventArgs e)
        {
            if (int.Parse(Points_Text.Text) > 0)
            {
                Point();
                character.Dexterity = (int)Dexterity_Text.Value;
                PDef_Text.Value = character.PDef;
                Attack_Text.Value = character.Attack;
            }
            else
            {
                BlockingFields();
            }
        }

        private void Constitution_Text_ValueChanged(object sender, EventArgs e)
        {
            if (int.Parse(Points_Text.Text) > 0)
            {
                Point();
                character.Constitution = (int)Constitution_Text.Value;
                HP_Text.Value = character.HP;
                PDef_Text.Value = character.PDef;
            }
            else
            {
                BlockingFields();
            }
        }

        private void Intelligence_Text_ValueChanged(object sender, EventArgs e)
        {
            if (int.Parse(Points_Text.Text) > 0)
            {
                Point();
                character.Intelligence = (int)Intelligence_Text.Value;
                MP_Text.Value = character.MP;
                MPAttack_Text.Value = character.MPAttack;
            }
            else
            {
                BlockingFields();
            }
        }

        private void BlockingFields()
        {
            Strength_Text.Enabled = false;
            Dexterity_Text.Enabled = false;
            Constitution_Text.Enabled = false;
            Intelligence_Text.Enabled = false;
        }

        private void Point()
        {
            Points_Text.Text = (int.Parse(Points_Text.Text) - 1).ToString();
        }

        private void Rogue_Button_Click(object sender, EventArgs e)
        {
            characterType = Rogue_Button.Text;
            Characteristics();
        }

        private void Warrior_Button_Click(object sender, EventArgs e)
        {
            characterType = Warrior_Button.Text;
            Characteristics();
        }

        private void Wizard_Button_Click(object sender, EventArgs e)
        {
            characterType = Wizard_Button.Text;
            Characteristics();
        }

        private void Characteristics()
        {
            switch (characterType)
            {
                case "Rogue":
                    character = new Rogue();
                    break;
                case "Warrior":
                    character = new Warrior();
                    break;
                case "Wizard":
                    character = new Wizard();
                    break;
            }

            xp = 0;
            Lvl_Text.Text = "0";
            XP_Text.Value = XP_Text.Minimum;
            character.Lvl = character.minLvl;
            character.XPLvl = character.minXPLvl;
            character.XP = (int)XP_Text.Value;

            Type_Lable.Text = character.Type;
            Points_Text.Text = character.Points.ToString();
            Name_Text.Text = "";

            Bow_CheckBox.Checked = false;
            Mace_CheckBox.Checked = false;
            Dagger_CheckBox.Checked = false;

            Strength_Text.Value = character.Strength;
            Dexterity_Text.Value = character.Dexterity;
            Constitution_Text.Value = character.Constitution;
            Intelligence_Text.Value = character.Intelligence;
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            SavedCharactersBox.Items.Add(character.Name);

            if (character.Id != ObjectId.Empty)
                DataBase.ReplaceByName(character);
            else
                DataBase.AddToDataBase(character);

            Skills_ComboBox.Items.Remove(Skills_ComboBox.SelectedItem);
            Skills_ComboBox.Visible = false;

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

            Bow_CheckBox.Checked = false;
            Mace_CheckBox.Checked = false;
            Dagger_CheckBox.Checked = false;
        }

        private void Name_Text_TextChanged(object sender, EventArgs e)
        {
            character.Name = Name_Text.Text;
        }

        private void SavedCharactersBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            character = DataBase.FindByName(SavedCharactersBox.Text);
            Type_Lable.Text = character.Type;
            Points_Text.Text = character.Points.ToString();
            Lvl_Text.Text = character.Lvl.ToString();
            XP_Text.Value = character.XP;
            Name_Text.Text = character.Name;
            Strength_Text.Value = character.Strength;
            Dexterity_Text.Value = character.Dexterity;
            Constitution_Text.Value = character.Constitution;
            Intelligence_Text.Value = character.Intelligence;
            Skill_Text.Text = character.skill.ToString();

            foreach (var eq in character.equipment)
            {
                //MessageBox.Show(eq.TypeEquipment);
                switch (eq.TypeEquipment)
                {
                    case "Bow":
                        Bow_CheckBox2.Visible = true;
                        Bow_CheckBox2.Checked = true;
                        break;
                    case "Mace":
                        Mace_CheckBox2.Visible = true;
                        Mace_CheckBox2.Checked = true;
                        break;
                    case "Dagger":
                        Dagger_CheckBox2.Visible= true;
                        Dagger_CheckBox2.Checked = true;
                        break;
                }
            }
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
            character.AddToEquipment(new Bow(equipmentName, 10));
        }

        private void Mace_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            equipmentName = Mace_CheckBox.Text;
            character.AddToEquipment(new Mace(equipmentName, 10));
        }

        private void Dagger_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            equipmentName = Dagger_CheckBox.Text;
            character.AddToEquipment(new Dagger(equipmentName, 10));
        }

        private void Skills_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Skill skill = new Skill(Skills_ComboBox.SelectedItem.ToString());
            character.AddToSkill(skill);
        }

        private void XP_Text_ValueChanged(object sender, EventArgs e)
        {
            character.XP += 500;
            xp = character.XPLvl + character.Lvl * 1000;

            if (character.XP >= xp)
            {
                character.XPLvl = character.XP;
                character.Lvl++;
                character.Points += 10;
                Lvl_Text.Text = (int.Parse(Lvl_Text.Text) + 1).ToString();
                Points_Text.Text = character.Points.ToString();
            }

            if(int.Parse(Lvl_Text.Text) % 3 == 0 && int.Parse(Lvl_Text.Text) != 0)
            {
                MessageBox.Show("Choose any skill");
                Skills_ComboBox.Visible = true;

                /*Skills_Lable.Visible = true;
                switch (Lvl_Text.Text)
                {
                    case "3":
                        Fireballs_ÑheckBox.Visible = true;
                        Invisibility_ÑheckBox.Visible = true;
                        Noiselessness_CheckBox.Visible = true;
                        break;
                    case "6":
                        Shild_ÑheckBox.Visible = true;
                        Flight_ÑheckBox.Visible = true;
                        MegaDamage_CheckBox.Visible = true;
                        break;
                    case "9":
                        Vision_ÑheckBox.Visible = true;
                        Speed_ÑheckBox.Visible = true;
                        Teleportation_CheckBox.Visible = true;
                        break;
                }*/
            }
            
        }
    }
}