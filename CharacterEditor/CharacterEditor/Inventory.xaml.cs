using CharacterEditorCore;
using System.Collections.Generic;
using System.Windows;
using CharacterEditorCore.Items;
using CharacterEditorMongoDataBase;
using System.Windows.Controls;
using UnitsEditor;
using MongoDB.Bson.Serialization;

namespace CharacterEditor
{
    /// <summary>
    /// Interaction logic for Inventory.xaml
    /// </summary>
    public partial class Inventory : Window
    {
        private BaseCharacteristics _selectedCharacter;

        public Inventory(BaseCharacteristics selectedCharacter)
        {
            InitializeComponent();

            _selectedCharacter = selectedCharacter;
            FillInventory();
        }

        private void FillInventory()
        {
            lblInventoryCapacity.Content = $"{_selectedCharacter.Inventory.Count} / {_selectedCharacter.InventCapacity}";
            lbInventory.DisplayMemberPath = "Name";
            lbInventory.Items.Clear();
            foreach (var item in _selectedCharacter.Inventory)
            {
                lbInventory.Items.Add(item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddItemBtn(object sender, RoutedEventArgs e)
        {
            var clickedBtn = (Button)sender;

            IItem item;

            switch(clickedBtn.Content)
            {
                case "Boots":
                    item = new Boots();
                    break;
                case "Helmet":
                    item = new Helmet();
                    break;
                case "Knife":
                    item = new Knife();
                    break;
                case "Pistol":
                    item = new Pistol();
                    break;
                case "Bow":
                    item = new Bow();
                    break;
                default:
                    return;
            }
            _selectedCharacter.AddItem(item);
            if(_selectedCharacter.InventCapacity > lbInventory.Items.Count)
            {
                lbInventory.Items.Add(item);
            }

            lblInventoryCapacity.Content = $"{_selectedCharacter.Inventory.Count} / {_selectedCharacter.InventCapacity}";
        }

        private void lbInventory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IItem deletedItem = (IItem)lbInventory.SelectedItem;
            _selectedCharacter.RemoveItem(deletedItem);
            lbInventory.Items.Remove(deletedItem);
            lblInventoryCapacity.Content = $"{_selectedCharacter.Inventory.Count} / {_selectedCharacter.InventCapacity}";
        }
    }
}
