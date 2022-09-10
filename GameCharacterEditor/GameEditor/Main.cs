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
            string nameOfCharachter = listBoxMain.SelectedItem.ToString();
            Unit infoName = GameEditorLibrary.Units.Info(nameOfCharachter);
            selectedUnit = infoName;
            numericUpDownStr.Minimum = Convert.ToDecimal(infoName.minStrength);
            numericUpDownStr.Maximum = Convert.ToDecimal(infoName.maxStrength);
            numericUpDownDex.Minimum = Convert.ToDecimal(infoName.minDexterity);
            numericUpDownDex.Maximum = Convert.ToDecimal(infoName.maxDexterity);
            numericUpDownCon.Minimum = Convert.ToDecimal(infoName.minConstitution);
            numericUpDownCon.Maximum = Convert.ToDecimal(infoName.maxConstitution);
            numericUpDownInt.Minimum = Convert.ToDecimal(infoName.minIntelligence);
            numericUpDownInt.Maximum = Convert.ToDecimal(infoName.maxIintelligence);

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
                case "GameEditorLibrary.Warrier":
                    selectedUnit.attackDamage += 5 * value;
                    selectedUnit.HP += 2 * value;
                    textBoxAttack.Text = selectedUnit.attackDamage.ToString();
                    textBoxHP.Text = selectedUnit.HP.ToString();
                    break;
                case "GameEditorLibrary.Wizard":
                    break;
                case "GameEditorLibrary.Rogue":
                    break;
                default:
                    break;
            }
        }

        private void ChangingDex(int value)
        {
            switch (selectedUnit.GetType().ToString())
            {
                case "GameEditorLibrary.Warrier":
                    selectedUnit.attackDamage += 1 * value;
                    selectedUnit.phDefention += 1 * value;
                    textBoxAttack.Text = selectedUnit.attackDamage.ToString();
                    break;
                case "GameEditorLibrary.Wizard":
                    break;
                case "GameEditorLibrary.Rogue":
                    break;
                default:
                    break;
            }
        }

        private void ChangingCon(int value)
        {
            switch (selectedUnit.GetType().ToString())
            {
                case "GameEditorLibrary.Warrier":
                    break;
                case "GameEditorLibrary.Wizard":
                    break;
                case "GameEditorLibrary.Rogue":
                    break;
                default:
                    break;
            }
        }

        private void ChangingInt(int value)
        {
            switch (selectedUnit.GetType().ToString())
            {
                case "GameEditorLibrary.Warrier":
                    break;
                case "GameEditorLibrary.Wizard":
                    break;
                case "GameEditorLibrary.Rogue":
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