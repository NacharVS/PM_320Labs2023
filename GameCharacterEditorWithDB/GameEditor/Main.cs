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
            ListUpdate();
            listBoxMain.SetSelected(0,true);
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
            selectedUnit.Strength = ((int)numericUpDownStr.Value);
            textBoxAttack.Text = selectedUnit.attackDamage.ToString();
            textBoxHP.Text = selectedUnit.HP.ToString();
        }

        private void NumericUpDownDex_ValueChanged(object sender, EventArgs e)
        {
            selectedUnit.Dexterity = ((int)numericUpDownDex.Value);
            textBoxAttack.Text = selectedUnit.attackDamage.ToString();
            textBoxPDef.Text = selectedUnit.phDefention.ToString();
        }

        private void NumericUpDownCon_ValueChanged(object sender, EventArgs e)
        {
            selectedUnit.Constitution = ((int)numericUpDownCon.Value);
            textBoxHP.Text = selectedUnit.HP.ToString();
            textBoxPDef.Text = selectedUnit.phDefention.ToString();
        }

        private void NumericUpDownInt_ValueChanged(object sender, EventArgs e)
        {
            selectedUnit.Intelligence = ((int)numericUpDownInt.Value);
            textBoxMana.Text = selectedUnit.MP.ToString();
            textBoxAttackMana.Text = selectedUnit.manaAttack.ToString();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            listBoxRes.Items.Add(selectedUnit.Name);
            DBConnection.AddToDataBase(selectedUnit);
            numericUpDownStr.Value = numericUpDownStr.Minimum;
            numericUpDownCon.Value = numericUpDownCon.Minimum;
            numericUpDownDex.Value = numericUpDownDex.Minimum;
            numericUpDownInt.Value = numericUpDownInt.Minimum;
            textBoxName.Text = "";
        }

        private void TextBoxName_TextChanged(object sender, EventArgs e)
        {
            selectedUnit.Name = textBoxName.Text;
        }

        private void ListBoxRes_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBoxRes.SelectedItems.Count > 0)
            {
                selectedUnit = DBConnection.FindByName(listBoxRes.Text);
                listBoxMain.SelectedItems.Clear();
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
    }
}