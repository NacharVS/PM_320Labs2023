using GameEditorLibrary;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace GameEditor
{
    public partial class Main : Form
    {
        Unit selectedUnit;

        public Main()
        {
            InitializeComponent();
            BsonClassMap.RegisterClassMap<Unit>();
            BsonClassMap.RegisterClassMap<Warrior>();
            BsonClassMap.RegisterClassMap<Rogue>();
            BsonClassMap.RegisterClassMap<Wizard>();
            BsonClassMap.RegisterClassMap<Item>();
            BsonClassMap.RegisterClassMap<Axe>();
            BsonClassMap.RegisterClassMap<Sword>();
            BsonClassMap.RegisterClassMap<Bow>();
            ListUpdate();
            listBoxMain.SetSelected(0, true);
        }

        private void ListBoxMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxMain.SelectedItems.Count > 0)
            {
                string nameOfCharachter = listBoxMain.SelectedItem.ToString();
                Unit infoName = GameEditorLibrary.Units.Info(nameOfCharachter);
                selectedUnit = infoName;
                textBoxName.Text = "";
                numericUpDownStr.Value = selectedUnit.Strength;
                numericUpDownDex.Value = selectedUnit.Dexterity;
                numericUpDownCon.Value = selectedUnit.Constitution;
                numericUpDownInt.Value = selectedUnit.Intelligence;
                listBoxRes.SelectedItems.Clear();
                panelMain.Visible = true;
                secondPanel.Visible = false;
                listBoxItems.Items.Clear();
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
            try
            {
                selectedUnit.Strength = ((int)numericUpDownStr.Value);
                textBoxAttack.Text = selectedUnit.attackDamage.ToString();
                textBoxHP.Text = selectedUnit.HP.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("LIMIT");
            }
        }

        private void NumericUpDownDex_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                selectedUnit.Dexterity = ((int)numericUpDownDex.Value);
                textBoxAttack.Text = selectedUnit.attackDamage.ToString();
                textBoxPDef.Text = selectedUnit.phDefention.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("LIMIT");
            }
        }

        private void NumericUpDownCon_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                selectedUnit.Constitution = ((int)numericUpDownCon.Value);
                textBoxHP.Text = selectedUnit.HP.ToString();
                textBoxPDef.Text = selectedUnit.phDefention.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("LIMIT");
            }
        }

        private void NumericUpDownInt_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                selectedUnit.Intelligence = ((int)numericUpDownInt.Value);
                textBoxMana.Text = selectedUnit.MP.ToString();
                textBoxAttackMana.Text = selectedUnit.manaAttack.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("LIMIT");
            }
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            if (listBoxMain.SelectedItems.Count == 0)
            {
                DBConnection.Replace(selectedUnit);
            }
            else
            {
                try
                {
                    listBoxRes.Items.Add(selectedUnit.Name);
                    DBConnection.AddToDataBase(selectedUnit);
                    numericUpDownStr.Value = numericUpDownStr.Minimum;
                    numericUpDownCon.Value = numericUpDownCon.Minimum;
                    numericUpDownDex.Value = numericUpDownDex.Minimum;
                    numericUpDownInt.Value = numericUpDownInt.Minimum;
                    textBoxName.Text = "";
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void TextBoxName_TextChanged(object sender, EventArgs e)
        {
            selectedUnit.Name = textBoxName.Text;
        }

        private void ListBoxRes_SelectedValueChanged(object sender, EventArgs e)
        {
            listBoxItems.Items.Clear();
            if (listBoxRes.SelectedItems.Count > 0)
            {
                selectedUnit = DBConnection.FindByName(listBoxRes.Text);
                listBoxMain.SelectedItems.Clear();
                textBoxName.Text = selectedUnit.Name;
                numericUpDownStr.Value = selectedUnit.Strength;
                numericUpDownDex.Value = selectedUnit.Dexterity;
                numericUpDownCon.Value = selectedUnit.Constitution;
                numericUpDownInt.Value = selectedUnit.Intelligence;
                panelMain.Visible = false;
                secondPanel.Visible = true;
                foreach (var i in selectedUnit.inventory)
                {
                    listBoxItems.Items.Add(i.ItemName);
                }
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
            Item infoName = GameEditorLibrary.Units.InfoItem(nameOfItem);
            selectedUnit.AddToInventory(infoName);
        }

        private void SecondComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nameOfItem = secondComboBox.SelectedItem.ToString();
            Item infoName = GameEditorLibrary.Units.InfoItem(nameOfItem);
            selectedUnit.AddToInventory(infoName);
        }

        private void ThirdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nameOfItem = thirdComboBox.SelectedItem.ToString();
            Item infoName = GameEditorLibrary.Units.InfoItem(nameOfItem);
            selectedUnit.AddToInventory(infoName);
        }
    }
}