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
using Units_Practic;

namespace EditUnit_Practic_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Unit> units;

        public MainWindow()
        {
            units = new List<Unit>() {new Warrior(), new Wizard(), new Rogue() };

            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            UpdateCharacteristics(0);
        }

        private void UpdateCharacteristics(int unit)
        {
            tbStrength.Text = units[unit].characteristics.strength.ToString();
            tbDexterity.Text = units[unit].characteristics.dexterity.ToString();
            tbConstitution.Text = units[unit].characteristics.constitution.ToString();
            tbIntelligence.Text = units[unit].characteristics.intelligence.ToString();

            tbHP.Text = units[unit].healthPoint.ToString();
            tbMP.Text = units[unit].manaPoint.ToString();
            tbLvl.Text = units[unit].lvl.ToString();
            tbBoostPoints.Text =units[unit].boostPoints.ToString();

            tbAtackPoint.Text = units[unit].atackPoint.ToString();
            tbMagicAtackPoint.Text = units[unit].magicAtackPoint.ToString();
            tbPhysicalProtectionPoint.Text = units[unit].physicalProtectionPoint.ToString();
        }

        private void dexBtnMax_Click(object sender, RoutedEventArgs e)
        {
            if (units[0].boostPoints > 0 && units[0].characteristics.dexterity + 1 <= units[0].characteristics.dexterityMax)
            {
                --units[0].boostPoints;
                ++units[0].characteristics.dexterity;

                units[0].UpdateHaracteristics();
                UpdateCharacteristics(0);
            }
        }

        private void dexBtnMin_Click(object sender, RoutedEventArgs e)
        {
            if (units[0].characteristics.dexterity - 1 >= units[0].characteristics.dexterityMin)
            {
                ++units[0].boostPoints;
                --units[0].characteristics.dexterity;

                units[0].UpdateHaracteristics();
                UpdateCharacteristics(0);
            }
        }

        private void strBtnMax_Click(object sender, RoutedEventArgs e)
        {
            if (units[0].boostPoints > 0 && units[0].characteristics.strength + 1 <= units[0].characteristics.strengthMax)
            {
                --units[0].boostPoints;
                ++units[0].characteristics.strength;

                units[0].UpdateHaracteristics();
                UpdateCharacteristics(0);
            }
        }

        private void strBtnMin_Click(object sender, RoutedEventArgs e)
        {
            if (units[0].characteristics.strength - 1 >= units[0].characteristics.strengthMin)
            {
                ++units[0].boostPoints;
                --units[0].characteristics.strength;

                units[0].UpdateHaracteristics();
                UpdateCharacteristics(0);
            }
        }

        private void consBtnMax_Click(object sender, RoutedEventArgs e)
        {
            if (units[0].boostPoints > 0 && units[0].characteristics.constitution + 1 <= units[0].characteristics.constitutionMax)
            {
                --units[0].boostPoints;
                ++units[0].characteristics.constitution;

                units[0].UpdateHaracteristics();
                UpdateCharacteristics(0);
            }
        }

        private void consBtnMin_Click(object sender, RoutedEventArgs e)
        {
            if (units[0].characteristics.constitution - 1 >= units[0].characteristics.constitutionMin)
            {
                ++units[0].boostPoints;
                --units[0].characteristics.constitution;

                units[0].UpdateHaracteristics();
                UpdateCharacteristics(0);
            }
        }

        private void intBtnMax_Click(object sender, RoutedEventArgs e)
        {
            if (units[0].boostPoints > 0 && units[0].characteristics.intelligence + 1 <= units[0].characteristics.intelligenceMax)
            {
                --units[0].boostPoints;
                ++units[0].characteristics.intelligence;

                units[0].UpdateHaracteristics();
                UpdateCharacteristics(0);
            }
        }

        private void intBtnMin_Click(object sender, RoutedEventArgs e)
        {
            if (units[0].characteristics.intelligence - 1 >= units[0].characteristics.intelligenceMin)
            {
                ++units[0].boostPoints;
                --units[0].characteristics.intelligence;

                units[0].UpdateHaracteristics();
                UpdateCharacteristics(0);
            }
        }
    }
}
