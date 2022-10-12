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
using Units_Practic.Characters;

namespace EditUnit_Practic_WPF.Pages
{
    /// <summary>
    /// Interaction logic for RoguePage.xaml
    /// </summary>
    public partial class RoguePage : Page
    {
        public Unit unit;

        public RoguePage()
        {
            unit = new Rogue();

            InitializeComponent();
        }

        public RoguePage(Unit unit)
        {
            this.unit = unit;

            InitializeComponent();
            tbName.Text = unit.name;
        }

        private void Page_Initialized(object sender, EventArgs e)
        {
            UpdateCharacteristics();
        }

        private void UpdateCharacteristics()
        {
            tbStrength.Text = unit.characteristics.strength.ToString();
            tbDexterity.Text = unit.characteristics.dexterity.ToString();
            tbConstitution.Text = unit.characteristics.constitution.ToString();
            tbIntelligence.Text = unit.characteristics.intelligence.ToString();

            tbHP.Text = unit.healthPoint.ToString();
            tbMP.Text = unit.manaPoint.ToString();
            tbLvl.Text = unit.lvl.lvl.ToString();
            tbBoostPoints.Text = unit.lvl.boostPoints.ToString();

            tbAtackPoint.Text = unit.atackPoint.ToString();
            tbMagicAtackPoint.Text = unit.magicAtackPoint.ToString();
            tbPhysicalProtectionPoint.Text = unit.physicalProtectionPoint.ToString();

            lvlPb.Maximum = unit.lvl.necessaryExp;
            lvlPb.Value = unit.lvl.exp;
        }

        private void dexBtnMax_Click(object sender, RoutedEventArgs e)
        {
            if (unit.lvl.boostPoints > 0 && unit.characteristics.dexterity + 1 <= unit.characteristics.dexterityMax)
            {
                --unit.lvl.boostPoints;
                ++unit.characteristics.dexterity;

                unit.UpdateHaracteristics();
                UpdateCharacteristics();
            }
        }

        private void dexBtnMin_Click(object sender, RoutedEventArgs e)
        {
            if (unit.characteristics.dexterity - 1 >= unit.characteristics.dexterityMin)
            {
                ++unit.lvl.boostPoints;
                --unit.characteristics.dexterity;

                unit.UpdateHaracteristics();
                UpdateCharacteristics();
            }
        }

        private void strBtnMax_Click(object sender, RoutedEventArgs e)
        {
            if (unit.lvl.boostPoints > 0 && unit.characteristics.strength + 1 <= unit.characteristics.strengthMax)
            {
                --unit.lvl.boostPoints;
                ++unit.characteristics.strength;

                unit.UpdateHaracteristics();
                UpdateCharacteristics();
            }
        }

        private void strBtnMin_Click(object sender, RoutedEventArgs e)
        {
            if (unit.characteristics.strength - 1 >= unit.characteristics.strengthMin)
            {
                ++unit.lvl.boostPoints;
                --unit.characteristics.strength;

                unit.UpdateHaracteristics();
                UpdateCharacteristics();
            }
        }

        private void consBtnMax_Click(object sender, RoutedEventArgs e)
        {
            if (unit.lvl.boostPoints > 0 && unit.characteristics.constitution + 1 <= unit.characteristics.constitutionMax)
            {
                --unit.lvl.boostPoints;
                ++unit.characteristics.constitution;

                unit.UpdateHaracteristics();
                UpdateCharacteristics();
            }
        }

        private void consBtnMin_Click(object sender, RoutedEventArgs e)
        {
            if (unit.characteristics.constitution - 1 >= unit.characteristics.constitutionMin)
            {
                ++unit.lvl.boostPoints;
                --unit.characteristics.constitution;

                unit.UpdateHaracteristics();
                UpdateCharacteristics();
            }
        }

        private void intBtnMax_Click(object sender, RoutedEventArgs e)
        {
            if (unit.lvl.boostPoints > 0 && unit.characteristics.intelligence + 1 <= unit.characteristics.intelligenceMax)
            {
                --unit.lvl.boostPoints;
                ++unit.characteristics.intelligence;

                unit.UpdateHaracteristics();
                UpdateCharacteristics();
            }
        }

        private void intBtnMin_Click(object sender, RoutedEventArgs e)
        {
            if (unit.characteristics.intelligence - 1 >= unit.characteristics.intelligenceMin)
            {
                ++unit.lvl.boostPoints;
                --unit.characteristics.intelligence;

                unit.UpdateHaracteristics();
                UpdateCharacteristics();
            }
        }

        private void btn_100xp_Click(object sender, RoutedEventArgs e)
        {
            unit.lvl.exp += 100;
            UpdateCharacteristics();
        }

        private void btn_300xp_Click(object sender, RoutedEventArgs e)
        {
            unit.lvl.exp += 300;
            UpdateCharacteristics();
        }

        private void btn_1000xp_Click(object sender, RoutedEventArgs e)
        {
            unit.lvl.exp += 1000;
            UpdateCharacteristics();
        }
    }
}
