using Characters;

namespace CharacterEditor
{
    public partial class CharacterEditor : Form
    {
        private Character _selectedCharacter;
        private int _countOfPoints;

        public CharacterEditor()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCreateCharacter_Click(object sender, EventArgs e)
        {
            if (lbCharacters.SelectedItem != null)
            {
                switch (lbCharacters.SelectedItem.ToString())
                {
                    case "Warrior":
                        _selectedCharacter = new Warrior();
                        break;

                    case "Rogue":
                        _selectedCharacter = new Rogue();
                        break;

                    case "Wizard":
                        _selectedCharacter = new Wizard();
                        break;

                    default:
                        break;
                }

                FillingInCharacteristics();
                _countOfPoints = 99;
                tbCountOfPoints.Text = _countOfPoints.ToString();
            }

        }

        private void FillingInCharacteristics()
        {
            tbStrength.Text = _selectedCharacter.Strength.ToString();
            tbDexterity.Text = _selectedCharacter.Dexterity.ToString();
            tbConstitution.Text = _selectedCharacter.Constitution.ToString();
            tbInteligence.Text = _selectedCharacter.Inteligence.ToString();
            tbHP.Text = _selectedCharacter.HP.ToString();
            tbMP.Text = _selectedCharacter.MP.ToString();
            tbDamage.Text = _selectedCharacter.Damage.ToString();
            tbPhysDef.Text = _selectedCharacter.PhysDef.ToString();
            tbMagDamage.Text = _selectedCharacter.MagDamage.ToString();
        }

        private void btnIncreaseStrength_Click(object sender, EventArgs e)
        {
            if (_selectedCharacter != null && _countOfPoints > 0 
                && _selectedCharacter.Strength + 1 <= _selectedCharacter.MaxStrength)
            {
                switch (_selectedCharacter.GetType().Name.ToString())
                {
                    case "Warrior":
                        ((Warrior)_selectedCharacter).Strength++;
                        break;

                    case "Rogue":
                        ((Rogue)_selectedCharacter).Strength++;
                        break;

                    case "Wizard":
                        ((Wizard)_selectedCharacter).Strength++;
                        break;

                    default:
                        break;
                }

                AfterIncreasing();
            }
        }

        private void btnIncreaseDexterity_Click(object sender, EventArgs e)
        {
            if (_selectedCharacter != null && _countOfPoints > 0
                && _selectedCharacter.Dexterity + 1 <= _selectedCharacter.MaxDexterity)
            {
                switch (_selectedCharacter.GetType().Name.ToString())
                {
                    case "Warrior":
                        ((Warrior)_selectedCharacter).Dexterity++;
                        break;

                    case "Rogue":
                        ((Rogue)_selectedCharacter).Dexterity ++;
                        break;

                    case "Wizard":
                        ((Wizard)_selectedCharacter).Dexterity++;
                        break;

                    default:
                        break;
                }

                AfterIncreasing();
            }          
        }

        private void btnIncreaseConstitution_Click(object sender, EventArgs e)
        {
            if (_selectedCharacter != null && _countOfPoints > 0
                && _selectedCharacter.Constitution + 1 <= _selectedCharacter.MaxConstitution)
            {
                switch (_selectedCharacter.GetType().Name.ToString())
                {
                    case "Warrior":
                        ((Warrior)_selectedCharacter).Constitution++;
                        break;

                    case "Rogue":
                        ((Rogue)_selectedCharacter).Constitution++;
                        break;

                    case "Wizard":
                        ((Wizard)_selectedCharacter).Constitution++;
                        break;

                    default:
                        break;
                }

                AfterIncreasing();
            }
        }

        private void btnIncreaseInteligence_Click(object sender, EventArgs e)
        {
            if (_selectedCharacter != null && _countOfPoints > 0
                && _selectedCharacter.Inteligence + 1 <= _selectedCharacter.MaxInteligence)
            {
                switch (_selectedCharacter.GetType().Name.ToString())
                {
                    case "Warrior":
                        ((Warrior)_selectedCharacter).Inteligence++;
                        break;

                    case "Rogue":
                        ((Rogue)_selectedCharacter).Inteligence++;
                        break;

                    case "Wizard":
                        ((Wizard)_selectedCharacter).Inteligence++;
                        break;

                    default:
                        break;
                }

                AfterIncreasing();
            }
        }

        private void AfterIncreasing()
        {
            FillingInCharacteristics();
            _countOfPoints--;
            tbCountOfPoints.Text = _countOfPoints.ToString();
        }

        private void btnSaveCharacter_Click(object sender, EventArgs e)
        {
            if (_selectedCharacter != null)
            {
                SaveFileDialog save = new SaveFileDialog();

                save.Filter = "txt files (*.txt)|*.txt";
                save.FilterIndex = 2;
                save.RestoreDirectory = true;

                if (save.ShowDialog() == DialogResult.OK)
                {
                    _selectedCharacter.Save(save.FileName);
                    MessageBox.Show("Character saved", "Success!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}