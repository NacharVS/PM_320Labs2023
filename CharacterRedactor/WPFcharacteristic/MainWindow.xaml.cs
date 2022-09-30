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
using MongoDBwpf;

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
        private void SaveDataBase_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MongoDBwpf.MongoDBwpf.AddToDataBase(entity);
                MessageBox.Show("Готово!");
            }
            catch (Exception)
            {
                MessageBox.Show("Не выбран персонаж");
            }
        }
        private void ReplaceDataBase_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MongoDBwpf.MongoDBwpf.ReplaceByName(entity.Name, entity);
                MessageBox.Show("Готово!");
            }
            catch (Exception)
            {
                MessageBox.Show("Не выбран персонаж");
            }
        }
        private void InsertDataBase_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show($"{EntityBox.Text.ToString()}");
                entity = MongoDBwpf.MongoDBwpf.FindByName(EntityBox.Text.ToString());

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

                MessageBox.Show("Готово!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не выбран персонаж или его нет в базе данных");
            }
        }
        private void InventoryPlus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newItem = new InventoryItem();
                newItem.Name = $"{entity.InventoryItems.Count + 1} weapon";

                entity.InventoryItems.Add(newItem);

                foreach (var item in entity.InventoryItems)
                {
                    Invenoty.Text += $"{item.Name} \n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не выбран персонаж");
            }
        }
    }
}
