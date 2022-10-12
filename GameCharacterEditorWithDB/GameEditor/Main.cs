using GameEditorLibrary;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace GameEditor
{
    public partial class Main : Form
    {
        Unit selectedUnit;
        bool checking = false;

        public Main()
        {
            InitializeComponent();
            BsonClassMap.RegisterClassMap<Unit>();
            BsonClassMap.RegisterClassMap<Warrior>();
            BsonClassMap.RegisterClassMap<Rogue>();
            BsonClassMap.RegisterClassMap<Wizard>();
            BsonClassMap.RegisterClassMap<Item>();
            ListUpdate();
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            listBoxMain.SetSelected(0, true);
        }

        public Main(string name)
        {
            InitializeComponent();
            ListUpdate();
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            listBoxRes.SelectedIndex = listBoxRes.Items.IndexOf(name);
        }

        private void ListBoxMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxOfBoots.SelectedItems.Clear();
            listBoxOfChestplates.SelectedItems.Clear();
            listBoxOfHelmets.SelectedItems.Clear();

            if (listBoxMain.SelectedItems.Count > 0)
            {
                listBoxSkills.Items.Clear();
                string nameOfCharachter = listBoxMain.SelectedItem.ToString();
                Unit infoName = GameEditorLibrary.Units.Info(nameOfCharachter);
                selectedUnit = infoName;
                textBoxName.Text = "";
                numericUpDownStr.Value = selectedUnit.Strength;
                numericUpDownDex.Value = selectedUnit.Dexterity;
                numericUpDownCon.Value = selectedUnit.Constitution;
                numericUpDownInt.Value = selectedUnit.Intelligence;
                numericUpDownExpa.Value = selectedUnit.CurrentExpa;
                textBoxMana.Text = selectedUnit.MP.ToString();
                textBoxAttackMana.Text = selectedUnit.manaAttack.ToString();
                textBoxHP.Text = selectedUnit.HP.ToString();
                textBoxAttack.Text = selectedUnit.attackDamage.ToString();
                textBoxPDef.Text = selectedUnit.phDefention.ToString();
                textBoxPoints.Text = selectedUnit.points.ToString();
                numericUpDownLevel.Value = selectedUnit.Level;
                listBoxRes.SelectedItems.Clear();
                panelMain.Visible = true;
                secondPanel.Visible = false;
                listBoxItems.Items.Clear();
                checking = true;
            }
            else
            {
                textBoxName.Text = selectedUnit.Name;
                numericUpDownStr.Value = selectedUnit.Strength;
                numericUpDownDex.Value = selectedUnit.Dexterity;
                numericUpDownCon.Value = selectedUnit.Constitution;
                numericUpDownInt.Value = selectedUnit.Intelligence;
            }
        }

        private void NumericUpDownStr_ValueChanged(object sender, EventArgs e)
        {
            if (checking == true)
            {
                if (selectedUnit.points > 0)
                {
                    try
                    {
                        selectedUnit.Strength = ((int)numericUpDownStr.Value);
                        textBoxAttack.Text = selectedUnit.attackDamage.ToString();
                        textBoxHP.Text = selectedUnit.HP.ToString();
                        selectedUnit.points--;
                    }
                    catch (Exception ex)
                    {
                        selectedUnit.points++;
                        numericUpDownStr.Value = selectedUnit.Strength;
                    }
                }
                else
                {
                    numericUpDownStr.Value = selectedUnit.Strength;
                }
            }
            else
            {
                try
                {
                    selectedUnit.Strength = ((int)numericUpDownStr.Value);
                    textBoxAttack.Text = selectedUnit.attackDamage.ToString();
                    textBoxHP.Text = selectedUnit.HP.ToString();
                }
                catch (Exception ex)
                {
                    numericUpDownStr.Value = selectedUnit.Strength;
                }
            }
            textBoxPoints.Text = selectedUnit.points.ToString();
        }

        private void NumericUpDownDex_ValueChanged(object sender, EventArgs e)
        {
            if (checking == true)
            { 
                if (selectedUnit.points > 0)
                {
                    try
                    {
                        selectedUnit.Dexterity = ((int)numericUpDownDex.Value);
                        textBoxAttack.Text = selectedUnit.attackDamage.ToString();
                        textBoxPDef.Text = selectedUnit.phDefention.ToString();
                        selectedUnit.points--;
                        textBoxPoints.Text = selectedUnit.points.ToString();
                    }
                    catch (Exception ex)
                    {
                        selectedUnit.points++;
                        numericUpDownDex.Value = selectedUnit.Dexterity;
                    }
                }
                else
                {
                    numericUpDownDex.Value = selectedUnit.Dexterity;
                }
            }
            else
            {
                try
                {
                    selectedUnit.Dexterity = ((int)numericUpDownDex.Value);
                    textBoxAttack.Text = selectedUnit.attackDamage.ToString();
                    textBoxPDef.Text = selectedUnit.phDefention.ToString();
                }
                catch (Exception ex)
                {
                    numericUpDownDex.Value = selectedUnit.Dexterity;
                }
            }
        }

        private void NumericUpDownCon_ValueChanged(object sender, EventArgs e)
        {
            if (checking == true)
            {
                if (selectedUnit.points > 0)
                {
                    try
                    {
                        selectedUnit.Constitution = ((int)numericUpDownCon.Value);
                        textBoxHP.Text = selectedUnit.HP.ToString();
                        textBoxPDef.Text = selectedUnit.phDefention.ToString();
                        selectedUnit.points--;
                        textBoxPoints.Text = selectedUnit.points.ToString();
                    }
                    catch (Exception ex)
                    {
                        selectedUnit.points++;
                        numericUpDownCon.Value = selectedUnit.Constitution;
                    }
                }
                else
                {
                    numericUpDownCon.Value = selectedUnit.Constitution;
                }
            }
            else
            {
                try
                {
                    selectedUnit.Constitution = ((int)numericUpDownCon.Value);
                    textBoxHP.Text = selectedUnit.HP.ToString();
                    textBoxPDef.Text = selectedUnit.phDefention.ToString();
                }
                catch (Exception ex)
                {
                    numericUpDownCon.Value = selectedUnit.Constitution;
                }
            }
        }

        private void NumericUpDownInt_ValueChanged(object sender, EventArgs e)
        {
            if (checking == true)
            {
                if (selectedUnit.points > 0)
                {
                    try
                    {
                        selectedUnit.Intelligence = ((int)numericUpDownInt.Value);
                        textBoxMana.Text = selectedUnit.MP.ToString();
                        textBoxAttackMana.Text = selectedUnit.manaAttack.ToString();
                        selectedUnit.points--;
                        textBoxPoints.Text = selectedUnit.points.ToString();
                    }
                    catch (Exception ex)
                    {
                        selectedUnit.points++;
                        numericUpDownInt.Value = selectedUnit.Intelligence;
                    }
                }
                else
                {
                    numericUpDownInt.Value = selectedUnit.Intelligence;
                }
            }
            else
            {
                try
                {
                    selectedUnit.Intelligence = ((int)numericUpDownInt.Value);
                    textBoxMana.Text = selectedUnit.MP.ToString();
                    textBoxAttackMana.Text = selectedUnit.manaAttack.ToString();
                }
                catch (Exception ex)
                {
                    numericUpDownInt.Value = selectedUnit.Intelligence;
                }
            }
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            if (listBoxMain.SelectedItems.Count == 0)
            {
                if (selectedUnit.helmet is not null) { selectedUnit.helmet.ChangeStatistic(selectedUnit, selectedUnit.helmet.Material, false); }
                if (selectedUnit.chestplate is not null) { selectedUnit.chestplate.ChangeStatistic(selectedUnit, selectedUnit.chestplate.Material, false); }
                if (selectedUnit.boots is not null) { selectedUnit.boots.ChangeStatistic(selectedUnit, selectedUnit.boots.Material, false); }
                DBConnection.Replace(selectedUnit);
            }
            else
            {
                try
                {
                    listBoxRes.Items.Add(selectedUnit.Name);
                    DBConnection.AddToDataBase(selectedUnit);
                    panel1.Visible = false;
                    panel2.Visible = false;
                    panel3.Visible = false;
                    listBoxMain.SetSelected(0, true);
                    textBoxName.Text = "";
                    listBoxSkills.Items.Clear();
                }
                catch (Exception ex) { }
            }
        }

        private void TextBoxName_TextChanged(object sender, EventArgs e)
        {
            selectedUnit.Name = textBoxName.Text;
        }

        private void ListBoxRes_SelectedValueChanged(object sender, EventArgs e)
        {
            checking = false;
            listBoxItems.Items.Clear();
            listBoxSkills.Items.Clear();
            textBoxPoints.Clear();

            if (listBoxRes.SelectedItems.Count > 0)
            {
                selectedUnit = DBConnection.FindByName(listBoxRes.Text);
                listBoxOfBoots.SelectedItems.Clear();
                listBoxOfChestplates.SelectedItems.Clear();
                listBoxOfHelmets.SelectedItems.Clear();
                listBoxMain.SelectedItems.Clear();

                textBoxName.Text = selectedUnit.Name;
                numericUpDownStr.Value = selectedUnit.Strength;
                numericUpDownDex.Value = selectedUnit.Dexterity;
                numericUpDownCon.Value = selectedUnit.Constitution;
                numericUpDownInt.Value = selectedUnit.Intelligence;
                if (selectedUnit.lvlc == true) 
                {
                    selectedUnit.Level--;
                }
                numericUpDownLevel.Value = selectedUnit.Level;
                numericUpDownExpa.Value = selectedUnit.CurrentExpa;

                if (selectedUnit.helmet is not null) 
                { listBoxOfHelmets.SelectedIndex = listBoxOfHelmets.Items.IndexOf(selectedUnit.helmet.Material); }
                if (selectedUnit.chestplate is not null) 
                { listBoxOfChestplates.SelectedIndex = listBoxOfChestplates.Items.IndexOf(selectedUnit.chestplate.Material); }
                if (selectedUnit.boots is not null) 
                { listBoxOfBoots.SelectedIndex = listBoxOfBoots.Items.IndexOf(selectedUnit.boots.Material); }
                if (selectedUnit.points == 0) 
                { textBoxPoints.Text = (selectedUnit.points).ToString(); }
                else 
                {
                    selectedUnit.points -= 5;
                    textBoxPoints.Text = (selectedUnit.points).ToString(); 
                }
                numericUpDownExpa.Value = selectedUnit.CurrentExpa;
                listBoxSkills.Visible = true;
                panelMain.Visible = false;
                secondPanel.Visible = true;
                foreach (var i in selectedUnit.inventory)
                {
                    listBoxItems.Items.Add(i.ItemName);
                }
                foreach (var i in selectedUnit.skills)
                {
                    listBoxSkills.Items.Add(i.SkillName);
                }
                checking = true;
            }
        }
        private void ListUpdate()
        {
            var collection = DBConnection.ImportData();
            foreach (var post in collection)
            {
                listBoxRes.Items.Add(post.Name);
            }
        }

        private void FirstComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nameOfItem = firstComboBox.SelectedItem.ToString();
            selectedUnit.AddToInventory(new Item(nameOfItem));
        }

        private void SecondComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nameOfItem = secondComboBox.SelectedItem.ToString();
            selectedUnit.AddToInventory(new Item(nameOfItem));
        }

        private void ThirdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nameOfItem = thirdComboBox.SelectedItem.ToString();
            selectedUnit.AddToInventory(new Item(nameOfItem));
        }

        private void NumericUpDownExpa_ValueChanged(object sender, EventArgs e)
        {
            selectedUnit.CurrentExpa = ((int)numericUpDownExpa.Value);
            numericUpDownLevel.Value = selectedUnit.Level;
            textBoxPoints.Text = selectedUnit.points.ToString();
        }

        private void NumericUpDownLevel_ValueChanged(object sender, EventArgs e)
        {
            if (selectedUnit.Level > 0 && selectedUnit.Level % 3 == 0)
            {
                switch (selectedUnit.typeOfUnit)
                {
                    case ("Warrior"):
                        if (selectedUnit.skills.Count < selectedUnit.Level / 3)
                        {
                            panel1.Visible = true;
                            skillsWarComboBox.Items.Clear();
                            skillsWarComboBox.Items.Add($"InvisibilityX{selectedUnit.Level / 3}");
                            skillsWarComboBox.Items.Add($"FireBallX{selectedUnit.Level / 3}");
                            skillsWarComboBox.Items.Add($"Speed X{selectedUnit.Level / 3}");
                        }
                        else 
                        {
                            panel1.Visible = false;
                        }
                        break;
                    case ("Rogue"):
                        if (selectedUnit.skills.Count < selectedUnit.Level / 3)
                        {
                            panel2.Visible = true;
                            skillsRogComboBox.Items.Clear();
                            skillsRogComboBox.Items.Add($"VanishX{selectedUnit.Level / 3}");
                            skillsRogComboBox.Items.Add($"StealthX{selectedUnit.Level / 3}");
                            skillsRogComboBox.Items.Add($"DistractX{selectedUnit.Level / 3}");
                        }
                        else
                        {
                            panel2.Visible = false;
                        }
                        break;
                    case ("Wizard"):
                        if (selectedUnit.skills.Count < selectedUnit.Level / 3)
                        {
                            panel3.Visible = true;
                            skillsWizComboBox.Items.Clear();
                            skillsWizComboBox.Items.Add($"InvisibilityX{selectedUnit.Level / 3}");
                            skillsWizComboBox.Items.Add($"Blood MageX{selectedUnit.Level / 3}");
                            skillsWizComboBox.Items.Add($"Chill FogX{selectedUnit.Level / 3}");
                        }
                        else
                        {
                            panel3.Visible = false;
                        }
                        break;
                }
            }
            else
            {
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
            }
        }

        private void SkillsWarComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Skill skill = new Skill(skillsWarComboBox.SelectedItem.ToString());
            selectedUnit.AddToSkills(skill);
            listBoxSkills.Visible = true;
            listBoxSkills.Items.Add(skill.SkillName);
            panel1.Visible = false;
        }

        private void SkillsRogComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Skill skill = new Skill(skillsRogComboBox.SelectedItem.ToString());
            selectedUnit.AddToSkills(skill);
            listBoxSkills.Visible = true;
            listBoxSkills.Items.Add(skill.SkillName);
            panel2.Visible = false;
        }

        private void SkillsWizComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Skill skill = new Skill(skillsWizComboBox.SelectedItem.ToString());
            selectedUnit.AddToSkills(skill);
            listBoxSkills.Visible = true;
            listBoxSkills.Items.Add(skill.SkillName);
            panel1.Visible = false;
        }

        private void ListBoxOfHelmets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DBConnection.FindByName(selectedUnit.Name) != null && listBoxOfHelmets.SelectedItems.Count > 0)
            {
                if (selectedUnit.helmet is null || checking == false)
                {
                    selectedUnit.helmet = new Helmet(listBoxOfHelmets.SelectedItem.ToString());
                    selectedUnit.helmet.ChangeStatistic(selectedUnit, listBoxOfHelmets.SelectedItem.ToString(), true);
                    UpdateStat();
                }
                else
                {
                    selectedUnit.helmet.ChangeStatistic(selectedUnit, selectedUnit.helmet.Material, false);
                    selectedUnit.helmet = new Helmet(listBoxOfHelmets.SelectedItem.ToString());
                    selectedUnit.helmet.ChangeStatistic(selectedUnit, listBoxOfHelmets.SelectedItem.ToString(), true);
                    UpdateStat();
                }
                DBConnection.Update(selectedUnit);
            }
        }

        private void ListBoxOfChestplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DBConnection.FindByName(selectedUnit.Name) != null && listBoxOfChestplates.SelectedItems.Count > 0)
            {
                if (selectedUnit.chestplate is null || checking == false)
                {
                    selectedUnit.chestplate = new Chestplate(listBoxOfChestplates.SelectedItem.ToString());
                    selectedUnit.chestplate.ChangeStatistic(selectedUnit, listBoxOfChestplates.SelectedItem.ToString(), true);
                    UpdateStat();
                }
                else
                {
                    selectedUnit.chestplate.ChangeStatistic(selectedUnit, selectedUnit.chestplate.Material, false);
                    selectedUnit.chestplate = new Chestplate(listBoxOfChestplates.SelectedItem.ToString());
                    selectedUnit.chestplate.ChangeStatistic(selectedUnit, listBoxOfChestplates.SelectedItem.ToString(), true);
                    UpdateStat();
                }
                DBConnection.Update(selectedUnit);
            }
        }

        private void ListBoxOfBoots_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DBConnection.FindByName(selectedUnit.Name) != null && listBoxOfBoots.SelectedItems.Count > 0)
            {
                if (selectedUnit.boots is null || checking == false)
                {
                    selectedUnit.boots = new Boots(listBoxOfBoots.SelectedItem.ToString());
                    selectedUnit.boots.ChangeStatistic(selectedUnit, listBoxOfBoots.SelectedItem.ToString(), true);
                    UpdateStat();
                }
                else
                {
                    selectedUnit.boots.ChangeStatistic(selectedUnit, selectedUnit.boots.Material, false);
                    selectedUnit.boots = new Boots(listBoxOfBoots.SelectedItem.ToString());
                    selectedUnit.boots.ChangeStatistic(selectedUnit, listBoxOfBoots.SelectedItem.ToString(), true);
                    UpdateStat();
                }
                DBConnection.Update(selectedUnit);
            }
        }

        private void UpdateStat()
        {
            numericUpDownStr.Value = selectedUnit.Strength;
            numericUpDownCon.Value = selectedUnit.Constitution;
            numericUpDownDex.Value = selectedUnit.Dexterity;
            numericUpDownInt.Value = selectedUnit.Intelligence;
            textBoxPDef.Text = selectedUnit.phDefention.ToString();
            textBoxHP.Text = selectedUnit.HP.ToString();
            textBoxMana.Text = selectedUnit.MP.ToString();
            textBoxAttack.Text = selectedUnit.attackDamage.ToString();
            textBoxAttackMana.Text = selectedUnit.manaAttack.ToString();
        }

        private void GameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SecondForm frm = new SecondForm(this, listBoxRes);
            frm.Show();
        }
    }
}