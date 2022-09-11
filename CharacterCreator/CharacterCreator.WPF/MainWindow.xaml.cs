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
using CharacterCreator.Core;

namespace CharacterCreator.Core
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Character? _selectedCharacter;
        public MainWindow()
        {
            InitializeComponent();
            
            OnStatChangedEvent += delegate
            {
                FillData();
            };
        }

        private void CharacterList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var chosenCharacterName = ((ComboBoxItem) e.AddedItems[0]).Content.ToString();
            switch (chosenCharacterName)
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
            };
            FillData();
        }

        private void FillData()
        {
            AvailableSkillPointsValueLabel.Content = _selectedCharacter.SkillPoints;
            
            StrengthValueLabel.Content = _selectedCharacter?.Strength;
            DexterityValueLabel.Content = _selectedCharacter?.Dexterity;
            ConstitutionValueLabel.Content = _selectedCharacter?.Constitution;
            IntelligenceValueLabel.Content = _selectedCharacter?.Intelligence;

            HPValueLabel.Content = _selectedCharacter?.HealthPoint;
            ManaValueLabel.Content = _selectedCharacter?.Mana;
            PhysAttackValueLabel.Content = _selectedCharacter?.PhysAttack;
            PhysDefenseValueLabel.Content = _selectedCharacter?.PhysDefense;
            MagicalAttackValueLabel.Content = _selectedCharacter?.MagicalAttack;
        }

        private void StrengthIncrementBtn_Click(object sender, RoutedEventArgs e)
        {
            _selectedCharacter.Strength += 1;
            OnStatChangedEvent?.Invoke();
        }
        
        private void StrengthDecrementBtn_Click(object sender, RoutedEventArgs e)
        {
            _selectedCharacter.Strength -= 1;
            OnStatChangedEvent?.Invoke();
        }
        
        private void DexterityIncrementBtn_Click(object sender, RoutedEventArgs e)
        {
            _selectedCharacter.Dexterity += 1;
            OnStatChangedEvent?.Invoke();
        }
        
        private void DexterityDecrementBtn_Click(object sender, RoutedEventArgs e)
        {
            _selectedCharacter.Dexterity -= 1;
            OnStatChangedEvent?.Invoke();
        }
        
        private void ConstitutionIncrementBtn_Click(object sender, RoutedEventArgs e)
        {
            _selectedCharacter.Constitution += 1;
            OnStatChangedEvent?.Invoke();
        }
        
        private void ConstitutionDecrementBtn_Click(object sender, RoutedEventArgs e)
        {
            _selectedCharacter.Constitution -= 1;
            OnStatChangedEvent?.Invoke();
        }
        
        private void IntelligenceIncrementBtn_Click(object sender, RoutedEventArgs e)
        {
            _selectedCharacter.Intelligence += 1;
            OnStatChangedEvent?.Invoke();
        }
        
        private void IntelligenceDecrementBtn_Click(object sender, RoutedEventArgs e)
        {
            _selectedCharacter.Intelligence -= 1;
            OnStatChangedEvent?.Invoke();
        }
        
        private delegate void OnStatChangedDelegate();

        private event OnStatChangedDelegate OnStatChangedEvent;
    }
}