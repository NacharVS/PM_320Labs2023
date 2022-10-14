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
using WPFcharacterictic.Core.BaseArmor;

namespace WPFcharacteristic.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Entity entity;
        private List<Armor> _equipment = new();
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
                    break;
                case "Rogue":
                    entity = new Rogue();
                    break;
                case "Wizard":
                    entity = new Wizard();
                    break;
            }

            Abilities.Items.Clear();
            foreach (var ability in entity.Abilities)
            {
                Abilities.Items.Add(ability.Key);
            }

            LoadEquipment();
            Refresh();
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

        private void StrengthPlus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                entity.IncreasedStrength();
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
                entity.IncreasedDexterity();
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
                entity.IncreasedConstitution();
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
                entity.IncreasedIntelligence();
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
                MongoDBwpf.MongoDBwpf<Entity>.AddToDataBase(entity, "Units");
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
                MongoDBwpf.MongoDBwpf<Entity>.ReplaceByName(entity.Name, entity, "Units");
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
                entity = MongoDBwpf.MongoDBwpf<Entity>.FindByName(EntityBox.Text, "Units");

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
                Refresh();
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
        private void Helm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var item = (Armor)Helms.SelectedItem;
                if (entity.ArmorCompatibilityCheck((Armor?)item))
                {
                    entity.Helmet = item;
                    RefreshEquipment(item);
                }
                else 
                {
                    throw new Exception("Броня имеет другой класс");
                }
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        private void Breastplates_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var item = (Armor)Breastplates.SelectedItem;
                if (entity.ArmorCompatibilityCheck((Armor?)item))
                {
                    entity.BodyArmor = item;
                    RefreshEquipment(item);
                }
                else 
                {
                    throw new Exception("Броня имеет другой класс");
                }
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        private void Sabatons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var item = (Armor)Sabatons.SelectedItem;
                if (entity.ArmorCompatibilityCheck((Armor?)item))
                {
                    entity.Feet = item;
                    HealthArmor.Text = Convert.ToString(Convert.ToInt32(HealthArmor.Text) + entity.Helmet.Health);
                    RefreshEquipment(item);
                }
                else 
                {
                    throw new Exception("Броня имеет другой класс");
                }
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void Refresh() 
        {
            Expirience.Text = entity.Expirience.ToString();
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

        private void RefreshEquipment(Armor armor)
        {
            HealthArmor.Text = (armor.Health + Convert.ToInt32(HealthArmor.Text)).ToString();
            ManaArmor.Text = (armor.Mana + Convert.ToDouble(ManaArmor.Text)).ToString();
            PhysicalAttackArmor.Text = (armor.PhysicalAttack + Convert.ToDouble(PhysicalAttackArmor.Text)).ToString();
            PhysicalDefenseArmor.Text = (armor.PhysicalDefense + Convert.ToDouble(PhysicalDefenseArmor.Text)).ToString();
            MagicAttackArmor.Text = (armor.MagicAttack + Convert.ToDouble(MagicAttackArmor.Text)).ToString();
            MagicDefenseArmor.Text = (armor.MagicDefense + Convert.ToDouble(MagicDefenseArmor.Text)).ToString();
        }

        private void LoadEquipment()
        {
            _equipment = MongoDBwpf<Armor>.GetAll("Armor");

            foreach (var i in _equipment.FindAll(x => x.Type == ArmorType.Helmet))
            {
                Helms.Items.Add(i);
            }

            foreach (var i in _equipment.FindAll(x => x.Type == ArmorType.Body))
            {
                Breastplates.Items.Add(i);
            }

            foreach (var i in _equipment.FindAll(x => x.Type == ArmorType.Feet))
            {
                Sabatons.Items.Add(i);
            }
        }

        private void CreateArmors()
        {
            Armor Berets = new Armor("Berets", ArmorType.Feet, 8, 0, 3, 0, 1, 0, "Warrior");
            Armor Boots = new Armor("Boots with wings", ArmorType.Feet, 8, 0, 0, 3, 0, 1, "Wizard");
            Armor ThiefBoots = new Armor("Thief boots", ArmorType.Feet, 5, 0, 0, 2, 5, 0, "Rogue");

            Armor Chainmail = new Armor("Chainmail", ArmorType.Body, 13, 0, 0, 0, 8, 0, "Warrior");
            Armor RegularCloak = new Armor("Regular cloak", ArmorType.Body, 5, 0, 0, 0, 3, 0, "Entity");
            Armor DragonJacket = new Armor("Dragon jacket", ArmorType.Body, 7, 0, 0, 0, 5, 10, "Wizard");

            Armor VikingHelmet = new Armor("Viking helmet", ArmorType.Helmet, 8, 0,0,0,5,0, "Warrior");
            Armor CatHat = new Armor("Cat hat", ArmorType.Helmet, 50,0,0,0,0,20, "Rogue");
            Armor Crown = new Armor("Crown", ArmorType.Helmet, 0,0,0,0,0,50, "Entity");

            MongoDBwpf<Armor>.AddToDataBase(Berets, "Armor");
            MongoDBwpf<Armor>.AddToDataBase(Boots, "Armor");
            MongoDBwpf<Armor>.AddToDataBase(ThiefBoots, "Armor");
            MongoDBwpf<Armor>.AddToDataBase(Chainmail, "Armor");
            MongoDBwpf<Armor>.AddToDataBase(RegularCloak, "Armor");
            MongoDBwpf<Armor>.AddToDataBase(DragonJacket, "Armor");
            MongoDBwpf<Armor>.AddToDataBase(VikingHelmet, "Armor");
            MongoDBwpf<Armor>.AddToDataBase(CatHat, "Armor");
            MongoDBwpf<Armor>.AddToDataBase(Crown, "Armor");

        }
    }
}
