using GameEditorLibrary;

namespace GameEditor
{
    public partial class Main : Form
    {
        Unit selectedUnit = new Unit();
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
            int value = (int)numericUpDownStr.Value - selectedUnit.strength;
            selectedUnit.strength = ((int)numericUpDownStr.Value);
            ChangingStr(value);
        }

        private void ChangingStr(int value)
        {
            switch (selectedUnit.GetType().ToString())
            {
                case "GameEditorLibrary.Warrior":
                    selectedUnit.attackDamage += 5 * value;
                    selectedUnit.HP += 2 * value;
                    textBoxAttack.Text = selectedUnit.attackDamage.ToString();
                    textBoxHP.Text = selectedUnit.HP.ToString();
                    break;
                case "GameEditorLibrary.Wizard":
                    selectedUnit.attackDamage += 2 * value;
                    selectedUnit.HP += 1 * value;
                    textBoxAttack.Text = selectedUnit.attackDamage.ToString();
                    textBoxHP.Text = selectedUnit.HP.ToString();
                    break;
                case "GameEditorLibrary.Rogue":
                    selectedUnit.attackDamage += 2 * value;
                    selectedUnit.HP += 1 * value;
                    textBoxAttack.Text = selectedUnit.attackDamage.ToString();
                    textBoxHP.Text = selectedUnit.HP.ToString();
                    break;
                default:
                    break;
            }
        }

        private void ChangingDex(int value)
        {
            switch (selectedUnit.GetType().ToString())
            {
                case "GameEditorLibrary.Warrior":
                    selectedUnit.attackDamage += 1 * value;
                    selectedUnit.phDefention += 1 * value;
                    textBoxAttack.Text = selectedUnit.attackDamage.ToString();
                    textBoxPDef.Text = selectedUnit.phDefention.ToString();
                    break;
                case "GameEditorLibrary.Wizard":
                    selectedUnit.phDefention += 0.5 * value;
                    textBoxPDef.Text = selectedUnit.phDefention.ToString();
                    break;
                case "GameEditorLibrary.Rogue":
                    selectedUnit.attackDamage += 4 * value;
                    selectedUnit.phDefention += 1.5 * value;
                    textBoxAttack.Text = selectedUnit.attackDamage.ToString();
                    textBoxPDef.Text = selectedUnit.phDefention.ToString();
                    break;
                default:
                    break;
            }
        }

        private void ChangingCon(int value)
        {
            switch (selectedUnit.GetType().ToString())
            {
                case "GameEditorLibrary.Warrior":
                    selectedUnit.HP += 10 * value;
                    selectedUnit.phDefention += 2 * value;
                    textBoxHP.Text = selectedUnit.HP.ToString();
                    textBoxPDef.Text = selectedUnit.phDefention.ToString();
                    break;
                case "GameEditorLibrary.Wizard":
                    selectedUnit.HP += 3 * value;
                    selectedUnit.phDefention += 1 * value;
                    textBoxHP.Text = selectedUnit.HP.ToString();
                    textBoxPDef.Text = selectedUnit.phDefention.ToString();
                    break;
                case "GameEditorLibrary.Rogue":
                    selectedUnit.HP += 6 * value;
                    textBoxHP.Text = selectedUnit.HP.ToString();
                    break;
                default:
                    break;
            }
        }

        private void ChangingInt(int value)
        {
            switch (selectedUnit.GetType().ToString())
            {
                case "GameEditorLibrary.Warrior":
                    selectedUnit.MP += 1 * value;
                    selectedUnit.manaAttack += 1 * value;
                    textBoxMana.Text = selectedUnit.MP.ToString();
                    textBoxAttackMana.Text = selectedUnit.manaAttack.ToString();
                    break;
                case "GameEditorLibrary.Wizard":
                    selectedUnit.MP += 2 * value;
                    selectedUnit.manaAttack += 5 * value;
                    textBoxMana.Text = selectedUnit.MP.ToString();
                    textBoxAttackMana.Text = selectedUnit.manaAttack.ToString();
                    break;
                case "GameEditorLibrary.Rogue":
                    selectedUnit.MP += 1.5 * value;
                    selectedUnit.manaAttack += 2 * value;
                    textBoxMana.Text = selectedUnit.MP.ToString();
                    textBoxAttackMana.Text = selectedUnit.manaAttack.ToString();
                    break;
                default:
                    break;
            }
        }

        private void NumericUpDownDex_ValueChanged(object sender, EventArgs e)
        {
            int value = (int)numericUpDownDex.Value - selectedUnit.dexterity;
            selectedUnit.dexterity = ((int)numericUpDownDex.Value);
            ChangingDex(value);
        }

        private void NumericUpDownCon_ValueChanged(object sender, EventArgs e)
        {
            int value = (int)numericUpDownCon.Value - selectedUnit.constitution;
            selectedUnit.constitution = ((int)numericUpDownCon.Value);
            ChangingCon(value);
        }

        private void NumericUpDownInt_ValueChanged(object sender, EventArgs e)
        {
            int value = (int)numericUpDownInt.Value - selectedUnit.intelligence;
            selectedUnit.intelligence = ((int)numericUpDownInt.Value);
            ChangingInt(value);
        }
    }
}