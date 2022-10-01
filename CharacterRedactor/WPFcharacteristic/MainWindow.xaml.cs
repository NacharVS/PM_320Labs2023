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

                    foreach (var ability in entity.Abilities)
                    {
                        Abilities.Items.Add(ability);
                    }
                    Refresh();
                    break;
                case "Rogue":
                    entity = new Rogue();

                    foreach (var ability in entity.Abilities)
                    {
                        Abilities.Items.Add(ability);
                    }
                    Refresh();

                    break;
                case "Wizard":
                    entity = new Wizard();

                    foreach (var ability in entity.Abilities)
                    {
                        Abilities.Items.Add(ability);
                    }

                    Refresh();

                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Refresh();
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
                Refresh();
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
                Refresh();
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
                Refresh();
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
                MessageBox.Show($"{EntityBox.Text}");
                entity = MongoDBwpf.MongoDBwpf.FindByName(EntityBox.Text);

                Refresh();

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
                entity.AddInventoryItem();

                Inventory.Text = "";

                foreach (var item in entity.InventoryItems)
                {
                    Inventory.Text += $"{item.Name} \n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ExpiriencePlus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                entity.AddExpirience(1000);
                Expirience.Text = entity.Expirience.ToString();
                Level.Text = entity.Level.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Персонаж не выбран");
            }
        }

        private void Abilities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var item = Abilities.SelectedItem;
                entity.UseAbility((string?)item);
                Refresh();
            }
            catch 
            {
                MessageBox.Show("Персонаж не выбран");
            }
        }

        private void Refresh() 
        {
            entity.IncreasedIntelligence();

            Level.Text = entity.Level.ToString();
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
    }
}
