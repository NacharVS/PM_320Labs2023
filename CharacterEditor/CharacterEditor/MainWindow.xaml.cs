using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CharacterEditorCore;

namespace UnitsEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> _characterNames;
        private BaseCharacteristics _selectedCharacter;
        public MainWindow()
        {
            InitializeComponent();

            _characterNames = new List<string>
            { "Warrior", "Rogue", "Wizard"};

            cbCharacters.ItemsSource = _characterNames;

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCharacter = cbCharacters.SelectedItem.ToString();
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

            FillCharacteristics();
            FillStats();
        }

        private void FillCharacteristics()
        {
            try
            {
                lbStrengthValue.Content = Convert.ToString(_selectedCharacter.Strength.Value);
                lbDexterityValue.Content = Convert.ToString(_selectedCharacter.Dexterity.Value);
                lbConstitutionValue.Content = Convert.ToString(_selectedCharacter.Constitution.Value);
                lbIntelligenceValue.Content = Convert.ToString(_selectedCharacter.Intelligence.Value);
            }
            catch { }
        }

        private void FillStats()
        {
            try
            {
                tbAttackDamageValue.Text = Convert.ToString(_selectedCharacter.AttackDamage);
                tbHealthValue.Text = Convert.ToString(_selectedCharacter.HealthPoint);
                tbManaValue.Text = Convert.ToString(_selectedCharacter.ManaPoint);
                tbPhysicalDefValue.Text = Convert.ToString(_selectedCharacter.PhysicalDef);
                tbMagicAttackValue.Text = Convert.ToString(_selectedCharacter.MagicAttack);
            }
            catch { }
        }

        private void btnPlusStrength_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(_selectedCharacter.ExpPoints > 0)
                {
                    _selectedCharacter.Strength.Value += 1;
                    lbStrengthValue.Content = Convert.ToString(_selectedCharacter.Strength.Value);
                    _selectedCharacter.CalcStats();
                    FillStats();
                }
            }
            catch { }
        }

        private void btnMinusStrength_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _selectedCharacter.Strength.Value -= 1;
                lbStrengthValue.Content = Convert.ToString(_selectedCharacter.Strength.Value);
                _selectedCharacter.CalcStats();
                FillStats();
            }
            catch { }
        }

        private void btnPlusDexterity_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _selectedCharacter.Dexterity.Value += 1;
                lbDexterityValue.Content = Convert.ToString(_selectedCharacter.Dexterity.Value);
                _selectedCharacter.CalcStats();
                FillStats();
            }
            catch { }
        }

        private void btnMinusDexterity_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _selectedCharacter.Dexterity.Value -= 1;
                lbDexterityValue.Content = Convert.ToString(_selectedCharacter.Dexterity.Value);
                _selectedCharacter.CalcStats();
                FillStats();
            }
            catch{ }
        }

        private void btnMinusConstitution_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _selectedCharacter.Constitution.Value -= 1;
                lbConstitutionValue.Content = Convert.ToString(_selectedCharacter.Constitution.Value);
                _selectedCharacter.CalcStats();
                FillStats();
            }
            catch{}
        }

        private void btnPlusConstitution_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _selectedCharacter.Constitution.Value += 1;
                lbConstitutionValue.Content = Convert.ToString(_selectedCharacter.Constitution.Value);
                _selectedCharacter.CalcStats();
                FillStats();
            }
            catch { }
        }

        private void btnPlusIntelligence_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _selectedCharacter.Intelligence.Value += 1;
                lbIntelligenceValue.Content = Convert.ToString(_selectedCharacter.Intelligence.Value);
                _selectedCharacter.CalcStats();
                FillStats();
            }
            catch { }
        }

        private void btnMinusIntelligence_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _selectedCharacter.Intelligence.Value -= 1;
                lbIntelligenceValue.Content = Convert.ToString(_selectedCharacter.Intelligence.Value);
                _selectedCharacter.CalcStats();
                FillStats();
            }
            catch{ }
        }
    }
}
