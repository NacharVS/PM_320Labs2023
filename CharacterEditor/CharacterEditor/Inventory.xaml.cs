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
        private readonly MainWindow _mainWindow;
        private BaseCharacteristics _selectedCharacter;

        public Inventory(MainWindow mainWindow, BaseCharacteristics selectedCharacter)
        {
            InitializeComponent();

            _mainWindow = mainWindow;
            _selectedCharacter = selectedCharacter;
            FillInventory();
        }

        private void FillInventory()
        {
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
            _selectedCharacter.Inventory.Add(item);
            lbInventory.Items.Add(item);
        }

        private void lbInventory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IItem deletedItem = (IItem)lbInventory.SelectedItem;
            _selectedCharacter.Inventory.Remove(deletedItem);
            lbInventory.Items.Remove(deletedItem);
        }
    }
}
