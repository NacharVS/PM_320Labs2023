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
using WPFcharacterictic.Core;
using WPFcharacterictic.Core.BaseEntitys;

namespace WPFcharacteristic.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Entity entity;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Entity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (e.AddedItems[0]) 
            {
                case "Warrior":
                    entity = new Warrior();

                    Points.Text = entity.AvailablePoints.ToString();
                    Strength.Text = entity.Strength.ToString();
                    Dexterity.Text = entity.Dexterity.ToString();
                    Constitution.Text = entity.Constitution.ToString();
                    Intelligence.Text = entity.Intelligence.ToString();

                    Health.Text = entity.Health.ToString();
                    Mana.Text = entity.Mana.ToString();
                    PhysicalAttack.Text = entity.PhysicalAttack.ToString();
                    MagicAttack.Text = entity.MagicAttack.ToString();
                    PhysicalDefense.Text = entity.PhysicalDefense.ToString();
                    MagicDefense.Text = entity.MagicDefense.ToString();
                    break;
                case "Rogue":
                    entity = new Rogue();

                    Points.Text = entity.AvailablePoints.ToString();
                    Strength.Text = entity.Strength.ToString();
                    Dexterity.Text = entity.Dexterity.ToString();
                    Constitution.Text = entity.Constitution.ToString();
                    Intelligence.Text = entity.Intelligence.ToString();

                    Health.Text = entity.Health.ToString();
                    Mana.Text = entity.Mana.ToString();
                    PhysicalAttack.Text = entity.PhysicalAttack.ToString();
                    MagicAttack.Text = entity.MagicAttack.ToString();
                    PhysicalDefense.Text = entity.PhysicalDefense.ToString();
                    MagicDefense.Text = entity.MagicDefense.ToString();

                    break;
                case "Wizard":
                    entity = new Wizard();

                    Points.Text = entity.AvailablePoints.ToString();
                    Strength.Text = entity.Strength.ToString();
                    Dexterity.Text = entity.Dexterity.ToString();
                    Constitution.Text = entity.Constitution.ToString();
                    Intelligence.Text = entity.Intelligence.ToString();

                    Health.Text = entity.Health.ToString();
                    Mana.Text = entity.Mana.ToString();
                    PhysicalAttack.Text = entity.PhysicalAttack.ToString();
                    MagicAttack.Text = entity.MagicAttack.ToString();
                    PhysicalDefense.Text = entity.PhysicalDefense.ToString();
                    MagicDefense.Text = entity.MagicDefense.ToString();

                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                entity.IncreasedStrength();

                Points.Text = entity.AvailablePoints.ToString();
                Strength.Text = entity.Strength.ToString();
                Dexterity.Text = entity.Dexterity.ToString();
                Constitution.Text = entity.Constitution.ToString();
                Intelligence.Text = entity.Intelligence.ToString();

                Health.Text = entity.Health.ToString();
                Mana.Text = entity.Mana.ToString();
                PhysicalAttack.Text = entity.PhysicalAttack.ToString();
                MagicAttack.Text = entity.MagicAttack.ToString();
                PhysicalDefense.Text = entity.PhysicalDefense.ToString();
                MagicDefense.Text = entity.MagicDefense.ToString();
            }
            catch (Exception) 
            {
                MessageBox.Show("Не выбран персонаж");
            }

        }

        private void DexterityPlus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                entity.IncreasedDexterity();

                Points.Text = entity.AvailablePoints.ToString();
                Strength.Text = entity.Strength.ToString();
                Dexterity.Text = entity.Dexterity.ToString();
                Constitution.Text = entity.Constitution.ToString();
                Intelligence.Text = entity.Intelligence.ToString();

                Health.Text = entity.Health.ToString();
                Mana.Text = entity.Mana.ToString();
                PhysicalAttack.Text = entity.PhysicalAttack.ToString();
                MagicAttack.Text = entity.MagicAttack.ToString();
                PhysicalDefense.Text = entity.PhysicalDefense.ToString();
                MagicDefense.Text = entity.MagicDefense.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Не выбран персонаж");
            }
        }

        private void ConstitutionPlus_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                entity.IncreasedConstitution();

                Points.Text = entity.AvailablePoints.ToString();
                Strength.Text = entity.Strength.ToString();
                Dexterity.Text = entity.Dexterity.ToString();
                Constitution.Text = entity.Constitution.ToString();
                Intelligence.Text = entity.Intelligence.ToString();

                Health.Text = entity.Health.ToString();
                Mana.Text = entity.Mana.ToString();
                PhysicalAttack.Text = entity.PhysicalAttack.ToString();
                MagicAttack.Text = entity.MagicAttack.ToString();
                PhysicalDefense.Text = entity.PhysicalDefense.ToString();
                MagicDefense.Text = entity.MagicDefense.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Не выбран персонаж");
            }
        }

        private void IntelligencePlus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                entity.IncreasedIntelligence();

                Points.Text = entity.AvailablePoints.ToString();
                Strength.Text = entity.Strength.ToString();
                Dexterity.Text = entity.Dexterity.ToString();
                Constitution.Text = entity.Constitution.ToString();
                Intelligence.Text = entity.Intelligence.ToString();

                Health.Text = entity.Health.ToString();
                Mana.Text = entity.Mana.ToString();
                PhysicalAttack.Text = entity.PhysicalAttack.ToString();
                MagicAttack.Text = entity.MagicAttack.ToString();
                PhysicalDefense.Text = entity.PhysicalDefense.ToString();
                MagicDefense.Text = entity.MagicDefense.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Не выбран персонаж");
            }
        }
    }
}
