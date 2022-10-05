using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using CharacterEditor;
using CharacterEditorCore;
using CharacterEditorMongoDataBase;

namespace UnitsEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<string> _characterNames;
        private BaseCharacteristics _selectedCharacter;
        public readonly CharacterEditorContext CharContext;

        private delegate void CharacteristicChangeDelegate();
        private delegate void ExpChangeDelegate();

        public MainWindow()
        {
            InitializeComponent();
            CharContext = new CharacterEditorContext();

            _characterNames = new List<string>
            { "Warrior", "Rogue", "Wizard"};

            cbNewCharacters.ItemsSource = _characterNames;
            cbExistCharacters.ItemsSource = CharContext.GetAllChars();

            ExpChangeEvent += FillCharacterInfo;
            lbAbilities.DisplayMemberPath = "Name";
        }

        private void NewCharComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbNewCharacters.SelectedItem is null)
            {
                return;
            }
            var selectedCharacter = cbNewCharacters.SelectedItem.ToString();
            tbCharacterName.Text = "";
            cbExistCharacters.SelectedItem = null;
            lbAbilities.Items.Clear();

            switch (selectedCharacter)
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
                    throw new Exception("Not correct Character!");
            }

            FillAbilities();
            CharacteristicChangeEvent += _selectedCharacter.SetDefStats;
            CharacteristicChangeEvent += FillCharacterInfo;
            _selectedCharacter.Lvl.OnLevelUpEvent += _selectedCharacter.AddCharacteristics;
            CharacteristicChangeEvent?.Invoke();

            _selectedCharacter.Lvl.OnLevelUpEvent += AddAbility;
        }

        public void FillCharacterInfo()
        {
            if (_selectedCharacter == null)
            {
                lbStrengthValue.Content = 0;
                lbDexterityValue.Content = 0;
                lbConstitutionValue.Content = 0;
                lbIntelligenceValue.Content = 0;
                lblExp.Content = 0;
                lblLvl.Content = 0;
                lbAbilities.Items.Clear();

                tbAttackDamageValue.Text = "0";
                tbHealthValue.Text = "0";
                tbManaValue.Text = "0";
                tbPhysicalDefValue.Text = "0";
                tbMagicAttackValue.Text = "0";
                tbCharacterName.Text = "";
                return;
            }
            try
            {
                lbStrengthValue.Content = Convert.ToString(_selectedCharacter.Strength.Value);
                lbDexterityValue.Content = Convert.ToString(_selectedCharacter.Dexterity.Value);
                lbConstitutionValue.Content = Convert.ToString(_selectedCharacter.Constitution.Value);
                lbIntelligenceValue.Content = Convert.ToString(_selectedCharacter.Intelligence.Value);
                lblExp.Content = Convert.ToString(_selectedCharacter.Lvl.CurrentExp);
                lblLvl.Content = _selectedCharacter.Lvl.CurrentLevel;

                tbAttackDamageValue.Text = Convert.ToString(_selectedCharacter.AttackDamage);
                tbHealthValue.Text = Convert.ToString(_selectedCharacter.HealthPoint);
                tbManaValue.Text = Convert.ToString(_selectedCharacter.ManaPoint);
                tbPhysicalDefValue.Text = Convert.ToString(_selectedCharacter.PhysicalDef);
                tbMagicAttackValue.Text = Convert.ToString(_selectedCharacter.MagicAttack);
            }
            catch { }
        }

        #region CharacteristicsChangeBtns
        private void BtnPlusStrength_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _selectedCharacter.Strength.Value += 1;
                lbStrengthValue.Content = Convert.ToString(_selectedCharacter.Strength.Value);
            }
            catch { }
        }

        private void BtnMinusStrength_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _selectedCharacter.Strength.Value -= 1;
                lbStrengthValue.Content = Convert.ToString(_selectedCharacter.Strength.Value);
            }
            catch { }
        }

        private void BtnPlusDexterity_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _selectedCharacter.Dexterity.Value += 1;
                lbDexterityValue.Content = Convert.ToString(_selectedCharacter.Dexterity.Value);
            }
            catch { }
        }

        private void BtnMinusDexterity_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _selectedCharacter.Dexterity.Value -= 1;
                lbDexterityValue.Content = Convert.ToString(_selectedCharacter.Dexterity.Value); ;
            }
            catch { }
        }

        private void BtnMinusConstitution_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _selectedCharacter.Constitution.Value -= 1;
                lbConstitutionValue.Content = Convert.ToString(_selectedCharacter.Constitution.Value);
            }
            catch { }
        }

        private void BtnPlusConstitution_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _selectedCharacter.Constitution.Value += 1;
                lbConstitutionValue.Content = Convert.ToString(_selectedCharacter.Constitution.Value);
            }
            catch { }
        }

        private void BtnPlusIntelligence_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _selectedCharacter.Intelligence.Value += 1;
                lbIntelligenceValue.Content = Convert.ToString(_selectedCharacter.Intelligence.Value);
            }
            catch { }
        }

        private void BtnMinusIntelligence_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _selectedCharacter.Intelligence.Value -= 1;
                lbIntelligenceValue.Content = Convert.ToString(_selectedCharacter.Intelligence.Value);
            }
            catch { }
        }

        private void CharacteristicChange(object sender, RoutedEventArgs e)
        {
            if (_selectedCharacter is null)
            {
                return;
            }
            CharacteristicChangeEvent?.Invoke();
        }
        #endregion

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbExistCharacters.SelectedItem is not null)
                {
                    if (tbCharacterName.Text != "")
                    {
                        _selectedCharacter.Name = tbCharacterName.Text;
                        if (CharContext.UpdateCharacterInDb(
                            ((CharacterIdName)cbExistCharacters.SelectedItem).Id,
                            _selectedCharacter))

                        {
                            cbExistCharacters.ItemsSource = CharContext.GetAllChars();
                            cbNewCharacters.SelectedIndex = -1;
                            _selectedCharacter = null;
                            FillCharacterInfo();
                            MessageBox.Show("Update succesfull");
                            return;
                        }
                    }
                }

                if (tbCharacterName.Text != "")
                {
                    _selectedCharacter.Name = tbCharacterName.Text;
                    if (CharContext.AddCharacterToDb(_selectedCharacter))
                    {
                        cbExistCharacters.ItemsSource = CharContext.GetAllChars();
                        cbNewCharacters.SelectedIndex = -1;
                        _selectedCharacter = null;
                        FillCharacterInfo();
                        MessageBox.Show("Save succesfull");
                    }
                }
            }
            catch { }

        }

        private void ExtCharComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var charInDb = (CharacterIdName)cbExistCharacters.SelectedItem;
            if( charInDb is not null)
            {
                tbCharacterName.Text = charInDb.Name;

                var findCharacter = CharContext.GetCharacter(charInDb.Id);
                if (findCharacter is not null)
                {
                    _selectedCharacter = findCharacter;
                    cbNewCharacters.SelectedItem = null;
                    lbAbilities.Items.Clear();
                    FillAbilities();

                    CharacteristicChangeEvent += _selectedCharacter.SetDefStats;
                    CharacteristicChangeEvent += FillCharacterInfo;
                    _selectedCharacter.Lvl.OnLevelUpEvent += _selectedCharacter.AddCharacteristics;
                    CharacteristicChangeEvent?.Invoke();

                    _selectedCharacter.Lvl.OnLevelUpEvent += AddAbility;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedCharacter is not null)
            {
                if (cbExistCharacters.SelectedItem is not null)
                {
                    var charInDb = (CharacterIdName)cbExistCharacters.SelectedItem;
                    if (charInDb is not null)
                    {
                        tbCharacterName.Text = charInDb.Name;

                        _selectedCharacter.Name = tbCharacterName.Text;
                        var inventWindow = new Inventory(_selectedCharacter, this);
                        inventWindow.Show();
                    }
                }
            }
            if (cbNewCharacters.SelectedItem is not null)
            {
                _selectedCharacter.Name = tbCharacterName.Text;
                var inventWindow = new Inventory( _selectedCharacter,this);

                inventWindow.Show();
            }
            if (cbNewCharacters.SelectedItem is null && _selectedCharacter is null)
            {
                MessageBox.Show("Select chatacter!");
            }
        }

        private void ExpChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var clickedBtn = (Button)sender;

                switch (clickedBtn.Name)
                {
                    case "ExpAdd1":
                        _selectedCharacter.Lvl.AddExp(100);
                        break;
                    case "ExpAdd2":
                        _selectedCharacter.Lvl.AddExp(200);
                        break;
                    case "ExpAdd5":
                        _selectedCharacter.Lvl.AddExp(500);
                        break;
                    default:
                        return;
                }
                ExpChangeEvent?.Invoke();
            }
            catch { }
            
        }

        private void AddAbility()
        {
            if(_selectedCharacter.Lvl.CurrentLevel % 3 == 0)
            {
                var abilitiesWindow = new Abilities(_selectedCharacter, this);
                abilitiesWindow.Show();
            }
        }

        private void FillAbilities()
        {
            if(_selectedCharacter is null)
            {
                return;
            }
            foreach(var ability in _selectedCharacter.Abilities)
            {
                lbAbilities.Items.Add(ability);
            }
        }

        private event CharacteristicChangeDelegate? CharacteristicChangeEvent;
        private event ExpChangeDelegate? ExpChangeEvent;

    }
}
