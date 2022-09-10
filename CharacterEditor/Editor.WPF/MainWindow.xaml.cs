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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void comboCharacter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var chosenCharacterName = ((ComboBoxItem)e.AddedItems[0]).Content.ToString();
            switch (chosenCharacterName)
            {
                case "Warrior":
                    _currentCharacter = new Warrior(5);
                    break;
                case "Rogue":
                    _currentCharacter = new Rogue(5);
                    break;
                case "Wizard":
                    _currentCharacter = new Wizard(5);
                    break;
                default:
                    break;
            };
            FillData();
        }

        private void FillData()
        {
            lbAvailableSkillPoints.Content = _currentCharacter?.AvailableSkillPoints;

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
    }
}
