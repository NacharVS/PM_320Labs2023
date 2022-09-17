using GameEditorLibrary;

namespace GameEditor
{
    public partial class Main : Form
    {
        Unit selectedUnit;
        public Main()
        {
            InitializeComponent();
        }

        private void ListBoxMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            Units.Clear();
            string nameOfCharachter = listBoxMain.SelectedItem.ToString();
            Unit infoName = GameEditorLibrary.Units.Info(nameOfCharachter);
            selectedUnit = infoName;
            numericUpDownStr.Minimum = Convert.ToDecimal(infoName.minStrength);
            numericUpDownStr.Maximum = Convert.ToDecimal(infoName.maxStrength);
            numericUpDownStr.Value = numericUpDownStr.Minimum;
            numericUpDownDex.Minimum = Convert.ToDecimal(infoName.minDexterity);
            numericUpDownDex.Maximum = Convert.ToDecimal(infoName.maxDexterity);
            numericUpDownDex.Value = numericUpDownDex.Minimum;
            numericUpDownCon.Minimum = Convert.ToDecimal(infoName.minConstitution);
            numericUpDownCon.Maximum = Convert.ToDecimal(infoName.maxConstitution);
            numericUpDownCon.Value = numericUpDownCon.Minimum;
            numericUpDownInt.Minimum = Convert.ToDecimal(infoName.minIntelligence);
            numericUpDownInt.Maximum = Convert.ToDecimal(infoName.maxIintelligence);
            numericUpDownInt.Value = numericUpDownInt.Minimum;
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
            listBoxRes.Items.Add($"{selectedUnit} : {selectedUnit.Strength}");
        }
    }
}