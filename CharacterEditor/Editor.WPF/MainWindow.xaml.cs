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
using Editor.Core;
using Editor.Core.Enums;

namespace Editor.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Character? _currentCharacter;
        private const int StartSkillPoints = 5;

        public MainWindow()
        {
            InitializeComponent();

            OnSkillChange += delegate(Character? sender, string propName, int val)
            {
                if (sender != null)
                {
                    var property = sender
                        .GetType()
                        .GetProperty(propName);

                    var currVal = property?.GetValue(sender);

                    property?.SetValue(sender, (int)(currVal ?? 0) + val);
                    FillData();
                }
            };
        }

        private void comboCharacter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var chosenCharacterName = ((ComboBoxItem)e.AddedItems[0]!)?.Content.ToString();
            switch (chosenCharacterName)
            {
                case "Warrior":
                    _currentCharacter = new Warrior(StartSkillPoints);
                    break;
                case "Rogue":
                    _currentCharacter = new Rogue(StartSkillPoints);
                    break;
                case "Wizard":
                    _currentCharacter = new Wizard(StartSkillPoints);
                    break;
            };
            FillData();
        }

        private void FillData()
        {
            lbSkillPointsVal.Content = _currentCharacter?.AvailableSkillPoints;

            lbStrengthVal.Content = _currentCharacter?.Strength;
            lbDexterityVal.Content = _currentCharacter?.Dexterity;
            lbConstitutionVal.Content = _currentCharacter?.Constitution;
            lbIntelligenceVal.Content = _currentCharacter?.Intelligence;

            lbHPVal.Content = _currentCharacter?.HealthPoints;
            lbMPVal.Content = _currentCharacter?.ManaPoints;

            lbPAtkVal.Content = _currentCharacter?.PhysicalDamage;
            lbPDefVal.Content = _currentCharacter?.PhysicalDefense;
            lbMAtkVal.Content = _currentCharacter?.MagicDamage;
            lbMDefVal.Content = _currentCharacter?.MagicDefense;
        }

        private void btnDecrStrength_Click(object sender, RoutedEventArgs e)
        {
            OnSkillChange?.Invoke(_currentCharacter, "Strength", -1);

        }

        private void btnDecrDexterity_Click(object sender, RoutedEventArgs e)
        {
            OnSkillChange?.Invoke(_currentCharacter, "Dexterity", -1);
        }

        private void btnDecrConstitution_Click(object sender, RoutedEventArgs e)
        {
            OnSkillChange?.Invoke(_currentCharacter, "Constitution", -1);
        }

        private void btnDecrIntelligence_Click(object sender, RoutedEventArgs e)
        {
            OnSkillChange?.Invoke(_currentCharacter, "Intelligence", -1);
        }

        private void btnIncrStrength_Click(object sender, RoutedEventArgs e)
        {
            OnSkillChange?.Invoke(_currentCharacter, "Strength", 1);
        }

        private void btnIncrDexterity_Click(object sender, RoutedEventArgs e)
        {
            OnSkillChange?.Invoke(_currentCharacter, "Dexterity", 1);
        }

        private void btnIncrConstitution_Click(object sender, RoutedEventArgs e)
        {
            OnSkillChange?.Invoke(_currentCharacter, "Constitution", 1);
        }

        private void btnIncrIntelligence_Click(object sender, RoutedEventArgs e)
        {
            OnSkillChange?.Invoke(_currentCharacter, "Intelligence", 1);
        }

        public delegate void HandleSkillChange(Character? character, string propertyName, int val);
        public event HandleSkillChange? OnSkillChange;
    }
}
