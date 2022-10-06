using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Units_Practic.Abilities;
using Units_Practic.Characters;

namespace EditUnit_Practic_WPF.Pages
{
    /// <summary>
    /// Interaction logic for WarriorPage.xaml
    /// </summary>
    public partial class WarriorPage : Page
    {
        public Unit unit;

        public WarriorPage()
        {
            unit = new Warrior();

            InitializeComponent();
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

            GetPotentialAbilities();
            GetAbilities();

            if (unit.lvl.abilitiesPoints > 0) cbPotentialAbilities.IsEnabled = true;
            else cbPotentialAbilities.IsEnabled = false;
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

        private void btn_500xp_Click(object sender, RoutedEventArgs e)
        {
            unit.lvl.exp += 500;
            UpdateCharacteristics();
        }

        private void btn_2500xp_Click(object sender, RoutedEventArgs e)
        {
            unit.lvl.exp += 2500;
            UpdateCharacteristics();
        }

        private void btn_10000xp_Click(object sender, RoutedEventArgs e)
        {
            unit.lvl.exp += 10000;
            UpdateCharacteristics();
        }

        private void cbPotentialAbilities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (Ability)cbPotentialAbilities.SelectedItem;

            if (item == null) return;

            unit.lvl.abilities.Add(item);
            unit.lvl.potentialAbilities.Remove(item);
            unit.lvl.abilitiesPoints -= 1;

            UpdateCharacteristics();
        }

        private void GetPotentialAbilities()
        {
            cbPotentialAbilities.Items.Clear();

            foreach (var ability in unit.lvl.potentialAbilities)
            {
                cbPotentialAbilities.Items.Add(ability);
            }
        }

        private void GetAbilities()
        {
            cbAbility.Items.Clear();

            foreach (var ability in unit.lvl.abilities)
            {
                cbAbility.Items.Add(ability);
            }
        }
    }
}
