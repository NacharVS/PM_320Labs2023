using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System;
using System.Data.Common;

namespace GameCharacterEditor
{
    public partial class GameCharacterEditor : Form
    {
        private Character character;
        private string characterType;
        private Armor armor;
        private Equipment equipment;
        private Skill skill;
        private bool skillBool;
        private int xp;

        public GameCharacterEditor()
        {
            InitializeComponent();
            BsonClassMap.RegisterClassMap<Character>();
            BsonClassMap.RegisterClassMap<Equipment>();
            BsonClassMap.RegisterClassMap<Skill>();
            BsonClassMap.RegisterClassMap<Warrior>();
            BsonClassMap.RegisterClassMap<Rogue>();
            BsonClassMap.RegisterClassMap<Wizard>();
            ListUpdate();
        }

        public GameCharacterEditor(string name)
        {
            InitializeComponent();
            ListUpdate();
            SavedCharactersBox.SelectedIndex = SavedCharactersBox.Items.IndexOf(name);
        }

        private void ListUpdate()
        {
            var collection = DataBase.ImportCharacterDataBase();

            foreach (var c in collection)
            {
                SavedCharactersBox.Items.Add(c.Name);
            }
        }

        private void Strength_Text_ValueChanged(object sender, EventArgs e)
        {
            if (int.Parse(Points_Text.Text) > 0)
            {
                try
                {
                    character.Strength = (int)Strength_Text.Value;
                    HP_Text.Value = character.HP;
                    Attack_Text.Value = character.Attack;
                    PointMinus();
                }
                catch (Exception ex)
                {
                    PointPlus();
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
                try
                {
                    character.Dexterity = (int)Dexterity_Text.Value;
                    PDef_Text.Value = character.PDef;
                    Attack_Text.Value = character.Attack;
                    PointMinus();
                }
                catch
                {
                    PointPlus();
                    Dexterity_Text.Value = character.Dexterity;
                }
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
                try
                {
                    character.Constitution = (int)Constitution_Text.Value;
                    HP_Text.Value = character.HP;
                    PDef_Text.Value = character.PDef;
                    PointMinus();
                }
                catch
                {
                    PointPlus();
                    Constitution_Text.Value = character.Constitution;
                }
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
                try
                {
                    character.Intelligence = (int)Intelligence_Text.Value;
                    MP_Text.Value = character.MP;
                    MPAttack_Text.Value = character.MPAttack;
                    PointMinus();
                }
                catch
                {
                    PointPlus();
                    Intelligence_Text.Value = character.Intelligence;
                }
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

        private void PointMinus()
        {
            character.Points--;
            Points_Text.Text = character.Points.ToString();
        }

        private void PointPlus()
        {
            character.Points++;
            Points_Text.Text = character.Points.ToString();
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

            Strength_Text.Enabled = true;
            Dexterity_Text.Enabled = true;
            Constitution_Text.Enabled = true;
            Intelligence_Text.Enabled = true;
            Equipment_CheckBox.Enabled = true;

            Name_Text.Enabled = true;
            OK_Button.Enabled = true;
            Save_Button.Enabled = true;
            GO_Button.Enabled = true;   
            XP_Text.Enabled = true;
            SavedCharactersBox.Enabled = false;

            xp = 0;
            Lvl_Text.Text = "0";
            XP_Text.Value = XP_Text.Minimum;
            character.Lvl = character.minLvl;
            character.XPLvl = character.minXPLvl;
            character.XP = (int)XP_Text.Value;

            Skill_CheckBox.Items.Clear();
            Skill_CheckBox.Items.Add("Barrier");
            Skill_CheckBox.Items.Add("Flight");
            Skill_CheckBox.Items.Add("Vision");
            Skill_CheckBox.Items.Add("Speed");
            Skill_CheckBox.Items.Add("Teleportation");
            Skill_CheckBox.Items.Add("Invisibility");
            Skill_CheckBox.Items.Remove(Skill_CheckBox.SelectedItem);

            Type_Lable.Text = character.Type;
            Points_Text.Text = character.Points.ToString();
            Name_Text.Text = "";

            Strength_Text.Value = character.Strength;
            Dexterity_Text.Value = character.Dexterity;
            Constitution_Text.Value = character.Constitution;
            Intelligence_Text.Value = character.Intelligence;
        }

        private void Name_Text_TextChanged(object sender, EventArgs e)
        {
            character.Name = Name_Text.Text;
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            SavedCharactersBox.Items.Clear();
            SavedCharactersBox.Items.Add(character.Name);
            ListUpdate();

            if (character.Id != ObjectId.Empty)
            {
                DataBase.ReplaceCharacterByName(character.Name, character);
            }
            else
                DataBase.AddCharacterToDataBase(character);
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            Application.Restart();
            /*Skill_CheckBox.Visible = false;
            Skills_Lable.Visible = false;
            Skill_Text.Visible = false;

            SavedCharactersBox.Enabled = true;
            Rogue_Button.Enabled = true;
            Warrior_Button.Enabled = true;
            Wizard_Button.Enabled = true;

            Type_Lable.Text = "CHARACTER";
            Name_Text.Text = "";
            Lvl_Text.Text = "0";
            Points_Text.Text = "0";
            XP_Text.Value = 0;

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

            Equipment_Text.Visible = false;
            Equipment_CheckBox.Visible = true;
            Equipment_Text.Text = "";
            Edit_Button.Visible = false;*/
        }

        private void SavedCharactersBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            character = DataBase.FindCharacterByName(SavedCharactersBox.Text);

            Type_Lable.Text = character.Type;
            Points_Text.Text = character.Points.ToString();
            Lvl_Text.Text = character.Lvl.ToString();
            XP_Text.Value = character.XP;
            Name_Text.Text = character.Name;
            Strength_Text.Value = character.Strength;
            Dexterity_Text.Value = character.Dexterity;
            Constitution_Text.Value = character.Constitution;
            Intelligence_Text.Value = character.Intelligence;

            SavedCharactersBox.Enabled = false;

            Rogue_Button.Enabled = false;
            Warrior_Button.Enabled = false;
            Wizard_Button.Enabled = false;

            Strength_Text.Enabled = true;
            Dexterity_Text.Enabled = true;
            Constitution_Text.Enabled = true;
            Intelligence_Text.Enabled = true;

            OK_Button.Enabled = true;
            Save_Button.Enabled = true;
            XP_Text.Enabled = true;

            Edit_Button.Visible = true;
            Equipment_CheckBox.Visible = false;
            Equipment_Text.Visible = true;
            for (int i = 0; i < character.equipmentList.Count; i++)
            {
                Equipment_Text.Text += character.equipmentList[i] + " ";
            }


            Skill_Text.Text = "";
            Skills_Lable.Visible = true;
            Skill_Text.Visible = true;
            for (int i = 0; i < character.skillList.Count; i++)
            {
                Skill_Text.Text += character.skillList[i] + " ";
            }

            Armor_Text.Text = "";
            Armor_Label.Visible = true;
            Armor_Text.Visible = true;
            for (int i = 0; i < character.armorList.Count; i++)
            {
                if (i % 2 == 0)
                {
                    Armor_Text.Text += character.armorList[i] + " ";
                }
                else
                {
                    Armor_Text.Text += character.armorList[i] + ", ";
                }
            }
        }

        private void Skills_CheckBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Skill_CheckBox.SelectedItem is not null)
            {
                skill = new Skill(Skill_CheckBox.SelectedItem.ToString());
                character.AddToSkillName(Skill_CheckBox.SelectedItem.ToString());
                //character.AddToSkill(skill);
                skillBool = true;
            }

            if (skillBool)
            {
                Skills_Lable.Visible = false;
                Skill_CheckBox.Visible = false;
                Skill_CheckBox.Items.Remove(Skill_CheckBox.SelectedItem);
                skillBool = false;
            }
        }
        private void Equipment_CheckBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            equipment = new Equipment(Equipment_CheckBox.SelectedItem.ToString(), 10);
            character.AddToEquipmentName(Equipment_CheckBox.SelectedItem.ToString());
            //character.AddToEquipment(equipment);
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            Equipment_Text.Visible = false;
            Equipment_CheckBox.Visible = true;
            Equipment_CheckBox.Enabled = true;
        }

        private void XP_Text_ValueChanged(object sender, EventArgs e)
        {
            character.XP += 500;
            xp = character.XPLvl + character.Lvl * 1000;

            if (character.XP == xp)
            {
                character.XPLvl = character.XP;
                character.Lvl++;
                character.Points += 10;
                Lvl_Text.Text = (int.Parse(Lvl_Text.Text) + 1).ToString();
                Points_Text.Text = character.Points.ToString();
            }

            if (int.Parse(Lvl_Text.Text) % 3 == 0 && int.Parse(Lvl_Text.Text) != 0
                && character.XP == character.XPLvl)
            {
                Skills_Lable.Visible = true;
                Skill_CheckBox.Visible = true;
            }

            if(int.Parse(Lvl_Text.Text) == 3)
            {
                Armor_ListBox.Visible = true;
                Armor_Label.Visible = true;
            }
        }

        private void Armor_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Material_ComboBox.Visible = true;
        }

        private void Material_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Armor_ListBox.SelectedItem.ToString())
            {
                case "Chain mail":
                    armor = new ChainMail(Armor_ListBox.SelectedItem.ToString(),Material_ComboBox.SelectedItem.ToString());
                    break;
                case "Helmet":
                    armor = new Helmet(Armor_ListBox.SelectedItem.ToString(),Material_ComboBox.SelectedItem.ToString());
                    break;
                case "Shield":
                    armor = new Shield(Armor_ListBox.SelectedItem.ToString(),Material_ComboBox.SelectedItem.ToString());
                    break;
            }

            switch (Material_ComboBox.SelectedItem.ToString())
            {
                case "Copper":
                    ArmorCharacteristics();
                    break;
                case "Silver":
                    if (int.Parse(Lvl_Text.Text) > 4 && int.Parse(Lvl_Text.Text) < 7)
                    {
                        ArmorCharacteristics();
                    }
                    else
                    {
                        MessageBox.Show("To choose a silver armor, you need to reach level 5",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    break;
                case "Gold":
                    if (int.Parse(Lvl_Text.Text) > 6)
                    {
                        ArmorCharacteristics();
                    }
                    else
                    {
                        MessageBox.Show("To choose a silver armor, you need to reach level 7",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    break;
            }
            DataBase.UpdateCharacterByName(SavedCharactersBox.Text, character);
        }

        private void ArmorCharacteristics()
        {
            armor.Check(character, Material_ComboBox.SelectedItem.ToString(),
                    Armor_ListBox.SelectedItem.ToString());
            character.AddToArmorName(Armor_ListBox.SelectedItem.ToString());
            character.AddToArmorName(Material_ComboBox.SelectedItem.ToString());
            //character.AddToArmor(armor);
            Strength_Text.Value = character.Strength;
            Dexterity_Text.Value = character.Dexterity;
            Intelligence_Text.Value = character.Intelligence;
            HP_Text.Value = character.HP;
            MP_Text.Value = character.MP;
            PDef_Text.Value = character.PDef;
            Attack_Text.Value = character.Attack;
        }

        private void GO_Button_Click(object sender, EventArgs e)
        {
            MatchCreator matchForm = new MatchCreator();
            matchForm.Show();
        }
    }
}